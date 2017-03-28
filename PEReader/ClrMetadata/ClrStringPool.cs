using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.Native;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Provides a list of strings in a .NET assembly used by metadata.
    /// </summary>
    public sealed class ClrStringPool : IEnumerable<string>
    {
        private readonly string[] _strings;
        private readonly Dictionary<uint, string> _stringsByOffset;


        /// <summary>
        /// Gets the number of strings contained in this string pool.
        /// </summary>
        public int Count
        {
            get { return _strings.Length; }
        }

        /// <summary>
        /// Gets the string with the given index.
        /// </summary>
        /// <param name="index">The index of the string to get.</param>
        /// <returns>The string at the given index.</returns>
        public string this[int index]
        {
            get
            {
                if (index < 0 || _strings.Length <= index)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return _strings[index];
            }
        }


        internal ClrStringPool(Stream peStream, STORAGESTREAM streamInfo, long baseOffset)
        {
            var items = new List<string>();
            _stringsByOffset = new Dictionary<uint, string>();

            long offset = baseOffset + streamInfo.iOffset;
            long end = offset + streamInfo.iSize;

            peStream.Seek(offset, SeekOrigin.Begin);

            while (peStream.Position < end)
            {
                uint stringOffset = checked((uint)(peStream.Position - offset));

                string str = peStream.ReadUtf8ZeroTerminated();
                items.Add(str);
                _stringsByOffset[stringOffset] = str;
            }

            // Stream size includes padding at the end for word-alignment
            // Remove the empty strings that come of this.
            while (items.Count > 1 &&
                   string.IsNullOrEmpty(items.Last()))
            {
                items.RemoveAt(items.Count - 1);
            }

            _strings = items.ToArray();
        }


        /// <summary>
        /// Gets an enumerator over the strings in this pool.
        /// </summary>
        /// <returns>An enumerator over the strings in this pool.</returns>
        public TypedArrayEnumerator<string> GetEnumerator()
        {
            return new TypedArrayEnumerator<string>(_strings);
        }

        /// <summary>
        /// Attempts to get a string by it's offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="value">[out] The string, or a default value if the offset does not point to a valid string.</param>
        /// <returns>True if a string was successfully obtained, or false if not.</returns>
        internal bool TryGetStringByOffset(uint offset, out string value)
        {
            // 'fast'-path: offset points to the start of a string.
            if (_stringsByOffset.TryGetValue(offset, out value))
            {
                return true;
            }

            // offset can point into the middle of a string.
            bool found = false;
            var pair = default(KeyValuePair<uint, string>);

            foreach (var kvp in _stringsByOffset)
            {
                found = kvp.Key > offset;

                if (!found)
                {
                    pair = kvp;
                }
                else
                {
                    break;
                }
            }

            if (found)
            {
                int startIdx = checked((int)(offset - pair.Key));
                value = pair.Value.Substring(startIdx);
                return true;
            }

            value = null;
            return false;
        }


        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private struct StringInfo : IComparable<StringInfo>
        {
            public uint Offset { get; }
            public string Text { get; }


            public StringInfo(uint offset, string text)
            {
                Offset = offset;
                Text = text;
            }


            public int CompareTo(StringInfo other)
            {
                return unchecked((int)(Offset - other.Offset));
            }
        }


    }
}
