using System;

namespace Practice06
{
    class BinarySearchTree<T> where T : IComparable
    {
        BinarySearchTreeNode<T> root;

        public void InorderTreeWalk()
        {
            InorderTreeWalk(root);
        }

        void InorderTreeWalk(BinarySearchTreeNode<T> x)
        {
            if (x != null)
            {
                InorderTreeWalk(x.left);
                Console.Write($"{x.key},");
                InorderTreeWalk(x.right);
            }
        }

        public BinarySearchTreeNode<T> TreeSearch(T k)
        {
            return TreeSearch(root, k);
        }

        BinarySearchTreeNode<T> TreeSearch(BinarySearchTreeNode<T> x, T k)
        {
            if (x == null || k.CompareTo(x.key) == 0)
            {
                return x;
            }
            if (k.CompareTo(x.key) < 0)
            {
                return TreeSearch(x.left, k);
            }
            else
            {
                return TreeSearch(x.right, k);
            }
        }

        BinarySearchTreeNode<T> TreeMinimum(BinarySearchTreeNode<T> x)
        {
            while (x.left != null)
            {
                x = x.left;
            }
            return x;
        }

        BinarySearchTreeNode<T> TreeSuccessor(BinarySearchTreeNode<T> x)
        {
            if (x.right != null)
            {
                return TreeMinimum(x.right);
            }
            var y = x.p;
            while (y != null && x == y.right)
            {
                x = y;
                y = y.p;
            }
            return y;
        }

        public void TreeInsert(T k)
        {
            BinarySearchTreeNode<T> z = new BinarySearchTreeNode<T>(k);
            BinarySearchTreeNode<T> y = null;
            BinarySearchTreeNode<T> x = root;

            while (x != null)
            {
                y = x;
                if (z.key.CompareTo(x.key) < 0)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            z.p = y;
            if (y == null)
            {
                root = z; // tree T was empty
            }
            else if (z.key.CompareTo(y.key) < 0)
            {
                y.left = z;
            }
            else
            {
                y.right = z;
            }
        }
    }
}
