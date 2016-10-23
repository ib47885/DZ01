using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Zadatci_2_i_3
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        GenericList<T> list;
        int currentIndex;
        public GenericListEnumerator(GenericList<T> inputList)
        {
            this.list = inputList;
            this.currentIndex = -1;
        }

        public T Current
        {
            get
            {
                return list.GetElement(currentIndex);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (currentIndex < list.Count)
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}

