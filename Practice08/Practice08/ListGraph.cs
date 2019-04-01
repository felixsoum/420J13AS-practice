using System;
using System.Collections.Generic;

namespace Practice08
{
    class ListGraph
    {
        List<Vertex> vertices = new List<Vertex>();
        List<Vertex>[] adjacencyList;
        readonly int minChar = int.MaxValue;
        readonly int maxChar = int.MinValue;

        public ListGraph(params char[] vertexKeys)
        {
            foreach (char k in vertexKeys)
            {
                vertices.Add(new Vertex(k));

                if (k < minChar)
                {
                    minChar = k;
                }
                if (k > maxChar)
                {
                    maxChar = k;
                }
            }
            adjacencyList = new List<Vertex>[maxChar - minChar + 1];
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                adjacencyList[i] = new List<Vertex>();
            }
        }

        public void AddEdge(char sourceKey, char destinationKey)
        {
            Vertex destination = vertices.Find(v => v.key == destinationKey);
            adjacencyList[sourceKey - minChar].Add(destination);
        }

        public void BreadthFirstSearch(char sourceKey)
        {
            Vertex s = vertices.Find(v => v.key == sourceKey);
            foreach (var u in vertices)
            {
                if (u == s)
                {
                    continue;
                }

                u.color = Color.White;
                u.distance = int.MaxValue;
                u.predecessor = null;
            }
            s.color = Color.Grey;
            s.distance = 0;
            s.predecessor = null;
            var queue = new Queue<Vertex>();
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                Vertex u = queue.Dequeue();
                foreach (var v in adjacencyList[u.key - minChar])
                {
                    if (v.color == Color.White)
                    {
                        v.color = Color.Grey;
                        v.distance = u.distance + 1;
                        v.predecessor = u;
                        queue.Enqueue(v);
                    }
                }
                u.color = Color.Black;
            }
        }

        public void PrintPath(char sourceKey, char destinationKey)
        {
            Vertex s = vertices.Find(v1 => v1.key == sourceKey);
            Vertex v = vertices.Find(v2 => v2.key == destinationKey);
            PrintPath(s, v);
            Console.WriteLine();
        }

        void PrintPath(Vertex s, Vertex v)
        {
            if (v == s)
            {
                Console.Write($"->{s}");
            }
            else if (v.predecessor == null)
            {
                Console.WriteLine($"no path from {s} to {v} exists");
            }
            else
            {
                PrintPath(s, v.predecessor);
                Console.Write($"->{v}");
            }
        }
    }
}
