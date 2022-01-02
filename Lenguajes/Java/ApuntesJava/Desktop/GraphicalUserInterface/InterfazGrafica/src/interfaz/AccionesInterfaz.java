package interfaz;

import interfaz.grafica.Interfaz;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AccionesInterfaz extends Interfaz implements ActionListener {
    public AccionesInterfaz() {
        super();
    }

    @Override
    public void cargaComponentes() {
        super.cargaComponentes();
        botonAceptar.addActionListener(this);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        JDialog dialogo;
        if (e.getSource() == botonAceptar) {
            // Comprobar si estan rellenados los campos
            // si es distinto de vacio los dos seran true, ambos tienen que estar rellenados
            boolean cajasTexto = !nombre.getText().isEmpty() && !apellido.getText().isEmpty();

            boolean radioButtons = radioSexoF.isSelected() || radioSexoM.isSelected();
            boolean checkBox = checkAficionesLeer.isSelected() || checkAficionesExpoPerros.isSelected() ||
                    checkAficionesTiroArco.isSelected();
            if (cajasTexto && radioButtons && checkBox) {
                dialogo = new JDialog();
                dialogo.setBounds(0, 0, 200, 200);
                dialogo.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
                dialogo.add(new JLabel("Gracias por usar la aplicacion"));
                dialogo.setVisible(true);
            } else {
                dialogo = new JDialog();
                dialogo.setBounds(0, 0, 300, 200);
                dialogo.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
                if (!cajasTexto)
                    dialogo.add(new JLabel("Tienes que escribir el nombre o el apellido")).setBounds(0, 30, 500, 20);
                if (!radioButtons)
                    dialogo.add(new JLabel("Tienes que seleccionar un sexo")).setBounds(0, 50, 500, 20);
                if (!checkBox)
                    dialogo.add(new JLabel("Tienes que seleccionar una aficion")).setBounds(0, 80, 500, 20);
                dialogo.setVisible(true);
            }
        }
    }
}
