namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
            this.Clear();
        }

        public ListItem<T> FirstElement { get; private set; }

        public void Add(T item)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(item);
            }
            else
            {
                var currentElement = this.FirstElement;

                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }

                currentElement.Next = new ListItem<T>(item);
            }
        }

        public void Clear()
        {
            this.FirstElement = null;
        }

        public bool Remove(T item)
        {
            if (this.FirstElement.Value.Equals(item))
            {
                this.FirstElement = this.FirstElement.Next;

                return true;
            }
            else
            {
                var previousElement = this.FirstElement;
                var currentElement = this.FirstElement.Next;
                while (currentElement != null)
                {
                    if (currentElement.Value.Equals(item))
                    {
                        previousElement.Next = currentElement.Next;

                        return true;
                    }
                }

                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.FirstElement;

            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}