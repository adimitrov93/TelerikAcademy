namespace LinkedList
{
    using System;

    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; private set; }

        public ListItem<T> Next { get; set; }
    }
}
