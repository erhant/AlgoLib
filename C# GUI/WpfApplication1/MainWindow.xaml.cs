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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Drawing;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int num1 = Int32.MinValue;
        private int num2 = Int32.MinValue;

        private int[] arr = null;
        private int arrSize = -1;
        private int arrAdder = -1;
        private int arrMax = -1;
        private int arrSearch = Int32.MinValue;

        // INITIALIZE CALL
        public MainWindow()
        {
            InitializeComponent();
        }
        // INPUT FUNCTIONS
        private void txtBox_Num1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.num1 = Convert.ToInt32(txtBox_Num1.Text);
            }
            catch (FormatException ex)
            {
                txtBox_Num1.Text = "";
                num1 = Int32.MinValue;
            }
        }
        private void txtBox_Num2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.num2 = Convert.ToInt32(txtBox_Num2.Text);
            }
            catch (FormatException ex)
            {
                txtBox_Num2.Text = "";
                num2 = Int32.MinValue;
            }
        }
        private void txtBox_ArrSize_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.arrSize = Convert.ToInt32(txtBox_ArrSize.Text);
            }
            catch (FormatException ex)
            {
                txtBox_ArrSize.Text = "";
                arrSize = -1;
            }
        }
        private void txtBox_ArrAdder_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.arrAdder = Convert.ToInt32(txtBox_ArrAdder.Text);
            }
            catch (FormatException ex)
            {
                txtBox_ArrAdder.Text = "";
                arrAdder = -1;
            }
        }
        private void txtBox_ArrMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.arrMax = Convert.ToInt32(txtBox_ArrMax.Text);
            }
            catch (FormatException ex)
            {
                txtBox_ArrMax.Text = "";
                arrMax = -1;
            }
        }
        private void txtBox_ArrSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.arrSearch = Convert.ToInt32(txtBox_ArrSearch.Text);
            }
            catch (FormatException ex)
            {
                txtBox_ArrSearch.Text = "";
                arrSearch = -1;
            }
        }
        // NUMBER / ALGORITHMS
        private void getPositiveDividers_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = String.Join(" ", NumberAlgorithms.GetPositiveDividers(num1));
            }
        }
        private void getPrimeFactors_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = num1 + " = " + String.Join("*", NumberAlgorithms.GetPrimeFactorsAll(num1));
            }
        }
        private void getGreekType_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = NumberAlgorithms.GetGreekType(num1);
            }
        }
        private void isPrime_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = "" + NumberAlgorithms.isPrime(num1);
            }
        }
        private void isPerfectSqr_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = "" + NumberAlgorithms.isPerfectSquare(num1);
            }
        }
        private void isKaprekarNumber_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = "" + NumberAlgorithms.isKaprekarNumber(num1);
            }
        }
        private void isHarshadNumber_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = "" + NumberAlgorithms.isHarshadNumber(num1);
            }
        }
        // NUMBER / CONST
        private void piConst_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "Pi = " + NumberAlgorithms.Pi + "\nIt is the ratio of the circles circumference to its diameter.";
        }
        private void eConst_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "E = " + NumberAlgorithms.E + "\nThe Natural Logarithm Base";
        }
        private void phiConst_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "Phi = " + NumberAlgorithms.Phi + "\nThe Golden Ratio: (a+b)/a = a/b = Phi";
        }
        // NUMBER / EDIT
        private void reverse_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue)
            {
                textBox1.Text = num1 + " reversed ";
                this.num1 = NumberAlgorithms.reverseNumber(num1);
                textBox1.Text += "is " + num1;
                txtBox_Num1.Text = num1 + "";
            }
        }
        private void random_Click_1(object sender, RoutedEventArgs e)
        {
            this.num1 = NumberAlgorithms.GetRandomNumber();
            txtBox_Num1.Text = num1 + "";
        }
        // NUMBER / PAIR
        private void amicable_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue && num2 != Int32.MinValue)
            {
                textBox1.Text = num1 + " and " + num2 + " Amicable = " + NumberAlgorithms.areAmicableNumbers(num1, num2);
            }
        }
        private void friendly_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue && num2 != Int32.MinValue)
            {
                textBox1.Text = num1 + " and " + num2 + " Friendly = " + NumberAlgorithms.areFriendlyNumbers(num1, num2);
            }
        }
        private void gcf_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue && num2 != Int32.MinValue)
            {
                textBox1.Text = "Greatest Common Factor of " + num1 + " and " + num2 + " is " + NumberAlgorithms.GreatestCommonFactor(num1, num2);
            }
        }
        private void lcm_Click_1(object sender, RoutedEventArgs e)
        {
            if (num1 != Int32.MinValue && num2 != Int32.MinValue)
            {
                textBox1.Text = "Least Common Factor of " + num1 + " and " + num2 + " is " + NumberAlgorithms.LeastCommonMultiple(num1, num2);
            }
        }
        // ARRAY / GENERATE
        private void genRandArr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0 && arrMax > 0)
            {
                arr = GeneratorAlgorithms.RandomArray(arrSize, arrMax);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void genSortedAarr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0 && arrAdder > 0 && arrMax > 0)
            {
                arr = GeneratorAlgorithms.SortedAscendingArray(arrSize, arrMax, arrAdder);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void genSortedDarr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0 && arrAdder > 0 && arrMax > 0)
            {
                arr = GeneratorAlgorithms.SortedDescendingArray(arrSize, arrMax, arrAdder);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void genRdmNoRecurArr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0 && arrAdder > 0 && arrMax > 0)
            {
                arr = GeneratorAlgorithms.RandomNoRecurrenceArray(arrSize, arrMax, arrAdder);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void genSqnArr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0 && arrAdder > 0)
            {
                arr = GeneratorAlgorithms.SequentialArray(arrSize, arrMax, arrAdder);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void genIncrArr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0 && arrMax > 0)
            {
                arr = GeneratorAlgorithms.IncrementialArray(arrSize, arrMax);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void genFiboArr_Click_1(object sender, RoutedEventArgs e)
        {
            if (arrSize > 0)
            {
                arr = GeneratorAlgorithms.FibonacciArray(arrSize);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        // ARRAY / SORT
        private void selSortA_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                SortingAlgorithms.SelectionSortAscending(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void sesSortD_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                SortingAlgorithms.SelectionSortDescending(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void bubbleSort_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                SortingAlgorithms.BubbleSort(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void heapSort_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                SortingAlgorithms.HeapSort(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void countSortFreq_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                SortingAlgorithms.LinearCountingSort_Freq(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        private void countSortScore_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                SortingAlgorithms.LinearCountingSort_Score(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        // ARRAY / MISC
        private void findMedian_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                textBox1.Text += "\nMedian Value = " + SearchingAlgorithms.FindMedian(arr);
            }
        }
        private void findAvarage_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                textBox1.Text += "\nAvarage = " + SearchingAlgorithms.FindAvarage(arr);
            }
        }
        private void findMax_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                textBox1.Text += "\nMaximum Value = " + SearchingAlgorithms.FindMax(arr);
            }
        }
        private void findMin_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                textBox1.Text += "\nMinimum Value = " + SearchingAlgorithms.FindMin(arr);
            }
        }
        private void hasRecurrence_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                textBox1.Text += "\n Has Recurrence = " + SearchingAlgorithms.HasRecurrence(arr);
            }
        }
        private void findMostRecurringElement_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                textBox1.Text += "Most Recurring Element = " + SearchingAlgorithms.FindMostRecurringElement(arr);
            }
        }
        private void oddEvenHeap_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                ArrayAlgorithms.OddEvenParseHeaped(arr);
                textBox1.Text = String.Join(" ", arr);
            }
        }
        // ARRAY / SEARCH
        private void linearSearch_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null && arrSearch != Int32.MinValue)
            {
                int p = SearchingAlgorithms.LinearSearch(arr, arrSearch);
                if (p == -1)
                {
                    textBox1.Text += "\nNo such element";
                }
                else
                {
                    textBox1.Text += "\nElement found at " + p;
                }
            }
        }
        private void binarySearch_Click_1(object sender, RoutedEventArgs e)
        {
            if (arr != null && arrSearch != Int32.MinValue)
            {
                int p = SearchingAlgorithms.LinearSearch(arr, arrSearch);
                if (p == -1)
                {
                    textBox1.Text = "No such element";
                }
                else
                {
                    textBox1.Text = "Element found at " + p;
                }
            }
        }
        // IMAGE
        private void openImgWindow_Click_1(object sender, RoutedEventArgs e)
        {
            ImageWindow imgWindow = new ImageWindow();
            imgWindow.Show();
        }
        // TEXT
        private void openTxtWindow_Click_1(object sender, RoutedEventArgs e)
        {
            TextWindow txtWindow = new TextWindow();
            txtWindow.Show();
        }
        // GRAPH
        private void lineGraph_Click_1(object sender, RoutedEventArgs e)
        {
            GraphInitializer gi = new GraphInitializer();
            gi.Show();
        }
        private void cycleGraphDirected_Click_1(object sender, RoutedEventArgs e)
        {
            if (num2 != Int32.MinValue)
            {
                GraphWindow gw = new GraphWindow();
                gw.setGraph(GraphAlgorithms.GenerateCycleDirected(num2));
                gw.Show();
            }            
        }

        private void cycleGraphNonD_Click_1(object sender, RoutedEventArgs e)
        {
            if (num2 != Int32.MinValue)
            {
                GraphWindow gw = new GraphWindow();
                gw.setGraph(GraphAlgorithms.GenerateCycleNonDirected(num2));
                gw.Show();
            }            
        }

        private void wheelGraph_Click_1(object sender, RoutedEventArgs e)
        {
            if (num2 != Int32.MinValue)
            {
                GraphWindow gw = new GraphWindow();
                gw.setGraph(GraphAlgorithms.GenerateWheelNonDirected(num2));
                gw.Show();
            }                      
        }
        private void wheelGraphDirected_Click_1(object sender, RoutedEventArgs e)
        {
            if (num2 != Int32.MinValue)
            {
                GraphWindow gw = new GraphWindow();
                gw.setGraph(GraphAlgorithms.GenerateWheelDirected(num2));
                gw.Show();
            }
        }

        
    }
}
