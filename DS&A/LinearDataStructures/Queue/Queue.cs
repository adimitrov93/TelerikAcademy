namespace Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IEnumerable<T>
    {
        private QueueItem<T> firstElement;
        private QueueItem<T> lastElement;

        public Queue()
        {
            this.firstElement = null;
            this.lastElement = null;
        }

        public void Enqueue(T item)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new QueueItem<T>(item);
                this.lastElement = this.firstElement;
            }
            else
            {
                this.lastElement.Next = new QueueItem<T>(item);
                this.lastElement = this.lastElement.Next;
            }
        }

        public T Dequeue()
        {
            var elementToReturn = this.firstElement.Value;
            this.firstElement = this.firstElement.Next;

            return elementToReturn;
        }

        public T Peek()
        {
            return this.firstElement.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = firstElement;
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
