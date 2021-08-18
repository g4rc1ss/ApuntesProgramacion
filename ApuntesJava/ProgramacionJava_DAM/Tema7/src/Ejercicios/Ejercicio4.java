package Ejercicios;

import javax.swing.JFrame;
import javax.swing.JLabel;

public class Ejercicio4 extends JFrame {

    private final String[] array = {"El Corte Ingl�s", "Deloitte", "Ceinmark"};

    private JLabel label;

    private int y = 10;

    private int z = 100;

    public Ejercicio4() {

        setLayout(null);

        for (int x = 0; x < array.length; x++) {

            label = new JLabel(array[x]);

            label.setBounds(10, y, 100, z);

            add(label);

            y += 10;

            z += 100;

        }

    }

    public static void main(String[] args) {

        Ejercicio4 ventana = new Ejercicio4();

        ventana.setBounds(10, 10, 500, 500);
        ventana.setVisible(true);
        ventana.setResizable(true);

        ventana.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

    }

}
