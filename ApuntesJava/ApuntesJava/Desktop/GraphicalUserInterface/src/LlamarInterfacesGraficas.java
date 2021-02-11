import InterfazGUI.Form.InterfazDisenio;

import javax.swing.*;

public class LlamarInterfacesGraficas {
    public static void main(String[] args) {
        new InterfazGUI.Code.ProyectoFarolas.InterfazGrafica().panelPrincipal();

        var frame = new JFrame("pruebaConDisenio");
        frame.setContentPane(new InterfazDisenio().getPanel1());
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
    }
}
