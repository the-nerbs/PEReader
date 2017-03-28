using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_NT_HEADERS32
    {
        /// <summary>
        /// The PE signature. Should be "PE\0\0".
        /// </summary>
        public uint Signature;

        /// <summary>
        /// The COFF header.
        /// </summary>
        public IMAGE_FILE_HEADER FileHeader;

        /// <summary>
        /// PE image header.
        /// </summary>
        public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
    }
}
