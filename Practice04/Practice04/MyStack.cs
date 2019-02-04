using System;

namespace Practice04
{
    public class MyStack<T>
    {
        int top = -1;
        readonly T[] S = new T[64];

        public bool StackEmpty()
        {
            return top == -1;
        }

        public void Push(T x)
        {
            S[++top] = x;
        }

        public T Pop()
        {
            if (StackEmpty())
            {
                throw new Exception("underflow");
            }
            return S[top--];
        }
    }
}
