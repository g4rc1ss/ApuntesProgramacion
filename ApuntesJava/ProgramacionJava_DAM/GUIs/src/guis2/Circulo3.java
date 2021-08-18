package guis2;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.awt.geom.Ellipse2D;
import java.util.Scanner;


import javax.swing.JPanel;

public class Circulo3 extends JPanel {
	
	private int a = 30;
	private int b = 30;
	private int x = 0;
	private int y = 0;
	private int v = 1;
	private Color color = new Color (0,0,0);
	private String cont;
	
	Scanner teclado = new Scanner( System.in );
	
	Circulo3(  ) {
		
	}
	
	void moverBola( ) {
		
		
			x = x + v;
			y = y + v;
			
			if(x == 250)
				v = -1;
			
			if(x == 0)
				v = 1;
			
		
		
	}

	public void paint(Graphics g) { 

		super.paint(g);
		
		Graphics2D g2d = (Graphics2D) g; 
		
		g2d.setColor(getColor());
		g2d.fillOval(x, y, a, b);
		g2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		
		
	}

	public Color getColor() {
		return color;
	}

	public void setColor(Color color) {
				
		System.out.println("Teclea una contraseña de caca");
		cont = teclado.nextLine();
		
		if(cont.equals("") == false){
			
			this.color = color;
			
		}
	}

}


/*
La clase Timer dispara un evento de tipo ActionEvent despues de un retardo especificado (sirve para hacer algo despues de un retardo).
 */
