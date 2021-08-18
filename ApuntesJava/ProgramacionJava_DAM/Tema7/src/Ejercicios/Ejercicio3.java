package Ejercicios;

import java.awt.Color;

import javax.swing.JFrame;
import javax.swing.JLabel;

public class Ejercicio3 extends JFrame {

    private final JLabel label1;
    private final JLabel label2;
    private final JLabel label3;

    public Ejercicio3() {

        setLayout(null);

        label1 = new JLabel("El Corte Ingl�s");
        label2 = new JLabel("Deloitte");
        label3 = new JLabel("Ceinmark");

        label1.setBounds(10, 10, 100, 100);
        label2.setBounds(10, 20, 100, 200);
        label3.setBounds(10, 30, 100, 300);

        add(label1);
        add(label2);
        add(label3);

    }

    public static void main(String[] args) {

        Ejercicio3 ventana = new Ejercicio3();

        ventana.setBounds(10, 10, 500, 500);
        ventana.setVisible(true);
        ventana.setResizable(true);

        ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

    }

}
