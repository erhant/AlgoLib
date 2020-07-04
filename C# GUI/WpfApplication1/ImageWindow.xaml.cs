using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        private BitmapImage img;
        private BitmapImage backupimg;

        public ImageWindow()
        {
            InitializeComponent();
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Image"; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "PNG Files (.png)|*.png"; // Filter files by extension
            dlg.Title = "Import Image";

            // Show open file dialog box
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                img = new BitmapImage(new Uri(dlg.FileName));
                backupimg = img;
                var image = sender as Image;
                image.Source = img;
            }
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Image"; // Default file name
                dlg.DefaultExt = ".png"; // Default file extension
                dlg.Filter = "PNG Files (.png)|*.png"; // Filter files by extension
                dlg.Title = "Save Image";

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(this.img));
                    using (var stream = dlg.OpenFile())
                    {
                        encoder.Save(stream);
                    }
                }
            }            
        }

        private void sortHorizontal_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.SortImageHorizontal(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void sortVertical_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.SortImageVertical(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void flipHorizontal_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.FlipHorizontal(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void flipVertical_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.FlipVertical(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void rotateLeft_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.Rotate90Left(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void rotateRight_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.Rotate90Right(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toErhanGray_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToErhanGray(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toErhanRGB1_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToErhanyRGB(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toNegative_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToNegative(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toOctonary_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToOctonary(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toTernary_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToTrenary(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toBinaryAvarageColored_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToBinaryAvarageColorful(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toBinaryAvarage_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToBinaryAvarage(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toBinaryMedian_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToBinaryMedian(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void toGrayscale_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.ToGrayscale(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void restore_Click(object sender, RoutedEventArgs e)
        {
            if (backupimg != null)
            {
                this.img = backupimg;
                this.imageHere.Source = img;
            }
        }

        private void maxAlpha_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.MaxAlpha
                    (ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }

        private void minAlpha_Click_1(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                this.img = ImageAlgorithms.BMPtoBMPIMG(ImageAlgorithms.MinAlpha(ImageAlgorithms.BMPIMGtoBMP(img)));
                this.imageHere.Source = img;
            }
        }
    }
}
