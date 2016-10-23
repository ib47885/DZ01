using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _capacity;
        private int _numberOfStoredElements;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _capacity = 4;
            _numberOfStoredElements = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 1)
            {
                throw new ArgumentException("initialSize must be >= 1 !");
            }
            _capacity = initialSize;
            _numberOfStoredElements = 0;
            _internalStorage = new int[initialSize];
        }

        public void Add(int item)
        {
            if (_numberOfStoredElements == _capacity)
            {
                _capacity = _capacity * 2;
                int[] newArray = new int[_capacity];
                _internalStorage.CopyTo(newArray, 0);
                _internalStorage = newArray;
            }

            _internalStorage[_numberOfStoredElements] = item;
            _numberOfStoredElements++;
        }

        public bool Remove(int item)
        {
            bool found = false;
            for (int i = 0; i < _numberOfStoredElements; ++i)
            {
                if (_internalStorage[i] == item)
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

        public int GetElement(int index)
        {
            if (index < 0 || index >= _numberOfStoredElements)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _numberOfStoredElements; ++i)
            {
                if (_internalStorage[i] == item)
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
            _internalStorage = new int[_capacity];
            _numberOfStoredElements = 0;
        }

        public bool Contains(int item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            return false;
        }

    }
}
