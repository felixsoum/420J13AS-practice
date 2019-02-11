using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice05;
using System.Collections.Generic;

namespace TestPractice05
{
    [TestClass]
    public class TestGradeBook
    {
        [TestMethod]
        public void TestHash()
        {
            Assert.AreEqual(0, GradeBook.Hash(0));
            Assert.AreEqual(1, GradeBook.Hash(1));
            Assert.AreEqual(0, GradeBook.Hash(101));
        }

        [TestMethod]
        public void TestSearchSuccess()
        {
            var gradeBook = new GradeBook();
            gradeBook[1000] = 60;
            gradeBook[1101] = 75;
            gradeBook[1202] = 90;
            Assert.AreEqual(75, gradeBook[1101]);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestSearchFail()
        {
            var gradeBook = new GradeBook();
            gradeBook[1000] = 60;
            gradeBook[1101] = 75;
            gradeBook[1202] = 90;
            double grade = gradeBook[1001];
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestDelete()
        {
            var gradeBook = new GradeBook();
            gradeBook[1000] = 60;
            gradeBook[1101] = 75;
            gradeBook[1202] = 90;
            gradeBook.Delete(1101);
            double grade = gradeBook[1001];
        }

        [TestMethod]
        public void TestCount()
        {
            var gradeBook = new GradeBook();
            Assert.AreEqual(0, gradeBook.Count);
            gradeBook[1000] = 60;
            gradeBook[1101] = 75;
            gradeBook[1202] = 90;
            Assert.AreEqual(3, gradeBook.Count);
            gradeBook.Delete(1101);
            Assert.AreEqual(2, gradeBook.Count);
        }
    }
}
