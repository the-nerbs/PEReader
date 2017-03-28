using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    /// <summary>
    ///   DOS executable header.
    /// </summary>
    /// <devdoc>
    ///   <para>
    ///     Unfortunately, MSDN seems to have removed any documentation on this structure, and
    ///     the PE/COFF spec doesn't document it. The comments here are straight from the
    ///     definition in WinNT.h.
    ///   </para>
    ///   <para>
    ///     Fun fact:
    ///     If the PE is DOS-compatible (which Microsoft compilers make), the file contains
    ///     a valid DOS program.  This is why you see "This program cannot be run in DOS mode"
    ///     when you open an EXE, DLL, or other PE file in a hex editor (or even notepad).
    ///   </para>
    /// </devdoc>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct IMAGE_DOS_HEADER
    {
        /// <summary>
        /// Magic number
        /// </summary>
        public ushort e_magic;

        /// <summary>
        /// Bytes on last page of file
        /// </summary>
        public ushort e_cblp;

        /// <summary>
        /// Pages in file
        /// </summary>
        public ushort e_cp;

        /// <summary>
        /// Relocations
        /// </summary>
        public ushort e_crlc;

        /// <summary>
        /// Size of header in paragraphs
        /// </summary>
        public ushort e_cparhdr;

        /// <summary>
        /// Minimum extra paragraphs needed
        /// </summary>
        public ushort e_minalloc;

        /// <summary>
        /// Maximum extra paragraphs needed
        /// </summary>
        public ushort e_maxalloc;

        /// <summary>
        /// Initial (relative) SS value
        /// </summary>
        public ushort e_ss;

        /// <summary>
        /// Initial SP value
        /// </summary>
        public ushort e_sp;

        /// <summary>
        /// Checksum
        /// </summary>
        public ushort e_csum;

        /// <summary>
        /// Initial IP value
        /// </summary>
        public ushort e_ip;

        /// <summary>
        /// Initial (relative) CS value
        /// </summary>
        public ushort e_cs;

        /// <summary>
        /// File address of relocation table
        /// </summary>
        public ushort e_lfarlc;

        /// <summary>
        /// Overlay number
        /// </summary>
        public ushort e_ovno;

        /// <summary>
        /// Reserved words
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] e_res;

        /// <summary>
        /// OEM identifier (for e_oeminfo)
        /// </summary>
        public ushort e_oemid;

        /// <summary>
        /// OEM information; e_oemid specific
        /// </summary>
        public ushort e_oeminfo;

        /// <summary>
        /// Reserved words
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public ushort[] e_res2;

        /// <summary>
        /// File address of new exe header
        /// </summary>
        public uint e_lfanew;
    }
}
