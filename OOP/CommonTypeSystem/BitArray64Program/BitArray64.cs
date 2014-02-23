namespace BitArray64Program
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        // Constants
        private const int NumberLenght = 64;

        // Constructors
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        // Properties
        public ulong Number { get; private set; }

        // Methods
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 64 - 1; i >= 0; i--)
            {
                yield return (int)((this.Number >> i) & 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var secondArray = obj as BitArray64;

            if (secondArray != null)
            {
                for (int i = 0; i < NumberLenght; i++)
                {
                    if (((this.Number >> i) & 1) != ((secondArray.Number >> i) & 1))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;

                result *= (23 + this.Number.GetHashCode());

                return result;
            }
        }

        public int this[int index]
        {
            get
            {
                if (ValidateIndexes(index))
                {
                    return (int)(this.Number >> (NumberLenght - index - 1) & 1);
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("The index must be between 0 and {0}", NumberLenght - 1));
                }
            }
            set
            {
                if (ValidateIndexes(index))
                {
                    if (value == 0)
                    {
                        ulong mask = ~(1UL << (NumberLenght - index - 1));

                        this.Number &= mask;
                    }
                    else if (value == 1)
                    {
                        ulong mask = 1UL << (NumberLenght - index - 1);

                        this.Number |= mask;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("value", "The value must be 1 or 0");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("The index must be between 0 and {0}", NumberLenght - 1));
                }
            }
        }
  
        private bool ValidateIndexes(int index)
        {
            if (index >= 0 || index < NumberLenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Operators
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
    }
}
