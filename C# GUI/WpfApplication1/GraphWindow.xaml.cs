using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for GraphWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        Graph graph;

        public GraphWindow()
        {
            InitializeComponent();
        }
        public void setGraph(Graph g)
        {
            this.graph = g;
        }
        public void messageTextBox(String s)
        {
            textBox1.Text = s;
        }

        private void intro_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = graph.IntroduceLines();
        }

        private void subGraphCount_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = GraphAlgorithms.FindSubGraphs(graph) + " Sub Graph(s) found";
        }

        private void maxWeightLines_Click_1(object sender, RoutedEventArgs e)
        {
            List<Graph.Edge> lines = GraphAlgorithms.GetHeaviestEdges(graph);
            textBox1.Text = "Maximum Weight is " + lines[0].Weight;
            textBox1.Text += "\nLines with this weight are :\n";
            foreach (Graph.Edge l in lines)
            {
                if (l.Direction == Graph.EdgeDirection.TwoWay)
                {
                    textBox1.Text += l.Node1 + " <==[" + l.Weight + "]==> " + l.Node2;
                }
                else
                {
                    textBox1.Text += l.Node1 + " ===[" + l.Weight + "]==> " + l.Node2;
                }
                textBox1.Text += "\n";
            }
        }

        private void minWeightLines_Click_1(object sender, RoutedEventArgs e)
        {
            List<Graph.Edge> lines = GraphAlgorithms.GetWeakestEdges(graph);
            textBox1.Text = "Minimum Weight is " + lines[0].Weight;
            textBox1.Text += "\nLines with this weight are :\n";
            foreach (Graph.Edge l in lines)
            {
                if (l.Direction == Graph.EdgeDirection.TwoWay)
                {
                    textBox1.Text += l.Node1 + " <==[" + l.Weight + "]==> " + l.Node2;
                }
                else
                {
                    textBox1.Text += l.Node1 + " ===[" + l.Weight + "]==> " + l.Node2;
                }
                textBox1.Text += "\n";
            }
        }

        private void intro3_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = graph.IntroduceMatrix();
        }

        private void isComplete_Click_1(object sender, RoutedEventArgs e)
        {
            if (GraphAlgorithms.IsCompleteGraph(graph))
            {
                textBox1.Text = "This graph is a complete graph";
            }
            else
            {
                textBox1.Text = "This graph is not a complete graph";
            }
        }

        private void isRegular_Click_1(object sender, RoutedEventArgs e)
        {
            //int degree = GraphAlgorithms.IsRegularGraph(graph); 
            //if (degree == -1)
            //{
            //    textBox1.Text = "This graph is not a regular graph";
            //}
            //else
            //{
            //    textBox1.Text = "This graph is a regular graph with a degree of "+degree;
            //}
        }

        private void MSTkruskal_Click_1(object sender, RoutedEventArgs e)
        {
            List<Graph.Edge> path = GraphAlgorithms.MST_Kruskal(graph);
            string ans = "";
            foreach (Graph.Edge l in path)
            {               
                    ans += l.Node1 + " <==[" + l.Weight + "]==> " + l.Node2;
                
                ans += "\n";
            }
            textBox1.Text = ans;
        }

        private void MSTprim_Click_1(object sender, RoutedEventArgs e)
        {
            List<Graph.Edge> path = GraphAlgorithms.MST_Prim(graph);
            string ans = "";
            foreach (Graph.Edge l in path)
            {
                ans += l.Node1 + " <==[" + l.Weight + "]==> " + l.Node2;

                ans += "\n";
            }
            textBox1.Text = ans;
        }

        private void Dijkstra_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = GraphAlgorithms.ShortestPath_Dijkstra(graph, 0);
        }

        private void FloydWarshall_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = GraphAlgorithms.ShortestPath_FloydWarshall(graph);
        }

        private void bfs_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void dfs_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
