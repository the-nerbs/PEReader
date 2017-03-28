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
    /// Provides a list of string literals that are used in code.
    /// </summary>
    public sealed class ClrUserStringPool : IEnumerable<string>
    {
        private string[] _strings;


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


        internal ClrUserStringPool(Stream peStream, STORAGESTREAM streamInfo, long baseOffset)
        {
            var items = new List<string>();

            long offset = baseOffset + streamInfo.iOffset;
            long end = offset + streamInfo.iSize;

            // TODO: why the +1 here?
            peStream.Seek(offset + 1, SeekOrigin.Begin);

            while (peStream.Position < end)
            {
                items.Add(ReadUserString(peStream));
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

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            // hmmm... typed arrays don't implement IEnumerable<>
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private static string ReadUserString(Stream stream)
        {
            //structure is:
            // - length         : byte
            // - data           : byte[length-1]
            // - specialChars   : byte
            //
            // 'specialChars' indicates that the string contains chars that
            // would break the CLR's fast string sorting. Which chars set this
            // is defined by the "HighCharTable" here:
            // https://github.com/dotnet/coreclr/blob/32f0f9721afb584b4a14d69135bea7ddc129f755/src/utilcode/util_nodependencies.cpp#L970
            //
            // I don't particularly care about this flag though, so it's only
            // read below to position the stream past the end of this string.

            int nBytes = stream.ReadByte();
            var bytes = new byte[nBytes];

            stream.Read(bytes, 0, nBytes);

            if (nBytes > 1)
            {
                return Encoding.Unicode.GetString(bytes, 0, nBytes - 1);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
