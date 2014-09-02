namespace AdvancedCollections.Contracts
{
    public interface IBinaryHeap<T>
    {
        int Count { get; }

        void Add(T value);

        T Remove();

        T Peek();
    }
}
