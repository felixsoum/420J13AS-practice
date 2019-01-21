using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice02;

namespace TestPractice02
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFibonacci()
        {
            Assert.AreEqual(55, Program.Fibonacci(10));
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            int[] binarySearchInput = new int[] { 1, 6, 7, 10, 12, 14, 22, 26 };
            int searchValue = 12;
            int resultIndex = Program.BinarySearch(binarySearchInput, searchValue, 0, binarySearchInput.Length - 1);
            Assert.AreEqual(4, resultIndex);
        }

        [TestMethod]
        public void TestMergeOdd()
        {
            int[] actual = new int[] { 2, 4, 8, 9, 11, 25, 34, 57, 3, 5, 7, 15, 26, 33, 44 };

            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);

            Program.Merge(actual, 0, (actual.Length - 1) / 2, actual.Length - 1);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void TestMergeEven()
        {
            int[] actual = new int[] { 2, 4, 8, 9, 11, 25, 34, 3, 5, 7, 15, 26, 33, 44 };

            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);

            Program.Merge(actual, 0, (actual.Length - 1)/ 2, actual.Length - 1);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void TestMergeSortOdd()
        {
            int[] actual = new int[] {64, 14, 47, 32, 75, 34, 75, 34, 56, 25, 45, 34, 67, 45, 67 };

            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);

            Program.MergeSort(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void TestMergeSortEven()
        {
            int[] actual = new int[] { 64, 14, 47, 32, 75, 34, 75, 34, 56, 25, 45, 34, 67, 45 };

            int[] copy = new int[actual.Length];
            actual.CopyTo(copy, 0);
            Array.Sort(copy);

            Program.MergeSort(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, copy));
        }

        [TestMethod]
        public void TestMaxHeapify()
        {
            int[] actual = new int[] { 27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0 };
            int[] expected = new int[] { 27, 17, 10, 16, 13, 9, 1, 5, 7, 12, 4, 8, 3, 0 };
            Program.MaxHeapify(actual, 3);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void BuildMaxHeap()
        {
            int[] actual = new int[] { 5, 3, 17, 10, 84, 19, 6, 22, 0 };
            int[] expected = new int[] { 84, 22, 19, 10, 3, 17, 6, 5, 0 };
            Program.BuildMaxHeap(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }

        [TestMethod]
        public void HeapSort()
        {
            int[] actual = new int[] { 64, 14, 47, 32, 75, 34, 75, 34, 56, 25, 45, 34, 67, 45, 67 };

            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Array.Sort(expected);

            Program.HeapSort(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(actual, expected));
        }
    }
}
