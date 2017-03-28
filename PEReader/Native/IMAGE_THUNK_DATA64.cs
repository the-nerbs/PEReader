using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.Native
{
    /// <devdoc>
    /// Much like IMAGE_RESOURCE_DIRECTORY_ENTRY, this is a union in WinNT.h.
    /// Unlike that though, this is just a union of 1 ULONGLONG with 4 different names.
    /// </devdoc>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct IMAGE_THUNK_DATA64
    {
        private ulong ulonglong;


        public ulong ForwarderString
        {
            get { return ulonglong; }
        }

        public ulong Function
        {
            get { return ulonglong; }
        }

        public ulong Ordinal
        {
            get { return ulonglong; }
        }

        public ulong AddressOfData
        {
            get { return ulonglong; }
        }


        public bool IsOrdinal
        {
            get { return ((ulonglong & 0x8000000000000000) != 0); }
        }
    }
}
