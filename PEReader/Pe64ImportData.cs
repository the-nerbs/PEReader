using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Provides access to a 64-bit PE file's import data.
    /// </summary>
    internal sealed class Pe64ImportData : IPeImportData
    {
        private readonly ImportModule[] _directory;


        public IList<ImportModule> Modules
        {
            get { return _directory; }
        }


        internal Pe64ImportData(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            _directory = ReadDirectoryTable(header, peStream);
        }


        private ImportModule[] ReadDirectoryTable(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            // Table is an array of descriptors, terminated by a 0'd out entry.
            var entries = new List<ImportModule>();

            while (true)
            {
                var entry = peStream.Read<IMAGE_IMPORT_DESCRIPTOR>();

                if (entry.OriginalFirstThunk != 0 ||
                    entry.TimeDateStamp != 0 ||
                    entry.ForwarderChain != 0 ||
                    entry.NameRva != 0 ||
                    entry.FirstThunk != 0)
                {
                    long curPos = peStream.Position;

                    string name = null;

                    if (entry.NameRva != 0)
                    {
                        long nameOffset = (entry.NameRva - header.VirtualAddress) + header.PointerToRawData;
                        peStream.Seek(nameOffset, SeekOrigin.Begin);

                        name = peStream.ReadAsciiZeroTerminated();
                    }


                    ImportedSymbol[] symbols = null;

                    if (entry.OriginalFirstThunk != 0)
                    {
                        long tableOffset = (entry.OriginalFirstThunk - header.VirtualAddress) + header.PointerToRawData;
                        peStream.Seek(tableOffset, SeekOrigin.Begin);

                        symbols = ReadImportLookupTable(header, peStream);
                    }

                    peStream.Seek(curPos, SeekOrigin.Begin);

                    entries.Add(new ImportModule(name, symbols));
                }
                else
                {
                    break;
                }
            }

            return entries.ToArray();
        }

        private ImportedSymbol[] ReadImportLookupTable(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            // symbols are an array, terminated by a 0'd out entry.
            var symbols = new List<ImportedSymbol>();

            while (true)
            {
                var entry = peStream.Read<IMAGE_THUNK_DATA64>();

                // note: everything but 'IsOrdinal' is the same... yay unions!
                if (entry.AddressOfData != 0)
                {
                    if (entry.IsOrdinal)
                    {
                        // note: ordinals are actually 16-bit.
                        int ordinal = checked((int)entry.Ordinal);
                        symbols.Add(new ImportedSymbol(ordinal));
                    }
                    else
                    {
                        long curOffset = peStream.Position;

                        long dataOffset = checked((long)
                            ((entry.AddressOfData - header.VirtualAddress) + header.PointerToRawData)
                        );
                        peStream.Seek(dataOffset, SeekOrigin.Begin);

                        // structure:
                        //  - Hint : ushort
                        //  - Name : char[] (NUL-terminated)
                        //  - Pad  : byte, only if Name does not end on a 2-byte boundary.
                        int hint = peStream.Read<ushort>();
                        string name = peStream.ReadAsciiZeroTerminated();

                        peStream.Seek(curOffset, SeekOrigin.Begin);

                        symbols.Add(new ImportedSymbol(hint, name));
                    }
                }
                else
                {
                    break;
                }
            }

            return symbols.ToArray();
        }
    }
}
