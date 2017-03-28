using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader.ClrMetadata
{
    internal static class ClrConstants
    {
        public const int MetadataSignature = 0x424A5342;    // "BSJB" (I'm not sure why though...)

        public const int MaxStreamName = 32;
    }

    [Flags]
    internal enum StorageHeaderFlags : byte
    {
        /// <summary>
        /// Normal default flags.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Additional data exists after header.
        /// </summary>
        ExtraData = 0x01,
    }
}
