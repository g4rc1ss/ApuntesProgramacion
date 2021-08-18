package guis2;

import java.awt.*;
import java.awt.event.*;
import java.awt.geom.Ellipse2D;

import javax.swing.*;


public class StartStop extends JFrame implements ActionListener{

	JButton start, stop;
	int x = 10;
	int y = 100;
	
	int a = 1;
	int b = 1;
	
	Timer tiempo;
	int intervalo = 100;
	
	StartStop(){
		
		setLayout( new FlowLayout() );
		
		tiempo = new Timer(intervalo, new Accion());
		tiempo.stop();
		
		start = new JButton("Start");
		add(start);
		start.addActionListener(this);
		
		stop = new JButton("Stop");
		add(stop);
		stop.addActionListener(this);

		
		
	}
	
	void moverBola( ) {
		
		
		x = x + a;
		y = y + b;
		
		if(x == 167)
			a = -1;
		
		if(x == 0)
			a = 1;
		
		if(y == 580)
			b = -1;
		
		if(y == 100)
			b = 1;
		
	
	
}

	
	public void paint(Graphics g) { 
		
		super.paint(g);
		Graphics2D g2d = (Graphics2D) g;
		g2d.setColor(Color.RED);
		g2d.fillOval(x, y, 30, 30);
		
		g2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		
		
								
	}
	
	
	@Override
	public void actionPerformed(ActionEvent e) {

		if(e.getSource()==start){
			
			tiempo.start();
			
		}
		
		if(e.getSource()==stop){
			
			tiempo.stop();
			
		}
		
	}
	
	public static void main(String[] args) {
		
		
		StartStop cosa=new StartStop();	//se crea el frame que va a contener el JPanel	
		cosa.setTitle("Rebotar");
		cosa.setBounds(50,50,200, 600);
		cosa.setVisible(true);
		cosa.setResizable(false);
		cosa.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		

	}

	class Accion implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent arg0) {
			
			moverBola();
			repaint();
			
		}
		
	}

}
