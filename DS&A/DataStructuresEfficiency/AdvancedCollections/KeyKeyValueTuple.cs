namespace AdvancedCollections
{
    public class KeyKeyValueTuple<K1, K2, V>
    {
        public KeyKeyValueTuple(K1 key1, K2 key2, V value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }

        public K1 Key1 { get; set; }

        public K2 Key2 { get; set; }

        public V Value { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}]", this.Key1, this.Key2, this.Value);
        }
    }
}
