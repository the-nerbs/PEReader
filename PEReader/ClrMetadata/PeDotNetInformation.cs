using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.CoreCLR;
using PEReader.ClrMetadata.Native;
using PEReader.Native;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Provides access to a PE file's .NET metadata.
    /// </summary>
    public sealed class PeDotNetInformation
    {
        private readonly IMAGE_COR20_HEADER _clrHeader;
        private readonly string _storageVersion;


        /// <summary>
        /// Gets the version of the CLR metadata header the assembly is build with.
        /// </summary>
        public Version ClrHeaderVersion
        {
            get
            {
                return new Version(
                    _clrHeader.MajorRuntimeVersion,
                    _clrHeader.MinorRuntimeVersion
                );
            }
        }

        /// <summary>
        /// Gets a value describing the characteristics of the assembly.
        /// </summary>
        public ClrHeaderFlags AssemblyFlags
        {
            get { return _clrHeader.Flags; }
        }

        /// <summary>
        /// Gets the version of the .NET runtime this was built for.
        /// </summary>
        public string RuntimeVersion
        {
            get { return _storageVersion; }
        }


        /// <summary>
        /// Gets an accessor for strings used by the CLR metadata.
        /// </summary>
        public ClrStringPool MetadataStrings { get; }

        /// <summary>
        /// Gets an accessor for string literals used in the .NET assembly code.
        /// </summary>
        public ClrUserStringPool StringLiterals { get; }

        /// <summary>
        /// Gets an accessor for GUIDs used by the CLR metadata.
        /// </summary>
        public ClrGuidPool Guids { get; }

        /// <summary>
        /// Gets an accessor for the metadata binary blobs.
        /// </summary>
        public ClrBlobPool Blobs { get; }

        /// <summary>
        /// Gets an accessor for the .NET metadata.
        /// </summary>
        public ClrMetadataAccessor Metadata { get; }


        internal PeDotNetInformation(IMAGE_SECTION_HEADER header, Stream peStream, IPeHeadersInternal headers)
        {
            _clrHeader = peStream.Read<IMAGE_COR20_HEADER>();


            long va = _clrHeader.MetaData.VirtualAddress;

            if (!headers.TryGetSectionForVirtualAddress(va, out header))
                throw new BadImageFormatException("CLR header does not point to any metadata.");

            long streamBaseOffset = (va - header.VirtualAddress) + header.PointerToRawData;

            peStream.Seek(streamBaseOffset, SeekOrigin.Begin);

            var storageSignature = peStream.Read<STORAGESIGNATURE>();
            _storageVersion = peStream.ReadUtf8(checked((int)storageSignature.iVersionString));

            var storageHeader = peStream.Read<STORAGEHEADER>();

            STORAGESTREAM[] streams = GetStreams(peStream, storageHeader.iStreams);

            foreach (var item in streams)
            {
                if (item.rcName == "#Strings")
                {
                    if (MetadataStrings != null)
                        throw new BadImageFormatException("Duplicate CLR metadata stream found: " + item.rcName);

                    MetadataStrings = new ClrStringPool(peStream, item, streamBaseOffset);
                }
                else if (item.rcName == "#US")
                {
                    if (StringLiterals != null)
                        throw new BadImageFormatException("Duplicate CLR metadata stream found: " + item.rcName);

                    StringLiterals = new ClrUserStringPool(peStream, item, streamBaseOffset);
                }
                else if (item.rcName == "#GUID")
                {
                    if (Guids != null)
                        throw new BadImageFormatException("Duplicate CLR metadata stream found: " + item.rcName);

                    Guids = new ClrGuidPool(peStream, item, streamBaseOffset);
                }
                else if (item.rcName == "#Blob")
                {
                    if (Blobs != null)
                        throw new BadImageFormatException("Duplicate CLR metadata stream found: " + item.rcName);

                    Blobs = new ClrBlobPool(peStream, item, streamBaseOffset);
                }
                else if (item.rcName == "#~")
                {
                    if (Metadata != null)
                        throw new BadImageFormatException("Duplicate CLR metadata stream found: " + item.rcName);

                    Metadata = new ClrMetadataAccessor(this, peStream, item, streamBaseOffset);
                }
            }
        }


        private STORAGESTREAM[] GetStreams(Stream peStream, int nStreams)
        {
            var streams = new STORAGESTREAM[nStreams];

            for (int i = 0; i < nStreams; i++)
            {
                streams[i].iOffset = peStream.Read<uint>();
                streams[i].iSize = peStream.Read<uint>();
                streams[i].rcName = peStream.ReadUtf8ZeroTerminated();

                peStream.AlignToBytes(4);
            }

            return streams;
        }
    }
}
