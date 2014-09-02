namespace HashTable.Tests
{
    using System;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void AddMustWorkProperly()
        {
            this.hashTable.Add("a", 1);

            int expected = 1;
            int actual = this.hashTable.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingSameKeyTwiceMustThrowAndException()
        {
            this.hashTable.Add("a", 1);
            this.hashTable.Add("a", 1);
        }

        [TestMethod]
        public void AfterAdding12ElementsTheTableMustResizeTwice()
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

            int expected = 32;
            int actual = this.hashTable.Capacity;

            Assert.AreEqual(expected, actual);
        }
    }
}
