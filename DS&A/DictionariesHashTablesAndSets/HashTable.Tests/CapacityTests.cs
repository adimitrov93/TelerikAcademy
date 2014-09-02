namespace HashTable.Tests
{
    using System;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CapacityTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void InitializeCapacityMustBe16()
        {
            int expected = 16;
            int actual = this.hashTable.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CapacityAfterResizingTheTableMustBe32()
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
