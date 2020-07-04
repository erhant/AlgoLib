package Algorithms;

import java.util.ArrayList;

public class GraphAlgorithms {

	private class Node {
		int data;
		int id;
		boolean marked=false;
		ArrayList<Node> adjacentNodes = new ArrayList<Node>();
	}
}
