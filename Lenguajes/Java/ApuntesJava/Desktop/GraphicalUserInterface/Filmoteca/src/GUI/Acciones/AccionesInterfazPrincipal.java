package GUI.Acciones;

import BBDD.EjecutarConsultaBBDD;
import GUI.InterfazPrincipal;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AccionesInterfazPrincipal implements ActionListener {
    private InterfazPrincipal interfazPrincipal;

    public AccionesInterfazPrincipal(InterfazPrincipal interfazPrincipal) {
        this.interfazPrincipal = interfazPrincipal;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == interfazPrincipal.getNext()) {
            interfazPrincipal.setPagina(
                    interfazPrincipal.getPagina() == new EjecutarConsultaBBDD().getTotalRows() - 1
                            ? 0
                            : interfazPrincipal.getPagina() + 1
            );
            interfazPrincipal.cargarDatos(interfazPrincipal.getPagina());
        }
    }
}
