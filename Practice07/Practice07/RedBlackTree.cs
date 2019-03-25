using System;
using System.Collections.Generic;

namespace Practice07
{
    class RedBlackTree<T> where T : IComparable
    {
        RedBlackTreeNode<T> root;
        readonly RedBlackTreeNode<T> nil = new RedBlackTreeNode<T>(default(T))
        {
            color = Color.Black
        };

        public RedBlackTree()
        {
            root = nil;
        }

        public void BreadthFirstPrint()
        {
            var printQueue = new Queue<RedBlackTreeNode<T>>();
            printQueue.Enqueue(root);
            while (printQueue.Count > 0)
            {
                var node = printQueue.Dequeue();
                if (node.left != nil)
                {
                    printQueue.Enqueue(node.left);
                }
                if (node.right != nil)
                {
                    printQueue.Enqueue(node.right);
                }
                Console.WriteLine(PrintNode(node));
            }
        }

        public string PrintKey(RedBlackTreeNode<T> x)
        {
            return x == nil ? "nil" : x.key.ToString();
        }

        public string PrintNode(RedBlackTreeNode<T> x)
        {
            return $"key:{x.key}, p:{PrintKey(x.p)}, left:{PrintKey(x.left)}, right:{PrintKey(x.right)}, color:{x.color}";
        }

        public void LeftRotate(RedBlackTreeNode<T> x)
        {
            var y = x.right;
            x.right = y.left;
            if (y.left != nil)
            {
                y.left.p = x;
            }
            y.p = x.p;
            if (x.p == nil)
            {
                root = y;
            }
            else if (x == x.p.left)
            {
                x.p.left = y;
            }
            else
            {
                x.p.right = y;
            }
            y.left = x;
            x.p = y;
        }

        public void RightRotate(RedBlackTreeNode<T> x)
        {
            var y = x.left;
            x.left = y.right;
            if (y.right != nil)
            {
                y.right.p = x;
            }
            y.p = x.p;
            if (x.p == nil)
            {
                root = y;
            }
            else if (x == x.p.right)
            {
                x.p.right= y;
            }
            else
            {
                x.p.left = y;
            }
            y.right= x;
            x.p = y;
        }

        public void InorderTreeWalk()
        {
            InorderTreeWalk(root);
        }

        void InorderTreeWalk(RedBlackTreeNode<T> x)
        {
            if (x != nil)
            {
                InorderTreeWalk(x.left);
                Console.Write($"{x.key},");
                InorderTreeWalk(x.right);
            }
        }

        public RedBlackTreeNode<T> Search(T k)
        {
            return Search(root, k);
        }

        RedBlackTreeNode<T> Search(RedBlackTreeNode<T> x, T k)
        {
            if (x == null || k.CompareTo(x.key) == 0)
            {
                return x;
            }
            if (k.CompareTo(x.key) < 0)
            {
                return Search(x.left, k);
            }
            else
            {
                return Search(x.right, k);
            }
        }

        RedBlackTreeNode<T> Minimum(RedBlackTreeNode<T> x)
        {
            while (x.left != nil)
            {
                x = x.left;
            }
            return x;
        }

        RedBlackTreeNode<T> Successor(RedBlackTreeNode<T> x)
        {
            if (x.right != nil)
            {
                return Minimum(x.right);
            }
            var y = x.p;
            while (y != nil && x == y.right)
            {
                x = y;
                y = y.p;
            }
            return y;
        }

        public void Insert(T k)
        {
            var z = new RedBlackTreeNode<T>(k);
            var y = nil;
            var x = root;

            while (x != nil)
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
            if (y == nil)
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
            z.left = nil;
            z.right = nil;
            InsertFixup(z);
        }

        void InsertFixup(RedBlackTreeNode<T> z)
        {
            while (z.p.color == Color.Red)
            {
                if (z.p == z.p.p.left)
                {
                    var y = z.p.p.right;
                    if (y.color == Color.Red)
                    {
                        z.p.color = Color.Black; // case 1
                        y.color = Color.Black; // case 1
                        z.p.p.color = Color.Red; // case 1
                        z = z.p.p; // case 1
                    }
                    else
                    {
                        if (z == z.p.right)
                        {
                            z = z.p; // case 2
                            LeftRotate(z); // case 2
                        }
                        z.p.color = Color.Black; // case 3
                        z.p.p.color = Color.Red; // case 3
                        RightRotate(z.p.p); // case 3
                    }
                }
                else
                {
                    var y = z.p.p.left;
                    if (y.color == Color.Red)
                    {
                        z.p.color = Color.Black; // case 1
                        y.color = Color.Black; // case 1
                        z.p.p.color = Color.Red; // case 1
                        z = z.p.p; // case 1
                    }
                    else
                    {
                        if (z == z.p.left)
                        {
                            z = z.p; // case 2
                            RightRotate(z); // case 2
                        }
                        z.p.color = Color.Black; // case 3
                        z.p.p.color = Color.Red; // case 3
                        LeftRotate(z.p.p); // case 3
                    }
                }
            }
            root.color = Color.Black;
        }
    }
}
