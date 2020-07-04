package Algorithms;

public class SortingAlgorithms {
	
	
	public static void selectionSortAscending (int[] arr) {
		
	      int i, j, minIndex, tmp;
	      int n = arr.length;
	      for (i = 0; i < n - 1; i++) {
	            minIndex = i;
	            for (j = i + 1; j < n; j++)
	                  if (arr[j] < arr[minIndex])
	                        minIndex = j;
	            if (minIndex != i) {
	                  tmp = arr[i];
	                  arr[i] = arr[minIndex];
	                  arr[minIndex] = tmp;
	            }
	      }
	}
	
	public static void selectionSortDescending (int[] arr) {
		
	      int i, j, maxIndex, tmp;
	      int n = arr.length;
	      for (i = 0; i < n - 1; i++) {
	    	  maxIndex = i;
	            for (j = i + 1; j < n; j++)
	                  if (arr[j] > arr[maxIndex])
	                	  maxIndex = j;
	            if (maxIndex != i) {
	                  tmp = arr[i];
	                  arr[i] = arr[maxIndex];
	                  arr[maxIndex] = tmp;
	            }
	      }
	}
	
	public static void bubbleSort ( int []arr ) {
		
		int n = arr.length;
	    int tmp;
	    boolean ctrl=true;
	    while ( ctrl ) {
	        ctrl=false;
	        for ( int i=0; i<n-1; i++ ) {
	            if ( arr[i]>arr[i+1] ) {
	                tmp=arr[i];
	                arr[i]=arr[i+1];
	                arr[i+1]=tmp;
	                ctrl=true;
	    			}
	            }
	        }
	}
	
	public static void heapSort(int arr[]) {
		
		int n = arr.length;
	    int i, tmp;
	    // Build heap (rearrange array)
	    for ( i=(n/2)-1; i>=0; i-- )
	        heapify(arr, n, i);

	    // One by one extract an element from heap
	    for ( i=n-1; i>=0; i--) {
	        // Swap current root with end
	        tmp=arr[0];
	        arr[0]=arr[i];
	        arr[i]=tmp;
	        // call max heapify on the reduced heap
	        heapify(arr, i, 0);
	    }
	}
	
	public static void linearCountingSort_Score( int []arr ) {
		
		int n = arr.length;
	    int[] tmp = new int[n];
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
	    // at this point we have the position that every number should go in the S array
	    // making a sorted array out of the given array
	    for ( int i=0; i<n; i++ ) {
	        tmp[s[i]]=arr[i];
	    }
	    // transferring that sorted array back to our normal array
	    for ( int i=0; i<n; i++ ) {
	        arr[i]=tmp[i];
	    }
	}
	
    public static void linearCountingSort_Freq( int []arr ) {
		
		int n = arr.length;
		int min, max, i, j;

	    min=arr[0];
	    max=arr[0];
	    for ( i=0; i<n; i++ ) {
	        if ( arr[i]<min ) {
	            min=arr[i];
	        }
	        else {
	            if ( arr[i]>max ) {
	                max=arr[i];
	            }
	        }
	    }
	    int[] f = new int[max-min+1];
	    for ( i=0; i<n; i++ ) {
	    	f[arr[i]-min]++;
	    }
	    j=0;
	    for ( i=0; i<f.length; i++ ) {
	    	while ( f[i]!=0 ) {
	    		arr[j]=i+min;
	    		j++;
	    		f[i]--;
	    	}
	    }
	    
	}
	
	
	public static void thermoSort ( int []arr ) { // works only when sorted array looks like : x, x+k, x+2k, x+3k, ..., x+n*k

		int n = arr.length;
	    int maxv, minv, i, pos; //swaps=0;
	    int[] newArr = new int[n];

	    minv=arr[0];
	    maxv=arr[0];
	    for ( i=1; i<n; i++ ) {
	        if ( arr[i]<minv ) {
	            minv=arr[i];
	        }
	        else {
	            if ( arr[i]>maxv ) {
	                maxv=arr[i];
	            }
	        }
	    }
	    for ( i=0; i<n; i++ ) {
	        pos = (( (arr[i]-minv)*(n-1) )/ (maxv-minv));
	        if ( newArr[pos]!=0 ) {
	        	throw ( new ArrayIndexOutOfBoundsException() );
	        }
	        newArr[pos]=arr[i];
	    }
	    for ( i=0; i<n; i++ ) {
	        arr[i]=newArr[i];
	    }

	}
	
	public static void instaSort( int []arr ) { // works only when sorted array looks like : x, x+1, x+2, x+3, ..., x+n
		
		int n = arr.length;
		int b[] = new int[n];
		int min=arr[0];
		for ( int i=1; i<n; i++ ) {
			if ( arr[i]<min ) {
	            min=arr[i];
	        }
		}
		for ( int i=0; i<n; i++ ) {
			b[arr[i]-min]=arr[i];
		}
		for ( int i=0; i<n; i++ ) {
			if ( b[i]==0 ) {
	        	throw ( new ArrayIndexOutOfBoundsException() );
	        }
			arr[i]=b[i];
		}
		
	}
	
	private static void heapify(int arr[], int n, int i) {
	    int tmp;
	    int largest=i;  // Initialize largest as root
	    int l=2*i + 1;  // left = 2*i + 1
	    int r=2*i + 2;  // right = 2*i + 2

	    // If left child is larger than root
	    if (l<n && arr[l]>arr[largest])
	        largest = l;

	    // If right child is larger than largest so far
	    if (r<n && arr[r]>arr[largest])
	        largest = r;

	    // If largest is not root
	    if (largest!=i) {
	        tmp=arr[i];
	        arr[i]=arr[largest];
	        arr[largest]=tmp;
	        // Recursively heapify the affected sub-tree
	        heapify(arr, n, largest);
	    }
	}
	
	
}
