package Algorithms;
import java.util.Random;

public class GeneratorAlgorithms {
	
	private static Random r = new Random();	
	
	public static int[] generateArray_SORTED_ASCENDING( int n, int max, int adder ) {

		int[] arr = new int[n];
	    arr[0]=r.nextInt(max)+1;
	    for ( int i=1; i<n; i++ ) {
	    	arr[i]=arr[i-1] + r.nextInt(adder)+1;
	    }
	    return arr;
	}
	
	
	public static int[] generateArray_SORTED_DESCENDING( int n, int max, int adder ) {

		int[] arr = new int[n];
	    arr[n-1]=r.nextInt(max)+1;
	    for ( int i=n-2; i>=0; i-- ) {
	    	arr[i]=arr[i+1] + r.nextInt(adder)+1;
	    }
	    return arr;
	}
	
	
	public static int[] generateArray_RANDOM( int n, int max ) {

		int[] arr = new int[n];
	    for ( int i=0; i<n; i++ ) {
	        arr[i]=r.nextInt(max)+1;
	    }
	    return arr;
	}
	
	
	public static int[] generateArray_RANDOM_NORECUR( int n, int max, int adder ) {

		int[] arr = new int[n];
	    int rdm_min, rdm_pos, coefficient, i=0;
	    rdm_min=r.nextInt(max)+1;
	    arr[r.nextInt(n)]=rdm_min;
	    while ( i<(n-1) ) {
	        rdm_pos=r.nextInt(n);
	        if ( arr[rdm_pos]==0 ) {
	            coefficient=r.nextInt(adder)+1;
	            rdm_min+=coefficient;
	            arr[rdm_pos]=rdm_min;
	            i++;
	        }
	    }
	    return arr;
	}
	
	
	public static int[] generateArray_SEQUENTIAL( int n, int max, int adder ) {
		
		int[] arr = new int[n];
		int rdm_min, rdm_pos, coefficient, i=0;
	    rdm_min=r.nextInt(max)+1;
	    coefficient=r.nextInt(adder)+1;
	    arr[r.nextInt(n)]=rdm_min;
	    while ( i<(n-1) ) {
	        rdm_pos=r.nextInt(n);
	        if ( arr[rdm_pos]==0 ) {
	            rdm_min+=coefficient;
	            arr[rdm_pos]=rdm_min;
	            i++;
	        }
	    }
	    return arr;
	}
	
	
	public static int[] generateArray_INCREMENTIAL( int n , int max ) {
		
		int[] arr = new int[n];
	    int rdm_min, rdm_pos, coefficient, i=0;
	    rdm_min=r.nextInt(max)+1;
	    coefficient=1;
	    arr[r.nextInt(n)]=rdm_min;
	    while ( i<(n-1) ) {
	        rdm_pos=r.nextInt(n);
	        if ( arr[rdm_pos]==0 ) {
	            rdm_min+=coefficient;
	            arr[rdm_pos]=rdm_min;
	            i++;
	        }
	    }
	    return arr;
	}
	
	public static int[][] generateMatrix_RANDOM( int n, int m, int max ) {
		int[][] mat = new int[n][m];
		for ( int i=0; i<n; i++ ) {
			for ( int j=0; j<m; j++ ) {
				mat[i][j]=r.nextInt(max)+1;
			}
		}
		return mat;
	}
	
	public static int[] generateMatrix_FIBONACCI( int n ) {
		int[] arr = new int[n];
		
		int num1=1; int num2=2;
		arr[0]=num1;
		arr[1]=num2;
		n-=2;
		int p=2;
		while ( n>0 ) {
			num2=num1+num2;
			num1=num2-num1;
			n--;
			arr[p]=num2;
			p++;
		}		
		return arr;
		
	}
	
//	public static int[][] generateMatrix_Latin( int n, int m, int max ) {
//		
//		int[][] mat = new int[n][m];
//		
//		
//	}
	
	
}
