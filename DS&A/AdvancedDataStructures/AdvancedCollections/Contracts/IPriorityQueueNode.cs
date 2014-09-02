namespace AdvancedCollections.Contracts
{
    using System;

    public interface IPriorityQueueNode<T> : IComparable<IPriorityQueueNode<T>>
    {
        T Value { get; }

        int Priority { get; }
    }
}
