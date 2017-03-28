using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    // Note: the original definition is a little more complex than I made it here...
    // typedef struct _IMAGE_RESOURCE_DIRECTORY_ENTRY {
    //     union {
    //         struct {
    //             DWORD NameOffset:31;
    //             DWORD NameIsString:1;
    //         } DUMMYSTRUCTNAME;
    //         DWORD   Name;
    //         WORD    Id;
    //     } DUMMYUNIONNAME;
    //     union {
    //         DWORD   OffsetToData;
    //         struct {
    //             DWORD   OffsetToDirectory:31;
    //             DWORD   DataIsDirectory:1;
    //         } DUMMYSTRUCTNAME2;
    //     } DUMMYUNIONNAME2;
    // } IMAGE_RESOURCE_DIRECTORY_ENTRY;
    //
    // To simplify this mess, I just have a couple backing fields with properties
    // to access each of the union fields.

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_RESOURCE_DIRECTORY_ENTRY
    {
        private uint word0;
        private uint word1;


        /// <summary>
        /// The offset of a string that gives the Type, Name, or Language ID
        /// entry, depending on level of table.
        /// </summary>
        /// <remarks>
        /// The name is structured as a length-prefixed string. The WinNT.h definition is:
        /// <code>
        /// typedef struct _IMAGE_RESOURCE_DIR_STRING_U {
        ///     WORD    Length;
        ///     WCHAR   NameString[ 1 ];
        /// } IMAGE_RESOURCE_DIR_STRING_U, *PIMAGE_RESOURCE_DIR_STRING_U;
        /// </code>
        /// </remarks>
        public uint NameOffset
        {
            get { return (word0 & 0x7FFFFFFF); }
        }

        /// <summary>
        /// If true, the name is a string (as opposed to an integer).
        /// </summary>
        public bool NameIsString
        {
            get
            {
                return (word0 & 0x80000000) != 0;
            }
        }

        /// <summary>
        /// A 32-bit integer that identifies the Type, Name, or Language ID entry.
        /// </summary>
        public uint Name
        {
            get { return word0; }
        }

        /// <summary>
        /// The 16-bit integer resource name.
        /// </summary>
        public ushort Id
        {
            get { return unchecked((ushort)word0); }
        }


        /// <summary>
        /// Address of a Resource Data entry (a leaf).
        /// </summary>
        public uint OffsetToData
        {
            get { return word1; }
        }

        /// <summary>
        /// The lower 31 bits are the address of another resource
        /// directory table (the next level down).
        /// </summary>
        public uint OffsetToDirectory
        {
            get { return (word1 & 0x7FFFFFFF); }
        }

        /// <summary>
        /// If true, this entry's data is a <see cref="IMAGE_RESOURCE_DIRECTORY"/>.
        /// </summary>
        public bool DataIsDirectory
        {
            get { return (word1 & 0x80000000) != 0; }
        }
    }
}
