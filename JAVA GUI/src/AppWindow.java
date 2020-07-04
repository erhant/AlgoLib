import Algorithms.ArrayAlgorithms;
import Algorithms.CryptingAlgorithms;
import Algorithms.GeneratorAlgorithms;
import Algorithms.MatrixAlgorithms;
import Algorithms.NumberAlgorithms;
import Algorithms.SearchAlgorithms;
import Frames.ArrayAlgPanel;
import Frames.ImageAlgPanel;
import Frames.NumberAlgPanel;

public class AppWindow {
	
	
	public static void main( String args[] ) {
		
		ImageAlgPanel imageOperations = new ImageAlgPanel();
		ArrayAlgPanel arrayOperations = new ArrayAlgPanel();
		NumberAlgPanel numberOperations = new NumberAlgPanel();
		int[] arr = {1, 3, 4, 5, 7, 2, 3, 4, 5, 6, 7, 9};
		CryptingAlgorithms.SORTCRYPT_demonstration(arr);
//		System.out.println(NumberAlgorithms.reverseNumber(234)+"");
	}
	
}
