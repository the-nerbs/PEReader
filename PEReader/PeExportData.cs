using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Provides access to a PE file's export data.
    /// </summary>
    public sealed class PeExportData
    {
        private readonly IMAGE_EXPORT_DIRECTORY _directory;
        private readonly ExportedSymbol[] _exportAddressTable;
        private readonly string[] _exportNameTable;
        private readonly int[] _ordinalTable;


        /// <summary>
        /// Gets the time stamp (UTC) that the export data was created.
        /// </summary>
        public DateTime TimeStampUtc
        {
            get
            {
                var offset = TimeSpan.FromSeconds(_directory.TimeDateStamp);
                return NativeConstants.TimeStampBase + offset;
            }
        }

        /// <summary>
        /// Gets the version of the export data.
        /// </summary>
        public Version Version
        {
            get
            {
                return new Version(
                    _directory.MajorVersion,
                    _directory.MinorVersion
                );
            }
        }

        /// <summary>
        /// Gets the name of this PE file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the entries of the export address table
        /// </summary>
        public IList<ExportedSymbol> ExportAddressTable
        {
            get { return _exportAddressTable; }
        }

        /// <summary>
        /// Gets the entries of the export name table.
        /// </summary>
        public IList<string> ExportNameTable
        {
            get { return _exportNameTable; }
        }

        /// <summary>
        /// Gets the entries of the export ordinal table.
        /// </summary>
        public IList<int> ExportOrdinalTable
        {
            get { return _ordinalTable; }
        }


        internal PeExportData(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            _directory = peStream.Read<IMAGE_EXPORT_DIRECTORY>();

            // read the name
            long nameOffset = (_directory.NameRva - header.VirtualAddress) + header.PointerToRawData;
            peStream.Seek(nameOffset, SeekOrigin.Begin);
            Name = peStream.ReadAsciiZeroTerminated();

            _exportAddressTable = ReadExportAddresTable(header, peStream);
            _exportNameTable = ReadExportNameTable(header, peStream);
            _ordinalTable = ReadOrdinalTable(header, peStream);
        }


        private ExportedSymbol[] ReadExportAddresTable(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            long eatOffset = (_directory.RvaOfExportAddressTable - header.VirtualAddress) + header.PointerToRawData;
            peStream.Seek(eatOffset, SeekOrigin.Begin);

            int eatSize = checked((int)_directory.NumberOfFunctions);
            var exportAddressTable = new ExportedSymbol[eatSize];

            for (int i = 0; i < eatSize; i++)
            {
                int rva = peStream.Read<int>();

                if (header.VirtualAddress <= rva &&
                    rva < (header.VirtualAddress + header.VirtualSize))
                {
                    long curOffset = peStream.Position;

                    long exportNameOffset = (rva - header.VirtualAddress) + header.PointerToRawData;
                    peStream.Seek(exportNameOffset, SeekOrigin.Begin);

                    string exportName = peStream.ReadAsciiZeroTerminated();

                    peStream.Seek(curOffset, SeekOrigin.Begin);

                    exportAddressTable[i] = new ExportedSymbol(exportName);
                }
                else
                {
                    exportAddressTable[i] = new ExportedSymbol(rva);
                }
            }

            return exportAddressTable;
        }

        private string[] ReadExportNameTable(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            long nameTableOffset = (_directory.RvaOfNames - header.VirtualAddress) + header.PointerToRawData;
            peStream.Seek(nameTableOffset, SeekOrigin.Begin);

            int nNames = checked((int)_directory.NumberOfNames);
            var names = new string[nNames];

            for (int i = 0; i < nNames; i++)
            {
                int rva = peStream.Read<int>();

                long curOffset = peStream.Position;

                long nameOffset = (rva - header.VirtualAddress) + header.PointerToRawData;
                peStream.Seek(nameOffset, SeekOrigin.Begin);

                names[i] = peStream.ReadAsciiZeroTerminated();

                peStream.Seek(curOffset, SeekOrigin.Begin);
            }

            return names;
        }

        private int[] ReadOrdinalTable(IMAGE_SECTION_HEADER header, Stream peStream)
        {
            long ordinalTableOffset = (_directory.RvaOfOrdinals - header.VirtualAddress) + header.PointerToRawData;
            peStream.Seek(ordinalTableOffset, SeekOrigin.Begin);

            int nOrdinals = checked((int)_directory.NumberOfNames);
            var ordinals = new int[nOrdinals];

            for (int i = 0; i < nOrdinals; i++)
            {
                ordinals[i] = peStream.Read<ushort>();
            }

            return ordinals;
        }
    }
}
