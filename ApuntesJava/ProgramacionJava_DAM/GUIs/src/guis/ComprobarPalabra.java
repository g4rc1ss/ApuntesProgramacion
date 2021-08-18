package guis;

import javax.swing.*;
import java.awt.event.*;

public class ComprobarPalabra extends JFrame implements ActionListener{

	private JLabel label1;
	private JLabel label2;
	
	private JTextField txt;
	
	private JScrollPane scroll;
	
	private JTextArea area;
	
	private JButton boton;
	
	
	ComprobarPalabra(){
		
		setLayout(null);
		
		label1 = new JLabel("Escribe una palabra:");
		label1.setBounds(100,100,150,20);
		add(label1);
		
		label2 = new JLabel("Escribe un texto: ");
		label2.setBounds(100,150,150,20);
		add(label2);
		
		txt = new JTextField();
		txt.setBounds(230, 95, 150, 30);
		add(txt);
		
		area = new JTextArea();
		scroll = new JScrollPane(area);
		scroll.setBounds(100,180,420,150);
		add(scroll);
		
		boton = new JButton("COMPROBAR");
		boton.setBounds(100,350,420,75);
		add(boton);
		boton.addActionListener(this);
		
	}
	
	public void actionPerformed(ActionEvent e) {
		
		String parrafo = area.getText();
		String palabra = txt.getText();
		
		if(parrafo.indexOf(palabra) != -1){
			
			setTitle("La palabra \"" + palabra + "\" está en el texto");
			
		}
		else{
			
			setTitle("La palabra \"" + palabra + "\" no está en el texto");
			
		}
		
	}
	
	public static void main(String[] args) {
		
		ComprobarPalabra obj = new ComprobarPalabra();
		
		obj.setBounds(100,100,600,600);
		obj.setResizable(true);
		obj.setVisible(true);
		obj.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		

	}

}
