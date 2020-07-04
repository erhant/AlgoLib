package Algorithms;

import java.util.ArrayList;

public class TezcanAlgorithms {

	public static String collatzTezcanForm_2nd ( int num ) {
		String s="";
		int twos=0, threes=0;
		while ( num!=1 ) {
			if ( num % 2 == 0 ) {
				num=num >> 1;
				twos++;
				if ( num % 2 == 1 ) {
					s+="2("+twos+"), ";	
				}						
			}
			else {
				num=num*3 + 1;
				threes++;
			}
		}
		s+="3("+threes+")";	
		return s;
	}
	
	public static String collatzTezcanForm_1st( int num ) {
		String s="";
		
			while ( num!=1 ) {
				if ( num % 2 == 0 ) {
					num=num >> 1;
					s+="2, ";			
				}
				else {
					num=num*3 + 1;
					s+="3, ";	
				}
			}
					
		return s;
	}
	
	public static boolean satisfy_N_piece(int num, int piece) {
		long ans = (long) (Math.pow(3, piece)*num + Math.pow(3, piece-1));
		//System.out.println("Num = "+num+" , Piece = "+piece+" , Ans = "+ans);
		for ( int i=piece-2; i>=0; i-- ) {
			while ( ans % 2 == 0 ) {
				ans = ans / 2;
			}
			ans+=Math.pow(3, i);
		}
		while ( ans>1 && ans%2==0 ) {
			ans=ans/2;
		}
		if ( ans==1 ) {
			return true;
		}
		else {
			return false;
		}
	}
	
	public static ArrayList<Integer> satisfies_M_PIECE_UPTO_N(int n, int m) {
		ArrayList<Integer> list = new ArrayList<Integer>();
		for ( int i=1; i<=n; i+=2 ) {
			if ( satisfy_N_piece(i, m) ) {
				list.add(i);
			}
		}
		return list;
	}
	
	public static ArrayList<Integer> satisfies_M_PIECE_UPTO_N_UNIQUE(int n, int m) {
		ArrayList<Integer> list = new ArrayList<Integer>();
		for ( int i=1; i<=n; i+=2 ) {
			if ( satisfy_N_piece(i, m) && !(satisfy_N_piece(i, m-1)) ) {
				list.add(i);
			}
		}
		return list;
	}
	
	public static double satisifiers_UPTO_N_ratio(int n, int piece) {
		double ans=0;
		for ( int i=1; i<=n; i+=2 ) {
			if ( satisfy_N_piece(i, piece) ) {
				ans++;
			}
		}
		ans = ans / ((n+1)/2);
		
		return ans;
	}
	
	public static int pieceSize ( int num ) {
		int ans=0;
		while ( num!=1 ) {
			if ( num % 2 == 0 ) {
				num=num >> 1;		
			}
			else {
				num=num*3 + 1;
				ans++;
			}
		}
		return ans;
	}
	
	public static String max_piece_UPTO_N(int n) {
		int maxno=1, maxpiece=0;
		for ( int i=1; i<=n; i++ ) {
			if ( pieceSize(i)>=maxpiece ) {
				maxpiece = pieceSize(i);
				maxno=i;
			}
		}
		return "Number "+maxno+" with "+maxpiece+" pieces has the maximum piece count";
	}
}
