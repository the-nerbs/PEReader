using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEReader.ClrMetadata;
using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Reads a Portable Executable (PE) file.
    /// </summary>
    public sealed class PeFile
    {
        private readonly IPeHeadersInternal _headers;


        /// <summary>
        /// Gets the path to the PE file.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the accessor for this PE file's header information.
        /// </summary>
        internal IPeHeaders Headers
        {
            get { return _headers; }
        }

        /// <summary>
        /// Gets an accessor for this PE file's export data.
        /// </summary>
        public PeExportData ExportData { get; }

        /// <summary>
        /// Gets an accessor for this PE file's import data.
        /// </summary>
        public IPeImportData ImportData { get; }

        /// <summary>
        /// Gets an accessor for this PE file's resources.
        /// </summary>
        public PeResources Resources { get; }

        /// <summary>
        /// Gets an accessor for this PE file's .NET information.
        /// </summary>
        public PeDotNetInformation DotNetInfo { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="PeFile"/>.
        /// </summary>
        /// <param name="path"></param>
        public PeFile(string path)
        {
            Path = path;

            var peImage = File.ReadAllBytes(path);
            var peStream = new MemoryStream(peImage, writable: false);

            _headers = GetHeaderAccessor(peStream);
            ExportData = GetExports(peStream);
            ImportData = GetImports(peStream);
            Resources = GetResources(peStream);

            DotNetInfo = GetDotNetMetadata(peStream);
        }


        private IPeHeadersInternal GetHeaderAccessor(Stream peStream)
        {
            var dosHeader = peStream.Read<IMAGE_DOS_HEADER>();
            if (dosHeader.e_magic != NativeConstants.DosSignature)
            {
                throw new BadImageFormatException("File does not have a valid DOS header.");
            }

            peStream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin);

            uint ntSignature = peStream.Read<uint>();
            if (ntSignature != NativeConstants.NTSignature)
            {
                throw new BadImageFormatException("File does not have a valid NT header.");
            }

            var machineType = (ImageFileMachine)peStream.Read<ushort>();

            // return to the beginning of the NT header for the accessors.
            peStream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin);

            switch (machineType)
            {
                case ImageFileMachine.I386:
                    return new Pe32Headers(peStream);

                case ImageFileMachine.AMD64:
                    return new Pe64Headers(peStream);

                default:
                    throw new BadImageFormatException($"File is for unsupported machine type {machineType}.");
            }
        }

        private PeExportData GetExports(Stream peStream)
        {
            IMAGE_SECTION_HEADER header;
            long fileOffset;

            if (TryGetDataSectionAndOffset(ImageDirectoryEntry.Export, out header, out fileOffset))
            {
                peStream.Seek(fileOffset, SeekOrigin.Begin);
                return new PeExportData(header, peStream);
            }

            // no export data
            return null;
        }

        private IPeImportData GetImports(Stream peStream)
        {
            IMAGE_SECTION_HEADER header;
            long fileOffset;

            if (TryGetDataSectionAndOffset(ImageDirectoryEntry.Import, out header, out fileOffset))
            {
                peStream.Seek(fileOffset, SeekOrigin.Begin);

                switch (_headers.Machine)
                {
                    case ImageFileMachine.I386:
                        return new Pe32ImportData(header, peStream);

                    case ImageFileMachine.AMD64:
                        return new Pe64ImportData(header, peStream);

                    default:
                        throw new BadImageFormatException($"File is for unsupported machine type {_headers.Machine}.");
                }
            }

            // no import data
            return null;
        }

        private PeResources GetResources(Stream peStream)
        {
            IMAGE_SECTION_HEADER header;
            long fileOffset;

            if (TryGetDataSectionAndOffset(ImageDirectoryEntry.Resource, out header, out fileOffset))
            {
                peStream.Seek(fileOffset, SeekOrigin.Begin);
                return new PeResources(header, peStream);
            }

            // no resources
            return null;
        }


        private PeDotNetInformation GetDotNetMetadata(Stream peStream)
        {
            IMAGE_SECTION_HEADER header;
            long fileOffset;

            if (TryGetDataSectionAndOffset(ImageDirectoryEntry.DotNetHeader, out header, out fileOffset))
            {
                peStream.Seek(fileOffset, SeekOrigin.Begin);
                return new PeDotNetInformation(header, peStream, _headers);
            }

            // no .NET metadata
            return null;
        }


        /// <summary>
        /// Attempts to get the section header which contains the given data directory contents,
        /// and the file offset at which the data content starts.
        /// </summary>
        /// <param name="dataDirectory">The directory to look up.</param>
        /// <param name="sectionHeader">[out] If successful, the header for the section containing the data, or a default value on failure.</param>
        /// <param name="fileOffset">[out] If successful, the offset in the file at which the data starts, or a default value on failure.</param>
        /// <returns>True if the data exists and the section containing it was successfully located, or false if not.</returns>
        private bool TryGetDataSectionAndOffset(ImageDirectoryEntry dataDirectory, 
                                                out IMAGE_SECTION_HEADER sectionHeader,
                                                out long fileOffset)
        {
            IMAGE_DATA_DIRECTORY directory;

            if (_headers.TryGetDirectoryHeader(dataDirectory, out directory))
            {
                if (_headers.TryGetSectionForVirtualAddress(directory.VirtualAddress, out sectionHeader))
                {
                    fileOffset = (directory.VirtualAddress - sectionHeader.VirtualAddress) + sectionHeader.PointerToRawData;
                    return true;
                }
            }

            // does not exist
            sectionHeader = default(IMAGE_SECTION_HEADER);
            fileOffset = default(long);
            return false;
        }
    }
}
