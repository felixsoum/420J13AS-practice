using System;

namespace Practice07
{
    enum Color
    {
        Red,
        Black
    }

    class RedBlackTreeNode<T> where T : IComparable
    {
        public T key;
        public RedBlackTreeNode<T> p;
        public RedBlackTreeNode<T> left;
        public RedBlackTreeNode<T> right;
        public Color color = Color.Red;

        public RedBlackTreeNode(T key)
        {
            this.key = key;
        }
    }
}
