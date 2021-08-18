package guis2;

import java.awt.BorderLayout;
import java.awt.*;
import javax.swing.*;

public class Ejercicio5 extends JFrame {
public Ejercicio5() {
	
}

	JPanel p1 = new JPanel();

	void unPanel() {
		p1.setLayout(new GridLayout(4, 3));
		for (int i = 1; i <= 9; i++) {
			p1.add(new JButton("" + i));
		}
		p1.add(new JButton("" + 0));
		p1.add(new JButton("Start"));
		p1.add(new JButton("Stop"));
		add(p1, BorderLayout.EAST);
		add(new JButton("Este botón está sobre la Ventana"));
	}

	void otroPanel() {

		JPanel p2 = new JPanel();
		p2.setLayout(new BorderLayout());
		p2.add(new JTextField("Esto es un textfield"), BorderLayout.NORTH);

		p2.add(p1, BorderLayout.SOUTH);
		add(p2, BorderLayout.SOUTH);
	}

	public static void main(String[] args) {
		Ejercicio5 frame = new Ejercicio5();
		frame.unPanel();
		frame.otroPanel();
		frame.setSize(400, 250);
		frame.setVisible(true);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

	}
}
