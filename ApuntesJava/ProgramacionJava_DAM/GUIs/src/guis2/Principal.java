package guis2;

import java.awt.Color;

import javax.swing.*;

public class Principal extends JFrame {
	
	int z = 10;
	Circulo3 cir = new Circulo3(  );
	
	
	Principal(  ) {
		
		add(cir);
		cir.setColor(new Color(0,100,0));
		
	}
	
	
	void repetir( int z ) throws InterruptedException {
		
		this.z = z;
		
		while( true ) {
			
			cir.moverBola();
			
			cir.repaint();
			
			Thread.sleep(z); // Para añadir tiempo al bucle infinito, que se ejecute cada 10 ms
			
		}
		
	}
	
	
	
	public static void main( String[ ] args ) throws InterruptedException {
		
		Principal ventana=new Principal();	//se crea el frame que va a contener el JPanel	
		ventana.setTitle("Circulo");
		ventana.setBounds(50,50,300, 300);
		ventana.setVisible(true);
        ventana.setResizable(true);
		ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		ventana.repetir(100);
		
		
		
	}

}

/*
Cambiar el tamaño de la bola desde el main
 */
