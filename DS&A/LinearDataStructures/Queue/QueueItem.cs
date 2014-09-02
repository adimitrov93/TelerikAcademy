namespace Queue
{
    using System;

    public class QueueItem<T>
    {
        public QueueItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; private set; }

        public QueueItem<T> Next { get; set; }
    }
}
