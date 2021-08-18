package guis2;
import javax.swing.*;
import java.awt.BorderLayout;
import java.awt.GridLayout;

public class Ejemplo4 extends JFrame {

	
	
	 void unPanel(){
		 
		 JPanel p1 = new JPanel();
		 setLayout(new BorderLayout());
		 p1.setLayout(new GridLayout(4, 3));
		 
		 // Add buttons to the panel
		 
		 for(int i = 1; i <= 9; i++) {
			 p1.add(new JButton("" + i));
		 }
		 
		 p1.add(new JButton("" + 0));
		 p1.add(new JButton("Start"));
		 p1.add(new JButton("Stop"));
		 add(p1,BorderLayout.EAST);
		 
	 }
	 
	 void panelDos(){
		 
		 
		 
	 }
	
	public static void main(String[] args) {
		
		Ejemplo4 cosa = new Ejemplo4();
		
		cosa.unPanel();
		cosa.setBounds(100,100,500,500);
		cosa.setResizable(true);
		cosa.setVisible(true);
		cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
	}

}