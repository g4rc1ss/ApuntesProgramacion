package guis;

import javax.swing.*;
import java.awt.event.*;

public class EjerPass extends JFrame implements ActionListener, KeyListener {

	String [] arrayUsuario = {"usu1","usu2","usu3","usu4"};
	String [] arrayPass = {"cont1","cont2","cont3","cont4"};
	
	String usuIntr;
	String passIntr;
	
	boolean sn;
	boolean espacio = false;
	private JLabel labelUsu;
	private JLabel labelPass;
	private JLabel labelY;
	private JLabel labelN;
	
	private JTextField textUsu;
	private JPasswordField textPass;
	
	private JButton boton;
	
	EjerPass(){
		
		setLayout(null);
		
		labelUsu = new JLabel ("Usuario: ");
		labelUsu.setBounds(100,100,80,20);
		add(labelUsu);
		
		labelPass = new JLabel ("Contraseña: ");
		labelPass.setBounds(100,150,80,20);
		add(labelPass);
		
		labelY = new JLabel ("Correcto");
		labelY.setBounds(180,300,100,30);
		labelY.setVisible(false);
		add(labelY);
		
		labelN = new JLabel ("Incorrecto");
		labelN.setBounds(180,300,100,30);
		labelN.setVisible(false);
		add(labelN);
		
		
		
		textUsu = new JTextField ();
		textUsu.setBounds(190, 100, 150, 20);
		add(textUsu);
		textUsu.addActionListener(this);
		
		textPass = new JPasswordField ();
		textPass.setBounds(190, 150, 150, 20);
		textPass.setEchoChar('?');
		textPass.addActionListener( this );
		
		add(textPass);
		
		
		
		boton = new JButton(" Confirmar ");
		boton.setBounds(140,200,150,50);
		add(boton);
		boton.addActionListener(this);
		boton.addKeyListener(this);
			
	}
	
	public void actionPerformed (ActionEvent e){
		
		usuIntr = textUsu.getText();
		passIntr = new String ( textPass.getPassword());
		
		if( espacio == false ){
			textUsu.transferFocus();
			espacio = true;
		}
		else if( espacio == true ){
			textPass.transferFocus();
			espacio = false;
		}
		
		if(e.getSource(  ) == boton){
			
			for(int x = 0; x < 4; x++){
				
				if(  usuIntr.equals(arrayUsuario [x]) && passIntr.equals(arrayPass[x])  ){
					
					sn = true;
					
					x = 4;
					
				}
				
				else{
					
					sn = false;
				
				}

			}
			
			if( sn == true ){
				
				labelN.setVisible(false);
				labelY.setVisible(true);
				
				setTitle("CORRECTO");
			}
			
			else{
				
				labelY.setVisible(false);
				labelN.setVisible(true); 
				
				setTitle("INCORRECTO");
				
			}
			
		}
		
	}
	
			
	public static void main(String[] args) {
		
		EjerPass cosa = new EjerPass();
		
		cosa.setBounds(100,100,500,500);
		cosa.setResizable(false);
		cosa.setVisible(true);
		cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		

	}

	@Override
	public void keyPressed(KeyEvent arg0) {
		
		
	}

	@Override
	public void keyReleased(KeyEvent arg0) {

		
		
	}

	@Override
	public void keyTyped(KeyEvent arg0) {
		for(int x = 0; x < 4; x++){
			
			if(  usuIntr.equals(arrayUsuario [x]) && passIntr.equals(arrayPass[x])  ){
				
				sn = true;
				
				x = 4;
				
			}
			
			else{
				
				sn = false;
			
			}

		}
		
		if( sn == true ){
			
			labelN.setVisible(false);
			labelY.setVisible(true);
			
			setTitle("CORRECTO");
		}
		
		else{
			
			labelY.setVisible(false);
			labelN.setVisible(true); 
			
			setTitle("INCORRECTO");
			
		}
	}

}
