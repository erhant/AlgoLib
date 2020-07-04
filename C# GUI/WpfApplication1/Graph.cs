using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Graph
    {
        public enum EdgeDirection {
            TwoWay,// Node1 <-> Node2
            OneWay // Node1 --> Node2
        };
        public struct Edge
        {
            public int Weight;
            public EdgeDirection Direction;
            public int Node1;
            public int Node2;
        }

        public List<Edge> edges; // Edge List
        public int[,] matrix; // Adjacency Matrix
        public int edgeCount; // number of lines
        public int vertexCount; // number of nodes

        public Graph(List<Edge> edges, int edgeCount, int vertexCount)
        {
            this.edges = edges;
            this.edgeCount = edgeCount;
            this.vertexCount = vertexCount;
            this.matrix = CreateMatrix();
        }
        // Returns the matrix of the graph, direction is from [I] to [J] for [I][J]
        private int[,] CreateMatrix()
        {
            int[,] matrix = new int[vertexCount, vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] = int.MaxValue;
                    }
                }
            }
            foreach (Edge l in edges)
            {
                if (l.Direction == EdgeDirection.OneWay)
                {
                    matrix[l.Node1, l.Node2] = l.Weight;
                }
                else
                {
                    matrix[l.Node1, l.Node2] = l.Weight;
                    matrix[l.Node2, l.Node1] = l.Weight;
                }
            }
            return matrix;
        }
        public string IntroduceLines()
        {
            string ans = "";
            foreach (Edge e in edges)
            {
                if (e.Direction == EdgeDirection.TwoWay)
                {
                    ans += e.Node1 + " <==[" + e.Weight + "]==> " + e.Node2;
                }
                else
                {
                    ans += e.Node1 + " ===[" + e.Weight + "]==> " + e.Node2;
                }
                ans += "\n";
            }
            return ans;
        }
        public string IntroduceMatrix()
        {
            string ans = "";
            for (int i = 0; i < this.vertexCount; i++)
                ans += "\t" + i;
            ans += "\n";
            for (int i = 0; i < this.vertexCount; i++)
            {
                ans += i;
                for (int j = 0; j < this.vertexCount; j++)
                {
                    if (matrix[i, j] == int.MaxValue) // int.MaxValue is considered as INF (infinite)
                    {
                        ans += "\t" + "INF";
                    }
                    else
                    {
                        ans += "\t" + matrix[i, j];
                    }

                }
                ans += "\n\n";
            }
            

            return ans;
        }
    }
}
