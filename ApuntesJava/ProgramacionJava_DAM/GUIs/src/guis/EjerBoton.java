package guis;


	import javax.swing.*;
	import java.awt.event.*;
	public class EjerBoton extends JFrame implements ActionListener {
	    JButton boton1;
	    public EjerBoton() {
	        setLayout(null);
	        boton1=new JButton("Pulsar para terminar");
	        boton1.setBounds(10,20,300,30);
	        add(boton1);
	        boton1.addActionListener(this);
	    }
	    
	    public void actionPerformed(ActionEvent e) {
	        if (e.getSource()==boton1) {
	            System.exit(0);
	        }
	    }
	    
	    public static void main(String[] ar) {
	        EjerBoton ventana=new EjerBoton();
	        ventana.setBounds(10,10,400,300);
	        ventana.setResizable(false);/* el operador no puede modificar el                              
	                                       tamaño de la ventana*/
	       ventana.setVisible(true);
	       ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	 }
	    
}


