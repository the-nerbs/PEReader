using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// Provides a typed enumerator for arrays.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    public struct TypedArrayEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _array;
        private int _current;


        /// <summary>
        /// Gets the current item.
        /// </summary>
        public T Current
        {
            get
            {
                if (_current < 0 || _array.Length <= _current)
                    throw new InvalidOperationException();

                return _array[_current];
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }


        internal TypedArrayEnumerator(T[] array)
        {
            _array = array;
            _current = -1;
        }


        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next
        /// element; false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (_current < _array.Length)
            {
                _current++;
                return (_current < _array.Length);
            }
            return false;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before
        /// the first element in the collection.
        /// </summary>
        public void Reset()
        {
            _current = -1;
        }


        /// <summary>
        /// This enumerator type has nothing to dispose.
        /// </summary>
        public void Dispose()
        {
            // Nothing to dispose.
        }
    }
}
