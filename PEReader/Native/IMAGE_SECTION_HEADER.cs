using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static PEReader.Native.NativeConstants;

namespace PEReader.Native
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    internal struct IMAGE_SECTION_HEADER
    {
        /// <summary>
        /// An 8-byte, null-padded UTF-8 encoded string. If the string is
        /// exactly 8 characters long, there is no terminating null. For
        /// longer names, this field contains a slash (/) that is followed by
        /// an ASCII representation of a decimal number that is an offset into
        /// the string table. Executable images do not use a string table and
        /// do not support section names longer than 8 characters. Long names
        /// in object files are truncated if they are emitted to an executable
        /// file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_SIZEOF_SHORT_NAME)]
        public byte[] Name;

        /// <summary>
        /// The total size of the section when loaded into memory. If this
        /// value is greater than SizeOfRawData, the section is zero-padded.
        /// </summary>
        public uint VirtualSize;

        /// <summary>
        /// The address of the first byte of the section relative to the image
        /// base when the section is loaded into memory.
        /// </summary>
        public uint VirtualAddress;

        /// <summary>
        /// The size of the initialized data on disk (for image files). For
        /// executable images, this must be a multiple of FileAlignment from
        /// the optional header. If this is less than VirtualSize, the
        /// remainder of the section is zero-filled. Because the SizeOfRawData 
        /// field is rounded but the VirtualSize field is not, it is possible
        /// for SizeOfRawData to be greater than VirtualSize as well. When a
        /// section contains only uninitialized data, this field should be zero.
        /// </summary>
        public uint SizeOfRawData;

        /// <summary>
        /// The file pointer to the first page of the section within the COFF
        /// file. This must be a multiple of FileAlignment from the optional
        /// header.
        /// </summary>
        public uint PointerToRawData;

        /// <summary>
        /// The file pointer to the beginning of relocation entries for the
        /// section. This is set to zero for executable images or if there
        /// are no relocations.
        /// </summary>
        public uint PointerToRelocations;

        /// <summary>
        /// The file pointer to the beginning of line-number entries for the
        /// section. This is set to zero if there are no COFF line numbers.
        /// This value should be zero for an image because COFF debugging
        /// information is deprecated.
        /// </summary>
        public uint PointerToLinenumbers;

        /// <summary>
        /// The number of relocation entries for the section. This is set to
        /// zero for executable images.
        /// </summary>
        public ushort NumberOfRelocations;

        /// <summary>
        /// The number of line-number entries for the section. This value
        /// should be zero for an image because COFF debugging information
        /// is deprecated.
        /// </summary>
        public ushort NumberOfLinenumbers;

        /// <summary>
        /// The flags that describe the characteristics of the section.
        /// </summary>
        public SectionCharacteristics Characteristics;


        /// <summary>
        /// Gets the name of this section as a string.
        /// </summary>
        /// <remarks>
        /// For object files, this can be formatted like "/#######", where the '#'s
        /// is an ASCII number representing a string-table offset to the full name.
        /// 
        /// However, this format is *not* supported in executable images (DLLs, EXEs),
        /// and names longer than 8 characters are truncated to fit the buffer.
        /// </remarks>
        public string NameStr
        {
            get { return Encoding.ASCII.GetString(Name).TrimEnd('\0'); }
        }
    }
}
