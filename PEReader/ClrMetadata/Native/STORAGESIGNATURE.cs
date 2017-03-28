using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.ClrMetadata.Native
{
    /// <summary>
    /// Signature block for the CLR metadata stream.
    /// </summary>
    /// <devdoc>
    /// See: CoreCLR/mdfileformat.h
    /// https://github.com/dotnet/coreclr/blob/32f0f9721afb584b4a14d69135bea7ddc129f755/src/md/inc/mdfileformat.h
    /// </devdoc>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct STORAGESIGNATURE
    {
        /// <summary>
        /// "Magic" signature
        /// </summary>
        public uint lSignature;

        /// <summary>
        /// Major file version
        /// </summary>
        public ushort iMajorVersion;

        /// <summary>
        /// Minor file version.
        /// </summary>
        public ushort iMinorVersion;

        /// <summary>
        /// Offset to next structure of information.
        /// </summary>
        public uint iExtraData;

        /// <summary>
        /// Length of the version string.
        /// </summary>
        public uint iVersionString;

        //  version string
        // BYTE pVersion[];
    }
}
