package Algorithms;
import java.awt.Color;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

public class ImageAlgorithms {
	
	private static int medianOfGrayScale( BufferedImage img ) {
		int i, j, k=0;
		int x = img.getWidth();
		int y = img.getHeight();
		int sum=0;
		int histogram[] = new int[256];
		
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				Color c = new Color( img.getRGB(i, j) );
				// because it is grayscale: r=g=b;
				k=c.getBlue();
				histogram[k]++;
			}
		}
		
		i=0;
		while ( sum<(x*y)/2 ) {
			sum+=histogram[i];
			i++;
		}
		return i-1;
	}
	
	private static int avarageOfRGB( BufferedImage img ) {
		int i, j;
		int x = img.getWidth();
		int y = img.getHeight();
		int sumr=0, sumg=0, sumb=0;
		Color tmpc;
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color(img.getRGB(i, j));
				sumr+=tmpc.getRed();
				sumg+=tmpc.getGreen();
				sumb+=tmpc.getBlue();
			}
		}
		tmpc = new Color(sumr/(x*y),sumg/(x*y),sumb/(x*y));
		return tmpc.getRGB();
	}
	
	private static int avarageOfGrayscale( BufferedImage img ) {
		int i, j;
		int x = img.getWidth();
		int y = img.getHeight();
		int sum=0;
		Color tmpc;
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color(img.getRGB(i, j));
				sum+=tmpc.getBlue();
			}
		}
		return sum/(x*y);
	}
	
	public static void writeImage(BufferedImage img, String outputformat, String outputname) {
		try {
			ImageIO.write(img, outputformat, new File(outputname+"."+outputformat));
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public static BufferedImage RGBtoGrayscale( BufferedImage originalimg) {
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		int r, g, b;
		for ( i=0; i<x; i++ ) { // i = x = column
			for ( j=0; j<y; j++ ) { // j = y = row
				Color c = new Color( img.getRGB(i, j) );
				r = c.getRed();
				g = c.getGreen();
				b = c.getBlue();
				Color cnew = new Color( (r+g+b)/3, (r+g+b)/3, (r+g+b)/3 );
				img.setRGB(i, j, cnew.getRGB());
			}
		}
		return img;
	}
	
	public static BufferedImage RGBtoTernary( BufferedImage originalimg) {
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		int rgb[] = new int[3];
		Color tmpc;
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color( img.getRGB(i, j) );
				rgb[0]=tmpc.getRed();
				rgb[1]=tmpc.getGreen();
				rgb[2]=tmpc.getBlue();
				if ( rgb[0]==SearchAlgorithms.findMax(rgb) ) {
					tmpc = new Color(rgb[0],0,0);
				}
				else if ( rgb[1]==SearchAlgorithms.findMax(rgb) ) {
					tmpc = new Color(0,rgb[1],0);
				}
				else {
					tmpc = new Color(0,0,rgb[2]);
				}
				img.setRGB(i, j, tmpc.getRGB());
			}
		}
		return img;
	}
	
	public static BufferedImage RGBto8way( BufferedImage originalimg ) {
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		int r, g, b;
		Color tmpc;
		int avgrgb = avarageOfRGB(img);
		Color avg = new Color(avgrgb);
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color( img.getRGB(i, j) );
				if ( tmpc.getRed() <= avg.getRed()) {
					r = 40;
				}
				else {
					r = 215;
				}
				if ( tmpc.getGreen() <= avg.getGreen() ) {
					g = 40;
				}
				else {
					g = 215;
				}
				if ( tmpc.getBlue() <= avg.getBlue() ) {
					b = 40;
				}
				else {
					b = 215;
				}
				tmpc = new Color(r,g,b);
				img.setRGB(i, j, tmpc.getRGB());
				
			}
		}
		return img;
	}
	
	public static BufferedImage RGBtoBinaryMED( BufferedImage originalimg) {
		BufferedImage img = originalimg;		
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		
		int r, g, b;
		for ( i=0; i<x; i++ ) { // i = x = column
			for ( j=0; j<y; j++ ) { // j = y = row
				Color c = new Color( img.getRGB(i, j) );
				r = c.getRed();
				g = c.getGreen();
				b = c.getBlue();
				Color cnew = new Color( (r+g+b)/3, (r+g+b)/3, (r+g+b)/3 );
				img.setRGB(i, j, cnew.getRGB());
			}
		}
		int median = medianOfGrayScale(img);		
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				Color co = new Color( img.getRGB(i, j) );
				if ( co.getBlue()<median ) { // r=g=b
					Color conew = new Color(40,40,40);
					img.setRGB(i, j, conew.getRGB());
				}
				else {
					Color conew = new Color(215,215,215);
					img.setRGB(i, j, conew.getRGB());
				}	
			}
		}
		return img;
	}
	
	public static BufferedImage RGBtoBinaryAVG( BufferedImage originalimg) {
		BufferedImage img = originalimg;		
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		
		int r, g, b;
		for ( i=0; i<x; i++ ) { // i = x = column
			for ( j=0; j<y; j++ ) { // j = y = row
				Color c = new Color( img.getRGB(i, j) );
				r = c.getRed();
				g = c.getGreen();
				b = c.getBlue();
				Color cnew = new Color( (r+g+b)/3, (r+g+b)/3, (r+g+b)/3 );
				img.setRGB(i, j, cnew.getRGB());
			}
		}
		int avg = avarageOfGrayscale(img);	
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				Color co = new Color( img.getRGB(i, j) );
				if ( co.getBlue()<avg ) { // r=g=b
					Color conew = new Color(40,40,40);
					img.setRGB(i, j, conew.getRGB());
				}
				else {
					Color conew = new Color(215,215,215);
					img.setRGB(i, j, conew.getRGB());
				}	
			}
		}
		return img;
	}
	
	public static BufferedImage RGBtoBinaryAVG_Color( BufferedImage originalimg) {
		BufferedImage img = originalimg;		
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		int avg = avarageOfRGB(img);	
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				if ( img.getRGB(i, j)<avg ) { // r=g=b
					img.setRGB(i, j, avg);
				}
				else {
					Color conew = new Color(215,215,215);
					img.setRGB(i, j, conew.getRGB());
				}	
			}
		}
		return img;
	}
	
	
	public static BufferedImage sortImage_Horizontal(BufferedImage originalimg) {
	
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight(); 
		int[] arr = new int[x];
		int col=0;
		for ( j=0; j<y; j++ ) {
			for ( i=0; i<x; i++ ) {
				arr[i] = img.getRGB(i, j);
			}
			SortingAlgorithms.heapSort(arr);
			for ( int k=0; k<x; k++ ) {
				img.setRGB(k, col, arr[k]);
			}
			col++;
		}
		return img;
	}
	
	public static BufferedImage sortImage_Vertical(BufferedImage originalimg) {
		
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight(); 
		int[] arr = new int[y];
		int row=0;
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				arr[j] = img.getRGB(i, j);
			}
			SortingAlgorithms.heapSort(arr);
			for ( int k=0; k<y; k++ ) {
				img.setRGB(row, k, arr[k]);
			}
			row++;
		}
		return img;
	}

	public static BufferedImage RGBtoErhanyGray( BufferedImage originalimg) {
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
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight(); 
		int[] arr1 = new int[x];
		int[] arr2 = new int[y];
		int[][] mat1 = new int[x][y];
		int[][] mat2 = new int[x][y];
		Color tmpc;
		i=0; j=0;
		for ( j=0; j<y; j++ ) {
			for ( i=0; i<x; i++ ) {
				tmpc = new Color( img.getRGB(i, j));
				arr1[i] = (tmpc.getBlue() + tmpc.getGreen() + tmpc.getRed()) / 3;
				
			}
			SortingAlgorithms.heapSort(arr1);
			for ( int k=0; k<x; k++ ) {
				mat1[k][j]=arr1[k];
			}
		}
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color( img.getRGB(i, j));
				arr2[j] = (tmpc.getBlue() + tmpc.getGreen() + tmpc.getRed()) / 3;
			}
			SortingAlgorithms.heapSort(arr2);
			for ( int k=0; k<y; k++ ) {
				mat2[i][k]=arr2[k];
			}
		}
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				mat1[i][j]=(mat1[i][j]+mat2[i][j]) / 2; 
				tmpc = new Color(mat1[i][j],mat1[i][j],mat1[i][j]);
				img.setRGB(i, j, tmpc.getRGB());
			}
		}
		int sum, tmp=9, k, l;
		for ( i=tmp; i<x-tmp; i++ ) {
			for ( j=tmp; j<y-tmp; j++ ) {
				sum=0;
				for ( k = i-tmp; k<i+tmp-1; k++ ) {
					for ( l = j-tmp; l<j+tmp-1; l++ ) {
						sum+=img.getRGB(k, l);
					}
				}
				for ( k = i-tmp; k<i+tmp-1; k++ ) {
					for ( l = j-tmp; l<j+tmp-1; l++ ) {
						img.setRGB(k, l, sum/((i+tmp-1)*(j+tmp-1)));
					}
				}
			}
		}
		return img;
	}
	
	public static BufferedImage RGBtoErhanyRGB_2(BufferedImage originalimg) {
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight(); 
		int[] arr1r = new int[x];
		int[] arr1g = new int[x];
		int[] arr1b = new int[x];
		int[] arr2r = new int[y];
		int[] arr2g = new int[y];
		int[] arr2b = new int[y];
		int[][] mat1r = new int[x][y];
		int[][] mat1g = new int[x][y];
		int[][] mat1b = new int[x][y];
		int[][] mat2r = new int[x][y];
		int[][] mat2g = new int[x][y];
		int[][] mat2b = new int[x][y];
		i=0; j=0;
		Color tmpc;
		for ( j=0; j<y; j++ ) {
			for ( i=0; i<x; i++ ) {
				tmpc = new Color(img.getRGB(i, j));
				arr1r[i] = tmpc.getRed();
				arr1g[i] = tmpc.getBlue();
				arr1b[i] = tmpc.getGreen();
			}
			ArrayAlgorithms.oddEvenParseHeaped(arr1r);
			ArrayAlgorithms.oddEvenParseHeaped(arr1g);
			ArrayAlgorithms.oddEvenParseHeaped(arr1b);
			for ( int k=0; k<x; k++ ) {
				mat1r[k][j]=arr1r[k];
				mat1g[k][j]=arr1r[k];
				mat1b[k][j]=arr1r[k];
			}
		}
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color(img.getRGB(i, j));
				arr2r[j] = tmpc.getRed();
				arr2g[j] = tmpc.getBlue();
				arr2b[j] = tmpc.getGreen();
			}
			ArrayAlgorithms.oddEvenParseHeaped(arr2r);
			ArrayAlgorithms.oddEvenParseHeaped(arr2g);
			ArrayAlgorithms.oddEvenParseHeaped(arr2b);
			for ( int k=0; k<y; k++ ) {
				mat2r[i][k]=arr2r[k];
				mat2g[i][k]=arr2g[k];
				mat2b[i][k]=arr2b[k];
			}
		}
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				mat1r[i][j]=(mat1r[i][j]+mat2r[i][j]) / 2;
				mat1g[i][j]=(mat1g[i][j]+mat2g[i][j]) / 2;
				mat1b[i][j]=(mat1b[i][j]+mat2b[i][j]) / 2;
				tmpc = new Color(mat1r[i][j],mat1g[i][j],mat1b[i][j]);
				img.setRGB(i, j, tmpc.getRGB());
			}
		}
		int sumr, sumg, sumb, tmp=3, k, l;
		for ( i=tmp; i<x-tmp; i++ ) {
			for ( j=tmp; j<y-tmp; j++ ) {
				sumr=0;
				sumg=0;
				sumb=0;
				for ( k = i-tmp; k<i+tmp-1; k++ ) {
					for ( l = j-tmp; l<j+tmp-1; l++ ) {
						tmpc = new Color( img.getRGB(k, l));
						sumr+=tmpc.getRed();
						sumg+=tmpc.getGreen();
						sumb+=tmpc.getBlue();
					}
				}
				for ( k = i-tmp; k<i+tmp-1; k++ ) {
					for ( l = j-tmp; l<j+tmp-1; l++ ) {
						tmpc = new Color(sumr/((i+tmp-1)*(j+tmp-1)),sumg/((i+tmp-1)*(j+tmp-1)),sumb/((i+tmp-1)*(j+tmp-1)));
						img.setRGB(k, l, tmpc.getRGB());
					}
				}
			}
		}
		return img;
	}
	
	public static BufferedImage RGBtoErhanyRGB(BufferedImage originalimg) {
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight(); 
		int[] arr1r = new int[x];
		int[] arr1g = new int[x];
		int[] arr1b = new int[x];
		int[] arr2r = new int[y];
		int[] arr2g = new int[y];
		int[] arr2b = new int[y];
		int[][] mat1r = new int[x][y];
		int[][] mat1g = new int[x][y];
		int[][] mat1b = new int[x][y];
		int[][] mat2r = new int[x][y];
		int[][] mat2g = new int[x][y];
		int[][] mat2b = new int[x][y];
		i=0; j=0;
		Color tmpc;
		for ( j=0; j<y; j++ ) {
			for ( i=0; i<x; i++ ) {
				tmpc = new Color(img.getRGB(i, j));
				arr1r[i] = tmpc.getRed();
				arr1g[i] = tmpc.getBlue();
				arr1b[i] = tmpc.getGreen();
			}
			SortingAlgorithms.heapSort(arr1r);
			SortingAlgorithms.heapSort(arr1g);
			SortingAlgorithms.heapSort(arr1b);
			for ( int k=0; k<x; k++ ) {
				mat1r[k][j]=arr1r[k];
				mat1g[k][j]=arr1r[k];
				mat1b[k][j]=arr1r[k];
			}
		}
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				tmpc = new Color(img.getRGB(i, j));
				arr2r[j] = tmpc.getRed();
				arr2g[j] = tmpc.getBlue();
				arr2b[j] = tmpc.getGreen();
			}
			SortingAlgorithms.heapSort(arr2r);
			SortingAlgorithms.heapSort(arr2g);
			SortingAlgorithms.heapSort(arr2b);
			for ( int k=0; k<y; k++ ) {
				mat2r[i][k]=arr2r[k];
				mat2g[i][k]=arr2g[k];
				mat2b[i][k]=arr2b[k];
			}
		}
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {
				mat1r[i][j]=(mat1r[i][j]+mat2r[i][j]) / 2;
				mat1g[i][j]=(mat1g[i][j]+mat2g[i][j]) / 2;
				mat1b[i][j]=(mat1b[i][j]+mat2b[i][j]) / 2;
				tmpc = new Color(mat1r[i][j],mat1g[i][j],mat1b[i][j]);
				img.setRGB(i, j, tmpc.getRGB());
			}
		}
		int sumr, sumg, sumb, tmp=3, k, l;
			for ( i=tmp; i<x-tmp; i++ ) {
				for ( j=tmp; j<y-tmp; j++ ) {
					sumr=0;
					sumg=0;
					sumb=0;
					for ( k = i-tmp; k<i+tmp-1; k++ ) {
						for ( l = j-tmp; l<j+tmp-1; l++ ) {
							tmpc = new Color( img.getRGB(k, l));
							sumr=(sumr+tmpc.getRed())/2;
							sumg=(sumg+tmpc.getGreen())/2;
							sumb=(sumb+tmpc.getBlue())/2;
						}
					}
					for ( k = i-tmp; k<i+tmp-1; k++ ) {
						for ( l = j-tmp; l<j+tmp-1; l++ ) {
							tmpc = new Color(sumr,sumg,sumb);
							img.setRGB(k, l, tmpc.getRGB());
						}
					}
				}
			}
			return img;
		
	}
	
	public static BufferedImage blurImage(BufferedImage originalimg, int blurdegree) { // needs optimization
		BufferedImage img = originalimg;
		int i, j, k, l;
		int x=img.getWidth();
		int y=img.getHeight();
		int sumr, sumg, sumb;
		Color tmp;
			for ( i=blurdegree; i<x-blurdegree; i++ ) {
				for ( j=blurdegree; j<y-blurdegree; j++ ) {
					sumr=0;
					sumg=0;
					sumb=0;
					for ( k = i-blurdegree; k<i+blurdegree; k++ ) {
						for ( l = j-blurdegree; l<j+blurdegree; l++ ) {
							tmp = new Color( img.getRGB(k, l));
							sumr=(sumr+tmp.getRed() )/2;
							sumg=(sumg+tmp.getGreen() )/2;
							sumb=(sumb+tmp.getBlue() )/2;
						}
					}
					tmp = new Color(sumr,sumg,sumb);
					for ( k = i-blurdegree; k<i+blurdegree; k++ ) {
						for ( l = j-blurdegree; l<j+blurdegree; l++ ) {							
							img.setRGB(k, l, tmp.getRGB());
						}
					}
				}
			}
			return img;
	}
	
	public static BufferedImage flip_Vertical(BufferedImage originalimg) {	
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		Color tmp;
		for ( j=0; j<y; j++ ) {
			for ( i=0; i<x/2; i++ ) {				
				tmp = new Color( img.getRGB(i, j));
				img.setRGB(i, j, img.getRGB(x-i-1, j));
				img.setRGB(x-i-1, j, tmp.getRGB());
			}
		}
		return img;
	}
	
	public static BufferedImage flip_Horizontal(BufferedImage originalimg) {	
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		Color tmp;
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y/2; j++ ) {				
				tmp = new Color( img.getRGB(i, j));
				img.setRGB(i, j, img.getRGB(i, y-j-1));
				img.setRGB(i, y-j-1, tmp.getRGB());
			}
		}
		return img;
	}
	
	public static BufferedImage rotate90_right(BufferedImage originalimg) {
		BufferedImage img = new BufferedImage(originalimg.getHeight(),originalimg.getWidth(),originalimg.getType());
		int i, j;
		int xorg = originalimg.getWidth();
		int yorg = originalimg.getHeight();
		int[] arr = new int[xorg];
		int k, l=0;
		for ( j=0; j<yorg; j++ ) {
			for ( i=0; i<xorg; i++ ) {
				arr[i]=originalimg.getRGB(i, j);
			}
			l++;
			for ( k=0; k<xorg; k++ ) {
				img.setRGB(yorg-l, k, arr[k]);
			}
		}
		return img;
	}
	
	public static BufferedImage rotate90_left(BufferedImage originalimg) {
		BufferedImage img = new BufferedImage(originalimg.getHeight(),originalimg.getWidth(),originalimg.getType());
		int i, j;
		int xorg = originalimg.getWidth();
		int yorg = originalimg.getHeight();
		int[] arr = new int[xorg];
		int k;
		for ( j=0; j<yorg; j++ ) {
			for ( i=0; i<xorg; i++ ) {
				arr[i]=originalimg.getRGB(i, j);
			}
			for ( k=0; k<xorg; k++ ) {
				img.setRGB(j, xorg-1-k, arr[k]);
			}
		}
		return img;
	}
	
	public static BufferedImage negative(BufferedImage originalimg) {
		BufferedImage img = originalimg;
		int i, j;
		int x=img.getWidth();
		int y=img.getHeight();
		Color tmpc;
		for ( i=0; i<x; i++ ) {
			for ( j=0; j<y; j++ ) {			
				tmpc = new Color(img.getRGB(i, j));
				tmpc = new Color(Math.abs(255-tmpc.getRed()),Math.abs(255-tmpc.getGreen()),Math.abs(255-tmpc.getBlue()));
				img.setRGB(i, j, tmpc.getRGB());
			}
		}
		return img;
	}
	
	public static BufferedImage randomImage(int width, int height) {
		BufferedImage img = new BufferedImage(width,height,BufferedImage.TYPE_INT_RGB);
		int[] reds = new int[img.getWidth()]; 
		int[] blues = new int[img.getWidth()]; 
		int[] greens = new int[img.getWidth()]; 
		Color tmpc;
		for ( int j=0; j<height; j++ ) {
			reds = GeneratorAlgorithms.generateArray_RANDOM(width, 255);
			blues = GeneratorAlgorithms.generateArray_RANDOM(width, 255);
			greens = GeneratorAlgorithms.generateArray_RANDOM(width, 255);
			for ( int i=0; i<width; i++ ) {
				tmpc = new Color(reds[i],blues[i],greens[i]);
				img.setRGB(i, j, tmpc.getRGB());
			}
		}
		return img;
		
	}

	
	
}
