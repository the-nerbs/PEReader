using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_IMPORT_DESCRIPTOR
    {
        /// <summary>
        /// The RVA of the import lookup table. This table contains a name or
        /// ordinal for each import.
        /// </summary>
        public uint OriginalFirstThunk;

        /// <summary>
        /// The stamp that is set to zero until the image is bound. After the
        /// image is bound, this field is set to the time/data stamp of the DLL.
        /// </summary>
        public uint TimeDateStamp;

        /// <summary>
        /// The index of the first forwarder reference.
        /// </summary>
        public uint ForwarderChain;

        /// <summary>
        /// The address of an ASCII string that contains the name of the DLL.
        /// This address is relative to the image base.
        /// </summary>
        public uint NameRva;

        /// <summary>
        /// The RVA of the import address table. The contents of this table
        /// are identical to the contents of the import lookup table until
        /// the image is bound.
        /// </summary>
        public uint FirstThunk;
    }
}
