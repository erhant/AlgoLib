package Frames;

import javax.swing.JFrame;
import javax.swing.JTextArea;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Arrays;
import java.util.InputMismatchException;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.JButton;
import javax.swing.JTextField;

public class CustomArrayWindow extends JFrame {
	private JTextField txtLengthHere;
	public CustomArrayWindow(ArrayAlgPanel aap) {
		setResizable(true);
		setSize(510,152);
		setVisible(true);
		setTitle("Custom Array");
		getContentPane().setLayout(null);
		String token;
		JTextArea txtrTypeYourInteger = new JTextArea();
		txtrTypeYourInteger.setWrapStyleWord(true);
		txtrTypeYourInteger.setLineWrap(true);
		txtrTypeYourInteger.setFont(new Font("Cambria Math", Font.PLAIN, 12));
		txtrTypeYourInteger.setText("Type your integer array here");
		txtrTypeYourInteger.setBounds(10, 11, 503, 72);
		
		txtLengthHere = new JTextField();
		txtLengthHere.setText("length here");
		txtLengthHere.setBounds(112, 94, 86, 20);
		getContentPane().add(txtLengthHere);
		txtLengthHere.setColumns(10);				
			
		getContentPane().add(txtrTypeYourInteger);
		
		JButton btnNewButton = new JButton("Enter");
		btnNewButton.setBounds(10, 94, 89, 23);
		btnNewButton.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				try {
					int n = Integer.parseInt(txtLengthHere.getText());
					
					String str=txtrTypeYourInteger.getText();
					String strA[]=new String[n];
					strA=str.split(" ");
					int intA[]=new int[n];
					for(int i=0; i<n; i++) {
					intA[i]=Integer.parseInt(strA[i]);
					}
					aap.setArr(intA);
					dispose();				
				} catch ( NumberFormatException ex ) {
					txtrTypeYourInteger.setBackground(Color.gray);		
					Timer t = new Timer();
					t.schedule(new TimerTask() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							txtrTypeYourInteger.setBackground(Color.white);		
						}
						
					}, 3000);
				} catch ( ArrayIndexOutOfBoundsException ex ) {
					txtrTypeYourInteger.setBackground(Color.gray);		
					Timer t = new Timer();
					t.schedule(new TimerTask() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							txtrTypeYourInteger.setBackground(Color.white);		
						}
						
					}, 3000);
				}
			}
			
		});
		getContentPane().add(btnNewButton);
		
		
	}
}
