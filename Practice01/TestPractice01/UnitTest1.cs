using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice01;

namespace TestPractice01
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSolveA()
        {
            Assert.AreEqual(43, Program.SolveA());
        }

        [TestMethod]
        public void TestSolveB()
        {
            Assert.AreEqual(15, Program.SolveB());
        }

        [TestMethod]
        public void TestInsertionSort()
        {
            int[] actual = new int[] { 36, 87, 345, 21, 76, 34, 77, 45, 2, 75, 23, 57, 12, 34 };
            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Program.InsertionSort(actual);
            Array.Sort(expected);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void TestInsertionSortDescending()
        {
            int[] actual = new int[] { 36, 87, 345, 21, 76, 34, 77, 45, 2, 75, 23, 57, 12, 34 };
            int[] expected = new int[actual.Length];
            actual.CopyTo(expected, 0);
            Program.InsertionSortDescending(actual);
            Array.Sort(expected);
            Array.Reverse(expected);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void TestBinaryAdd()
        {
            bool[] A = new bool[] { true, false, true, false, true, false, true, false };
            bool[] B = new bool[] { true, true, false, false, true, true, false, false };
            bool[] expected = new bool[] { true, false, true, true, true, false, true, true, false };
            bool[] actual = Program.BinaryAdd(A, B);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }
    }
}
