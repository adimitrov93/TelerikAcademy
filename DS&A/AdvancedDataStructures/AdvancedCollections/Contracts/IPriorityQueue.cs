namespace AdvancedCollections.Contracts
{
    public interface IPriorityQueue<T>
    {
        int Count { get; }

        void Enqueue(T value, int priority);

        T Dequeue();

        T Peek();
    }
}
