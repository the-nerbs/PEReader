using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    /// <summary>
    /// Gives the RVA and size of an image data directory.
    /// </summary>
    [DebuggerDisplay("RVA = {VirtualAddress} : {Size} bytes")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_DATA_DIRECTORY
    {
        /// <summary>
        /// The RVA of the table.
        /// </summary>
        public uint VirtualAddress;

        /// <summary>
        /// The size of the table in bytes.
        /// </summary>
        public uint Size;
    }
}
