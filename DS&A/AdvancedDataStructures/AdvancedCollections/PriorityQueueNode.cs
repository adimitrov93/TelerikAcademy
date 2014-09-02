namespace AdvancedCollections
{
    using System;

    using AdvancedCollections.Contracts;

    internal class PriorityQueueNode<T> : IPriorityQueueNode<T>
    {
        private T value;
        private int priority;

        public PriorityQueueNode(T value, int priority)
        {
            this.Value = value;
            this.Priority = priority;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                this.value = value;
            }
        }

        public int Priority
        {
            get
            {
                return this.priority;
            }

            private set
            {
                this.priority = value;
            }
        }

        public int CompareTo(IPriorityQueueNode<T> other)
        {
            return this.Priority.CompareTo(other.Priority);
        }
    }
}
