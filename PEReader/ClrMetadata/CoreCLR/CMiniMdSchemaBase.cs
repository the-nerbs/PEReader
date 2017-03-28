using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.ClrMetadata.CoreCLR
{
    internal enum HeapFlags : byte
    {
        None        = 0,
        HeapString4 = 0x01,
        HeapGuid4   = 0x02,
        HeapBlob4   = 0x08,
        PaddingBit  = 0x08,
        DeltaOnly   = 0x20,
        ExtraData   = 0x40,
        HasDelete   = 0x80
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct CMiniMdSchemaBase
    {
        /// <summary>
        /// Reserved, must be zero.
        /// </summary>
        public uint m_ulReserved;

        // Version numbers
        public byte m_major;
        public byte m_minor;

        /// <summary>
        /// Bits for heap sizes
        /// </summary>
        public HeapFlags m_heaps;

        /// <summary>
        /// Log[2](largest RID)
        /// </summary>
        public byte m_rid;

        /// <summary>
        /// Bit mask of present table counts
        /// </summary>
        public ulong m_maskvalid;

        /// <summary>
        /// Bit mask of sorted tables.
        /// </summary>
        public ulong m_sorted;
    }
}
