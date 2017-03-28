using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Accessor for general PE data.
    /// </summary>
    public interface IPeHeaders
    {
        /// <summary>
        /// NT signature
        /// </summary>
        uint Signature { get; }


        // IMAGE_FILE_HEADER data

        /// <summary>
        /// Gets the machine for which the PE was built.
        /// </summary>
        ImageFileMachine Machine { get; }

        /// <summary>
        /// Gets the number of sections defined in this PE file.
        /// </summary>
        int NumberOfSections { get; }

        /// <summary>
        /// Gets the time stamp of the PE file.
        /// </summary>
        DateTime TimeStampUtc { get; }

        /// <summary>
        /// Gets the PE image characteristics.
        /// </summary>
        ImageCharacteristics ImageCharacteristics { get; }



        // IMAGE_OPTIONAL_HEADER data

        /// <summary>
        /// The preferred base address for the loaded image.
        /// </summary>
        ulong ImageBase { get; }

        /// <summary>
        /// The alignment for mapped image sections.
        /// </summary>
        uint SectionAlignment { get; }

        /// <summary>
        /// The required OS version.
        /// </summary>
        Version OSVersion { get; }

        /// <summary>
        /// The image version.
        /// </summary>
        Version ImageVersion { get; }

        /// <summary>
        /// The subsystem version
        /// </summary>
        Version SubsystemVersion { get; }

        /// <summary>
        /// The byte-size of the image when loaded.  This may differ from the physical size
        /// due to sections being mapped to match the <see cref="SectionAlignment"/>.
        /// </summary>
        long InMemoryImageSize { get; }

        /// <summary>
        /// Image checksum value.
        /// </summary>
        uint CheckSum { get; }

        /// <summary>
        /// The subsystem that is required to run this image.
        /// </summary>
        ImageSubsystem Subsystem { get; }

        /// <summary>
        /// DLL characteristics flags. See: <see cref="DllCharacteristics"/>.
        /// </summary>
        DllCharacteristics DllCharacteristics { get; }
    }
}
