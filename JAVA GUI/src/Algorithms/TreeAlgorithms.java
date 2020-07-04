package Algorithms;

public class TreeAlgorithms {
	
	private class Node {
	    int data;
	    Node left;
	    Node right;
	}
	
	void printPostOrder(Node root) {
	    if(root == null) {
	        return;
	    }
	    else {
	    	printPostOrder(root.left);
	    	printPostOrder(root.right);
	        System.out.print(root.data + " ");
	    }
	}
	
	void printPreOrder(Node root) {
	    System.out.print(root.data + " ");

	    if (root.left != null) {
	    	printPreOrder(root.left);
	    } 
	    
	    if (root.right != null) {
	    	printPreOrder(root.right);
	    }
	}

}
