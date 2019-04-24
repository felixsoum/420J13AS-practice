using System;

namespace Practice06
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> integerTree = new BinarySearchTree<int>();
            integerTree.TreeInsert(2);
            integerTree.TreeInsert(4);
            integerTree.TreeInsert(8);
            integerTree.TreeInsert(6);
            integerTree.TreeInsert(1);
            integerTree.TreeInsert(3);
            integerTree.TreeInsert(7);
            integerTree.TreeInsert(5);
            integerTree.InorderTreeWalk();
            Console.WriteLine();
            int threeSuccessor = integerTree.TreeSuccessor(3);
            Console.WriteLine($"Successor of 3 is {threeSuccessor}.");
            Console.WriteLine();

            BinarySearchTree<string> wordTree = new BinarySearchTree<string>();
            wordTree.TreeInsert("haricot");
            wordTree.TreeInsert("eggplant");
            wordTree.TreeInsert("coconut");
            wordTree.TreeInsert("durian");
            wordTree.TreeInsert("fraise");
            wordTree.TreeInsert("banana");
            wordTree.TreeInsert("apple");
            wordTree.TreeInsert("grapes");
            wordTree.InorderTreeWalk();
            Console.WriteLine();
            string bananaSuccessor = wordTree.TreeSuccessor("banana");
            Console.WriteLine($"Successor of banana is {bananaSuccessor}.");
            Console.WriteLine();
        }
    }
}
