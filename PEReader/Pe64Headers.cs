using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Accessor for 64-bit PE (PE32+) files.
    /// </summary>
    internal sealed class Pe64Headers : IPeHeadersInternal
    {
        private readonly IMAGE_NT_HEADERS64 _ntHeader;
        private readonly IMAGE_DATA_DIRECTORY[] _dataDirectories;
        private readonly IMAGE_SECTION_HEADER[] _sectionHeaders;
        private readonly Dictionary<string, int> _sectionNameToIndex;


        /// <inheritdoc />
        public uint Signature
        {
            get { return _ntHeader.Signature; }
        }

        /// <inheritdoc />
        public ImageFileMachine Machine
        {
            get { return _ntHeader.FileHeader.Machine; }
        }

        /// <inheritdoc />
        public int NumberOfSections
        {
            get { return _ntHeader.FileHeader.NumberOfSections; }
        }

        /// <inheritdoc />
        public DateTime TimeStampUtc
        {
            get
            {
                var offset = TimeSpan.FromSeconds(_ntHeader.FileHeader.TimeDateStamp);
                return NativeConstants.TimeStampBase + offset;
            }
        }

        /// <inheritdoc />
        public ImageCharacteristics ImageCharacteristics
        {
            get { return _ntHeader.FileHeader.Characteristics; }
        }


        /// <inheritdoc />
        public ulong ImageBase
        {
            get { return _ntHeader.OptionalHeader.ImageBase; }
        }

        /// <inheritdoc />
        public uint SectionAlignment
        {
            get { return _ntHeader.OptionalHeader.SectionAlignment; }
        }

        /// <inheritdoc />
        public Version ImageVersion
        {
            get
            {
                return new Version(
                    _ntHeader.OptionalHeader.MajorImageVersion,
                    _ntHeader.OptionalHeader.MinorImageVersion
                );
            }
        }

        /// <inheritdoc />
        public Version OSVersion
        {
            get
            {
                return new Version(
                    _ntHeader.OptionalHeader.MajorOperatingSystemVersion,
                    _ntHeader.OptionalHeader.MinorOperatingSystemVersion
                );
            }
        }

        /// <inheritdoc />
        public Version SubsystemVersion
        {
            get
            {
                return new Version(
                    _ntHeader.OptionalHeader.MajorSubsystemVersion,
                    _ntHeader.OptionalHeader.MinorSubsystemVersion
                );
            }
        }

        /// <inheritdoc />
        public long InMemoryImageSize
        {
            get
            {
                return _ntHeader.OptionalHeader.SizeOfImage;
            }
        }

        /// <inheritdoc />
        public uint CheckSum
        {
            get { return _ntHeader.OptionalHeader.CheckSum; }
        }

        /// <inheritdoc />
        public ImageSubsystem Subsystem
        {
            get { return _ntHeader.OptionalHeader.Subsystem; }
        }

        /// <inheritdoc />
        public DllCharacteristics DllCharacteristics
        {
            get { return _ntHeader.OptionalHeader.DllCharacteristics; }
        }


        /// <summary>
        /// Initializes a new instance of <see cref="Pe64Headers"/>.
        /// </summary>
        /// <param name="peStream">
        /// The stream to the PE file, positioned at the <see cref="IMAGE_NT_HEADERS64"/> structure.
        /// </param>
        public Pe64Headers(Stream peStream)
        {
            _ntHeader = peStream.Read<IMAGE_NT_HEADERS64>();

            // read the data directories
            int nDirectories = checked((int)_ntHeader.OptionalHeader.NumberOfRvaAndSizes);
            _dataDirectories = new IMAGE_DATA_DIRECTORY[nDirectories];

            for (int i = 0; i < nDirectories; i++)
            {
                _dataDirectories[i] = peStream.Read<IMAGE_DATA_DIRECTORY>();
            }


            // read the section headers
            int nSections = NumberOfSections;
            _sectionHeaders = new IMAGE_SECTION_HEADER[nSections];
            _sectionNameToIndex = new Dictionary<string, int>(capacity: nSections);

            for (int i = 0; i < nSections; i++)
            {
                _sectionHeaders[i] = peStream.Read<IMAGE_SECTION_HEADER>();

                string name = _sectionHeaders[i].NameStr;
                _sectionNameToIndex[name] = i;
            }
        }


        /// <inheritdoc />
        public bool TryGetDirectoryHeader(ImageDirectoryEntry type, out IMAGE_DATA_DIRECTORY entry)
        {
            int index = (int)type;

            if (0 <= index && index < _dataDirectories.Length)
            {
                entry = _dataDirectories[index];
                return true;
            }

            entry = default(IMAGE_DATA_DIRECTORY);
            return false;
        }

        /// <inheritdoc />
        public bool TryGetSectionHeader(string sectionName, out IMAGE_SECTION_HEADER header)
        {
            int index;
            if (_sectionNameToIndex.TryGetValue(sectionName, out index))
            {
                header = _sectionHeaders[index];
                return true;
            }

            header = default(IMAGE_SECTION_HEADER);
            return false;
        }

        /// <inheritdoc />
        public bool TryGetSectionForVirtualAddress(long address, out IMAGE_SECTION_HEADER header)
        {
            for (int i = 0; i < _sectionHeaders.Length; i++)
            {
                long baseAddress = _sectionHeaders[i].VirtualAddress;
                long endAddress = baseAddress + _sectionHeaders[i].VirtualSize;

                if (baseAddress <= address && address < endAddress)
                {
                    header = _sectionHeaders[i];
                    return true;
                }
            }

            header = default(IMAGE_SECTION_HEADER);
            return false;
        }
    }
}
