package guis;

import javax.swing.*;
import java.awt.event.*;
import java.awt.Color;

public class ComboColores extends JFrame implements ActionListener{
	
	private JLabel rojo;
	private JLabel verde;
	private JLabel azul;
		
	private JComboBox nRojo;
	private JComboBox nVerde;
	private JComboBox nAzul;
	
	private JButton boton;
	
	
	ComboColores(){
		
		setLayout(null);
		
		rojo = new JLabel("Rojo: ");
		rojo.setBounds(100, 87, 100, 50);
		add(rojo);
		
		verde = new JLabel("Verde: ");
		verde.setBounds(100, 187, 100, 50);
		add(verde);
		
		azul = new JLabel("Azul: ");
		azul.setBounds(100, 287, 100, 50);
		add(azul);
		
		
		
		nRojo = new JComboBox();
		nRojo.setBounds(150, 100, 150,25);
		add(nRojo);
		
		nVerde = new JComboBox();
		nVerde.setBounds(150, 200, 150,25);
		add(nVerde);

		nAzul = new JComboBox();
		nAzul.setBounds(150, 300, 150,25);
		add(nAzul);
		
		boton = new JButton("Fijar color");
		boton.setBounds(150, 400, 150, 80);
		add(boton);
		boton.addActionListener(this);
		
	}
	
	void aniadirCampos(){
		
		for(int x = 0; x<256; x++){
		
			nRojo.addItem(x);
			nVerde.addItem(x);
			nAzul.addItem(x);
		
		}
		
	}
	
	public void actionPerformed (ActionEvent e){
				
		int r = (int) nRojo.getSelectedItem();
		int g = (int) nVerde.getSelectedItem();
		int b = (int) nAzul.getSelectedItem();
		
		
		
		if(e.getSource() == boton){
			
			Color color = new Color (r, g, b);
			
			boton.setBackground(color);
			
		}
		
	}
	
	
	public static void main(String[] args) {
		
		ComboColores ventana=new ComboColores();
		
		ventana.aniadirCampos();
		ventana.setTitle("Colores");
        ventana.setBounds(20,20,500,600);
        ventana.setVisible(true);
        ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		
		
	}
}
