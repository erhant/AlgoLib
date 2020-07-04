using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class GraphAlgorithms
    {
        // Generates a non-directed Cycle Graph
        public static Graph GenerateCycleNonDirected(int nodeCount)
        {
            Random r = new Random();
            List<Graph.Edge> lines = new List<Graph.Edge>();
            for (int i = 0; i < nodeCount - 1; i++)
            {
                Graph.Edge l = new Graph.Edge();
                l.Node1 = i;
                l.Node2 = i + 1;
                l.Weight = r.Next(256);
                l.Direction = Graph.EdgeDirection.TwoWay;
                lines.Add(l);
            }
            Graph.Edge li = new Graph.Edge();
            li.Node1 = nodeCount - 1;
            li.Node2 = 0;
            li.Weight = r.Next(256);
            li.Direction = Graph.EdgeDirection.TwoWay;
            lines.Add(li);
            return new Graph(lines, lines.Count, nodeCount);
        }
        // Generates a directed Cycle Graph
        public static Graph GenerateCycleDirected(int nodeCount)
        {
            Random r = new Random();
            List<Graph.Edge> lines = new List<Graph.Edge>();
            for (int i = 0; i < nodeCount - 1; i++)
            {
                Graph.Edge l = new Graph.Edge();
                l.Node1 = i;
                l.Node2 = i + 1;
                l.Weight = r.Next(256);
                l.Direction = Graph.EdgeDirection.NodeToNode;
                lines.Add(l);
            }
            Graph.Edge li = new Graph.Edge();
            li.Node1 = nodeCount - 1;
            li.Node2 = 0;
            li.Weight = r.Next(256);
            li.Direction = Graph.EdgeDirection.NodeToNode;
            lines.Add(li);
            return new Graph(lines, lines.Count, nodeCount);
        }
        // Generates a non-directed Wheel graph
        public static Graph GenerateWheelNonDirected(int nodeCount)
        {
            Random r = new Random();
            List<Graph.Edge> lines = new List<Graph.Edge>();
            for (int i = 0; i < nodeCount - 2; i++)
            {
                Graph.Edge l = new Graph.Edge();
                l.Node1 = i;
                l.Node2 = i + 1;
                l.Weight = r.Next(256);
                l.Direction = Graph.EdgeDirection.TwoWay;
                lines.Add(l);
                Graph.Edge l2 = new Graph.Edge();
                l2.Node1 = i;
                l2.Node2 = nodeCount;
                l2.Weight = r.Next(256);
                l2.Direction = Graph.EdgeDirection.TwoWay;
                lines.Add(l2);
            }
            Graph.Edge li = new Graph.Edge();
            li.Node1 = nodeCount - 2;
            li.Node2 = 0;
            li.Weight = r.Next(256);
            li.Direction = Graph.EdgeDirection.TwoWay;
            lines.Add(li);
            Graph.Edge li2 = new Graph.Edge();
            li2.Node1 = nodeCount - 2;
            li2.Node2 = nodeCount - 1;
            li2.Weight = r.Next(256);
            li2.Direction = Graph.EdgeDirection.TwoWay;
            lines.Add(li2);
            return new Graph(lines, lines.Count, nodeCount);

        }
        // Generates a directed Wheel Graph 
        public static Graph GenerateWheelDirected(int nodeCount)
        {
            Random r = new Random();
            List<Graph.Edge> lines = new List<Graph.Edge>();
            for (int i = 0; i < nodeCount - 2; i++)
            {
                Graph.Edge l = new Graph.Edge();
                l.Node1 = i;
                l.Node2 = i + 1;
                l.Weight = r.Next(256);
                l.Direction = Graph.EdgeDirection.NodeToNode;
                lines.Add(l);
                Graph.Edge l2 = new Graph.Edge();
                l2.Node1 = i;
                l2.Node2 = nodeCount - 1;
                l2.Weight = r.Next(256);
                l2.Direction = Graph.EdgeDirection.NodeToNode;
                lines.Add(l2);
            }
            Graph.Edge li = new Graph.Edge();
            li.Node1 = nodeCount - 2;
            li.Node2 = 0;
            li.Weight = r.Next(256);
            li.Direction = Graph.EdgeDirection.NodeToNode;
            lines.Add(li);
            Graph.Edge li2 = new Graph.Edge();
            li2.Node1 = nodeCount - 2;
            li2.Node2 = nodeCount - 1;
            li2.Weight = r.Next(256);
            li2.Direction = Graph.EdgeDirection.NodeToNode;
            lines.Add(li2);
            return new Graph(lines, lines.Count, nodeCount);
        }
        // Adds a line to the graph and returns the new graph
        public static Graph AddLine(Graph graph, int node1, int node2, int weight, Graph.EdgeDirection direction)
        {
            foreach (Graph.Edge l in graph.edges)
            {
                if ((l.Node1 == node1 && l.Node2 == node2) || (l.Node1 == node2 && l.Node2 == node1))
                {
                    return graph;
                }
            }
            Graph.Edge li = new Graph.Edge();
            li.Node1 = node1;
            li.Node2 = node2;
            li.Weight = weight;
            li.Direction = direction;
            int nodeCount = graph.vertexCount;
            List<Graph.Edge> lines = graph.edges;
            lines.Add(li);
            graph = new Graph(lines, lines.Count, nodeCount);
            return graph;

        }
        // Returns the number of graphs in the graph, single nodes are also counted as graphs
        public static int FindSubGraphs(Graph graph)
        {
            List<Graph.Edge> lines = graph.edges;
            int[] etiquette = new int[graph.vertexCount]; // etiquettes for nodes that show which graph they are member of
            int graphNo = 0; // shows which graph the node is member of
            int curNode1, curNode2; // variables needed for readability
            foreach (Graph.Edge l in lines)
            {
                curNode1 = l.Node1; // etiquette starts from 0
                curNode2 = l.Node2; // etiquette starts from 0
                if (etiquette[curNode1] + etiquette[curNode2] == 0)
                { // means both is 0, we create a graph
                    graphNo++;
                    etiquette[curNode1] = graphNo;
                    etiquette[curNode2] = graphNo;
                }
                else if (etiquette[curNode1] * etiquette[curNode2] == 0)
                { // means one of them is 0, we join the 0 to the non-zero
                    etiquette[curNode1] = etiquette[curNode1] + etiquette[curNode2];
                    etiquette[curNode2] = etiquette[curNode1] + etiquette[curNode2];
                }
                else if (etiquette[curNode1] != etiquette[curNode2])
                { // means both nodes used to be on different graphs, now they join each other                   
                    for (int j = 0; j < graph.vertexCount; j++)
                        if (etiquette[j] == etiquette[curNode2])
                            etiquette[j] = etiquette[curNode1];
                }
                // else would mean there is N1 --- N2 as well as N2 --- N1 ( duplicate )
            }
            // now we need to add single nodes as graphs
            foreach (int i in etiquette)
                if (i == 0)
                    graphNo++;
            return graphNo;
        }
        // Returns a list of lines with maximum weights
        public static List<Graph.Edge> GetHeaviestEdges(Graph graph)
        {
            List<Graph.Edge> lines = graph.edges;
            List<Graph.Edge> ans = new List<Graph.Edge>();
            int maxWeight = 0;
            foreach (Graph.Edge l in lines)
            {
                if (l.Weight == maxWeight)
                {
                    ans.Add(l);
                }
                else
                {
                    if (l.Weight > maxWeight)
                    {
                        ans.Clear();
                        ans.Add(l);
                        maxWeight = l.Weight;
                    }
                }
            }
            return ans;
        }
        // Returns a list of lines with minimum weights
        public static List<Graph.Edge> GetWeakestEdges(Graph graph)
        {
            List<Graph.Edge> lines = graph.edges;
            List<Graph.Edge> ans = new List<Graph.Edge>();
            int minWeight = int.MaxValue;
            foreach (Graph.Edge l in lines)
            {
                if (l.Weight == minWeight)
                {
                    ans.Add(l);
                }
                else
                {
                    if (l.Weight < minWeight)
                    {
                        ans.Clear();
                        ans.Add(l);
                        minWeight = l.Weight;
                    }
                }
            }
            return ans;
        }
        // Returns a boolean value about graph being a Complete graph or not
        public static bool IsCompleteGraph(Graph graph)
        {
            if (graph.vertexCount * (graph.vertexCount - 1) / 2 == graph.edgeCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Finds the minimum spanning tree using Prim Algorithm, prefer with Unidrected, Connected and Weighted graph
        public static List<Graph.Edge> MST_Prim(Graph graph)
        {
            int[,] matrix = graph.matrix;
            List<Graph.Edge> path = new List<Graph.Edge>();
            // ignore row and col 0 for the matrix. ( it has size nodeCount+1 so you can go 1 to nodeCount )
            // root is chosen as 1.
            // invalid paths are -1 in the matrix
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            for (int i = 1; i < graph.vertexCount; i++)
            {
                cols.Add(i);
            }
            // because root is 1 we start from 1st row we remove 1st column.
            rows.Add(0);
            int removed = 1;
            while (removed < graph.vertexCount)
            {
                int min = int.MaxValue;
                int minCol = 0;
                int node1 = 0, node2 = 0;
                foreach (int i in rows)
                {
                    foreach (int j in cols)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                            minCol = j;
                            node1 = i;
                            node2 = j;
                        }
                    }
                }
                Graph.Edge l = new Graph.Edge();
                l.Node1 = node1;
                l.Node2 = node2;
                l.Weight = matrix[node1, node2];
                l.Direction = Graph.EdgeDirection.TwoWay;
                path.Add(l);
                rows.Add(minCol);
                cols.Remove(minCol);
                removed++;
            }
            return path;
        }
        // Finds the minimum spanning tree using Kruskal Algorithm, prefer with Undirected, Connected and Weighted graph
        public static List<Graph.Edge> MST_Kruskal(Graph graph)
        {
            List<Graph.Edge> lines = graph.edges;
            List<Graph.Edge> path = new List<Graph.Edge>();
            for (int i = 0; i < lines.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < lines.Count; j++)
                {
                    if (lines[j].Weight < lines[minIndex].Weight)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Graph.Edge tmp = lines[i];
                    lines[i] = lines[minIndex];
                    lines[minIndex] = tmp;
                }
            }
            // lines have been sorted
            int[] etiquette = new int[graph.vertexCount]; // etiquettes for nodes that show which graph they are member of
            int graphNo = 0; // shows which graph the node is member of
            int curNode1, curNode2; // variables needed for readability
            foreach (Graph.Edge l in lines)
            {
                curNode1 = l.Node1; // one end of a line
                curNode2 = l.Node2; // the other end of a line
                if (etiquette[curNode1] + etiquette[curNode2] == 0)
                { // means both nodes are not a member of any graph, so we create a graph
                    graphNo++;
                    etiquette[curNode1] = graphNo;
                    etiquette[curNode2] = graphNo;
                    path.Add(l);
                }
                else if (etiquette[curNode1] * etiquette[curNode2] == 0)
                { // means one of them is in a graph but the other is not, we join the non-member one to the graph
                    etiquette[curNode1] = etiquette[curNode1] + etiquette[curNode2];
                    etiquette[curNode2] = etiquette[curNode1] + etiquette[curNode2];
                    path.Add(l);
                }
                else if (etiquette[curNode1] != etiquette[curNode2])
                { // means both nodes used to be on different graphs, now they join each other                   
                    for (int j = 0; j < graph.vertexCount; j++)
                        if (etiquette[j] == etiquette[curNode2])
                            etiquette[j] = etiquette[curNode1];

                }
                // else would mean there is N1 --- N2 as well as N2 --- N1 ( duplicate )
            }
            return path;
        }
        // Funtion that implements Dijkstra's single source shortest path algorithm using adjacency matrix
        public static string ShortestPath_Dijkstra(Graph graph, int src)
        {
            int[,] matrix = graph.matrix;
            // The output array.  dist[i] will hold the shortest distance from src to i    
            int[] dist = new int[graph.vertexCount];
            // sptSet[i] will true if vertex i is included in shortest path tree or shortest distance from src to i is finalized
            bool[] sptSet = new bool[graph.vertexCount];
            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < graph.vertexCount; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            // Distance of source vertex from itself is always 0
            dist[src] = 0;
            // Find shortest path for all vertices
            for (int count = 0; count < graph.vertexCount - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices not
                // yet processed. u is always equal to src in first iteration.
                int u = -1;
                int min = Int32.MaxValue;
                for (int v = 0; v < graph.vertexCount; v++)
                {
                    if (sptSet[v] == false && dist[v] <= min)
                    {
                        min = dist[v];
                        u = v;
                    }
                }
                // Mark the picked vertex as processed
                sptSet[u] = true;
                // Update dist value of the adjacent vertices of the picked vertex.
                for (int v = 0; v < graph.vertexCount; v++)
                {
                    // Update dist[v] only if is not in sptSet, there is an edge from 
                    // u to v, and total weight of path from src to  v through u is 
                    // smaller than current value of dist[v]
                    if (!sptSet[v] && matrix[u, v] != int.MaxValue && dist[u] != int.MaxValue && dist[u] + matrix[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + matrix[u, v];
                    }
                }
            }
            //Return the results as a string
            string ans = "";
            ans += "Vertex\tMinimum Distance from Source\n";
            for (int i = 0; i < graph.vertexCount; i++)
            {
                ans += i + "\t" + dist[i] + "\n";
            }
            return ans;
        }
        // Solves the all-pairs shortest path problem using Floyd Warshall algorithm
        public static string ShortestPath_FloydWarshall(Graph graph)
        {
            /* dist[][] will be the output matrix that will finally have the shortest 
              distances between every pair of vertices */
            int[,] matrix = graph.matrix;
            int[,] dist = new int[graph.vertexCount, graph.vertexCount];
            int i, j, k;
            /* Initialize the solution matrix same as input graph matrix. Or 
               we can say the initial values of shortest distances are based
               on shortest paths considering no intermediate vertex. */
            for (i = 0; i < graph.vertexCount; i++)
                for (j = 0; j < graph.vertexCount; j++)
                    dist[i, j] = matrix[i, j];
            /* Add all vertices one by one to the set of intermediate vertices.
              ---> Before start of a iteration, we have shortest distances between all
              pairs of vertices such that the shortest distances consider only the
              vertices in set {0, 1, 2, .. k-1} as intermediate vertices.
              ----> After the end of a iteration, vertex no. k is added to the set of
              intermediate vertices and the set becomes {0, 1, 2, .. k} */
            for (k = 0; k < graph.vertexCount; k++)
            {
                // Pick all vertices as source one by one
                for (i = 0; i < graph.vertexCount; i++)
                {
                    // Pick all vertices as destination for the
                    // above picked source
                    for (j = 0; j < graph.vertexCount; j++)
                    {
                        // If vertex k is on the shortest path from
                        // i to j, then update the value of dist[i][j]
                        if ((dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue) && dist[i, k] + dist[k, j] < dist[i, j])
                            dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
            // Return the shortest distance matrix as a string
            string ans = "Following matrix shows the shortest distances between every pair of vertices \n";
            for (int x = 0; x < graph.vertexCount; x++)
                ans += "\t" + x;
            ans += "\n";
            for (int x = 0; x < graph.vertexCount; x++)
            {
                ans += x;
                for (int y = 0; y < graph.vertexCount; y++)
                {
                    if (dist[x, y] == int.MaxValue)
                        ans += "\t" + "INF";
                    else
                        ans += "\t" + dist[x, y];
                }
                ans += "\n\n";
            }
            return ans;
        }
        // Returns the path from a node to another using Bread First Search, uses Queue, use with non-directed
        public static string BreadthFirstTraversal(Graph graph)
        {
            Queue<int> q = new Queue<int>();
            bool[] visited = new bool[graph.vertexCount];
            string ans;
            int[,] m = graph.matrix;
            int v = 0;
            q.Enqueue(v);
            visited[v] = true;
            ans = v + ", ";
            while (q.Count > 0)
            {
                v = q.Dequeue();


            }
            return ans;
        }
        // Returns the path from a node to another using Depth First Search, uses Stack, use with non-directed
        public static string DepthFirstTraversal(Graph graph)
        {
            Stack<int> s = new Stack<int>();
            int[,] m = graph.matrix;
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < graph.vertexCount; i++)
            {
                for (int j = 0; j < graph.vertexCount; j++)
                {
                    return "";
                }
            }
            return "";
        }
    }
}
