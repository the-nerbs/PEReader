using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Provides access to a PE file's native resources.
    /// </summary>
    /// <devdoc>
    /// PE resources are structured as a tree in PE files.
    /// 
    /// By convention only 3 tiers are used, and only as such:
    ///   - Types - BITMAP, REGISTRY, MENU, DIALOG, ...
    ///     - Names - strings or integers uniquely identifying a resource
    ///       - Languages - variants of a single resource for each locale.
    ///
    /// This convention is assumed by Wine (and by extension ReactOS):
    ///  https://doxygen.reactos.org/d0/db5/dll_2win32_2kernel32_2wine_2res_8c.html#a75afddcb6ac2ec8d0c0117d741e0862f
    /// 
    /// It is also presented as a fact in this article from 1994:
    ///     "Peering Inside the PE: A Tour of the Win32 Portable Executable File Format"
    ///         https://msdn.microsoft.com/en-us/library/ms809762.aspx
    /// 
    /// I feel safe in assuming that this convention is followed by all PEs
    /// compiled in the last 20 or so years, and that this has been convention
    /// for so long that it's become de facto standard.
    /// </devdoc>
    public sealed class PeResources
    {
        private const int RootId = 0;
        private const int NoLink = -1;


        private readonly Dictionary<int, ResDirectory> _directories = new Dictionary<int, ResDirectory>();
        private readonly Dictionary<int, ResDirectoryEntry> _entries = new Dictionary<int, ResDirectoryEntry>();
        private readonly Dictionary<int, PeResourceData> _data = new Dictionary<int, PeResourceData>();


        internal PeResources(IMAGE_SECTION_HEADER sectionHeader, Stream peStream)
        {
            int nextId = RootId;

            ReadDirectory(peStream, sectionHeader.VirtualAddress, sectionHeader.PointerToRawData, NoLink, ref nextId);
        }


        /// <summary>
        /// Gets all resources of the given type.
        /// </summary>
        /// <param name="type">The name of the type of resources to get.</param>
        /// <returns>A collection of byte arrays containing the resource data.</returns>
        public IEnumerable<PeResourceData> GetResourcesOfType(string type)
        {
            var root = _directories[RootId];

            if (root.directory.NumberOfNamedEntries > 0)
            {
                for (int i = 0; i < root.NumChildren; i++)
                {
                    var entry = _entries[root.childMappings[i]];

                    if (entry.IsNamed &&
                        StringComparer.OrdinalIgnoreCase.Equals(entry.name, type))
                    {
                        foreach (var data in GetAllChildDatas(entry))
                        {
                            yield return data;
                        }
                    }
                }
            }
        }


        private int ReadDirectory(Stream peStream, long virtualAddress, long baseOffset, int parentId, ref int nextId)
        {
            int dirId = nextId++;
            var dirInfo = new ResDirectory();
            dirInfo.id = dirId;
            dirInfo.parentEntry = parentId;

            _directories.Add(dirId, dirInfo);

            dirInfo.directory = peStream.Read<IMAGE_RESOURCE_DIRECTORY>();

            int nChildren = dirInfo.directory.NumberOfIdEntries + dirInfo.directory.NumberOfNamedEntries;
            dirInfo.childMappings = new int[nChildren];

            // read the directory table rows
            for (int i = 0; i < nChildren; i++)
            {
                int entryId = nextId++;

                var dirEntry = new ResDirectoryEntry();
                dirEntry.id = entryId;
                dirEntry.ownerDirectory = dirId;

                dirInfo.childMappings[i] = entryId;
                dirEntry.entry = peStream.Read<IMAGE_RESOURCE_DIRECTORY_ENTRY>();

                _entries.Add(entryId, dirEntry);
            }

            // read the child data.
            for (int i = 0; i < nChildren; i++)
            {
                ResDirectoryEntry dirEntry = _entries[dirInfo.childMappings[i]];

                ReadEntryName(dirEntry, peStream, virtualAddress, baseOffset);

                ReadEntryChildren(dirEntry, peStream, virtualAddress, baseOffset, ref nextId);
            }

            return dirId;
        }

        private void ReadEntryName(ResDirectoryEntry dirEntry, Stream peStream,
                                   long virtualAddress, long baseOffset)
        {
            // read the name
            if (dirEntry.entry.NameIsString)
            {
                // note: offset from beginning of section.
                peStream.Seek(baseOffset + dirEntry.entry.NameOffset, SeekOrigin.Begin);

                int nChars = peStream.Read<short>();

                // names are in "Unicode" (UTF-16LE, wchar_t)
                int nBytes = nChars * 2;

                var nameBytes = new byte[nBytes];
                peStream.Read(nameBytes, 0, nBytes);

                dirEntry.name = Encoding.Unicode.GetString(nameBytes);
            }
            else
            {
                dirEntry.name = dirEntry.entry.Id.ToString();
            }
        }

        private void ReadEntryChildren(ResDirectoryEntry dirEntry, Stream peStream,
                                       long virtualAddress, long baseOffset, ref int nextId)
        {
            // read the child node(s)
            if (dirEntry.entry.DataIsDirectory)
            {
                // note: offset from beginning of section.
                peStream.Seek(baseOffset + dirEntry.entry.OffsetToDirectory, SeekOrigin.Begin);

                dirEntry.child = ReadDirectory(peStream, virtualAddress, baseOffset, dirEntry.id, ref nextId);
            }
            else
            {
                // note: offset from beginning of section.
                peStream.Seek(baseOffset + dirEntry.entry.OffsetToData, SeekOrigin.Begin);

                var dataEntry = peStream.Read<IMAGE_RESOURCE_DATA_ENTRY>();

                // decode the RVA to file offset
                long realDataAddr = baseOffset + dataEntry.OffsetToData - virtualAddress;
                peStream.Seek(realDataAddr, SeekOrigin.Begin);

                var dataBytes = new byte[dataEntry.Size];
                peStream.Read(dataBytes, 0, dataBytes.Length);

                string type, name, localeId;
                GetResourceInfo(dirEntry, out type, out name, out localeId);

                int dataId = nextId++;
                _data.Add(dataId, new PeResourceData(type, name, localeId, dataBytes));
                dirEntry.child = dataId;
            }
        }


        private IEnumerable<PeResourceData> GetAllChildDatas(ResDirectoryEntry entry)
        {
            if (entry.IsSubdirectory)
            {
                // subdirectory, recursively yield the data
                var dir = _directories[entry.child];

                for (int i = 0; i < dir.NumChildren; i++)
                {
                    var childEntry = _entries[dir.childMappings[i]];

                    foreach (var data in GetAllChildDatas(childEntry))
                    {
                        yield return data;
                    }
                }
            }
            else
            {
                // leaf node, just yield the data
                yield return _data[entry.child];
            }
        }

        private void GetResourceInfo(ResDirectoryEntry dataEntry, out string type, out string name, out string localeId)
        {
            Debug.Assert(!dataEntry.IsSubdirectory, "attempted to get type/name/locale of resource directory node.");

            localeId = dataEntry.name;

            ResDirectory localeDir = _directories[dataEntry.ownerDirectory];

            ResDirectoryEntry nameEntry = _entries[localeDir.parentEntry];
            name = nameEntry.name;

            ResDirectory nameDirectory = _directories[nameEntry.ownerDirectory];

            ResDirectoryEntry typeEntry = _entries[nameDirectory.parentEntry];
            type = typeEntry.name;
        }


        private class ResDirectory
        {
            public int id;
            public int parentEntry;
            public IMAGE_RESOURCE_DIRECTORY directory;
            public int[] childMappings;

            public int NumChildren
            {
                get { return directory.NumberOfIdEntries + directory.NumberOfNamedEntries; }
            }
        }

        [DebuggerDisplay("Entry: {name}")]
        private class ResDirectoryEntry
        {
            public int id;
            public int ownerDirectory;
            public IMAGE_RESOURCE_DIRECTORY_ENTRY entry;
            public string name;
            public int child;

            public bool IsNamed
            {
                get { return entry.NameIsString; }
            }

            public bool IsSubdirectory
            {
                get { return entry.DataIsDirectory; }
            }
        }
    }
}
