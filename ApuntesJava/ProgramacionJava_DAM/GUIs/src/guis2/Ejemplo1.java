package guis2;
import javax.swing.*;

import javax.swing.*;
import java.awt.GridLayout;
import java.awt.event.*;

public class Ejemplo1 extends JFrame{

	void metodo(){
		setLayout(new GridLayout(4, 3));	//4 filas 3 columnas
		for(int i = 1; i <= 9; i++) {
		add(new JButton("" + i));
		}
		add(new JButton("" + 0));
		add(new JButton("Start"));
		add(new JButton("Stop"));
		
	}
	
public static void main(String[] args) {
		
		Ejemplo1 cosa = new Ejemplo1();
		
		cosa.metodo();
		
			cosa.setBounds(100,100,500,500);
			cosa.setResizable(true);
			cosa.setVisible(true);
			cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
			
	}

	
}
