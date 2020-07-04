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
    /// Interaction logic for GraphInitializer.xaml
    /// </summary>
    public partial class GraphInitializer : Window
    {
        int nodeCount;
        int lineCount;
        List<Graph.Edge> lines = new List<Graph.Edge>();

        public GraphInitializer()
        {
            InitializeComponent();
            firstgrid.Visibility = System.Windows.Visibility.Visible;
            secondGrid.Visibility = System.Windows.Visibility.Hidden;
        }

        private void acceptBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lineCount = Convert.ToInt32(firstTxtBox.Text);
                this.nodeCount = Convert.ToInt32(firstTxtBox2.Text);
                firstgrid.Visibility = System.Windows.Visibility.Collapsed;
                secondGrid.Visibility = System.Windows.Visibility.Visible;
                cmbBox_Node1_Loaded_1(null, null);
                cmbBox_Node2_Loaded_1(null, null);
            }
            catch (FormatException ex)
            {
                firstTxtBox.Text = "";
                firstTxtBox2.Text = "";
            }
        }
        // COMBO BOX LOADERS
        private void cmbBox_Direction_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<string> items = new List<string>();
            items.Add("Two Way Direction");
            items.Add("Node 1 to Node 2");
            cmbBox_Direction.ItemsSource = items;
            cmbBox_Direction.SelectedIndex = 0;
        }
        private void cmbBox_Node1_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<int> items = new List<int>();
            for (int i = 0; i < nodeCount; i++)
            {
                items.Add(i);
            }
            cmbBox_Node1.ItemsSource = items;
            cmbBox_Node1.SelectedIndex = 0;
        }
        private void cmbBox_Node2_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<int> items = new List<int>();
            for (int i = 0; i < nodeCount; i++)
            {
                items.Add(i);
            }
            cmbBox_Node2.ItemsSource = items;
            cmbBox_Node2.SelectedIndex = 0;
        }

        private void btn_Accept_Click_1(object sender, RoutedEventArgs e)
        {
            Graph.Edge l = new Graph.Edge();
            l.Weight = Convert.ToInt32(txtBox_weight.Text);
            if ((string)cmbBox_Direction.SelectedItem == "Two Way Direction")
            {
                l.Direction = Graph.EdgeDirection.TwoWay;
            }
            else
            {
                l.Direction = Graph.EdgeDirection.NodeToNode;
            }
            l.Node1 = (int)cmbBox_Node1.SelectedItem;
            l.Node2 = (int)cmbBox_Node2.SelectedItem;
            if (l.Node1 == l.Node2)
            {
                return;
            }
            foreach (Graph.Edge line in lines)
            {
                if (line.Node1 == l.Node1 && line.Node2 == l.Node2)
                {
                    return;
                }
                if (l.Direction != Graph.EdgeDirection.NodeToNode)
                {
                    if (line.Node2 == l.Node1 && line.Node1 == l.Node2)
                    {
                        return;
                    }
                }                
            }
            lines.Add(l);
            lineCount--;
            infoLbl.Content = lineCount + " lines left to enter.";
            if (lineCount == 0)
            {
                GraphWindow gw = new GraphWindow();
                gw.setGraph(new Graph(lines,lineCount,nodeCount));
                gw.Show();
                this.Close();
            }
        }
    }
}
