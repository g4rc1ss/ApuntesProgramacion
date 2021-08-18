package guis;

import javax.swing.*;
import javax.swing.event.*;
import java.awt.event.*;

public class EjerCB extends JFrame implements ActionListener, ChangeListener {
	
	private JLabel terminos;
	
	private JCheckBox acepto;
	
	private JButton boton;
	
	public EjerCB(  ) {
		
		setLayout( null );
		
		terminos = new JLabel( "Acepta los terminos o mueres" );
		terminos.setBounds(100,100,350,20);
		add(terminos);
		
		acepto = new JCheckBox( "Acepto los terminos para no morir" );
		acepto.setBounds(100,150,350,20);
		add( acepto );
		acepto.addChangeListener(this);
		
		boton = new JButton( "Pulsa" );
		boton.setBounds(140,200,150,50);
		add(boton);
		boton.addActionListener(this);
		boton.setEnabled(false);
		
	}
	
	@Override
	public void stateChanged(ChangeEvent eC) {
		
		if( acepto.isSelected() == true )
			boton.setEnabled(true);
		
		else
			boton.setEnabled(false);
		
	}
	

	@Override
	public void actionPerformed(ActionEvent e) {
		
		if( e.getSource() == boton )
			System.exit(0);
		
	}

	public static void main(String[] args) {
		
		EjerCB cosa = new EjerCB();
		
		cosa.setBounds(100,100,500,500);
		cosa.setResizable(false);
		cosa.setVisible(true);
		cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		

	}

}
