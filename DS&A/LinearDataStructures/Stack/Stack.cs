namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private const int DEFAULT_INITIAL_ARRAY_SIZE = 4;

        private T[] elements;
        private int currentIndex;

        public Stack()
            : this(DEFAULT_INITIAL_ARRAY_SIZE)
        {
        }

        public Stack(int capacity)
        {
            this.elements = new T[capacity];
            this.currentIndex = 0;
        }

        public void Push(T item)
        {
            if (this.currentIndex == this.elements.Length)
            {
                this.ExpandArray();
            }

            this.elements[this.currentIndex] = item;
            this.currentIndex++;
        }

        public T Pop()
        {
            this.currentIndex--;

            return this.elements[this.currentIndex];
        }

        public T Peek()
        {
            return this.elements[this.currentIndex - 1];
        }

        private void ExpandArray()
        {
            var newArray = new T[this.elements.Length * 2];

            for (int i = 0; i < this.elements.Length; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.currentIndex - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
