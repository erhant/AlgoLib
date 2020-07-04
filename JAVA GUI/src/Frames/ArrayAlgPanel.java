package Frames;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.SystemColor;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileNotFoundException;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JSlider;
import javax.swing.JTextArea;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import Algorithms.ArrayAlgorithms;
import Algorithms.CryptingAlgorithms;
import Algorithms.GeneratorAlgorithms;
import Algorithms.SearchAlgorithms;
import Algorithms.SortingAlgorithms;

import javax.swing.JTextField;
public class ArrayAlgPanel extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = -5113019782095687886L;
	private JTextArea arrout;
	private int[] arr;
	private int n = 60;
	private JSlider slider;
	private JLabel errorlabel;
	private int max = 40;
	private int adder = 2;
	private JTextField tfSearch;
	private JLabel timeLabel;
	private long time; // time
	
	public ArrayAlgPanel() {
		setTitle("Array Algorithms");
		setVisible(true);
		setSize(1111, 404);
		getContentPane().setLayout(null);
		setResizable(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Timer t = new Timer();
		JMenuBar algorithmsBar = new JMenuBar();
		setJMenuBar(algorithmsBar);
		JPanel sortingpanel = new JPanel();
		sortingpanel.setLocation(0, 0);
		sortingpanel.setSize(1090, 345);
		sortingpanel.setLayout(null);
		getContentPane().add(sortingpanel);
		
		JLabel lblRandMax = new JLabel("Rand Max");
		lblRandMax.setBounds(391, 299, 91, 14);
		sortingpanel.add(lblRandMax);
		
		JLabel lblAdder = new JLabel("Adder");
		lblAdder.setBounds(389, 325, 45, 14);
		sortingpanel.add(lblAdder);
		
		errorlabel = new JLabel("");
		errorlabel.setFont(new Font("Tahoma", Font.BOLD, 15));
		errorlabel.setBounds(22, 270, 562, 23);
		sortingpanel.add(errorlabel);
		
		tfSearch = new JTextField();
		tfSearch.setText("5");
		tfSearch.setBounds(462, 296, 39, 20);
		sortingpanel.add(tfSearch);
		tfSearch.setColumns(10);
		
		JLabel lblSearch = new JLabel("Search");
		lblSearch.setBounds(511, 299, 45, 14);
		sortingpanel.add(lblSearch);
		
		JMenu sortMenu = new JMenu("Sort");
		JMenu selectionSort = new JMenu("Selection Sort");
		sortMenu.add(selectionSort);
		JMenuItem selectionSortasc = new JMenuItem("Ascending");
		selectionSortasc.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					time = System.nanoTime();
					SortingAlgorithms.selectionSortAscending(arr);
					time = System.nanoTime() - time; 
					updateTimeLabel(time);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}
			}			
			
		});
		selectionSort.add(selectionSortasc);
		JMenuItem selectionSortdesc = new JMenuItem("Descending");
		selectionSortdesc.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					time = System.nanoTime();
					SortingAlgorithms.selectionSortDescending(arr);
					time = System.nanoTime() - time; 
					updateTimeLabel(time);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}
			}			
			
		});
		selectionSort.add(selectionSortdesc);
		JMenuItem bubbleSort = new JMenuItem("Bubble Sort");
		bubbleSort.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					time = System.nanoTime();
					SortingAlgorithms.bubbleSort(arr);
					time = System.nanoTime() - time; 
					updateTimeLabel(time);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}
			}	
		});
		sortMenu.add(bubbleSort);
		JMenu countSorts = new JMenu("Counting Sort");
		sortMenu.add(countSorts);
		JMenuItem countingSort_freq = new JMenuItem("Frequency");
		countingSort_freq.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					time = System.nanoTime();
					SortingAlgorithms.linearCountingSort_Freq(arr);
					time = System.nanoTime() - time; 
					updateTimeLabel(time);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}
			}	
		});		
		countSorts.add(countingSort_freq);
		JMenuItem countingSort_score = new JMenuItem("Score");
		countingSort_score.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					time = System.nanoTime();
					SortingAlgorithms.linearCountingSort_Score(arr);
					time = System.nanoTime() - time; 
					updateTimeLabel(time);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}
			}	
		});
		countSorts.add(countingSort_score);
		JMenuItem thermoSort = new JMenuItem("Thermo Sort*");
		thermoSort.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					
					try {
						time = System.nanoTime();
						SortingAlgorithms.thermoSort(arr);
						time = System.nanoTime() - time; 
						updateTimeLabel(time);
						arrout.setText(ArrayAlgorithms.returnArrayString(arr));
					}
					catch ( ArrayIndexOutOfBoundsException e ) {
						errorlabel.setText("Dont use this sort with non-uniform arrays");
					}
					
				}
			}	
		});
		sortMenu.add(thermoSort);
		JMenuItem instaSort = new JMenuItem("Insta Sort*");
		instaSort.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					try {
						time = System.nanoTime();
						SortingAlgorithms.instaSort(arr);
						time = System.nanoTime() - time; 
						updateTimeLabel(time);
						arrout.setText(ArrayAlgorithms.returnArrayString(arr));
					}
					catch ( ArrayIndexOutOfBoundsException e ) {
						errorlabel.setText("Dont use this sort with non-incremential arrays");
						t.schedule(new TimerTask() {

							@Override
							public void run() {
								// TODO Auto-generated method stub
								errorlabel.setText("");
							}
							
						}, 3000);
					}
					
				}
			}	
		});
		sortMenu.add(instaSort);
		
		JMenu editMenu = new JMenu("Edit");
		JMenuItem shuffleArray = new JMenuItem("Shuffle Elements");
		shuffleArray.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					ArrayAlgorithms.shuffleElements(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}
			}	
		});
		editMenu.add(shuffleArray);
		JMenuItem elimRecurrence = new JMenuItem("Eliminate Recurrences");
		elimRecurrence.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					arr = ArrayAlgorithms.eliminateRecurrence(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
					setN(arr.length);
					slider.setValue(n);
				}
			}	
		});
		editMenu.add(elimRecurrence);
		JMenuItem elimPlateau = new JMenuItem("Eliminate Plateaus");
		elimPlateau.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if ( arr!=null ) {
					arr = ArrayAlgorithms.eliminatePlateau(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
					setN(arr.length);
					slider.setValue(n);
				}
			}	
		});
		editMenu.add(elimPlateau);
		JMenuItem rotateLeft = new JMenuItem("Rotate Left");
		rotateLeft.addActionListener(new ActionListener() {			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if ( arr!=null ) {
					ArrayAlgorithms.rotateLeft(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}				
			}
		});
		editMenu.add(rotateLeft);
		JMenuItem rotateRight = new JMenuItem("Rotate Right");
		rotateRight.addActionListener(new ActionListener() {			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if ( arr!=null ) {
					ArrayAlgorithms.rotateRight(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}				
			}
		});
		editMenu.add(rotateRight);
		JMenuItem oddEvenParse = new JMenuItem("Parse Odd-Even");
		oddEvenParse.addActionListener(new ActionListener() {			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if ( arr!=null ) {
					ArrayAlgorithms.oddEvenParse(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}				
			}
		});
		editMenu.add(oddEvenParse);
		JMenuItem oddEvenParseSorted = new JMenuItem("Parse Odd-Even Sorted");
		oddEvenParseSorted.addActionListener(new ActionListener() {			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if ( arr!=null ) {
					ArrayAlgorithms.oddEvenParseHeaped(arr);
					arrout.setText(ArrayAlgorithms.returnArrayString(arr));
				}				
			}
		});
		editMenu.add(oddEvenParseSorted);
		
		JMenu generateMenu = new JMenu("Generate");
		JMenuItem gen_random = new JMenuItem("Random");
		gen_random.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateArray_RANDOM(n, max);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_random);
		JMenuItem gen_random_norecur = new JMenuItem("Random & No Recurrence");
		gen_random_norecur.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateArray_RANDOM_NORECUR(n, max, adder);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_random_norecur);
		JMenuItem gen_sorted_a = new JMenuItem("Sorted Ascending");
		gen_sorted_a.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateArray_SORTED_ASCENDING(n, max, adder);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_sorted_a);
		JMenuItem gen_sorted_d = new JMenuItem("Sorted Descending");
		gen_sorted_d.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateArray_SORTED_DESCENDING(n, max, adder);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_sorted_d);
		JMenuItem gen_sequential = new JMenuItem("Sequential");
		gen_sequential.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateArray_SEQUENTIAL(n, max, adder);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_sequential);
		JMenuItem gen_incremential = new JMenuItem("Incremential");
		gen_incremential.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateArray_INCREMENTIAL(n, max);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_incremential);
		JMenuItem gen_custom = new JMenuItem("Custom");
		gen_custom.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				new CustomArrayWindow(getMyself());
			}			
		});
		generateMenu.add(gen_custom);
		JMenuItem gen_fibonacci = new JMenuItem("Fibonacci");
		gen_fibonacci.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = GeneratorAlgorithms.generateMatrix_FIBONACCI(n);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		generateMenu.add(gen_fibonacci);
		
		
		JMenu searchMenu = new JMenu("Search");
		JMenuItem findMax = new JMenuItem("Find Max");
		findMax.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int res = SearchAlgorithms.findMax(arr);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nMax = "+res);
			}			
		});
		searchMenu.add(findMax);
		JMenuItem findMin = new JMenuItem("Find Min");
		findMin.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int res = SearchAlgorithms.findMin(arr);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nMin = "+res);
			}			
		});
		searchMenu.add(findMin);
		JMenuItem findAvg = new JMenuItem("Find Avarage");
		findAvg.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int res = SearchAlgorithms.findAvarage(arr);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nAvarage = "+res);
			}			
		});
		searchMenu.add(findAvg);
		JMenuItem findMedian = new JMenuItem("Find Median");
		findMedian.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int res = SearchAlgorithms.findMedian(arr);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nMedian = "+res);
			}			
		});
		searchMenu.add(findMedian);
		JMenuItem findRecurrence = new JMenuItem("Find Recurrence");
		findRecurrence.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int res = SearchAlgorithms.findMostRecurringElement(arr);
				arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nRecurring = "+res);
			}			
		});
		searchMenu.add(findRecurrence);
		JMenuItem isSorted = new JMenuItem("Is It Sorted?");
		isSorted.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nSorted = "+ArrayAlgorithms.isSorted(arr));
			}			
		});
		searchMenu.add(isSorted);
		JMenuItem linearSearch = new JMenuItem("Linear Search");
		linearSearch.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					int res = SearchAlgorithms.linearSearch(arr, Integer.parseInt(tfSearch.getText()));
					if ( res==-1 ) {
						arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nNo such element");
					}
					else {
						arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nFound at "+res);
					}
				}
				catch ( NumberFormatException ex ) {
					tfSearch.setBackground(Color.gray);
					Timer t = new Timer();
					t.schedule(new TimerTask() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							tfSearch.setBackground(Color.white);
						}
						
					}, 3000);
				}
				
				
			}			
		});
		searchMenu.add(linearSearch);
		JMenuItem binarySearch = new JMenuItem("Binary Search");
		binarySearch.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					int res = SearchAlgorithms.binarySearch(arr, Integer.parseInt(tfSearch.getText()));
					if ( res==-1 ) {
						arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nNo such element");
					}
					else {
						arrout.setText(ArrayAlgorithms.returnArrayString(arr)+"\n\nFound at "+res);
					}
				}
				catch ( NumberFormatException ex ) {
					tfSearch.setBackground(Color.gray);
					Timer t = new Timer();
					t.schedule(new TimerTask() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							tfSearch.setBackground(Color.white);
						}
						
					}, 3000);
				}
			}			
		});
		searchMenu.add(binarySearch);
		
		JMenu cryptoMenu = new JMenu("Crypt");
		JMenuItem sortingcrypt_encyrpt_makey = new JMenuItem("Sorter Method : Encryption Masterkey");
		sortingcrypt_encyrpt_makey.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if ( arr!=null ) {
					CryptingAlgorithms.SORTCRYPT_encryptSingleMasterKey(arr);
					arrout.setText("Array crypted...");
				}
			}			
		});
		cryptoMenu.add(sortingcrypt_encyrpt_makey);
		JMenuItem sortingcrypt_decyrpt_makey = new JMenuItem("Sorter Method : Decryption Masterkey");
		sortingcrypt_decyrpt_makey.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = CryptingAlgorithms.SORTCRYPT_decryptSingleMasterKey();
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		cryptoMenu.add(sortingcrypt_decyrpt_makey);
		JMenuItem sortingcrypt_encyrpt_mukey = new JMenuItem("Sorter Method : Encryption Multikey");
		sortingcrypt_encyrpt_mukey.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if ( arr!=null ) {
					CryptingAlgorithms.SORTCRYPT_encryptMultiKey(arr);
					arrout.setText("Array crypted...");
				}
			}			
		});
		cryptoMenu.add(sortingcrypt_encyrpt_mukey);
		JMenuItem sortingcrypt_decyrpt_mukey = new JMenuItem("Sorter Method : Decryption Multikey");
		sortingcrypt_decyrpt_mukey.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				arr = CryptingAlgorithms.SORTCRYPT_decryptMultiKey();
				arrout.setText(ArrayAlgorithms.returnArrayString(arr));
			}			
		});
		cryptoMenu.add(sortingcrypt_decyrpt_mukey);
		JMenuItem sortingcrypt_encyrpt = new JMenuItem("Sorter Method Delete Keys");
		sortingcrypt_encyrpt.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				CryptingAlgorithms.SORTCRYPT_deleteAllKeys();
			}			
		});
		cryptoMenu.add(sortingcrypt_encyrpt);
		
		
		
		
		
		
		
		
		algorithmsBar.add(generateMenu);
		algorithmsBar.add(sortMenu);
		algorithmsBar.add(searchMenu);
		algorithmsBar.add(cryptoMenu);
		algorithmsBar.add(editMenu);
		sortingpanel.setLayout(null);
		
		arrout = new JTextArea("Generate an array please");
		arrout.setBackground(SystemColor.menu);
		arrout.setBounds(22, 20, 1058, 265);
		arrout.setEditable(false);
		arrout.setLineWrap(true);
		arrout.setFont(new Font("Cambria Math", Font.BOLD, 12));
		sortingpanel.add(arrout);
		
		
		JLabel lblArrayLength = new JLabel(" Array Length :");
		lblArrayLength.setFont(new Font("Tahoma", Font.BOLD, 11));
		lblArrayLength.setBounds(22, 304, 83, 14);
		sortingpanel.add(lblArrayLength);
		
		JLabel arrayLength = new JLabel("60");
		arrayLength.setBounds(110, 304, 30, 14);
		sortingpanel.add(arrayLength);
		
		this.slider = new JSlider();
		slider.setToolTipText("");
		slider.setValue(60);
		slider.setSnapToTicks(true);
		slider.setMinimum(10);
		slider.setMaximum(500);
		slider.setBounds(139, 304, 200, 23);
		slider.addChangeListener(new ChangeListener() {
			@Override
			public void stateChanged(ChangeEvent e) {
				// TODO Auto-generated method stub
				setN(slider.getValue());
				arrayLength.setText(slider.getValue()+"");
			}
		});
		sortingpanel.add(slider);
		
		JTextField randmaxtf = new JTextField();
		randmaxtf.setText(getMax()+"");
		randmaxtf.setBounds(349, 296, 30, 20);
		sortingpanel.add(randmaxtf);
		randmaxtf.setColumns(10);
		randmaxtf.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				try {
					Integer.parseInt(randmaxtf.getText());
				} catch ( NumberFormatException e) {
					// do nothing
					return;
				}
				setMax(Integer.parseInt(randmaxtf.getText()));
			}
			
		});
		
		JTextField addertf = new JTextField();
		addertf.setText(getAdder()+"");
		addertf.setColumns(10);
		addertf.setBounds(349, 322, 30, 20);
		addertf.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				try {
					Integer.parseInt(addertf.getText());
				} catch ( NumberFormatException e) {
					// do nothing
					return;
				}
				setAdder(Integer.parseInt(addertf.getText()));
			}
		});
		sortingpanel.add(addertf);
		
		timeLabel = new JLabel("Time : ");
		timeLabel.setFont(new Font("Cambria Math", Font.BOLD, 16));
		timeLabel.setBounds(582, 299, 177, 40);
		sortingpanel.add(timeLabel);		
		
		getContentPane().repaint();
	}
	
	
	public ArrayAlgPanel getMyself() {
		return this;
	}
	
	public int getN() {
		return n;
	}

	public void setN(int n) {
		this.n = n;
	}

	public int getMax() {
		return max;
	}

	public void setMax(int max) {
		this.max = max;
	}

	public int getAdder() {
		return adder;
	}

	public void setAdder(int adder) {
		this.adder = adder;
	}
	
	public void setArr( int []newarr ) {
		this.arr = newarr;
		updateArrOut(arr);
		setN(arr.length);
		slider.setValue(n);
	}
	
	public void updateArrOut(int []arr) {
		arrout.setText(ArrayAlgorithms.returnArrayString(arr));
	}
	
	public void updateTimeLabel(long time) {
		timeLabel.setText("Time : " + time + "ns");
	}
}
