using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PEReader.Native;

namespace PEReader.ClrMetadata.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_COR20_HEADER
    {
        /// <summary>
        /// The size of this structure
        /// </summary>
        public uint HeaderSize;

        /// <summary>
        /// Major version of the CLR this was built for.
        /// </summary>
        public ushort MajorRuntimeVersion;

        /// <summary>
        /// Minor version of the CLR this was built for.
        /// </summary>
        public ushort MinorRuntimeVersion;


        /// <summary>
        /// Managed types and code metadata.
        /// </summary>
        public IMAGE_DATA_DIRECTORY MetaData;

        /// <summary>
        /// Flags describing this assembly's characteristics.
        /// </summary>
        public ClrHeaderFlags Flags;


        /// <summary>
        /// Points to the Main function for EXEs, unused for DLLs.
        /// </summary>
        /// <devdoc>
        /// If the NativeEntryPoint flag is set in <see cref="Flags"/>, this is an RVA.
        /// If the falg is not set, this is the MD token of the managed main function.
        /// </devdoc>
        public uint EntryPointTokenOrRva;

        /// <summary>
        /// Managed resources blob.
        /// </summary>
        public IMAGE_DATA_DIRECTORY Resources;

        /// <summary>
        /// The signature for signed assemblies.
        /// </summary>
        public IMAGE_DATA_DIRECTORY StrongNameSignature;


        /// <summary>
        /// Deprecated entry - should be unused.
        /// </summary>
        public IMAGE_DATA_DIRECTORY CodeManagerTable;

        // Used for managed code that has unmanaged code inside it (or exports methods as unmanaged entry points).
        public IMAGE_DATA_DIRECTORY VTableFixups;
        public IMAGE_DATA_DIRECTORY ExportAddressTableJumps;

        /// <summary>
        /// Null for ordinary IL images. Populated by NGEN to point at a CORCOMPILE_HEADER.
        /// </summary>
        public IMAGE_DATA_DIRECTORY ManagedNativeHeader;
    }
}
