using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice04;

namespace Practice04Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMyStack()
        {
            MyStack<int> myStack = new MyStack<int>();

            Assert.IsTrue(myStack.StackEmpty());

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            Assert.IsFalse(myStack.StackEmpty());

            Assert.AreEqual(myStack.Pop(), 3);
            Assert.AreEqual(myStack.Pop(), 2);
            Assert.AreEqual(myStack.Pop(), 1);

            Assert.IsTrue(myStack.StackEmpty());
        }
    }
}
