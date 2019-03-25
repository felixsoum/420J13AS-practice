namespace Practice07
{
    class Program
    {
        static void Main(string[] args)
        {
            var redBlackTree = new RedBlackTree<int>();
            redBlackTree.Insert(7);
            redBlackTree.Insert(6);
            redBlackTree.Insert(5);
            redBlackTree.Insert(4);
            redBlackTree.Insert(3);
            redBlackTree.Insert(2);
            redBlackTree.Insert(1);
            redBlackTree.BreadthFirstPrint();
            redBlackTree.InorderTreeWalk();
        }
    }
}
