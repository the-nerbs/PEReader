using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.Native
{
    /// <devdoc>
    /// Much like IMAGE_RESOURCE_DIRECTORY_ENTRY, this is a union in WinNT.h.
    /// Unlike that though, this is just a union of 1 DWORD with 4 different names.
    /// </devdoc>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_THUNK_DATA32
    {
        private uint dword;


        public uint Ordinal
        {
            get { return dword; }
        }

        public uint AddressOfData
        {
            get { return dword; }
        }


        public bool IsOrdinal
        {
            get { return ((dword & 0x80000000) != 0); }
        }
    }
}
