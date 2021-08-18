package guis;

import javax.swing.*;
import java.awt.event.*;

public class Calculadora extends JFrame implements ActionListener {
	
	String Strg1;
	String Strg2;
	
	private JLabel labelNum1;
	private JLabel labelNum2;
	private JLabel labelResultado;
	
	private JTextField txtNum1;
	private JTextField txtNum2;
	private JTextField txtResultado;
	
	private JButton botonSumar;
	private JButton botonBorrar;
	
	Calculadora(){
		
		setLayout( null );
		
		labelNum1 = new JLabel("Primer numero: ");
		labelNum1.setBounds(100,100,150,20);
		add(labelNum1);
		
		labelNum2 = new JLabel("Segundo numero: ");
		labelNum2.setBounds(100,150,150,20);
		add(labelNum2);
		
		labelResultado = new JLabel("Resultado: ");
		labelResultado.setBounds(400,125,80,20);
		add(labelResultado);
		
		
		
		txtNum1 = new JTextField();
		txtNum1.setBounds(225,100,150,20);
		add(txtNum1);
		
		txtNum2 = new JTextField();
		txtNum2.setBounds(225,150,150,20);
		add(txtNum2);
		
		txtResultado = new JTextField();
		txtResultado.setBounds(500,125,150,20);
		add(txtResultado);
		
		
		
		botonSumar = new JButton("Sumar");
		botonSumar.setBounds(240,250,100,50);
		add(botonSumar);
		botonSumar.addActionListener(this);
		
		botonBorrar = new JButton("Borrar");
		botonBorrar.setBounds(360,250,100,50);
		add(botonBorrar);
		botonBorrar.addActionListener(this);
	}
	
	public void actionPerformed(ActionEvent e){
		
		try{
		
			if(e.getSource() == botonSumar ){
		
				Strg1 = txtNum1.getText();
				Strg2 = txtNum2.getText();
	
				int num1 = Integer.parseInt(Strg1);
				int num2 = Integer.parseInt(Strg2);
		
				int resultadoSuma = num1 + num2;
		
				String resultadoStrg = String.valueOf(resultadoSuma);
		
				txtResultado.setText(resultadoStrg);
			
			}
			if(e.getSource() == botonBorrar){
				
				txtNum1.setText("");
				txtNum2.setText("");
				txtResultado.setText("");
				
			}
			
		}catch(NumberFormatException e1){
			
			setTitle("Falta meter numeros");
			
		}
	}
	
	
	
	public static void main(String[] args) {
		
		Calculadora obj = new Calculadora();
		
		obj.setBounds(100,100,700,400);
		obj.setResizable(false);
		obj.setVisible(true);
		obj.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}

}
