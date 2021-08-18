package ejercicios;

import javax.swing.*;
import java.awt.event.*;

public class EjercicioPass extends JFrame implements ActionListener {
	
	private JLabel label1;
	private JLabel label2;
	
	private JTextField usuario;
	
	private JPasswordField contrasenia;
	
	private JButton boton, botonCerrar;
	
	private String[] usuarios = { "Diego", "Markel", "AsierF", "AsierG" };
	private String[] contrasenias = { "1234", "123", "123456", "holaQue123" };
	
	private String nombre;
	private String pass;
	
	EjercicioPass(  ) {
		
		setLayout(null);
		
		label1 = new JLabel( "Usuario: " );
		label1.setBounds( 10, 100, 80, 15 );
		add(label1);
		
		label2 = new JLabel( "Contraseña: " );
		label2.setBounds(10, 130, 90, 15);
		add(label2);
		
		usuario = new JTextField(  );
		usuario.setBounds( 105, 100, 250, 20 );
		add(usuario);
		
		contrasenia = new JPasswordField(  );
		contrasenia.setBounds(105, 130, 250, 20);
		add(contrasenia);
		contrasenia.setEchoChar('#');
		
		boton = new JButton( "Presiona" );
		boton.setBounds(140, 200, 200, 50);
		add(boton);
		boton.addActionListener(this);
		
		botonCerrar = new JButton( "Cerrar" );
		botonCerrar.setBounds( 140, 260, 130, 50 );
		add(botonCerrar);
		botonCerrar.addActionListener(this);
		
	}
	
	
	public void actionPerformed(ActionEvent e) {
		
		nombre = usuario.getText();
		
		pass = new String( contrasenia.getPassword() );
		
		if( e.getSource(  ) == boton )
			for( int x = 0; x < 4; x ++ ) {
			
				if( nombre.equals( usuarios[ x ] ) && pass.equals( contrasenias[ x ] ) ) {
				
					setTitle( "¡¡¡CORRECTO!!!" );
					x = 4;
				
				}
			
			else
				setTitle( "Incorrecto :((" );
			
		}
		
		if( e.getSource( ) == botonCerrar )
			System.exit(0);
		
	}
	
	
	public static void main( String[ ] args ) {
		
		EjercicioPass ejercicio = new EjercicioPass(  );
		
		ejercicio.setBounds(300, 300, 450, 350);
		
		ejercicio.setResizable(false);
		
		ejercicio.setVisible(true);
		
		ejercicio.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		
	}

}
