using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader
{
    internal class SortedList<T> : IList<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly List<T> _items = new List<T>();


        public int Count
        {
            get { return _items.Count; }
        }

        public T this[int index]
        {
            get { return _items[index]; }
        }


        public SortedList()
            : this(null, null)
        { }

        public SortedList(IComparer<T> comparer)
            : this(null, comparer)
        { }

        public SortedList(IEnumerable<T> items)
            : this(items, null)
        { }

        public SortedList(IEnumerable<T> items, IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;

            if (items != null)
            {
                _items.AddRange(items);
            }
        }


        public void Add(T item)
        {
            int idx = _items.BinarySearch(item, _comparer);

            if (idx < 0)
            {
                idx = ~idx;
            }

            _items.Insert(idx, item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            int idx = _items.BinarySearch(item, _comparer);

            return (idx >= 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            int idx = _items.BinarySearch(item, _comparer);

            if (idx >= 0)
            {
                _items.RemoveAt(idx);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public int IndexOf(T item)
        {
            int idx = _items.BinarySearch(item, _comparer);
            return Math.Max(-1, idx);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }


        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        T IList<T>.this[int index]
        {
            get { return this[index]; }
            set
            {
                throw new NotSupportedException();
            }
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
