using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfApplication1
{
    class ImageAlgorithms
    {
        public static Bitmap BMPIMGtoBMP(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                return new Bitmap(bitmap);
            }
        }
        public static BitmapImage BMPtoBMPIMG(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private static int medianOfGrayScale(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int sum = 0;
            int[] histogram = new int[256];

            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    Color c = img.GetPixel(i, j);
                    histogram[c.R]++; // because it is grayscale: r=g=b;
                }
            }
            i = 0;
            while (sum < (x * y) / 2)
            {
                sum += histogram[i];
                i++;
            }
            return i - 1;
        }
        private static int avarageOfRGB(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int sumr = 0, sumg = 0, sumb = 0;
            Color tmpc;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    sumr += tmpc.R;
                    sumg += tmpc.G;
                    sumb += tmpc.B;
                }
            }
            tmpc = Color.FromArgb(sumr / (x * y), sumg / (x * y), sumb / (x * y));
            return tmpc.ToArgb();
        }
        private static int avarageOfGrayscale(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int sum = 0;
            Color tmpc;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    sum += tmpc.R;
                }
            }
            return sum / (x * y);
        }
        private static int[] histogramOfGrayscale(Bitmap img) 
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[] hist = new int[256];
            for ( i = 0;  i < x;  i++)
			{
			    for (j = 0; j < y; j++)
			    {
			        hist[img.GetPixel(i, j).R]++;
			    }
			}
            return hist;
        }
        private static int[,] histogramOfRGB(Bitmap img) 
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[,] hist = new int[256,3];
            for ( i = 0;  i < x;  i++)
			{
			    for (j = 0; j < y; j++)
			    {
			        hist[img.GetPixel(i, j).R,0]++;
                    hist[img.GetPixel(i, j).G,1]++;
                    hist[img.GetPixel(i, j).B,2]++;
			    }
			}
            return hist;
        }

        public static Bitmap ToGrayscale(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int r, g, b;
            for (i = 0; i < x; i++)
            { // i = x = column
                for (j = 0; j < y; j++)
                { // j = y = row
                    Color c = img.GetPixel(i, j);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    img.SetPixel(i, j, Color.FromArgb((r + g + b) / 3, (r + g + b) / 3, (r + g + b) / 3));
                }
            }
            return img;
        }
        public static Bitmap ToTrenary(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[] rgb = new int[3];
            Color tmpc;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    rgb[0] = tmpc.R;
                    rgb[1] = tmpc.G;
                    rgb[2] = tmpc.B;
                    int max = SearchingAlgorithms.FindMax(rgb);
                    if (rgb[0] == max)
                    {
                        tmpc = Color.FromArgb(rgb[0], 0, 0);
                    }
                    else if (rgb[1] == max)
                    {
                        tmpc = Color.FromArgb(0, rgb[1], 0);
                    }
                    else
                    {
                        tmpc = Color.FromArgb(0, 0, rgb[2]);
                    }
                    img.SetPixel(i, j, tmpc);
                }
            }
            return img;
        }
        public static Bitmap ToOctonary(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int r, g, b;
            Color tmpc;
            int avgrgb = avarageOfRGB(img);
            Color avg = Color.FromArgb(avgrgb);
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    if (tmpc.R <= avg.R)
                    {
                        r = 40;
                    }
                    else
                    {
                        r = 215;
                    }
                    if (tmpc.G <= avg.G)
                    {
                        g = 40;
                    }
                    else
                    {
                        g = 215;
                    }
                    if (tmpc.B <= avg.B)
                    {
                        b = 40;
                    }
                    else
                    {
                        b = 215;
                    }
                    img.SetPixel(i, j, Color.FromArgb(r, g, b));

                }
            }
            return img;
        }
        public static Bitmap ToBinaryMedian(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;

            int r, g, b;
            for (i = 0; i < x; i++)
            { // i = x = column
                for (j = 0; j < y; j++)
                { // j = y = row
                    Color c = img.GetPixel(i, j);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    img.SetPixel(i, j, Color.FromArgb((r + g + b) / 3, (r + g + b) / 3, (r + g + b) / 3));
                }
            }
            int median = medianOfGrayScale(img);
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    Color co = img.GetPixel(i, j);
                    if (co.B < median)
                    { // r=g=b
                        img.SetPixel(i, j, Color.FromArgb(40, 40, 40));
                    }
                    else
                    {
                        img.SetPixel(i, j, Color.FromArgb(215, 215, 215));
                    }
                }
            }
            return img;
        }
        public static Bitmap ToBinaryAvarage(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;

            int r, g, b;
            for (i = 0; i < x; i++)
            { // i = x = column
                for (j = 0; j < y; j++)
                { // j = y = row
                    Color c = img.GetPixel(i, j);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    img.SetPixel(i, j, Color.FromArgb((r + g + b) / 3, (r + g + b) / 3, (r + g + b) / 3));
                }
            }
            int avg = avarageOfGrayscale(img);
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    Color co = img.GetPixel(i, j);
                    if (co.B < avg)
                    { // r=g=b
                        img.SetPixel(i, j, Color.FromArgb(40, 40, 40));
                    }
                    else
                    {
                        img.SetPixel(i, j, Color.FromArgb(215, 215, 215));
                    }
                }
            }
            return img;
        }
        public static Bitmap ToBinaryAvarageColorful(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int avg = (avarageOfRGB(img));
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    if (img.GetPixel(i, j).ToArgb() < avg)
                    { // r=g=b
                        img.SetPixel(i, j, Color.FromArgb(avg));
                    }
                    else
                    {
                        img.SetPixel(i, j, Color.FromArgb(215, 215, 215));
                    }
                }
            }
            return img;
        }
        public static Bitmap SortImageHorizontal(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[] arr = new int[x];
            int col = 0;
            for (j = 0; j < y; j++)
            {
                for (i = 0; i < x; i++)
                {
                    arr[i] = img.GetPixel(i, j).ToArgb();
                }
                SortingAlgorithms.HeapSort(arr);
                for (int k = 0; k < x; k++)
                {
                    img.SetPixel(k, col, Color.FromArgb(arr[k]));
                }
                col++;
            }
            return img;
        }
        public static Bitmap SortImageVertical(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[] arr = new int[y];
            int row = 0;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    arr[j] = img.GetPixel(i, j).ToArgb();
                }
                SortingAlgorithms.HeapSort(arr);
                for (int k = 0; k < y; k++)
                {
                    img.SetPixel(row, k, Color.FromArgb(arr[k]));
                }
                row++;
            }
            return img;
        }
        public static Bitmap ToErhanGray(Bitmap img)
        {
            /* What this does is:
             * For a 3x3 e.g.
             * 1	4	5
             * 7	3	3
             * 1	5	2
             * To two different:
             * 1	4	5
             * 3	3	7
             * 1	2	5
             * and
             * 1	3	2
             * 1	4	3
             * 7	5	5
             * and then add and divide by 2 using them
             * 1	3	3
             * 2	3	5
             * 4	3	5
             */
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[] arr1 = new int[x];
            int[] arr2 = new int[y];
            int[,] mat1 = new int[x, y];
            int[,] mat2 = new int[x, y];
            Color tmpc;
            i = 0; j = 0;
            for (j = 0; j < y; j++)
            {
                for (i = 0; i < x; i++)
                {
                    tmpc = img.GetPixel(i, j);
                    arr1[i] = (tmpc.B + tmpc.G + tmpc.R) / 3;

                }
                SortingAlgorithms.HeapSort(arr1);
                for (int p = 0; p < x; p++)
                {
                    mat1[p, j] = arr1[p];
                }
            }
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    arr2[j] = (tmpc.B + tmpc.G + tmpc.R) / 3;
                }
                SortingAlgorithms.HeapSort(arr2);
                for (int p = 0; p < y; p++)
                {
                    mat2[i, p] = arr2[p];
                }
            }
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    mat1[i, j] = (mat1[i, j] + mat2[i, j]) / 2;
                    img.SetPixel(i, j, Color.FromArgb(mat1[i, j], mat1[i, j], mat1[i, j]));
                }
            }
            int sum, tmp = 9, k, l;
            for (i = tmp; i < x - tmp; i++)
            {
                for (j = tmp; j < y - tmp; j++)
                {
                    sum = 0;
                    for (k = i - tmp; k < i + tmp - 1; k++)
                    {
                        for (l = j - tmp; l < j + tmp - 1; l++)
                        {
                            sum += img.GetPixel(k, l).ToArgb();
                        }
                    }
                    for (k = i - tmp; k < i + tmp - 1; k++)
                    {
                        for (l = j - tmp; l < j + tmp - 1; l++)
                        {
                            img.SetPixel(k, l, Color.FromArgb(sum / ((i + tmp - 1) * (j + tmp - 1))));
                        }
                    }
                }
            }
            return img;
        }
        public static Bitmap ToErhanyRGB(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            int[] arr1r = new int[x];
            int[] arr1g = new int[x];
            int[] arr1b = new int[x];
            int[] arr2r = new int[y];
            int[] arr2g = new int[y];
            int[] arr2b = new int[y];
            int[,] mat1r = new int[x, y];
            int[,] mat1g = new int[x, y];
            int[,] mat1b = new int[x, y];
            int[,] mat2r = new int[x, y];
            int[,] mat2g = new int[x, y];
            int[,] mat2b = new int[x, y];
            i = 0; j = 0;
            Color tmpc;
            for (j = 0; j < y; j++)
            {
                for (i = 0; i < x; i++)
                {
                    tmpc = img.GetPixel(i, j);
                    arr1r[i] = tmpc.R;
                    arr1g[i] = tmpc.G;
                    arr1b[i] = tmpc.B;
                }
                SortingAlgorithms.HeapSort(arr1r);
                SortingAlgorithms.HeapSort(arr1g);
                SortingAlgorithms.HeapSort(arr1b);
                for (int p = 0; p < x; p++)
                {
                    mat1r[p, j] = arr1r[p];
                    mat1g[p, j] = arr1r[p];
                    mat1b[p, j] = arr1r[p];
                }
            }
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    arr2r[j] = tmpc.R;
                    arr2g[j] = tmpc.G;
                    arr2b[j] = tmpc.B;
                }
                SortingAlgorithms.HeapSort(arr2r);
                SortingAlgorithms.HeapSort(arr2g);
                SortingAlgorithms.HeapSort(arr2b);
                for (int p = 0; p < y; p++)
                {
                    mat2r[i, p] = arr2r[p];
                    mat2g[i, p] = arr2g[p];
                    mat2b[i, p] = arr2b[p];
                }
            }
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    mat1r[i, j] = (mat1r[i, j] + mat2r[i, j]) >> 1;
                    mat1g[i, j] = (mat1g[i, j] + mat2g[i, j]) >> 1;
                    mat1b[i, j] = (mat1b[i, j] + mat2b[i, j]) >> 1;
                    img.SetPixel(i, j, Color.FromArgb(mat1r[i, j], mat1g[i, j], mat1b[i, j]));
                }
            }
            return img;
        }
        public static Bitmap BlurImage(Bitmap img, int blurdegree)
        { // needs optimization
            int i, j, k, l;
            int x = img.Width;
            int y = img.Height;
            int sumr, sumg, sumb;
            Color tmpc;
            for (i = blurdegree; i < x - blurdegree; i++)
            {
                for (j = blurdegree; j < y - blurdegree; j++)
                {
                    sumr = 0;
                    sumg = 0;
                    sumb = 0;
                    for (k = i - blurdegree; k < i + blurdegree; k++)
                    {
                        for (l = j - blurdegree; l < j + blurdegree; l++)
                        {
                            tmpc = img.GetPixel(i, j);
                            sumr = (sumr + tmpc.R) >> 1;
                            sumg = (sumg + tmpc.G) >> 1;
                            sumb = (sumb + tmpc.B) >> 1;
                        }
                    }
                    tmpc = Color.FromArgb(sumr, sumg, sumb);
                    for (k = i - blurdegree; k < i + blurdegree; k++)
                    {
                        for (l = j - blurdegree; l < j + blurdegree; l++)
                        {
                            img.SetPixel(k, l, tmpc);
                        }
                    }
                }
            }
            return img;
        }
        public static Bitmap FlipVertical(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            Color tmp;
            for (j = 0; j < y; j++)
            {
                for (i = 0; i < x / 2; i++)
                {
                    tmp = img.GetPixel(i, j);
                    img.SetPixel(i, j, img.GetPixel(x - i - 1, j));
                    img.SetPixel(x - i - 1, j, tmp);
                }
            }
            return img;
        }
        public static Bitmap FlipHorizontal(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            Color tmp;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y / 2; j++)
                {
                    tmp = img.GetPixel(i, j);
                    img.SetPixel(i, j, img.GetPixel(i, y - j - 1));
                    img.SetPixel(i, y - j - 1, tmp);
                }
            }
            return img;
        }
        public static Bitmap Rotate90Right(Bitmap originalimg)
        {
            Bitmap newimg = new Bitmap(originalimg.Height, originalimg.Width);
            int i, j;
            int xorg = originalimg.Width;
            int yorg = originalimg.Height;
            int[] arr = new int[xorg];
            int k, l = 0;
            for (j = 0; j < yorg; j++)
            {
                for (i = 0; i < xorg; i++)
                {
                    arr[i] = originalimg.GetPixel(i, j).ToArgb();
                }
                l++;
                for (k = 0; k < xorg; k++)
                {
                    newimg.SetPixel(yorg - l, k, Color.FromArgb(arr[k]));
                }
            }
            return newimg;
        }
        public static Bitmap Rotate90Left(Bitmap originalimg)
        {
            Bitmap newimg = new Bitmap(originalimg.Height, originalimg.Width);
            int i, j;
            int xorg = originalimg.Width;
            int yorg = originalimg.Height;
            int[] arr = new int[xorg];
            int k;
            for (j = 0; j < yorg; j++)
            {
                for (i = 0; i < xorg; i++)
                {
                    arr[i] = originalimg.GetPixel(i, j).ToArgb();
                }
                for (k = 0; k < xorg; k++)
                {
                    newimg.SetPixel(j, xorg - 1 - k, Color.FromArgb(arr[k]));
                }
            }
            return newimg;
        }
        public static Bitmap ToNegative(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            Color tmpc;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    tmpc = img.GetPixel(i, j);
                    tmpc = Color.FromArgb(Math.Abs(255 - tmpc.R), Math.Abs(255 - tmpc.G), Math.Abs(255 - tmpc.B));
                    img.SetPixel(i, j, tmpc);
                }
            }
            return img;
        }
        public static Bitmap MaxAlpha(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            byte maxA = 0;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    if (img.GetPixel(i, j).A > maxA)
                    {
                        maxA = img.GetPixel(i, j).A;
                    }
                }
            }
            byte adder = (byte)(byte.MaxValue - maxA);
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    img.SetPixel(i, j,Color.FromArgb(img.GetPixel(i, j).A+adder, img.GetPixel(i, j).R, img.GetPixel(i, j).G, img.GetPixel(i, j).B));
                }
            }
            return img;
        }
        public static Bitmap MinAlpha(Bitmap img)
        {
            int i, j;
            int x = img.Width;
            int y = img.Height;
            byte minA = byte.MaxValue;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    if (img.GetPixel(i, j).A < minA)
                    {
                        minA = img.GetPixel(i, j).A;
                    }
                }
            }
            byte subber = minA;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    img.SetPixel(i, j, Color.FromArgb(img.GetPixel(i, j).A - subber, img.GetPixel(i, j).R, img.GetPixel(i, j).G, img.GetPixel(i, j).B));
                }
            }
            return img;
        }
    }
}
