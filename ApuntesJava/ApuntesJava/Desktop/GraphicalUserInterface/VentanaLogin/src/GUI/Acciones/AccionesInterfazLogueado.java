package GUI.Acciones;

import GUI.InterfazLogueado;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AccionesInterfazLogueado implements ActionListener {
    private InterfazLogueado interfazLogueado;

    public AccionesInterfazLogueado(InterfazLogueado interfazLogueado) {
        this.interfazLogueado = interfazLogueado;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == interfazLogueado.getCerrarVentana())
            interfazLogueado.dispose();
    }
}
