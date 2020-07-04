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
    /// Interaction logic for TextWindow.xaml
    /// </summary>
    public partial class TextWindow : Window
    {
        public TextWindow()
        {
            InitializeComponent();
        }

        private void reverse_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = TextAlgorithms.ReverseText(textBox1.Text);
        }

        private void toRobotLang_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = TextAlgorithms.ToRobotLanguage(textBox1.Text);
        }

        private void searchText_Click_1(object sender, RoutedEventArgs e)
        {
            int[] res = TextAlgorithms.SearchRecurrence(textBox1.Text, searchTextBox.Text);
            if (res == null)
            {
                resultsTxtBox.Text = "No matches found";
            }
            else
            {
                resultsTxtBox.Text = "Found " + res.Length + " results:";
                foreach (int i in res)
                {
                    resultsTxtBox.Text += "\nPos[" + i + "]";
                }
            }
        }
    }
}
