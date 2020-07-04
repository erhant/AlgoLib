package Algorithms;


public class MatrixAlgorithms {
	
	public static void printMatrix(int[][] mat) {
		int rows = mat.length;
		int cols = mat[0].length;
		for ( int i=0; i<rows; i++ ) {
			System.out.print("\n"+i+":\t");
			for ( int j=0; j<cols; j++ ) {
				System.out.print(mat[i][j]+"\t");
			}
 		}
		System.out.println("");
	}
	
	public static void printMatrix(int[][] mat, String matrixname) {
		int rows = mat.length;
		int cols = mat[0].length;
		System.out.print("\n"+matrixname+":");
		for ( int i=0; i<rows; i++ ) {
			System.out.print("\n"+i+":\t");
			for ( int j=0; j<cols; j++ ) {
				System.out.print(mat[i][j]+"\t");
			}
 		}
		System.out.println("");
	}
	
}
