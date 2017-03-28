using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct IMAGE_RESOURCE_DATA_ENTRY
    {
        /// <summary>
        /// The address (RVA) of a unit of resource data in the Resource Data area.
        /// </summary>
        public uint OffsetToData;

        /// <summary>
        /// The size, in bytes, of the resource data that is pointed to by the Data RVA field.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The code page that is used to decode code point values within the resource data.
        /// Typically, the code page would be the Unicode code page.
        /// </summary>
        public uint CodePage;

        /// <summary>
        /// Reserved, must be 0.
        /// </summary>
        public uint Reserved;
    }
}
