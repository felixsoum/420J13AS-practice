using System;

namespace Practice09
{
    class MatrixGraph : Graph
    {
        readonly int[,] adjacencyMatrix;

        public MatrixGraph(params char[] vertexKeys) : base(vertexKeys)
        {
            int n = maxChar - minChar + 1;
            adjacencyMatrix = new int[n, n];
        }

        public override void AddEdge(char sourceKey, char destinationKey, int weight = 1)
        {
            adjacencyMatrix[sourceKey - minChar, destinationKey - minChar] = weight;
        }

        public override void BreadthFirstSearch(char sourceKey)
        {
            throw new NotImplementedException();
        }

        public override void DepthFirstSearch()
        {
            foreach (Vertex u in vertices)
            {
                u.color = Color.White;
                u.predecessor = null;
            }

            time = 0;

            foreach (Vertex u in vertices)
            {
                if (u.color == Color.White)
                {
                    DepthFirstSearchVisit(u);
                }
            }
        }

        void DepthFirstSearchVisit(Vertex u)
        {
            time++;
            u.discoveryTime = time;
            u.color = Color.Grey;

            foreach (Vertex v in vertices)
            {
                if (adjacencyMatrix[u.key - minChar, v.key - minChar] == 0)
                {
                    continue;
                }

                if (v.color == Color.White)
                {
                    v.predecessor = u;
                    DepthFirstSearchVisit(v);
                }
            }

            u.color = Color.Black;
            time++;
            u.finishingTime = time;
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

        void Relax(Vertex u, Vertex v)
        {
            int weight = adjacencyMatrix[u.key - minChar, v.key - minChar];

            int before = v.distance;
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
            throw new NotImplementedException();
        }
    }
}
