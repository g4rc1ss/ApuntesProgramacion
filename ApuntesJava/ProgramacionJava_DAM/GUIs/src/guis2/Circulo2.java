package guis2;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JFrame;
import javax.swing.JPanel;
import java.awt.Graphics2D;      
import java.awt.geom.Ellipse2D;
public class Circulo2 extends JPanel { 

	public void paint(Graphics g) {  //si usamos la clase Graphics2D podemos acceder a más métodos que con la clase Graphics
                          // para ello creamos una instacia de Graphics2D y hacemos un casting a la instancia g

		Graphics2D g2d= (Graphics2D) g; //necesitamos import java.awt.Graphics2D;                          
		g.setColor(Color.RED);
		g.fillOval(20, 100, 30, 30);
		g2d.draw(new Ellipse2D.Double(20, 150, 30, 30)); //para métodos de Graphics2D hay que utilizar g2d
	}	
	
	



public static void main(String[] args) {
		JFrame ventana=new JFrame();	//se crea el frame que va a contener el JPanel	
		ventana.setTitle("Circulo");
		ventana.setBounds(50,50,300, 300);
		ventana.setVisible(true);
            ventana.setResizable(false);

		ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//CuadradosCirculos obj=new CuadradosCirculos();
		//ventana.add(obj);
            ventana.add(new Circulo2()); //sustituye a las 2 líneas anteriores
		
	}
}