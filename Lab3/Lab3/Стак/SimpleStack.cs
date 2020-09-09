using System;

namespace Lab3
{
    class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        public void Push(T obj)
        {
            Add(obj);
        }
        public T Pop()
        {

            if (this.Count == 0) return default(T);
            if (this.Count == 1)
            {
                this.first = null;
                T res = this.last.data;
                this.last = null;
                this.Count--;
                return res;
            }
            else
            {
                T res = this.last.data;
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                this.last = newLast;
                newLast.next = null;
                this.Count--;
                return res;
            }
        }
    }
}
