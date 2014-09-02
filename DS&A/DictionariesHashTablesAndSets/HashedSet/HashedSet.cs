namespace HashedSet
{
    using System;
    using System.Collections.Generic;

    using HashTable;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public void Add(T value)
        {
            try
            {
                this.hashTable.Add(value.GetHashCode(), value);
            }
            catch (ArgumentException)
            {
            }
        }

        public bool Find(T value)
        {
            try
            {
                if (this.hashTable.Find(value.GetHashCode()).Equals(value))
                {
                    return true;
                }
            }
            catch (KeyNotFoundException)
            {
            }

            return false;
        }

        public void Remove(T value)
        {
            this.hashTable.Remove(value.GetHashCode());
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void IntersectWith(HashedSet<T> other)
        {
            var elementsToRemove = new List<T>();

            foreach (var value in this.hashTable)
            {
                if (!other.Find(value))
                {
                    elementsToRemove.Add(value);
                }
            }

            foreach (var element in elementsToRemove)
            {
                this.Remove(element);
            }
        }

        public void UnionWith(HashedSet<T> other)
        {
            foreach (var item in other)
            {
                this.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.hashTable.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
