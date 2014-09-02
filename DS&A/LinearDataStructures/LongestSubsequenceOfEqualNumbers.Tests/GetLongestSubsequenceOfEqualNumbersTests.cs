namespace LongestSubsequenceOfEqualNumbers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program to test whether the method works correctly.
    /// </summary>
    [TestClass]
    public class GetLongestSubsequenceOfEqualNumbersTests
    {
        [TestMethod]
        public void TestWithEqualSubsequences()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var result = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

            var expectedCount = 1;
            var actualCount = result.Count;

            var expectedNumber = 1;
            var actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void TestWithLongestSubsequence()
        {
            var numbers = new List<int>() { 1, 2, 2, 3, 4, 5, 6 };
            var result = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

            var expectedCount = 2;
            var actualCount = result.Count;

            var expectedNumber = 2;
            var actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void AreAllNumbersInTheResultListEqual()
        {
            var numbers = new List<int>() { 1, 2, 2, 3, 4, 5, 6 };
            var result = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

            var areAllNumbersEqual = true;

            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i] != result[i + 1])
                {
                    areAllNumbersEqual = false;

                    break;
                }
            }

            Assert.IsTrue(areAllNumbersEqual);
        }

        [TestMethod]
        public void TestWithOnly1Subsequence()
        {
            var numbers = new List<int>() { 3, 3, 3 };
            var result = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

            var expectedCount = 3;
            var actualCount = result.Count;

            var expectedNumber = 3;
            var actualNumber = result[0];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithNullSequence()
        {
            var result = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithEmptySequence()
        {
            var numbers = new List<int>();
            var result = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);
        }
    }
}
