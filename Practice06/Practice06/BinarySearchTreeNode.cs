using System;

namespace Practice06
{
    class BinarySearchTreeNode<T> where T : IComparable
    {
        public T key;
        public BinarySearchTreeNode<T> p;
        public BinarySearchTreeNode<T> left;
        public BinarySearchTreeNode<T> right;

        public BinarySearchTreeNode(T key)
        {
            this.key = key;
        }
    }
}
