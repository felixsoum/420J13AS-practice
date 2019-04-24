using System;

namespace Practice09
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBreadthFirstSearch();
            TestDepthFirstSearch();
            //TestBellmanFord();
            TestDijkstra();
        }

        static void TestBreadthFirstSearch()
        {
            Console.WriteLine("Breadth First Search:");
            Graph graph = new ListGraph('1', '2', '3', '4', '5', '6');
            //Graph graph = new MatrixGraph('1', '2', '3', '4', '5', '6');
            graph.AddEdge('1', '2');
            graph.AddEdge('1', '4');
            graph.AddEdge('2', '5');
            graph.AddEdge('3', '5');
            graph.AddEdge('3', '6');
            graph.AddEdge('4', '2');
            graph.AddEdge('5', '4');
            graph.AddEdge('6', '6');

            graph.BreadthFirstSearch('3');
            graph.PrintPath('3', '2'); // ->3->5->4->2
            graph.PrintPath('3', '1'); // no path from 3 to 1 exists
            Console.WriteLine();
        }

        static void TestDepthFirstSearch()
        {
            Console.WriteLine("Depth First Search:");
            //Graph graph = new ListGraph('u', 'v', 'w', 'x', 'y', 'z');
            Graph graph = new MatrixGraph('u', 'v', 'w', 'x', 'y', 'z');
            graph.AddEdge('u', 'v');
            graph.AddEdge('u', 'x');
            graph.AddEdge('v', 'y');
            graph.AddEdge('w', 'y');
            graph.AddEdge('w', 'z');
            graph.AddEdge('x', 'v');
            graph.AddEdge('y', 'x');
            graph.AddEdge('z', 'z');

            graph.DepthFirstSearch();
            graph.PrintTimestamps();
            // Vertex u: 1/8
            // Vertex v: 2/7
            // Vertex w: 9/12
            // Vertex x: 4/5
            // Vertex y: 3/6
            // Vertex z: 10/11
            Console.WriteLine();
        }

        static void TestBellmanFord()
        {
            Console.WriteLine("Bellman-Ford Algorithm:");
            //Graph graph = new ListGraph('s', 't', 'x', 'y', 'z');
            Graph graph = new MatrixGraph('s', 't', 'x', 'y', 'z');
            graph.AddEdge('s', 't', 6);
            graph.AddEdge('s', 'y', 7);
            graph.AddEdge('t', 'x', 5);
            graph.AddEdge('t', 'y', 8);
            graph.AddEdge('t', 'z', -4);
            graph.AddEdge('x', 't', -2);
            graph.AddEdge('y', 'x', -3);
            graph.AddEdge('y', 'z', 9);
            graph.AddEdge('z', 's', 2);
            graph.AddEdge('z', 'x', 7);

            Console.WriteLine(graph.BellmanFord('s')); // True
            graph.PrintPath('s', 'z'); // ->s->y->t->x->z

            graph.AddEdge('z', 'y', -9999);
            Console.WriteLine(graph.BellmanFord('s')); // False
            Console.WriteLine();
        }

        static void TestDijkstra()
        {
            Console.WriteLine("Dijkstra's Algorithm:");
            Graph graph = new ListGraph('s', 't', 'x', 'y', 'z');
            //Graph graph = new MatrixGraph('s', 't', 'x', 'y', 'z');
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
            Console.WriteLine();
        }
    }
}
