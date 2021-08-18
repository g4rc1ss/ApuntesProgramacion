package guis;

import javax.swing.*;
import java.awt.*;
import java.util.Scanner;
import java.io.File;

public class InterfazGrafica extends JFrame {
	
	private JLabel label1;
	private JLabel label2;
	private JLabel label3;
	private JLabel label4;
	
	private JButton boton;
	
	private JTextField texto;
	
	private JComboBox opcion;
	
	private JCheckBox opcionCheck;
	
	InterfazGrafica(  ) {
		
		setLayout(null);
		
		label1 = new JLabel( "INTERFAZ GRAFICA" );
		label1.setBounds(150, 5, 200, 15); //Ubicamos y damos tamaño(píxeles) al texto: columna, fila, ancho, alto
		add(label1);
		
		label2 = new JLabel( "Nombre: " );
		label2.setBounds(10, 100, 80, 15);
		add(label2);
		
		label3 = new JLabel( "Entregado: " );
		label3.setBounds(10, 130, 80, 15);
		add(label3);
		
		label4 = new JLabel( "provincia: " );
		label4.setBounds(10, 160, 80, 15);
		add(label4);
		
		//------------------------------------------------//
		
		texto = new JTextField();
		texto.setBounds(90, 100, 300, 20);
		add(texto);
		
		opcionCheck = new JCheckBox();
		opcionCheck.setBounds(90, 120, 30, 30);
		add(opcionCheck);
		
		opcion = new JComboBox();
		opcion.setBounds(90, 160, 150, 20);
		add(opcion);
		
		
		
		boton = new JButton("Pulsar");
		boton.setBounds(150, 200, 200, 50);
		add(boton);
		
	}
	
	public void leerProvincias() {
		
Scanner scan = null;
		
		File provincias = new File( "provincias.txt" );
		
		
		try{
			
			scan = new Scanner( provincias );
			
			while( scan.hasNextLine() ){
				
				String linea = scan.nextLine();
				
				opcion.addItem( linea );
				
			}
			
		} catch( Exception e ) {
			
			e.printStackTrace();
			
		} finally{
			
			try{
				
				if( scan != null )
					scan.close();
				
			} catch( Exception e ) {
				
				e.printStackTrace();
				
			}
			
		} // fin de finally
		
	}

	public static void main( String[ ] args ) {
		
		InterfazGrafica objetoInterfaz = new InterfazGrafica();
		
		objetoInterfaz.leerProvincias();
		
		objetoInterfaz.setBounds(300, 300, 450, 350);
		
		objetoInterfaz.setVisible(true);
		
		objetoInterfaz.setResizable(true);
		
		objetoInterfaz.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
	}

}
