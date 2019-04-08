using System;
using System.Collections.Generic;

namespace Practice09
{
    class ListGraph
    {
        List<Vertex> vertices = new List<Vertex>();
        List<AdjacentVertex>[] adjacencyList;
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
            adjacencyList = new List<AdjacentVertex>[maxChar - minChar + 1];
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                adjacencyList[i] = new List<AdjacentVertex>();
            }
        }

        public void AddEdge(char sourceKey, char destinationKey, int weight = 1)
        {
            Vertex destination = vertices.Find(v => v.key == destinationKey);
            adjacencyList[sourceKey - minChar].Add(new AdjacentVertex(destination, weight));
        }

        void InitializeSingleSource(Vertex s)
        {
            foreach (var v in vertices)
            {
                v.distance = int.MaxValue;
                v.predecessor = null;
            }
            s.distance = 0;
        }

        void Relax(Vertex u, AdjacentVertex adjV)
        {
            Vertex v = adjV.vertex;
            int weight = adjV.weight;

            if (v.distance > u.distance + weight)
            {
                v.distance = u.distance + weight;
                v.predecessor = u;
            }
        }

        public void Dijkstra(char sourceKey)
        {
            Vertex s = vertices.Find(v => v.key == sourceKey);
            InitializeSingleSource(s);

            var minQueue = new PriorityQueue<Vertex>();
            minQueue.AddRange(vertices);

            while (minQueue.Count > 0)
            {
                Vertex u = minQueue.ExtractMin();

                foreach (AdjacentVertex v in adjacencyList[u.key - minChar])
                {
                    Relax(u, v);
                }
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
