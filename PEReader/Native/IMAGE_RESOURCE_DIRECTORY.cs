using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_RESOURCE_DIRECTORY
    {
        /// <summary>
        /// Resource flags. This field is reserved for future use. It is currently set to zero.
        /// </summary>
        public uint Characteristics;

        /// <summary>
        /// The time that the resource data was created by the resource compiler.
        /// </summary>
        public uint TimeDateStamp;

        /// <summary>
        /// The major version number, set by the user.
        /// </summary>
        public ushort MajorVersion;

        /// <summary>
        /// The minor version number, set by the user.
        /// </summary>
        public ushort MinorVersion;

        /// <summary>
        /// The number of directory entries immediately following the table that use strings
        /// to identify Type, Name, or Language entries (depending on the level of the table).
        /// </summary>
        public ushort NumberOfNamedEntries;

        /// <summary>
        /// The number of directory entries immediately following the Name
        /// entries that use numeric IDs for Type, Name, or Language entries.
        /// </summary>
        public ushort NumberOfIdEntries;


        // This structure is followed immediately by a variable-sized array of IMAGE_RESOURCE_DIRECTORY_ENTRY
        // It's length is the total # entries: NumberOfNamedEntries + NumberOfIdEntries
        // IMAGE_RESOURCE_DIRECTORY_ENTRY DirectoryEntries[];
    }
}
