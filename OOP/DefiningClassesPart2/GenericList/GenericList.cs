namespace GenericList
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        // Fields
        private T[] internalArray;

        // Constructors
        public GenericList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("The size cannot be negative or zero");
            }

            internalArray = new T[size];
            Count = 0;
        }

        // Properties
        public int Count { get; private set; }

        // Indexers
        public T this[int index]
        {
            get
            {
                return internalArray[index];
            }
            set
            {
                internalArray[index] = value;
            }
        }

        // Methods
        public void Add(T newItem)
        {
            checkCapacity();

            internalArray[Count] = newItem;
            Count++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(string.Format("Index must be between 0 and {0}", Count - 1));
            }

            return internalArray[index];
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(string.Format("Index must be between 0 and {0}", Count - 1));
            }

            for (int i = index; i < Count; i++)
            {
                internalArray[i] = internalArray[i + 1];
            }

            Count--;
        }

        public void InsertAt(T newItem, int index)
        {
            checkCapacity();

            for (int i = Count - 1; i >= index; i--)
            {
                internalArray[i + 1] = internalArray[i];
            }

            internalArray[index] = newItem;

            Count++;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(internalArray, 0, Count);
                Count = 0;
            }
        }

        public int IndexOf(T searched)
        {
            for (int i = 0; i < Count; i++)
            {
                if (internalArray[i].Equals(searched))
                {
                    return i;
                }
            }

            return -1;      // If there is no such element in that list
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                output.Append(internalArray[i].ToString());

                if (i < Count - 1)
                {
                    output.Append(", ");
                }
            }

            return output.ToString();
        }

        private void checkCapacity()
        {
            if (Count == internalArray.Length)
            {
                T[] newInternalArray = new T[internalArray.Length * 2];

                for (int i = 0; i < internalArray.Length; i++)
                {
                    newInternalArray[i] = internalArray[i];
                }

                internalArray = newInternalArray;
            }
        }

        public T Min()
        {
            T min = internalArray[0];

            for (int i = 1; i < Count; i++)
            {
                if (internalArray[i].CompareTo(min) < 0)
                {
                    min = internalArray[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = internalArray[0];

            for (int i = 1; i < Count; i++)
            {
                if (internalArray[i].CompareTo(max) > 0)
                {
                    max = internalArray[i];
                }
            }

            return max;
        }
    }
}
