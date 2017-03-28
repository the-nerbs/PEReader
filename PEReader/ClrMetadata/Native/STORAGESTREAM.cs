using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using static PEReader.ClrMetadata.ClrConstants;

namespace PEReader.ClrMetadata.Native
{
    // Note: this is *not* read through the marshaler, so no layout attributes
    [DebuggerDisplay("{rcName} : Offset={iOffset} : Size={iSize}")]
    internal struct STORAGESTREAM
    {
        /// <summary>
        /// Offset in file for this stream.
        /// </summary>
        public uint iOffset;

        /// <summary>
        /// Size of the file.
        /// </summary>
        public uint iSize;

        /// <summary>
        /// Stream name.
        /// </summary>
        public string rcName;
    }
}
