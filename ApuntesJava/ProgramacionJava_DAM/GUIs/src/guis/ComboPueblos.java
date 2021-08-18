package guis;

import javax.swing.*;
import java.awt.event.*;

public class ComboPueblos extends JFrame implements ActionListener {
	
	
	private JLabel label;
	private JComboBox caja;
	
	
	ComboPueblos(){
		
		setLayout (null);
		
		label = new JLabel( "Pueblos:" );
		label.setBounds(100,100,150,20);
		add( label );
		
		caja = new JComboBox(  );
		caja.setBounds(230, 95, 150, 30);
		add( caja );
		caja.addItem( "Barakaldo" );
		caja.addItem( "Berango" );
		caja.addItem( "Bilbao" );
		caja.addActionListener(this);
		
		
	}
	
	@Override
	public void actionPerformed(ActionEvent e) {
		
		String texto = (String)caja.getSelectedItem();
		
		if(texto.equals( "Barakaldo" ) )
			setTitle("Barakaldo");
		
		else if(texto.equals( "Berango" ) )
			setTitle("Berango");
		
		else 
			setTitle("Bilbao");
		
	}

public static void main(String[] args) {
		
		ComboPueblos obj = new ComboPueblos();
		
		obj.setBounds(100,100,600,600);
		obj.setResizable(true);
		obj.setVisible(true);
		obj.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		

	}
	
}
