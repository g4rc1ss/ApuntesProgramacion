package guis2;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JFrame;

public class Circulo extends JFrame {
	
	public void paint(Graphics g) { 
		
		super.paint(g);
		g.setColor(Color.RED);
		g.fillOval(20, 100, 30, 30);
								
	}
		
	public static void main(String[] args) {
		Circulo obj = new Circulo();	
		obj.setTitle("Circulo");
		obj.setBounds(50,50,300, 300);
		obj.setVisible(true);
        obj.setResizable(false);
		obj.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	
}
