namespace HashTable.Tests
{
    using System;
    using System.Collections.Generic;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void SearchingExistingKeyMustReturnTheCorrectValue()
        {
            this.hashTable.Add("a", 1);

            int expected = 1;
            int actual = this.hashTable.Find("a");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void SearchingNonExistingKeyMustThrowException()
        {
            this.hashTable.Find("a");
        }

        [TestMethod]
        public void SearchingWithTheIndexerMustReturnTheCorrectValue()
        {
            this.hashTable.Add("a", 1);

            int expected = 1;
            int actual = this.hashTable["a"];

            Assert.AreEqual(expected, actual);
        }
    }
}
