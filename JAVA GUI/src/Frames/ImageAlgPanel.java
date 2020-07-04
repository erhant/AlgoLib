package Frames;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JLabel;
import javax.swing.JTextField;

import Algorithms.CryptingAlgorithms;
import Algorithms.ImageAlgorithms;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.SystemColor;
import java.awt.Toolkit;
import java.awt.Window;

import javax.swing.JSlider;
import javax.swing.JTextArea;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;
import javax.swing.JPanel;

@SuppressWarnings("unused")
public class ImageAlgPanel extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = -5464644212890409588L;
	private BufferedImage img, createdimg;
	private JTextField txtinputname;
	private JTextField txtinputformat;
	private String filename;
	private String fileformat;
	private JLabel imagelbl = new JLabel("");
	private JPanel pictureHere = new JPanel();
	private JTextField txtFilename;
	
	public ImageAlgPanel() {
		setTitle("Image Algorithms");
		setLocation(0, 0);
		Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
		setSize((int)screenSize.getWidth()-500,(int)screenSize.getHeight()-500);
		setVisible(true);
		setResizable(true);
		getContentPane().setLayout(null);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		pictureHere.setLayout(new BorderLayout());
		getContentPane().add(pictureHere);
		pictureHere.add(imagelbl, BorderLayout.CENTER);
		
		JLabel lblfilename = new JLabel("Input File:");
		lblfilename.setBounds(10, 11, 86, 14);
		getContentPane().add(lblfilename);
		
		txtinputname = new JTextField();
		txtinputname.setText("myimage");
		txtinputname.setBounds(10, 26, 86, 20);
		getContentPane().add(txtinputname);
		txtinputname.setColumns(10);
		
		JLabel lblfileformat = new JLabel("Input Format:");
		lblfileformat.setBounds(10, 51, 86, 14);
		getContentPane().add(lblfileformat);
		
		txtinputformat = new JTextField();
		txtinputformat.setText("png");
		txtinputformat.setColumns(10);
		txtinputformat.setBounds(10, 66, 86, 20);
		getContentPane().add(txtinputformat);
		
		JTextArea errorlabel = new JTextArea();
		errorlabel.setFont(new Font("Calibri", Font.BOLD, 15));
		errorlabel.setForeground(Color.BLACK);
		errorlabel.setBackground(SystemColor.menu);
		errorlabel.setEditable(false);
		errorlabel.setBounds(10, 226, 86, 66);
		errorlabel.setLineWrap(true);
		errorlabel.setWrapStyleWord(true);
		getContentPane().add(errorlabel);
		
		Timer t = new Timer();
		JButton imgAccepter = new JButton("Accept");
		imgAccepter.setBounds(7, 92, 89, 23);
		imgAccepter.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				filename = txtinputname.getText();
				fileformat = txtinputformat.getText();
				try {
					errorlabel.setText("Image activated...");
					img = ImageIO.read(new File(filename+"."+fileformat));
					updateImage(img);
					t.schedule(new TimerTask() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							errorlabel.setText("");
						}
						
					}, 3000);
				} catch (IOException ex) {
					// TODO Auto-generated catch block
					errorlabel.setText("Invalid Image Name / Format");
					t.schedule(new TimerTask() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							errorlabel.setText("");
						}
						
					}, 3000);
				}
			}
			
		});
		getContentPane().add(imgAccepter);
		
		txtFilename = new JTextField();
		txtFilename.setText("outputname");
		txtFilename.setBounds(10, 160, 86, 20);
		getContentPane().add(txtFilename);
		txtFilename.setColumns(10);
		
		JButton imgWrite = new JButton("Write");
		imgWrite.setBounds(7, 126, 89, 23);
		imgWrite.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( createdimg!=null )
				ImageAlgorithms.writeImage(createdimg, fileformat, txtFilename.getText());
			}
			
		});
		getContentPane().add(imgWrite);
		
		JButton btnClear = new JButton("Clear");
		btnClear.setBounds(7, 191, 89, 23);
		btnClear.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				removeImage();
			}
			
		});
		getContentPane().add(btnClear);
		
		
		
		JMenuBar algorithmsBar = new JMenuBar();
		setJMenuBar(algorithmsBar);
		JMenu algorithms = new JMenu("Algorithms");
		algorithmsBar.add(algorithms);
		JMenuItem rgb2gray = new JMenuItem("Grayscale");
		rgb2gray.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoGrayscale(img);	
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(rgb2gray);
		JMenuItem rgb2binarymedian = new JMenuItem("Binary ( Median )");
		rgb2binarymedian.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoBinaryMED(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(rgb2binarymedian);
		JMenuItem rgb2binaryavarage = new JMenuItem("Binary ( Avarage )");
		rgb2binaryavarage.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoBinaryAVG(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(rgb2binaryavarage);
		JMenuItem rgb2binaryavgcolor = new JMenuItem("Binary ( Avarage Color )");
		rgb2binaryavgcolor.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoBinaryAVG_Color(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(rgb2binaryavgcolor);
		JMenuItem rgb2ternary = new JMenuItem("Ternary");
		rgb2ternary.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoTernary(img);			
					updateImage(createdimg);
					
				}
			}			
		});
		algorithms.add(rgb2ternary);
		JMenuItem rgb28way = new JMenuItem("8-Way");
		rgb28way.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBto8way(img);			
					updateImage(createdimg);
					
				}
			}			
		});
		algorithms.add(rgb28way);
		JMenuItem rgb2erhany = new JMenuItem("ErhanStyle");
		rgb2erhany.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoErhanyRGB(img);			
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(rgb2erhany);
		JMenuItem rgb2erhany_2 = new JMenuItem("ErhanStyle_2");
		rgb2erhany_2.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.RGBtoErhanyRGB_2(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(rgb2erhany_2);
		JMenuItem negative = new JMenuItem("Negative");
		negative.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.negative(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(negative);
		JMenuItem sortVertical = new JMenuItem("Sort Vertical");
		sortVertical.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.sortImage_Vertical(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(sortVertical);
		JMenuItem sortHorizontal = new JMenuItem("Sort Horizontal");
		sortHorizontal.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					createdimg = ImageAlgorithms.sortImage_Horizontal(img);		
					updateImage(createdimg);
				}
			}			
		});
		algorithms.add(sortHorizontal);
		
		
		JMenu edits = new JMenu("Edit");
		algorithmsBar.add(edits);
		JMenuItem flipVertical = new JMenuItem("Flip Vertical");
		flipVertical.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					img = ImageAlgorithms.flip_Vertical(img);
					createdimg = img;
					updateImage(createdimg);
				}
			}			
		});
		edits.add(flipVertical);
		JMenuItem flipHorizontal = new JMenuItem("Flip Horizontal");
		flipHorizontal.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					img = ImageAlgorithms.flip_Horizontal(img);		
					createdimg = img;
					updateImage(createdimg);
				}
			}			
		});
		edits.add(flipHorizontal);
		JMenuItem rotate90right = new JMenuItem("Rotate Right");
		rotate90right.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					img = ImageAlgorithms.rotate90_right(img);	
					createdimg = img;
					updateImage(createdimg);
				}
			}			
		});
		edits.add(rotate90right);
		JMenuItem rotate90left = new JMenuItem("Rotate Left");
		rotate90left.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if ( img!=null ) {
					img = ImageAlgorithms.rotate90_left(img);	
					createdimg = img;
					updateImage(createdimg);
				}
			}			
		});
		edits.add(rotate90left);
		
		
		
		JMenu news = new JMenu("New");
		algorithmsBar.add(news);
		JMenuItem randomImage = new JMenuItem("Random Image");
		randomImage.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				img = ImageAlgorithms.randomImage(840, 680);	
				createdimg = img;
				updateImage(img);
				
			}			
		});
		news.add(randomImage);
		
		
		getContentPane().repaint();
	}
	
	private void updateImage(BufferedImage updatethis) {
		imagelbl.setIcon(new ImageIcon(updatethis));
		pictureHere.setBounds(119, 11, updatethis.getWidth(), updatethis.getHeight());
		imagelbl.setSize(pictureHere.getWidth(), pictureHere.getHeight());
		getContentPane().repaint();
	}
	
	private void removeImage() {
		imagelbl.setIcon(null);
	}
}
