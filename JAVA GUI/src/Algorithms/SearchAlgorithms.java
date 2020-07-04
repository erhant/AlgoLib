package Algorithms;

public class SearchAlgorithms {
	
	public static int findMax( int []arr, int from, int to ) {
		int maxpos=from, n = arr.length;
		if ( from>=0 && to<n ) {
			for ( int i=from; i<=to; i++)
		        if ( arr[i]>arr[maxpos] )
		            maxpos=i;
		    return arr[maxpos];
		} else {
			return -1;
		}
	}
	
	public static int findMin( int []arr, int from, int to ) {
		int minpos=from, n = arr.length;
		if ( from>=0 && to<n ) {
		    for ( int i=from; i<to; i++)
		    	if ( arr[i]<arr[minpos] )
		    		minpos=i;
		    return arr[minpos];
		} else {
			return -1;
		}
	}
	
	public static int findMin ( int []arr ) {
	    int minpos=0, n=arr.length;
	    for ( int i=1; i<n; i++)
	    	if ( arr[i]<arr[minpos] )
	    		minpos=i;
	    return arr[minpos];
	}
	
	public static int findMax ( int []arr ) {
	    int maxpos=0, n = arr.length;
	    for ( int i=1; i<n; i++)
	        if ( arr[i]>arr[maxpos] )
	            maxpos=i;
	    return arr[maxpos];
	}
	
	public static int binarySearch ( int []arr, int x ) {

		int n = arr.length;
	    int left=0, right=n-1, center; 
	    center=(left+right)/2;
	    while ( (left<=right) && (arr[center]!=x) ) {
	        if ( x>arr[center] ) {
	        	left=center+1;
	        } else {
	        	right=center-1;
	        }
	        center=(left+right)/2;
	    }
	    if ( left>right ) {
	        return -1;
	    }
	    return center;
	    
	}
	
	public static int linearSearch ( int []arr, int x ) {		
	    int n = arr.length;
		int i=0;
	    while ( i<n && arr[i]!=x )
	        i++;
	    if ( i>=n ) {
	    	return -1;
	    }
	    else {
	    	return i;
	    }
	}
	
	public static int findMedian( int arr[] ) {
		int n=arr.length;
		int[] s = new int[n];
	    for ( int i=0; i<n; i++ ) {
	        for ( int j=i+1; j<n; j++ ) {
	            if ( arr[i]>arr[j] ) {
	                s[i]++;
	            }
	            else {
	                s[j]++;
	            }
	        }
	    }
	    int i=0;
	    while ( s[i]!=n/2 ) {
	    	i++;
	    }
	    return arr[i];
	}
	
	public static int findAvarage( int arr[] ) {
		int n=arr.length;
		int sum=0;
		for ( int i=0; i<n; i++ ) {
			sum+=arr[i];
		}
		return sum/n;
	}
	
	public static boolean hasRecurrence( int arr[] ) {
		boolean recurs=false;
		int n = arr.length, control, k=0;
		int[] b = new int[n];
		for ( int i=0; i<n; i++ ) {
			control = SearchAlgorithms.linearSearch(b, arr[i]);
			if ( control==-1 ) {
				b[k]=arr[i];
				k++;
			}
			else {
				recurs=true;
			}
		}
		return recurs;
	}
	
	public static int findMostRecurringElement( int arr[] ) {
		int n = arr.length;
		int k=0, control;
		int[] kinds = new int[n];
		int[] counts = new int[n];
		for ( int i=0; i<n; i++ ) {
			control = SearchAlgorithms.linearSearch(kinds, arr[i]);
			if ( control==-1 ) {
				kinds[k]=arr[i];
				counts[k]++;
				k++;
			}
			else {
				counts[control]++;
			}
		}		
		return kinds[SearchAlgorithms.linearSearch(counts, findMax(counts))];
	}
	
	
	
}
