package guis2;


import javax.swing.*;

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.*;

public class Ejemplo2 extends JFrame{

		void metodo1(){
		
		setLayout(new BorderLayout());
		add(new JButton("bot�n 1"), BorderLayout.EAST);
		// add(new JButton("bot�n 1"), "East");
		add(new JButton("bot�n 2"), BorderLayout.SOUTH);
		add(new JButton( "bot�n 3"), BorderLayout.WEST);
		add(new JButton(" bot�n 4 "), BorderLayout.NORTH);
		add(new JButton(" bot�n 5"), BorderLayout.CENTER);
	
	}
	
	public static void main( String [] args ){
		
		Ejemplo2 cosa = new Ejemplo2();
		
			cosa.metodo1();
			cosa.setBounds(100,100,500,500);
			cosa.setResizable(true);
			cosa.setVisible(true);
			cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
	}
	
}
