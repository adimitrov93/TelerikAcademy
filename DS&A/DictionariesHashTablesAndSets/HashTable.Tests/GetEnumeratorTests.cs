namespace HashTable.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetEnumeratorTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void ForEachOverTheTableMustReturnAllAddedValues()
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

            var returnedFromForEach = new List<int>();
            foreach (var item in this.hashTable)
            {
                returnedFromForEach.Add(item);
            }

            int expected = 12;
            int actual = returnedFromForEach.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
