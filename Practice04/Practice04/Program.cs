/*
 * felixsoum 
 * 
 * 420-J13-AS
 * 
 * Practice stack, queue and linked list.
 */

using System;

namespace Practice04
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            Console.WriteLine($"First {myStack.Pop()}, then {myStack.Pop()}, finally {myStack.Pop()}.");
        }
    }
}
