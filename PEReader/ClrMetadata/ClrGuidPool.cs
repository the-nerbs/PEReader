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
    /// Provides a list of GUIDs used in an assembly's metadata.
    /// </summary>
    public sealed class ClrGuidPool : IEnumerable<Guid>
    {
        private const int SizeOfGuid = 16;


        private readonly Guid[] _guids;


        /// <summary>
        /// Gets the number of strings contained in this string pool.
        /// </summary>
        public int Count
        {
            get { return _guids.Length; }
        }

        /// <summary>
        /// Gets the string with the given index.
        /// </summary>
        /// <param name="index">The index of the string to get.</param>
        /// <returns>The string at the given index.</returns>
        public Guid this[int index]
        {
            get
            {
                if (index < 0 || _guids.Length <= index)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return _guids[index];
            }
        }


        internal ClrGuidPool(Stream peStream, STORAGESTREAM streamInfo, long baseOffset)
        {
            int count = checked((int)(streamInfo.iSize / SizeOfGuid));

            var guids = new Guid[count];

            if (count > 0)
            {
                long offset = baseOffset + streamInfo.iOffset;
                peStream.Seek(offset, SeekOrigin.Begin);

                var buffer = new byte[SizeOfGuid];

                for (int i = 0; i < count; i++)
                {
                    peStream.Read(buffer, 0, SizeOfGuid);
                    guids[i] = new Guid(buffer);
                }
            }

            _guids = guids.ToArray();
        }


        /// <summary>
        /// Gets an enumerator over the strings in this pool.
        /// </summary>
        /// <returns>An enumerator over the strings in this pool.</returns>
        public TypedArrayEnumerator<Guid> GetEnumerator()
        {
            return new TypedArrayEnumerator<Guid>(_guids);
        }

        IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
