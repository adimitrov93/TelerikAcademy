namespace AdvancedCollections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private readonly MultiDictionary<K1, KeyKeyValueTuple<K1, K2, V>> byKey1;
        private readonly MultiDictionary<K2, KeyKeyValueTuple<K1, K2, V>> byKey2;
        private readonly MultiDictionary<Tuple<K1, K2>, KeyKeyValueTuple<K1, K2, V>> byDoubleKeys;

        public BiDictionary(bool allowDublicates)
        {
            this.byKey1 = new MultiDictionary<K1, KeyKeyValueTuple<K1, K2, V>>(allowDublicates);
            this.byKey2 = new MultiDictionary<K2, KeyKeyValueTuple<K1, K2, V>>(allowDublicates);
            this.byDoubleKeys = new MultiDictionary<Tuple<K1, K2>, KeyKeyValueTuple<K1, K2, V>>(allowDublicates);
        }

        public IEnumerable<KeyKeyValueTuple<K1, K2, V>> Values
        {
            get
            {
                return this.byDoubleKeys.Values;
            }
        }

        public int Count
        {
            get
            {
                return this.byDoubleKeys.KeyValuePairs.Count;
            }
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            var tuple = new KeyKeyValueTuple<K1, K2, V>(key1, key2, value);
            var key1Key2 = new Tuple<K1, K2>(key1, key2);

            this.byKey1[key1].Add(tuple);
            this.byKey2[key2].Add(tuple);
            this.byDoubleKeys[key1Key2].Add(tuple);
        }

        public IEnumerable<V> GetByFirstKey(K1 key1)
        {
            return this.byKey1[key1].Select(a => a.Value);
        }

        public IEnumerable<V> GetBySecondKey(K2 key2)
        {
            return this.byKey2[key2].Select(a => a.Value);
        }

        public IEnumerable<V> GetByTwoKeys(K1 key1, K2 key2)
        {
            return this.byDoubleKeys[new Tuple<K1, K2>(key1, key2)].Select(a => a.Value);
        }

        public void RemoveByFirstKey(K1 key1)
        {
            var values = this.byKey1[key1];

            foreach (var tuple in values)
            {
                this.byKey2.Remove(tuple.Key2, tuple);
                this.byDoubleKeys.Remove(new Tuple<K1, K2>(tuple.Key1, tuple.Key2), tuple);
            }

            this.byKey1.Remove(key1);
        }

        public void RemoveBySecondKey(K2 key2)
        {
            var values = this.byKey2[key2];

            foreach (var tuple in values)
            {
                this.byKey1.Remove(tuple.Key1, tuple);
                this.byDoubleKeys.Remove(new Tuple<K1, K2>(tuple.Key1, tuple.Key2), tuple);
            }

            this.byKey2.Remove(key2);
        }

        public void RemoveByTwoKeys(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            var values = this.byDoubleKeys[tuple];

            foreach (var value in values)
            {
                this.byKey1.Remove(key1, value);
                this.byKey2.Remove(key2, value);
            }

            this.byDoubleKeys.Remove(tuple);
        }

        public void Clear()
        {
            this.byKey1.Clear();
            this.byKey2.Clear();
            this.byDoubleKeys.Clear();
        }
    }
}
