using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.ClrMetadata.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct STORAGEHEADER
    {
        public StorageHeaderFlags fFlags;

        public byte pad;

        public ushort iStreams;
    }
}
