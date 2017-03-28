using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEReader.Native;

namespace PEReader
{
    internal interface IPeHeadersInternal : IPeHeaders
    {
        /// <summary>
        /// Attempts to get a data directory header.
        /// </summary>
        /// <param name="type">The data directory entry to get.</param>
        /// <param name="entry">[out] If successful, the requested entry, or a default value on failure.</param>
        /// <returns>True if the directory exists and lookup succeeded, or false if not.</returns>
        bool TryGetDirectoryHeader(ImageDirectoryEntry type, out IMAGE_DATA_DIRECTORY entry);

        /// <summary>
        /// Attempts to get the section header with the given name.
        /// </summary>
        /// <param name="sectionName">The name of the section to get.</param>
        /// <param name="header">[out] If successful, the requested section's header, or a default value on failure.</param>
        /// <returns>True if the section exists and lookup succeeded, or false if not.</returns>
        bool TryGetSectionHeader(string sectionName, out IMAGE_SECTION_HEADER header);

        /// <summary>
        /// Attempts to get the section which contains the given virtual address.
        /// </summary>
        /// <param name="address">The address to lookup.</param>
        /// <param name="header">[out] If successful, the header for the section containing the address, or a default value on failure.</param>
        /// <returns>True if a section was found to contain the given address, or false if not.</returns>
        /// <remarks>
        /// Use this to look up the contents of data directory entries.
        /// </remarks>
        bool TryGetSectionForVirtualAddress(long address, out IMAGE_SECTION_HEADER header);
    }

    /// <summary>
    /// Extension methods for the <see cref="IPeHeaders"/> interface.
    /// </summary>
    internal static class PeHeadersExtensionMethods
    {
        /// <summary>
        /// Attempts to get a well-known section's header.
        /// </summary>
        /// <param name="accessor">[this] The accessor interface.</param>
        /// <param name="section">The section to get.</param>
        /// <param name="header">[out] If succeeded, the requested section's header, or a default value on failure.</param>
        /// <returns>True if the section exists and lookup succeeded, or false if not.</returns>
        public static bool TryGetSectionHeader(this IPeHeadersInternal accessor, WellKnownSection section, out IMAGE_SECTION_HEADER header)
        {
            switch (section)
            {
                case WellKnownSection.Debug:
                    return accessor.TryGetSectionHeader(".debug", out header);

                case WellKnownSection.Drectve:
                    return accessor.TryGetSectionHeader(".drectve", out header);

                case WellKnownSection.EData:
                    return accessor.TryGetSectionHeader(".edata", out header);

                case WellKnownSection.PData:
                    return accessor.TryGetSectionHeader(".pdata", out header);

                case WellKnownSection.Reloc:
                    return accessor.TryGetSectionHeader(".reloc", out header);

                case WellKnownSection.TLS:
                    return accessor.TryGetSectionHeader(".tls", out header);

                case WellKnownSection.Rsrc:
                    return accessor.TryGetSectionHeader(".rsrc", out header);

                case WellKnownSection.CorMeta:
                    return accessor.TryGetSectionHeader(".cormeta", out header);

                case WellKnownSection.SxData:
                    return accessor.TryGetSectionHeader(".sxdata", out header);

                default:
                    throw new ArgumentException("Invalid section");
            }
        }
    }
}
