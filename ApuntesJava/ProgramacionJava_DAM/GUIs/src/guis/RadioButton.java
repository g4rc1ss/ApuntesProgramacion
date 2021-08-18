package guis;
import javax.swing.*;
import javax.swing.event.*;

import java.awt.Color;
import java.awt.color.*;

public class RadioButton extends JFrame implements ChangeListener{

	private JRadioButton rad1, rad2, rad3;
	
	private ButtonGroup bg;
	
	RadioButton(){
		
		setLayout(null);
		
		bg = new ButtonGroup();
		
		rad1 = new JRadioButton("Rojo");
		rad1.setBounds(50, 50, 150, 20);
		rad1.addChangeListener(this);
		bg.add(rad1);
		add(rad1);
		
		rad2 = new JRadioButton("Verde");
		rad2.setBounds(50, 100, 150, 20);
		rad2.addChangeListener(this);
		bg.add(rad2);
		add(rad2);
		
		rad3 = new JRadioButton("Azul");
		rad3.setBounds(50, 150, 150, 20);
		rad3.addChangeListener(this);
		bg.add(rad3);
		add(rad3);
		
	}
	
	@Override
	public void stateChanged(ChangeEvent eC) {
		
		Color color=null;
		
		if(rad1.isSelected() == true){
			color=Color.red;
		}
		 
		if(rad2.isSelected() == true){
			color=Color.green;
		}
		
		if(rad3.isSelected() == true){
			color=Color.blue;
		}
		
		getContentPane().setBackground(color);
		
	}
	
	public static void main(String[] args) {
		
		RadioButton cosa = new RadioButton();
		
			cosa.setBounds(100,100,500,500);
			cosa.setResizable(false);
			cosa.setVisible(true);
			cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		
	}

}
