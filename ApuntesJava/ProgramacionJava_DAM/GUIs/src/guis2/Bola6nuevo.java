package guis2;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

public class Bola6nuevo extends JFrame {
	
	int z = 10;
	Circulo3 cir = new Circulo3(  );
	Timer tiempo;
	int intervalo = 10;
	
	
	Bola6nuevo(  ) {
		
		add(cir);
		cir.setColor(new Color(0,100,0));
		
		tiempo = new Timer( intervalo, new Accion() );
		tiempo.start();
		
	}
	
	
/*	void repetir( int z ) throws InterruptedException {
		
		this.z = z;
		
		while( true ) {
			
			cir.moverBola();
			
			cir.repaint();
			
			Thread.sleep(z); // Para añadir tiempo al bucle infinito, que se ejecute cada 10 ms
			
		}
		
	}
	
	*/
	
	public static void main( String[ ] args ) throws InterruptedException {
		
		Principal ventana=new Principal();	//se crea el frame que va a contener el JPanel	
		ventana.setTitle("Circulo");
		ventana.setBounds(50,50,300, 300);
		ventana.setVisible(true);
        ventana.setResizable(true);
		ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//ventana.repetir(100);
		
		
		
	}
	class Accion implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent arg0) {
			
			cir.moverBola();
			cir.repaint();
			
		}
		
	}
}


