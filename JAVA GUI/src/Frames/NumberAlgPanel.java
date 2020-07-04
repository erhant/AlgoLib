package Frames;

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
import Algorithms.NumberAlgorithms;
import Algorithms.SortingAlgorithms;
import Algorithms.TezcanAlgorithms;

import java.awt.Color;
import java.awt.GridLayout;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.SystemColor;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import java.util.Timer;
import java.util.TimerTask;

import javax.swing.UIManager;

public class NumberAlgPanel extends JFrame {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -2154789879610099836L;
	private int num, num2;
	private JTextField auxNumberEntryTF;
	
	public NumberAlgPanel() {
		setTitle("Number Algorithms");
		setVisible(true);
		setSize(576, 500);
		setResizable(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		getContentPane().setLayout(null);
		Timer timer = new Timer();
		
		JLabel numberEntryLBL_1 = new JLabel("Actual Number Here:");
		numberEntryLBL_1.setBounds(10, 11, 137, 14);
		getContentPane().add(numberEntryLBL_1);
		
		JTextField numberEntryTF = new JTextField();
		numberEntryTF.setBounds(10, 31, 86, 20);
		getContentPane().add(numberEntryTF);
		numberEntryTF.setColumns(10);
		
		JLabel numberEntryLBL_2 = new JLabel("Second Number Here:");
		numberEntryLBL_2.setBounds(157, 11, 228, 14);
		getContentPane().add(numberEntryLBL_2);
		
		auxNumberEntryTF = new JTextField();
		auxNumberEntryTF.setColumns(10);
		auxNumberEntryTF.setBounds(157, 31, 86, 20);
		getContentPane().add(auxNumberEntryTF);
		
		JTextArea resulttxtarea = new JTextArea();
		resulttxtarea.setEditable(false);
		resulttxtarea.setWrapStyleWord(true);
		resulttxtarea.setLineWrap(true);
		resulttxtarea.setFont(UIManager.getFont("Label.font"));
		resulttxtarea.setBackground(SystemColor.menu);
		resulttxtarea.setBounds(10, 62, 540, 368);
		getContentPane().add(resulttxtarea);
		
		JMenuBar numberBar = new JMenuBar();
	    setJMenuBar(numberBar);
		JMenu find = new JMenu("Find");
		numberBar.add(find);
		JMenuItem positiveDividers = new JMenuItem("Positive Factors");
		positiveDividers.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Positive Factors: \n" + ArrayAlgorithms.returnArrayString(NumberAlgorithms.getPositiveDividers(num)));	
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		find.add(positiveDividers);
		JMenuItem primeFactors = new JMenuItem("Prime Factors");
		primeFactors.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Prime Factors:\n" + ArrayAlgorithms.returnArrayString(NumberAlgorithms.getPrimeFactors_UNIQUE(num)));
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		find.add(primeFactors);
		JMenuItem oddsInAlliquotSum = new JMenuItem("#Odds In Alliquot Sum");
		oddsInAlliquotSum.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Number of odds in alliquot sum: " + NumberAlgorithms.getNumberOfOddElementsInAlliquotSum(num) + "\n"+NumberAlgorithms.getNumberOfPrimeFactors(num)+" primes.");	
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		find.add(oddsInAlliquotSum);
		JMenuItem alliquotSum = new JMenuItem("Alliquot Sum");
		alliquotSum.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Alliquot Sum: " + NumberAlgorithms.getAlliquotSum(num));	
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		find.add(alliquotSum);
		
		JMenu about = new JMenu("About");
		numberBar.add(about);
		JMenuItem isPerfectNumber = new JMenuItem("Perfect Number");
		isPerfectNumber.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Perfect : " + NumberAlgorithms.isPerfectNumber(num));				
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		about.add(isPerfectNumber);
		JMenuItem isAbundantNumber = new JMenuItem("Abundant Number");
		isAbundantNumber.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Abundant : " + NumberAlgorithms.isAbundantNumber(num));				
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		about.add(isAbundantNumber);
		JMenuItem isDeficientNumber = new JMenuItem("Deficient Number");
		isDeficientNumber.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Deficient : " + NumberAlgorithms.isDeficientNumber(num));				
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		about.add(isDeficientNumber);
		JMenuItem isPerfectSquare = new JMenuItem("Perfect Square");
		isPerfectSquare.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					if ( NumberAlgorithms.isPerfectSquare(num) ) {
						resulttxtarea.setText("Perfect Square : " + NumberAlgorithms.isPerfectSquare(num) + "\nRoot = "+(int)Math.sqrt(num));	
					}
					else {
						resulttxtarea.setText("Perfect Square : " + NumberAlgorithms.isPerfectSquare(num));	
					}
								
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		about.add(isPerfectSquare);
		JMenuItem isPrime = new JMenuItem("Prime");
		isPrime.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText("Prime : " + NumberAlgorithms.isPrime(num));		
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		about.add(isPrime);
		
		JMenu tezcan = new JMenu("Tezcan");
		numberBar.add(tezcan);
		JMenuItem collatzTezcanForm1 = new JMenuItem("Collatz Tezcan Form 1");
		collatzTezcanForm1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText(TezcanAlgorithms.collatzTezcanForm_1st(num));		
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(collatzTezcanForm1);
		JMenuItem collatzTezcanForm2 = new JMenuItem("Collatz Tezcan Form 2");
		collatzTezcanForm2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText(TezcanAlgorithms.collatzTezcanForm_2nd(num));		
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(collatzTezcanForm2);
		JMenuItem satisfyNpiece = new JMenuItem("Satisfy M(Second Number) Piece");
		satisfyNpiece.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText("Satisfy: "+TezcanAlgorithms.satisfy_N_piece(num, num2));					
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(satisfyNpiece);
		JMenuItem satisfyMpiece_UPTO_N = new JMenuItem("Satisfy M(Second Number) Piece Up to N");
		satisfyMpiece_UPTO_N.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText(TezcanAlgorithms.satisfies_M_PIECE_UPTO_N(num, num2).toString());					
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(satisfyMpiece_UPTO_N);
		JMenuItem satisfyMpiece_UPTO_N_UNIQ = new JMenuItem("Satisfy M(Second Number) Piece Up to N Unique");
		satisfyMpiece_UPTO_N_UNIQ.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText(TezcanAlgorithms.satisfies_M_PIECE_UPTO_N_UNIQUE(num, num2).toString());					
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(satisfyMpiece_UPTO_N_UNIQ);
		JMenuItem satisfyMpiece_UPTO_N_ratio = new JMenuItem("Ratio Odds / Satisfiers M(Second Number) Piece ( Up to N )");
		satisfyMpiece_UPTO_N_ratio.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText("#odd numbers / #satisfying numbers for "+num2+" piece = "+TezcanAlgorithms.satisifiers_UPTO_N_ratio(num, num2));					
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(satisfyMpiece_UPTO_N_ratio);
		JMenuItem maxPiece_UPTO_N = new JMenuItem("Max piece up to N");
		maxPiece_UPTO_N.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					resulttxtarea.setText(TezcanAlgorithms.max_piece_UPTO_N(num));		
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		tezcan.add(maxPiece_UPTO_N);
		
		
		JMenu pair = new JMenu("Pair");
		numberBar.add(pair);
		JMenuItem gcf = new JMenuItem("Greatest Common Divisor");
		gcf.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText("Greatest Common Factor : "+NumberAlgorithms.greatestCommonFactor(num, num2));					
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		pair.add(gcf);
		JMenuItem lcm = new JMenuItem("Least Common Multiple");
		lcm.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText("Least Common Multiple : "+NumberAlgorithms.leastCommonMultiple(num, num2));					
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		pair.add(lcm);
		JMenuItem areFriendly = new JMenuItem("Friendly Numbers");
		areFriendly.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText("Friendly : " + NumberAlgorithms.areFriendlyNumbers(num, num2));	
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}						
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		pair.add(areFriendly);
		JMenuItem areAmicable = new JMenuItem("Amicable Numbers");
		areAmicable.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					try {
						num2 = Integer.parseInt(auxNumberEntryTF.getText());
						resulttxtarea.setText("Amicable : " + NumberAlgorithms.areAmicableNumbers(num, num2));
					}
					catch (NumberFormatException ex ) {
						auxNumberEntryTF.setBackground(Color.lightGray);
						timer.schedule(new TimerTask() {
							public void run() {
								auxNumberEntryTF.setBackground(Color.white);
							}
						}, 3000);
					}
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}		
					}, 3000);
				}
			}
		});
		pair.add(areAmicable);
		
		JMenu edit = new JMenu("Edit");
		numberBar.add(edit);
		JMenuItem reverse = new JMenuItem("Reverse");
		reverse.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				try {
					num = Integer.parseInt(numberEntryTF.getText());
					numberEntryTF.setText(NumberAlgorithms.reverseNumber(num)+"");
								
				}
				catch ( NumberFormatException ex ) {
					numberEntryTF.setBackground(Color.lightGray);
					timer.schedule(new TimerTask() {
						public void run() {
							numberEntryTF.setBackground(Color.white);
						}					
					}, 3000);
				}
			}	
		});
		edit.add(reverse);
		
		
		getContentPane().repaint();
		
	}
}
