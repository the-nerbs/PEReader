using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// Interface for blob instances.
    /// </summary>
    public interface IBlob : IEnumerable<byte>
    {
        /// <summary>
        /// Gets size of this blob.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Gets the byte at the given index.
        /// </summary>
        /// <param name="index">The index of the byte to get.</param>
        /// <returns>The byte.</returns>
        byte this[int index] { get; }
    }
}
