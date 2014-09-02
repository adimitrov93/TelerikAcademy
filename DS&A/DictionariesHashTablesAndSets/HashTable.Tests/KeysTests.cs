namespace HashTable.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KeysTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void InitialCountOfKeysMustBe0()
        {
            int expected = 0;
            int actual = this.hashTable.Keys.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOfKeysAfterAddingSomeFilesMustBeCorrect()
        {
            this.hashTable.Add("a", 1);
            this.hashTable.Add("b", 2);
            this.hashTable.Add("c", 3);
            this.hashTable.Add("d", 4);
            this.hashTable.Add("e", 5);

            int expected = 5;
            int actual = this.hashTable.Keys.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOfKeysAfterAddingSomeFilesAndSomeDeletedMustBeCorrect()
        {
            this.hashTable.Add("a", 1);
            this.hashTable.Add("b", 2);
            this.hashTable.Add("c", 3);
            this.hashTable.Add("d", 4);
            this.hashTable.Add("e", 5);

            this.hashTable.Remove("a");
            this.hashTable.Remove("b");

            int expected = 3;
            int actual = this.hashTable.Keys.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOfKeysAfterRehashingMustBeCorrect()
        {
            this.hashTable.Add("a", 1);
            this.hashTable.Add("b", 2);
            this.hashTable.Add("c", 3);
            this.hashTable.Add("d", 4);
            this.hashTable.Add("e", 5);
            this.hashTable.Add("f", 6);
            this.hashTable.Add("g", 7);
            this.hashTable.Add("h", 8);
            this.hashTable.Add("i", 9);
            this.hashTable.Add("j", 10);
            this.hashTable.Add("k", 11);
            this.hashTable.Add("l", 12);

            int expected = 12;
            int actual = this.hashTable.Keys.Count();

            Assert.AreEqual(expected, actual);
        }
    }
}
