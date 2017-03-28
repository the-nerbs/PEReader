using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_EXPORT_DIRECTORY
    {
        /// <summary>
        /// Reserved, must be 0.
        /// </summary>
        public uint Characteristics;

        /// <summary>
        /// The time and date that the export data was created.
        /// </summary>
        public uint TimeDateStamp;

        /// <summary>
        /// The major version number. The major and minor version numbers
        /// can be set by the user.
        /// </summary>
        public ushort MajorVersion;

        /// <summary>
        /// The minor version number.
        /// </summary>
        public ushort MinorVersion;

        /// <summary>
        /// The address of the ASCII string that contains the name of the DLL.
        /// This address is relative to the image base.
        /// </summary>
        public uint NameRva;

        /// <summary>
        /// The starting ordinal number for exports in this image. This field
        /// specifies the starting ordinal number for the export address table.
        /// It is usually set to 1.
        /// </summary>
        public uint BaseOrdinal;

        /// <summary>
        /// The number of entries in the export address table.
        /// </summary>
        public uint NumberOfFunctions;

        /// <summary>
        /// The number of entries in the name pointer table. This is also the
        /// number of entries in the ordinal table.
        /// </summary>
        public uint NumberOfNames;

        /// <summary>
        /// The address (RVA) of the export address table, relative to the image base.
        /// </summary>
        public uint RvaOfExportAddressTable;

        /// <summary>
        /// The address (RVA) of the export name pointer table, relative to the image
        /// base. The table size is given by the Number of Name Pointers field.
        /// </summary>
        public uint RvaOfNames;

        /// <summary>
        /// The address (RVA) of the ordinal table, relative to the image base.
        /// </summary>
        public uint RvaOfOrdinals;
    }
}
