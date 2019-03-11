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
            System.Console.WriteLine();

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
            System.Console.WriteLine();
        }
    }
}
