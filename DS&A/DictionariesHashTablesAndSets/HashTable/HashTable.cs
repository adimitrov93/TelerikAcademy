namespace HashTable
{
    using System;
    using System.Collections.Generic;

    public class HashTable<K, V> : IEnumerable<V> where K : IEquatable<K>
    {
        private const int InitialCapacity = 16;

        private LinkedList<KeyValuePair<K, V>>[] items;
        private LinkedList<K> keys;

        public HashTable()
        {
            this.items = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
            this.keys = new LinkedList<K>();
            this.Count = 0;
        }

        public int Capacity
        {
            get
            {
                return this.items.Length;
            }
        }

        public int Count { get; private set; }

        public IEnumerable<K> Keys
        {
            get
            {
                return new LinkedList<K>(this.keys);
            }
        }

        public void Add(K key, V value)
        {
            BaseAdd(key, value);
            this.Count++;
            this.keys.AddLast(key);

            if (Count >= this.Capacity * 0.75)
            {
                var cachedItems = this.Resize();
                this.Rehash(cachedItems);
            }
        }

        public V Find(K key)
        {
            var hash = this.GetHashCodeByKey(key);

            if (this.IsInitialized(this.items[hash]))
            {
                foreach (var item in this.items[hash])
                {
                    if (key.Equals(item.Key))
                    {
                        return item.Value;
                    }
                }
            }

            throw new KeyNotFoundException();
        }

        public void Remove(K key)
        {
            var hash = this.GetHashCodeByKey(key);

            if (this.IsInitialized(this.items[hash]))
            {
                bool isFound = false;
                KeyValuePair<K, V> itemToRemove = default(KeyValuePair<K, V>);

                foreach (var item in this.items[hash])
                {
                    if (key.Equals(item.Key))
                    {
                        isFound = true;
                        itemToRemove = item;

                        break;
                    }
                }

                if (isFound)
                {
                    this.items[hash].Remove(itemToRemove);
                    this.keys.Remove(itemToRemove.Key);
                    this.Count--;

                    return;
                }
            }

            throw new KeyNotFoundException();
        }

        public void Clear()
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                this.items[i] = null;
            }

            this.keys.Clear();
            this.Count = 0;
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
        }

        public IEnumerator<V> GetEnumerator()
        {
            foreach (var list in this.items)
            {
                if (IsInitialized(list))
                {
                    foreach (var item in list)
                    {
                        yield return item.Value;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void BaseAdd(K key, V value)
        {
            var hash = this.GetHashCodeByKey(key);

            if (!this.IsInitialized(this.items[hash]))
            {
                this.items[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            foreach (var item in this.items[hash])
            {
                if (key.Equals(item.Key))
                {
                    throw new ArgumentException("Key already exists", "key");
                }
            }

            this.items[hash].AddLast(new KeyValuePair<K, V>(key, value));
        }

        private int GetHashCodeByKey(K key)
        {
            int hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);

            return hash;
        }

        private bool IsInitialized(LinkedList<KeyValuePair<K, V>> list)
        {
            if (list != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerable<LinkedList<KeyValuePair<K, V>>> Resize()
        {
            var cachedItems = this.items;
            this.items = new LinkedList<KeyValuePair<K, V>>[this.Capacity * 2];

            return cachedItems;
        }

        private void Rehash(IEnumerable<LinkedList<KeyValuePair<K, V>>> cachedItems)
        {
            foreach (var list in cachedItems)
            {
                if (this.IsInitialized(list))
                {
                    foreach (var item in list)
                    {
                        this.BaseAdd(item.Key, item.Value);
                    }
                }
            }
        }
    }
}
