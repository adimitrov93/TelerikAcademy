namespace AdvancedCollections
{
    using AdvancedCollections.Contracts;

    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly IBinaryHeap<IPriorityQueueNode<T>> queue;

        public PriorityQueue()
        {
            this.queue = new BinaryHeap<IPriorityQueueNode<T>>();
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public void Enqueue(T value, int priority)
        {
            this.queue.Add(new PriorityQueueNode<T>(value, priority));
        }

        public T Dequeue()
        {
            return this.queue.Remove().Value;
        }

        public T Peek()
        {
            return this.queue.Peek().Value;
        }
    }
}
