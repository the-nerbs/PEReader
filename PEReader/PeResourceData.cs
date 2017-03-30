using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// Provides information on a resource.
    /// </summary>
    public sealed class PeResourceData
    {
        /// <summary>
        /// Gets the type of this resource entry.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the name of this resource entry.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the locale ID of this resource entry.
        /// </summary>
        public int LocaleId { get; }

        /// <summary>
        /// Gets the data of this resource entry.
        /// </summary>
        ReadOnlyCollection<byte> Data { get; }

        /// <summary>
        /// Gets a <see cref="CultureInfo"/> describing the locale of this resource entry.
        /// </summary>
        public CultureInfo Locale
        {
            get { return CultureInfo.GetCultureInfo(LocaleId); }
        }


        internal PeResourceData(string type, string name, int localeId, byte[] data)
        {
            Type = type;
            Name = name;
            LocaleId = localeId;
            Data = new ReadOnlyCollection<byte>(data);
        }
    }
}
