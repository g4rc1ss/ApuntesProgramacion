package GUI.Acciones;

import BBDD.EjecutarConsultaBBDD_FormUpdate;
import EnumOptions.NombreTable;
import GUI.FormUpdateTables;
import jdk.jshell.spi.ExecutionControl;

import javax.swing.*;
import java.awt.event.*;

public class AccionesFormUpdateTables implements ActionListener, FocusListener, KeyListener {
    private FormUpdateTables formUpdateTables;

    public AccionesFormUpdateTables(FormUpdateTables formUpdateTables) {
        this.formUpdateTables = formUpdateTables;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == formUpdateTables.getListTables()) {
            formUpdateTables.cargarPeliculasOrDirectores();

        } else if (e.getSource() == formUpdateTables.getSelectElementToChangeOrDelete()) {
            if (formUpdateTables.getListTables().getSelectedItem() == NombreTable.pelicula)
                formUpdateTables.cargarDatosPeliculas();
            else if (formUpdateTables.getListTables().getSelectedItem() == NombreTable.director)
                formUpdateTables.cargarDatosDirectores();

        } else if (e.getSource() == formUpdateTables.getUpdate()) {
            if (!formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem().equals("")) {
                int result = new EjecutarConsultaBBDD_FormUpdate().updateTable(
                        (NombreTable) formUpdateTables.getListTables().getSelectedItem(),
                        formUpdateTables.getTitulo().getText(),
                        formUpdateTables.getGenero().getText(),
                        formUpdateTables.getDuracion().getText().isEmpty() || formUpdateTables.getDuracion().getText().equals("duracion")
                                ? 0.0
                                : Double.parseDouble(formUpdateTables.getDuracion().getText()),
                        formUpdateTables.getPais().getText(),
                        formUpdateTables.getDirectores().getSelectedIndex() + 1,
                        formUpdateTables.getListTables().getSelectedItem() == NombreTable.pelicula
                                ? (String) formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem()
                                : ((String) formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem()).split(" ")[0],
                        formUpdateTables.getListTables().getSelectedItem() == NombreTable.director
                                ? ((String) formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem()).split(" ")[1]
                                : ""
                );
                if (result > 0)
                    formUpdateTables.cargarPeliculasOrDirectores();
            }

        } else if (e.getSource() == formUpdateTables.getDelete()) {
            if (!formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem().equals("")) {
                int result = new EjecutarConsultaBBDD_FormUpdate().deleteRow(
                        (NombreTable) formUpdateTables.getListTables().getSelectedItem(),
                        formUpdateTables.getListTables().getSelectedItem() == NombreTable.pelicula
                                ? (String) formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem()
                                : ((String) formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem()).split(" ")[0],
                        formUpdateTables.getListTables().getSelectedItem() == NombreTable.director
                                ? ((String) formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem()).split(" ")[1]
                                : ""
                );
                if (result > 0)
                    formUpdateTables.cargarPeliculasOrDirectores();
            }

        } else if (e.getSource() == formUpdateTables.getInsert()) {
            if (formUpdateTables.getSelectElementToChangeOrDelete().getSelectedItem().equals("")) {
                int result = new EjecutarConsultaBBDD_FormUpdate().insertInto(
                        (NombreTable) formUpdateTables.getListTables().getSelectedItem(),
                        formUpdateTables.getTitulo().getText(),
                        formUpdateTables.getGenero().getText(),
                        formUpdateTables.getDuracion().getText().isEmpty() || formUpdateTables.getDuracion().getText().equals("duracion")
                                ? 0.0
                                : Double.parseDouble(formUpdateTables.getDuracion().getText()),
                        formUpdateTables.getPais().getText(),
                        formUpdateTables.getDirectores().getSelectedIndex() + 1
                );
                if (result > 0)
                    formUpdateTables.cargarPeliculasOrDirectores();

            }
        }
    }

    @Override
    public void focusGained(FocusEvent e) {
        JTextField campo = null;
        if (e.getSource() == formUpdateTables.getTitulo()) {
            if (formUpdateTables.getTitulo().getText().equals("titulo") || formUpdateTables.getTitulo().getText().equals("")) {
                campo = formUpdateTables.getTitulo();
                campo.setText("");
                formUpdateTables.setTitulo(campo);
            }

        } else if (e.getSource() == formUpdateTables.getDuracion()) {
            if (formUpdateTables.getDuracion().getText().equals("duracion") || formUpdateTables.getDuracion().getText().equals("")) {
                campo = formUpdateTables.getDuracion();
                campo.setText("");
                formUpdateTables.setDuracion(campo);
            }

        } else if (e.getSource() == formUpdateTables.getGenero()) {
            if (formUpdateTables.getGenero().getText().equals("genero") || formUpdateTables.getGenero().getText().equals("")) {
                campo = formUpdateTables.getGenero();
                campo.setText("");
                formUpdateTables.setGenero(campo);
            }

        } else if (e.getSource() == formUpdateTables.getPais()) {
            if (formUpdateTables.getPais().getText().equals("pais") || formUpdateTables.getPais().getText().equals("")) {
                campo = formUpdateTables.getPais();
                campo.setText("");
                formUpdateTables.setPais(campo);
            }
        }
    }

    @Override
    public void focusLost(FocusEvent e) {
        JTextField campo = null;
        if (e.getSource() == formUpdateTables.getTitulo()) {
            campo = formUpdateTables.getTitulo();
            if (campo.getText().isBlank() || campo.getText().isEmpty()) {
                campo.setText("titulo");
            }
            formUpdateTables.setTitulo(campo);

        } else if (e.getSource() == formUpdateTables.getDuracion()) {
            campo = formUpdateTables.getDuracion();
            if (campo.getText().isBlank() || campo.getText().isEmpty()) {
                campo.setText("duracion");
            }
            formUpdateTables.setDuracion(campo);

        } else if (e.getSource() == formUpdateTables.getGenero()) {
            campo = formUpdateTables.getGenero();
            if (campo.getText().isBlank() || campo.getText().isEmpty()) {
                campo.setText("genero");
            }
            formUpdateTables.setGenero(campo);

        } else if (e.getSource() == formUpdateTables.getPais()) {
            campo = formUpdateTables.getPais();
            if (campo.getText().isBlank() || campo.getText().isEmpty()) {
                campo.setText("pais");
            }
            formUpdateTables.setPais(campo);
        }
    }

    @Override
    public void keyTyped(KeyEvent e) {
        if (e.getSource() == formUpdateTables.getDuracion()) {
            char letter = e.getKeyChar();
            if (Character.isLetter(letter))
                e.consume();
        }
    }

    @Override
    public void keyPressed(KeyEvent e) {
    }

    @Override
    public void keyReleased(KeyEvent e) {

    }
}

