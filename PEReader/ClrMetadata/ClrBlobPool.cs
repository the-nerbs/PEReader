using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.Native;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Provides access to a PE file's .NET metadata blobs.
    /// </summary>
    public sealed class ClrBlobPool : IList<IBlob>
    {
        private byte[] _data;
        private IBlob[] _blobs;


        /// <summary>
        /// Gets the number of blobs.
        /// </summary>
        public int Count
        {
            get { return _blobs.Length; }
        }

        /// <summary>
        /// Gets the blob at the given index.
        /// </summary>
        /// <param name="index">The index to access.</param>
        /// <returns>The blob at the given index.</returns>
        public IBlob this[int index]
        {
            get { return _blobs[index]; }
        }


        internal ClrBlobPool(Stream peStream, STORAGESTREAM streamInfo, long baseOffset)
        {
            long offset = baseOffset + streamInfo.iOffset;
            peStream.Seek(offset, SeekOrigin.Begin);

            _data = new byte[streamInfo.iSize];
            peStream.Read(_data, 0, _data.Length);


            // start at byte 1 - skips the first 0 element.
            int idx = 1;
            var blobs = new List<IBlob>();

            while (idx < _data.Length)
            {
                int len;

                if ((_data[idx] & 0xC0) == 0xC0)
                {
                    len = ((_data[idx + 0] & 0x3F) << 24) |
                          ((_data[idx + 1] & 0xFF) << 16) |
                          ((_data[idx + 2] & 0xFF) <<  8) |
                          ((_data[idx + 3] & 0xFF) <<  0);

                    idx += 4;
                }
                else if ((_data[idx] & 0x80) == 0x80)
                {
                    len = ((_data[idx + 0] & 0x7F) << 8) |
                          ((_data[idx + 1] & 0xFF) << 0);

                    idx += 2;
                }
                else
                {
                    len = _data[idx];
                    idx += 1;
                }

                blobs.Add(new Blob(_data, idx, len));
                idx += len;
            }

            Debug.Assert(idx == _data.Length);

            _blobs = blobs.ToArray();
        }


        /// <summary>
        /// Gets an enumerator over the blobs.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IBlob> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _blobs[i];
            }
        }


        #region Explicit implementations

        bool ICollection<IBlob>.IsReadOnly
        {
            get { return true; }
        }

        int IList<IBlob>.IndexOf(IBlob item)
        {
            return Array.IndexOf(_blobs, item);
        }

        bool ICollection<IBlob>.Contains(IBlob item)
        {
            return ((IList<IBlob>)_blobs).Contains(item);
        }

        IBlob IList<IBlob>.this[int index]
        {
            get { return _blobs[index]; }
            set { throw new NotSupportedException(); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _blobs.GetEnumerator();
        }

        #endregion

        #region Unsupported interface implementations

        void IList<IBlob>.Insert(int index, IBlob item)
        {
            throw new NotSupportedException();
        }

        void IList<IBlob>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<IBlob>.Add(IBlob item)
        {
            throw new NotSupportedException();
        }

        void ICollection<IBlob>.Clear()
        {
            throw new NotSupportedException();
        }

        void ICollection<IBlob>.CopyTo(IBlob[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        bool ICollection<IBlob>.Remove(IBlob item)
        {
            throw new NotSupportedException();
        }

        #endregion


        private class Blob : IBlob
        {
            private readonly byte[] _allData;
            private readonly int _startIdx;
            private readonly int _count;


            public byte this[int index]
            {
                get
                {
                    if (index < 0 || _count <= index)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }

                    return _allData[index + _startIdx];
                }
            }

            public int Size
            {
                get { return _count; }
            }


            internal Blob(byte[] allData, int start, int size)
            {
                _allData = allData;
                _startIdx = start;
                _count = size;
            }


            public IEnumerator<byte> GetEnumerator()
            {
                for (int i = 0; i < _count; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
