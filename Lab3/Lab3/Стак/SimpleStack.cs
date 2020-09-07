using System;

namespace Lab3
{
    /// <summary>
    /// Класс стек
    /// </summary>
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
                this.last = null;
                return this.first.data;
            }
            else
            {
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                this.last = newLast;
                newLast.next = null;
                this.Count--;
                return newLast.next.data;
            }
        }
    }
}
