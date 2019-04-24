using System;
using System.Collections.Generic;

namespace Practice09
{
    class ListGraph : Graph
    {
        readonly List<AdjacentVertex>[] adjacencyList;

        public ListGraph(params char[] vertexKeys) : base(vertexKeys)
        {
            adjacencyList = new List<AdjacentVertex>[maxChar - minChar + 1];
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                adjacencyList[i] = new List<AdjacentVertex>();
            }
        }

        public override void AddEdge(char sourceKey, char destinationKey, int weight = 1)
        {
            Vertex destination = vertices.Find(v => v.key == destinationKey);
            adjacencyList[sourceKey - minChar].Add(new AdjacentVertex(destination, weight));
        }

        public override void BreadthFirstSearch(char sourceKey)
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
                foreach (AdjacentVertex neighbor in adjacencyList[u.key - minChar])
                {
                    var v = neighbor.vertex;
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

        public override void DepthFirstSearch()
        {
            throw new NotImplementedException();
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

        public override bool BellmanFord(char sourceKey)
        {
            throw new NotImplementedException();
        }

        public override void Dijkstra(char sourceKey)
        {
            InitializeSingleSource(sourceKey);

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
    }
}
