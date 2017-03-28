using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    internal static class NativeConstants
    {
        public const uint DosSignature = 0x5A4D;        // "MZ"
        public const uint NTSignature  = 0x00004550;    // "PE\0\0"

        public const int IMAGE_NUMBEROF_DIRECTORY_ENTRIES = 16;

        public const int IMAGE_SIZEOF_SHORT_NAME = 8;

        public const int IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10B;
        public const int IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20B;
        public const int IMAGE_ROM_OPTIONAL_HDR_MAGIC  = 0x107;

        public static readonly DateTime TimeStampBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public static SectionAlignment GetAlignment(this SectionCharacteristics flags)
        {
            int align = (int)(flags & SectionCharacteristics.AlignMask) >> 20;
            return (SectionAlignment)align;
        }
    }

    internal enum WellKnownSection
    {
        Debug,
        Drectve,
        EData,
        PData,
        Reloc,
        TLS,
        Rsrc,
        CorMeta,
        SxData,
    }

    [Flags]
    internal enum SectionCharacteristics : uint
    {
        NoPadding                    = 0x00000008,
        ContainsCode                 = 0x00000020,
        InitializedData              = 0x00000040,
        UninitializedData            = 0x00000080,
        LinkOther                    = 0x00000100,
        LinkInfo                     = 0x00000200,
        LinkRemove                   = 0x00000800,
        LinkComdat                   = 0x00001000,
        NoDeferSpeculativeExceptions = 0x00004000,
        GlobalPointerRefs            = 0x00008000,

        MemoryPurgeable              = 0x00020000,

        MemoryLocked                 = 0x00040000,
        MemoryPreload                = 0x00080000,

        AlignBit0                    = 0x00100000,
        AlignBit1                    = 0x00200000,
        AlignBit2                    = 0x00400000,
        AlignBit3                    = 0x00800000,

        ExtendedRelocations          = 0x01000000,
        MemoryDiscardable            = 0x02000000,
        MemoryNotCached              = 0x04000000,
        MemoryNotPaged               = 0x08000000,
        MemoryShared                 = 0x10000000,
        MemoryExecutable             = 0x20000000,
        MemoryReadable               = 0x40000000,
        MemoryWriteable              = 0x80000000,


        AlignMask                    = (AlignBit0 | AlignBit1 | AlignBit2 | AlignBit3),
    }

    internal enum SectionAlignment
    {
        Align1    = 0x1,
        Align2    = 0x2,
        Align4    = 0x3,
        Align8    = 0x4,
        Align16   = 0x5,
        Align32   = 0x6,
        Align64   = 0x7,
        Align128  = 0x8,
        Align256  = 0x9,
        Align512  = 0xA,
        Align1024 = 0xB,
        Align2048 = 0xC,
        Align4096 = 0xD,
        Align8192 = 0xE,
    }

    internal enum ImageDirectoryEntry
    {
        /// <summary>
        /// Export Directory
        /// </summary>
        Export = 0,

        /// <summary>
        /// Import Directory
        /// </summary>
        Import = 1,

        /// <summary>
        /// Resource Directory
        /// </summary>
        Resource = 2,

        /// <summary>
        /// Exception Directory
        /// </summary>
        Exception = 3,

        /// <summary>
        /// Security Directory
        /// </summary>
        Security = 4,

        /// <summary>
        /// Base Relocation Table
        /// </summary>
        BaseReloc = 5,

        /// <summary>
        /// Debug Directory
        /// </summary>
        Debug = 6,

        // I'm not sure either - it's commented out in WinNT.h, too...
        // Copyright   = 7,     // (X86 usage)

        /// <summary>
        /// Architecture Specific Data
        /// </summary>
        Architecture = 7,

        /// <summary>
        /// RVA of GP
        /// </summary>
        GlobalPtr = 8,

        /// <summary>
        /// TLS Directory
        /// </summary>
        TLS = 9,

        /// <summary>
        /// Load Configuration Directory
        /// </summary>
        LoadConfig = 10,

        /// <summary>
        /// Bound Import Directory in headers
        /// </summary>
        BoundImport = 11,

        /// <summary>
        /// Import Address Table
        /// </summary>
        IAT = 12,

        /// <summary>
        /// Delay Load Import Descriptors
        /// </summary>
        DelayImport = 13,

        /// <summary>
        /// .NET metadata header.
        /// </summary>
        /// <devdoc>
        /// WinNT.h calls this entry "COM_DESCRIPTOR", but this name is a holdover from
        /// when .NET was just COM v2.
        /// </devdoc>
        DotNetHeader = 14,
    }
}
