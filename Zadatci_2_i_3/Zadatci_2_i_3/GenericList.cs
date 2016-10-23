using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatci_2_i_3
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _capacity;
        private int _numberOfStoredElements;

        public GenericList()
        {
            _internalStorage = new X[4];
            _capacity = 4;
            _numberOfStoredElements = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 1)
            {
                throw new ArgumentException("initialSize must be >= 1 !");
            }
            _capacity = initialSize;
            _numberOfStoredElements = 0;
            _internalStorage = new X[initialSize];
        }

        public void Add(X item)
        {
            if (_numberOfStoredElements == _capacity)
            {
                _capacity = _capacity * 2;
                X[] newArray = new X[_capacity];
                _internalStorage.CopyTo(newArray, 0);
                _internalStorage = newArray;
            }

            _internalStorage[_numberOfStoredElements] = item;
            _numberOfStoredElements++;
        }

        public bool Remove(X item)
        {
            bool found = false;
            for (int i = 0; i < _numberOfStoredElements; ++i)
            {
                if (_internalStorage[i].Equals(item))
                {
                    RemoveAt(i);
                    found = true;
                }
            }

            return found;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _numberOfStoredElements)
            {
                return false;
            }

            Array.Copy(_internalStorage, index + 1, _internalStorage, index, _numberOfStoredElements - index - 1);
            _numberOfStoredElements--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index >= _numberOfStoredElements)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _numberOfStoredElements; ++i)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int Count
        {
            get
            {
                return _numberOfStoredElements;
            }
        }

        public void Clear()
        {
            _internalStorage = new X[_capacity];
            _numberOfStoredElements = 0;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
