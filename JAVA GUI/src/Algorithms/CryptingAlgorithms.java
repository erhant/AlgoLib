package Algorithms;


import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.Arrays;

public class CryptingAlgorithms {

	/**
	 * Deletes all present keys and lock arrays.
	 * 
	 */
	public static void SORTCRYPT_deleteAllKeys()  {
         (new File("masterkey.mkey")).delete();
         (new File("lock.arr")).delete();
         boolean success = true;
         int i=0;
         while ( success ) {
        	 success = (new File("key"+i+".skey")).delete();
        	 i++;
         }
	}
	private static int[][] SORTCRYPT_generatePairfromNormalArray( int arr[] ) {
			
	      int i, j;
	      int n = arr.length;
	      int[] positions = new int[n];
	      int[][] pair = new int[2][n]; // [0][n] = sorted array, [1][n] = positions at normal array;

	      int[] tmp = new int[n];
	      int[] s = new int[n];

	      for (  i=0; i<n; i++ ) {
	        for (  j=i+1; j<n; j++ ) {
	            if ( arr[i]>arr[j] ) {
	                s[i]++;
	            }
	            else {
	                s[j]++;
	            }
	        }
	      }
	      // at this point we have the position that every number should go in the S array
	      for (  i=0; i<n; i++ ) {
	        tmp[s[i]]=arr[i];
	        positions[s[i]]=i;
	      }
	      // transferring that sorted array back to
	      for ( i=0; i<n; i++ ) {
	    	  pair[0][i]=tmp[i];
	    	  pair[1][i]=positions[i];
	      }
	      return pair;
	}
	
	private static int[] SORTCRYPT_parseBottomRowfromPair( int[][] pair ) {
		/* For pair:
		 * Returns Positions
		 * For SPair:
		 * Returns Frequencies
		 */
		int n = pair[0].length;
		int[] arr = new int[n];
		for ( int i=0; i<n; i++ ) {
			arr[i]=pair[1][i];
		}
		return arr;
	}
	
	private static int[] SORTCRYPT_parseTopRowfromPair( int[][] pair ) {
		/* For pair:
		 * Returns Sorted Array
		 * For SPair:
		 * Returns Adders
		 */
		int n = pair[0].length;
		int[] arr = new int[n];
		for ( int i=0; i<n; i++ ) {
			arr[i]=pair[0][i];
		}
		return arr;
	}
	
	private static int[][] SORTCRYPT_generatePairfromSortedArray( int[] sortedarr ) {
		/*
		 * e.g. 
		 * 1 1 1 3 3 4 6 7 8 9 9
		 * Key[0][] : 1 2 1 2 1 1 1
		 * Key[1][] : 3 2 1 1 1 1 2
		 */
		int x = -1, k = -1, n = sortedarr.length, subber=0;
		int[][] tmp = new int[n][n];
		Arrays.fill(tmp[1], 1);
		for ( int i=0; i<n; i++ ) {
			if ( sortedarr[i]!=x ) {
				k++;
				x=sortedarr[i];
				tmp[0][k]=x-subber;
				subber=x;
			}
			else {
				tmp[1][k]++;
			}
		}
		int[][] spair = new int[2][k+1];
		for ( int i=0; i<=k; i++ ) {
			spair[0][i] = tmp[0][i];
			spair[1][i] = tmp[1][i];
		}
		return spair;
	}
	
	private static int[] SORTCRYPT_decryptPairOfNormalArray( int[] positions, int[] sortedarr ) {
		/* 
		 * IN A PAIR
		 * TOP ROW : SORTED ARRAY
		 * BOTTOM ROW : POSITIONS
		 */
		int n = sortedarr.length;
		int[] arr = new int[n];
		for ( int i=0; i<n; i++ ) {
			arr[positions[i]]=sortedarr[i];
		}
		return arr;
	}
	
	private static int[] SORTCRYPT_decryptPairOfSortedArray( int[] frequencies, int[] adders ) {
		/* 
		 * IN AN SPAIR
		 * TOP ROW : ADDERS
		 * BOTTOM ROW : FREQUENCIES 
		 * 
		 */
		int n=0, p=0;
		for ( int i=0; i<frequencies.length; i++ ) {
			n+=frequencies[i];
		}
		// now n becomes the length of normal array
		int[] arr = new int[n];
		int element = 0;
		for ( int i=0; i<adders.length; i++ ) {
			element+=adders[i];
			for ( int j=0; j<frequencies[i]; j++ ) {
				arr[p]=element;
				p++;
			}
		}
		return arr;
	}
	
	private static void SORTCRYPT_updateMasterKey( int[][] masterkey, int[] arr, int iteration ) {
		/*
		 * [0][] = positions
		 * [1][] = frequencies 1
		 * [2][] = frequencies 2
		 * [..][]
		 * 
		 */
		int n = arr.length;
		for ( int i=0; i<n; i++ ) {
			masterkey[iteration][i]=arr[i];
		}
	}
	
	public static void SORTCRYPT_demonstration( int[] arr ) {
		
		int[][] pair;
		int[][] spair;
		int iteration = 0;
		
		// everything here is done to find the iteration count
		int[] tmparr = arr;
		pair = CryptingAlgorithms.SORTCRYPT_generatePairfromNormalArray(tmparr);
		iteration++;
		spair = pair;
		while ( SearchAlgorithms.hasRecurrence(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(spair)) ) {
			spair = CryptingAlgorithms.SORTCRYPT_generatePairfromSortedArray(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(spair));
			iteration++;
		}
		
		// this is updating masterkey while crypting
		int[][] masterkey = new int[iteration][arr.length];
		iteration=0;
		pair = CryptingAlgorithms.SORTCRYPT_generatePairfromNormalArray(arr);
		MatrixAlgorithms.printMatrix(pair,"Iteration 0");
		CryptingAlgorithms.SORTCRYPT_updateMasterKey(masterkey, CryptingAlgorithms.SORTCRYPT_parseBottomRowfromPair(pair), iteration);
		iteration++;
		spair = pair;
		while ( SearchAlgorithms.hasRecurrence(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(spair)) ) {
			spair = CryptingAlgorithms.SORTCRYPT_generatePairfromSortedArray(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(spair));
			CryptingAlgorithms.SORTCRYPT_updateMasterKey(masterkey, CryptingAlgorithms.SORTCRYPT_parseBottomRowfromPair(spair), iteration);
			MatrixAlgorithms.printMatrix(spair,"Iteration Matrix "+iteration);
			iteration++;
		}
		arr = CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(spair);
		
		
		System.out.println("\nTotal Iterations : " + iteration);
		MatrixAlgorithms.printMatrix(masterkey,"Masterkey");
		System.out.println("Last Array on hand:\n" + ArrayAlgorithms.returnArrayString(arr));
		
		
		// this is decrypting
		for ( int i=masterkey.length-1; i>=1; i-- ) {
			arr = CryptingAlgorithms.SORTCRYPT_decryptPairOfSortedArray(masterkey[i], arr);
		}
		arr = CryptingAlgorithms.SORTCRYPT_decryptPairOfNormalArray(masterkey[0], arr);
		System.out.println("Decrypted Array:\n" + ArrayAlgorithms.returnArrayString(arr));
	}
	
	/**
	 * Decrypts a lock array using a masterkey.
	 * Returns the original array. 
	 * 
	 * @return
	 */
	public static int[] SORTCRYPT_decryptSingleMasterKey() {
		
		ObjectInputStream ois = null;
		int[][] masterkey = null;
		int[] lock = null;
		try {ois = new ObjectInputStream(new FileInputStream("masterkey.mkey"));
		} catch (FileNotFoundException e) {e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		
		try {masterkey = (int[][]) ois.readObject();
		} catch (ClassNotFoundException | IOException e) {e.printStackTrace();}
		
		try {ois = new ObjectInputStream(new FileInputStream("lock.arr"));
		} catch (FileNotFoundException e){e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		
		try {lock =  (int[]) ois.readObject();
		} catch (ClassNotFoundException | IOException e) {e.printStackTrace();}
		
		int iteration = masterkey.length;
		for ( int i=iteration-1; i>=1; i-- ) {
			lock = CryptingAlgorithms.SORTCRYPT_decryptPairOfSortedArray(masterkey[i], lock);
		}
		lock = CryptingAlgorithms.SORTCRYPT_decryptPairOfNormalArray(masterkey[0], lock);
		try {
			ois.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return lock;
	}
	
	private static int[] SORTCRYPT_decrypt( int[][] masterkey, int[] lastOnHand ) {
		
		int[] arr = new int[masterkey[0].length];
		int iteration = masterkey.length;
		for ( int i=iteration-1; i>=1; i-- ) {
			arr = CryptingAlgorithms.SORTCRYPT_decryptPairOfSortedArray(masterkey[i], arr);
		}
		arr = CryptingAlgorithms.SORTCRYPT_decryptPairOfNormalArray(masterkey[0], arr);
		return arr;
	}
	
	/**
	 * Decrypts a lock array using multiple keys
	 * Returns the original array. 
	 * 
	 */
	public static int[] SORTCRYPT_decryptMultiKey() {
		/*
		 * Make sure there was only one encryption was made 
		 * Other wise you will get exception.
		 */
		ObjectInputStream ois = null;
		int[] readKey = null;
		int[] lock = null;
		int p=0;
		boolean keysfinished=false;
		
		// going to the last key
		while ( !keysfinished ) {
			try {ois = new ObjectInputStream(new FileInputStream("key"+p+".skey"));
			} catch (FileNotFoundException e) { keysfinished=true; } catch (IOException e) {e.printStackTrace();}
			p++;
		}
		p-=2;
		try {ois = new ObjectInputStream(new FileInputStream("lock.arr"));
		} catch (FileNotFoundException e){e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		
		try {lock =  (int[]) ois.readObject();
		} catch (ClassNotFoundException | IOException e) {e.printStackTrace();}
		
		// these keys are frequency keys
		while ( p>0 ) {
			try {ois = new ObjectInputStream(new FileInputStream("key"+p+".skey"));
			} catch (FileNotFoundException e) { e.printStackTrace(); } catch (IOException e) {e.printStackTrace();}
			try {readKey = (int[]) ois.readObject();
			} catch (ClassNotFoundException | IOException e) {e.printStackTrace();}
			p--;
			lock = CryptingAlgorithms.SORTCRYPT_decryptPairOfSortedArray(readKey, lock);
		}
		
		// last key is the position key
		try {ois = new ObjectInputStream(new FileInputStream("key"+p+".skey"));
		} catch (FileNotFoundException e) { e.printStackTrace(); } catch (IOException e) {e.printStackTrace();}
		try {readKey = (int[]) ois.readObject();
		} catch (ClassNotFoundException | IOException e) {e.printStackTrace();}
		p--;
		lock = CryptingAlgorithms.SORTCRYPT_decryptPairOfNormalArray(readKey, lock);
		try {
			ois.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return lock;
	}
	
	private static int SORTCRYPT_findIterationCount( int[] arr ) {
		
		int iteration=0;
		int[][] pair;
		int[] tmparr = arr;
		pair = CryptingAlgorithms.SORTCRYPT_generatePairfromNormalArray(tmparr);
		iteration++;
		while ( SearchAlgorithms.hasRecurrence(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair)) ) {
			pair = CryptingAlgorithms.SORTCRYPT_generatePairfromSortedArray(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair));
			iteration++;
		}
		return iteration;
	}
	
	/**
	 * Encrypts an array using sortCrypt method by Erhan Tezcan
	 * Writes a single masterkey to a file, as well as lock array
	 * 
	 * @param initial array
	 * @return lock array
	 */
	public static int[] SORTCRYPT_encryptSingleMasterKey( int[] arr ) {
		SORTCRYPT_deleteAllKeys();
		int iteration = SORTCRYPT_findIterationCount(arr);
		int[][] pair;
		int[][] masterkey = new int[iteration][arr.length];
		iteration=0;
		pair = CryptingAlgorithms.SORTCRYPT_generatePairfromNormalArray(arr);
		CryptingAlgorithms.SORTCRYPT_updateMasterKey(masterkey, CryptingAlgorithms.SORTCRYPT_parseBottomRowfromPair(pair), iteration);
		iteration++;
		while ( SearchAlgorithms.hasRecurrence(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair)) ) {
			pair = CryptingAlgorithms.SORTCRYPT_generatePairfromSortedArray(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair));
			CryptingAlgorithms.SORTCRYPT_updateMasterKey(masterkey, CryptingAlgorithms.SORTCRYPT_parseBottomRowfromPair(pair), iteration);
			iteration++;
		}
		arr = CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair);
		// writing masterkey to a file
		ObjectOutputStream oos = null;
		try { oos = new ObjectOutputStream(new FileOutputStream("masterkey.mkey"));
		} catch (FileNotFoundException e) {e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		
		try {oos.writeObject(masterkey);
		} catch (IOException e) {e.printStackTrace();} catch (NullPointerException e) {e.printStackTrace();}
		
		try {oos = new ObjectOutputStream(new FileOutputStream("lock.arr"));
		} catch (FileNotFoundException e) {e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		
		try { oos.writeObject(arr); 
		} catch (IOException e) {e.printStackTrace();}
		try {
			oos.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return arr;
	}
	
	/**
	 * Encrypts an array using the sortCrypt method by Erhan Tezcan
	 * Uses multi-key method to create as many keys neccessary.
	 * Writes them in the file in precedence order.
	 * key0 is crucial.
	 * Also writes the lock array to a file.
	 * @param initial array
	 * @return lock array
	 */
	public static int[] SORTCRYPT_encryptMultiKey( int[] arr ) {
		SORTCRYPT_deleteAllKeys();
		int[][] pair;
		int iteration = 0;
		ObjectOutputStream oos = null;
		pair = CryptingAlgorithms.SORTCRYPT_generatePairfromNormalArray(arr);
		try { oos = new ObjectOutputStream(new FileOutputStream("key"+iteration+".skey"));
		} catch (FileNotFoundException e) {e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		try {oos.writeObject(CryptingAlgorithms.SORTCRYPT_parseBottomRowfromPair(pair));
		} catch (IOException e) {e.printStackTrace();} catch (NullPointerException e) {e.printStackTrace();}
		iteration++;
		while ( SearchAlgorithms.hasRecurrence(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair)) ) {
			pair = CryptingAlgorithms.SORTCRYPT_generatePairfromSortedArray(CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair));
			try { oos = new ObjectOutputStream(new FileOutputStream("key"+iteration+".skey"));
			} catch (FileNotFoundException e) {e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
			try {oos.writeObject(CryptingAlgorithms.SORTCRYPT_parseBottomRowfromPair(pair));
			} catch (IOException e) {e.printStackTrace();} catch (NullPointerException e) {e.printStackTrace();}
			iteration++;
		}
		arr = CryptingAlgorithms.SORTCRYPT_parseTopRowfromPair(pair);
		
		
		
		try {oos = new ObjectOutputStream(new FileOutputStream("lock.arr"));
		} catch (FileNotFoundException e) {e.printStackTrace();} catch (IOException e) {e.printStackTrace();}
		
		try { oos.writeObject(arr); 
		} catch (IOException e) {e.printStackTrace();}
		try {
			oos.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return arr;
	}
	
	
}





















