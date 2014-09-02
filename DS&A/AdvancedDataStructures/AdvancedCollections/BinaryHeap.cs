namespace AdvancedCollections
{
    using System;

    using AdvancedCollections.Contracts;

    public class BinaryHeap<T> : IBinaryHeap<T> where T : IComparable<T>
    {
        private const int InitialHeapSize = 8;

        private T[] heap;
        private int firstEmptyIndex;

        public BinaryHeap()
            : this(InitialHeapSize)
        {
        }

        public BinaryHeap(int capacity)
        {
            this.heap = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                return this.heap.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.firstEmptyIndex;
            }
        }

        public void Add(T elementToAdd)
        {
            if (this.firstEmptyIndex == this.Capacity)
            {
                this.DoubleTheCapacity();
            }

            var currentElementIndex = this.firstEmptyIndex;
            this.firstEmptyIndex++;

            this.heap[currentElementIndex] = elementToAdd;
            var parentIndex = (currentElementIndex - 1) / 2;
            while (parentIndex >= 0 && this.heap[currentElementIndex].CompareTo(this.heap[parentIndex]) > 0)
            {
                var parent = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[currentElementIndex];
                this.heap[currentElementIndex] = parent;

                currentElementIndex = parentIndex;
                parentIndex = (currentElementIndex - 1) / 2;
            }
        }

        public T Remove()
        {
            if (this.firstEmptyIndex == 0)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            var root = this.heap[0];
            this.firstEmptyIndex--;

            var currentElementIndex = 0;
            this.heap[currentElementIndex] = this.heap[this.firstEmptyIndex];
            this.heap[this.firstEmptyIndex] = default(T);

            while (true)
            {
                var firstChildIndex = (2 * currentElementIndex) + 1;
                var secondChildIndex = (2 * currentElementIndex) + 2;

                if (firstChildIndex < this.firstEmptyIndex && secondChildIndex < this.firstEmptyIndex)
                {
                    if (this.heap[firstChildIndex].CompareTo(this.heap[currentElementIndex]) > 0 &&
                        this.heap[firstChildIndex].CompareTo(this.heap[secondChildIndex]) >= 0)
                    {
                        this.Swap(firstChildIndex, currentElementIndex);
                        currentElementIndex = firstChildIndex;
                    }
                    else if (this.heap[secondChildIndex].CompareTo(this.heap[currentElementIndex]) > 0 &&
                             this.heap[secondChildIndex].CompareTo(this.heap[firstChildIndex]) > 0)
                    {
                        this.Swap(secondChildIndex, currentElementIndex);
                        currentElementIndex = secondChildIndex;
                    }
                }
                else if (firstChildIndex < this.firstEmptyIndex &&
                         this.heap[firstChildIndex].CompareTo(this.heap[currentElementIndex]) > 0)
                {
                    this.Swap(firstChildIndex, currentElementIndex);
                    currentElementIndex = firstChildIndex;
                }
                else if (secondChildIndex < this.firstEmptyIndex &&
                         this.heap[secondChildIndex].CompareTo(this.heap[currentElementIndex]) > 0)
                {
                    this.Swap(secondChildIndex, currentElementIndex);
                    currentElementIndex = secondChildIndex;
                }
                else
                {
                    break;
                }
            }

            return root;
        }

        public T Peek()
        {
            return this.heap[0];
        }

        private void DoubleTheCapacity()
        {
            var newArray = new T[this.Capacity * 2];

            for (int i = 0; i < this.Capacity; i++)
            {
                newArray[i] = this.heap[i];
            }

            this.heap = newArray;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var firstElement = this.heap[firstIndex];
            this.heap[firstIndex] = this.heap[secondIndex];
            this.heap[secondIndex] = firstElement;
        }
    }
}