namespace Practice09
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new ListGraph('s', 't', 'x', 'y', 'z');
            graph.AddEdge('s', 't', 10);
            graph.AddEdge('s', 'y', 5);
            graph.AddEdge('t', 'x', 1);
            graph.AddEdge('t', 'y', 2);
            graph.AddEdge('x', 'z', 4);
            graph.AddEdge('y', 't', 3);
            graph.AddEdge('y', 'x', 9);
            graph.AddEdge('y', 'z', 2);
            graph.AddEdge('z', 's', 7);
            graph.AddEdge('z', 'x', 6);

            graph.Dijkstra('s');
            graph.PrintPath('s', 'x'); // ->s->y->t->x
            graph.PrintPath('s', 'z'); // ->s->y->z
        }
    }
}
