package guis;
import java.awt.Color;
import java.awt.Container;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class Paneles extends JFrame implements ActionListener {

        private JPanel panel1 =new JPanel();
        private JPanel panel2 =new JPanel();
        JTextField field1, field2, field3;        
        JButton boton;
        String cadena1, cadena2;


        
        Paneles(){
        	
        }
        
          void metodo(){
                panel1.setLayout(null);
                panel1.setBounds(10,10,300,500);
                add(panel1);
                
                panel2.setLayout(null);
                panel2.setBounds(10,10,300,500);
                add(panel2);
                
                JLabel label1,label2, label3;
                label1= new JLabel("Primer Numero:");                                 
                label1.setBounds(8,20,100,40); 
                panel1.add(label1); 
    
                 label2 = new JLabel("Segundo Numero:");                            
                 label2.setBounds(8,60,120,40); 
                 panel1.add(label2); 
        
                 label3 = new JLabel("Resultado:");                            
                 label3.setBounds(8,40,100,40); 
                 panel2.add(label3); 
    
                 field1= new JTextField (20);
                 field1.setBounds (125,25,100,25);            
                 panel1.add(field1);
            
                  field2=new JTextField(20);
                  field2.setBounds (125,65,100,25);           
                  panel1.add(field2);
            
                  field3=new JTextField(20);
                  field3.setBounds (125,65,100,25);             
                  panel2.add(field3);
            

                  boton = new JButton("Sumar");
                  boton.setBounds(50,60, 75, 20);
                  boton.addActionListener(this);
                  panel1.add(boton);
           
            
                
          

                   
                 Color color=null; 
                 panel2.setBackground(Color.RED);
                 panel1.setBackground(Color.GREEN);
                        
                        
                 panel1.setVisible(true);
                 panel2.setVisible(false);
}  

                
         public void actionPerformed (ActionEvent e) {
                        
        	 panel1.setVisible(false);
             panel2.setVisible(true); 
             
            cadena1=field1.getText();
            cadena2=field2.getText();
            setTitle("Resultado de sumar: " +cadena1+ " + "+ cadena2);
            int x1=Integer.parseInt(cadena1);
            int x2=Integer.parseInt(cadena2);
            int x3;
            x3=x1+x2;
            String total=String.valueOf(x3);
            field3.setText(total);
                            
         }                                               
           

        

public static void main (String [] args){
        Paneles sumado2 = new Paneles();
        sumado2.setLayout(null);
        sumado2.setBounds(10,10,300,500);
    sumado2.setVisible(true);
    sumado2.setResizable(false);
    sumado2.setTitle("REALIZA UNA SUMA");
    sumado2.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    sumado2.metodo();
}
}
