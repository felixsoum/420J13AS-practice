/*
 * felixsoum 
 * 
 * 420-J13-AS
 * 
 * Practice random, quicksort and counting sort.
 */

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice03;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQuicksort()
        {
            int[] actual = new int[] { 55, 57, 46, 86, 33, 75, 45, 47, 25, 57, 55, 46, 23 };
            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);
            Program.Quicksort(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void TestQuicksortDescending()
        {
            int[] actual = new int[] { 55, 57, 46, 86, 33, 75, 45, 47, 25, 57, 55, 46, 23 };
            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);
            Array.Reverse(expected);
            Program.QuicksortDescending(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void TestRandomizedQuicksort()
        {
            for (int i = 0; i < 100; i++)
            {
                int[] actual = new int[] { 55, 57, 46, 86, 33, 75, 45, 47, 25, 57, 55, 46, 23 };
                int[] expected = new int[actual.Length];
                actual.CopyTo(expected, 0);
                Array.Sort(expected);
                Program.RandomizedQuicksort(actual);
                Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
            }
        }

        [TestMethod]
        public void TestCountingSort()
        {
            int[] actual = new int[] { 55, 57, 46, 86, 33, 75, 45, 47, 25, 57, 55, 46, 23 };
            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);
            int[] B = new int[actual.Length];
            Program.CountingSort(actual, B, new int[100]);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, B));
        }
    }
}
