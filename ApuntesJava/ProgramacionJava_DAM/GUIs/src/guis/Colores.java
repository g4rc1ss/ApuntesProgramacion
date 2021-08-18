package guis;

import java.awt.Color;
import java.awt.Container;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;


public class Colores extends JFrame implements ActionListener{
	JButton boton1,boton2,boton3;
	
	
	Colores(){
		
		setLayout(null);
		
		boton1=new JButton(new ImageIcon("verde.jpg"));
		boton1.setRolloverIcon(new ImageIcon("verdev.jpg"));
		boton1.setBorderPainted(false); //para quitar el cuadrado que enmarca
		boton1.setBounds(10,20,100,100);
		add(boton1);
		boton1.addActionListener(this);

		boton2=new JButton(new ImageIcon("rojo.png"));
		boton2.setRolloverIcon(new ImageIcon("rojov.png"));
		boton2.setBounds(150,20,100,100);
		add(boton2);
		boton2.addActionListener(this);

		boton3=new JButton(new ImageIcon("azul.jpg"));
		boton3.setRolloverIcon(new ImageIcon("azulv.jpg"));
		boton3.setBounds(10,150,120,120);
		add(boton3);
		boton3.addActionListener(this);
		
	}
	
	
	
	public void actionPerformed(ActionEvent e){
		
		Color color=null; 
		 
		if(e.getSource()==boton1) color=Color.green;
		if(e.getSource()==boton2) color=Color.red;
		if(e.getSource()==boton3) color=Color.blue;
		getContentPane().setBackground(color);
	}

	
	public static void main(String[] args) {
		
		Colores ventana=new Colores();
		ventana.setTitle("Colores");
        ventana.setBounds(20,20,400,400);
        ventana.setVisible(true);
        ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
	}

}

