package GUI.Acciones;

import BBDD.EjecutarConsultaBBDD_FormUpdate;
import BBDD.EjecutarConsultaBBDD_InterfazPrincipal;
import GUI.FormUpdateTables;
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
                    interfazPrincipal.getPagina() == new EjecutarConsultaBBDD_InterfazPrincipal().getTotalRows(
                            (String) interfazPrincipal.getListDirectorFilter().getSelectedItem(),
                            (String) interfazPrincipal.getListGeneroFilter().getSelectedItem()
                    ) - 1
                            ? 0
                            : interfazPrincipal.getPagina() + 1
            );
            interfazPrincipal.cargarDatos(
                    interfazPrincipal.getPagina(),
                    (String) interfazPrincipal.getListDirectorFilter().getSelectedItem(),
                    (String) interfazPrincipal.getListGeneroFilter().getSelectedItem()
            );
        } else if (e.getSource() == interfazPrincipal.getListDirectorFilter() || e.getSource() == interfazPrincipal.getListGeneroFilter()) {
            interfazPrincipal.cargarDatos(
                    0,
                    (String) interfazPrincipal.getListDirectorFilter().getSelectedItem(),
                    (String) interfazPrincipal.getListGeneroFilter().getSelectedItem()
            );
        } else if (e.getSource() == interfazPrincipal.getInsertUpdateDelete()) {
            new FormUpdateTables();
        }
        }
}
