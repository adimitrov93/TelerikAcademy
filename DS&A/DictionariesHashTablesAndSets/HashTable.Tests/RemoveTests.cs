namespace HashTable.Tests
{
    using System;
    using System.Collections.Generic;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveTests
    {
        private HashTable<string, int> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            this.hashTable = new HashTable<string, int>();
        }

        [TestMethod]
        public void RemoveExistingKeyMustWorkCorrectly()
        {
            this.hashTable.Add("a", 1);
            this.hashTable.Remove("a");

            int expected = 0;
            int actual = this.hashTable.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveNonExistingKeyMustThrowAnException()
        {
            this.hashTable.Remove("a");
        }
    }
}
