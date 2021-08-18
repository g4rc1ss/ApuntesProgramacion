package GUI;

import BBDD.EjecutarConsultaBBDD_FormUpdate;
import BBDD.EjecutarConsultaBBDD_InterfazPrincipal;
import EnumOptions.NombreTable;
import GUI.Acciones.AccionesFormUpdateTables;

import javax.swing.*;
import java.awt.*;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class FormUpdateTables extends JFrame {
    private JComboBox listTables = null;
    private JComboBox selectElementToChangeOrDelete;
    private JComboBox directores = null;
    private JTextField titulo = null;
    private JTextField pais = null;
    private JTextField duracion = null;
    private JTextField genero = null;
    private JButton insert = null;
    private JButton update = null;
    private JButton delete = null;

    public FormUpdateTables() {
        setBounds(520, 0, 500, 300);
        setResizable(false);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        setTitle("Actividad 2");
        cargarComponentes();
        setLayout(null);
        setVisible(true);
    }

    private void cargarComponentes() {
        JLabel mensajeInicio = new JLabel("Actualizador");
        mensajeInicio.setBounds(190, 10, 200, 50);
        mensajeInicio.setFont(new Font("TimesRoman", Font.PLAIN, 20));
        add(mensajeInicio);

        listTables = new JComboBox<NombreTable>();
        listTables.setBounds(30, 25, 120, 20);
        for (NombreTable table : NombreTable.values())
            listTables.addItem(table);
        listTables.addActionListener(new AccionesFormUpdateTables(this));
        add(listTables);

        selectElementToChangeOrDelete = new JComboBox<String>();
        selectElementToChangeOrDelete.setBounds(340, 25, 120, 20);
        cargarPeliculasOrDirectores();
        selectElementToChangeOrDelete.addActionListener(new AccionesFormUpdateTables(this));
        add(selectElementToChangeOrDelete);

        directores = new JComboBox<String>();
        directores.setBounds(180, 115, 100, 25);
        cargarDirectores();
        add(directores);


        titulo = new JTextField("titulo");
        titulo.setBounds(30, 80, 400, 25);
        titulo.addFocusListener(new AccionesFormUpdateTables(this));
        add(titulo);

        pais = new JTextField("pais");
        pais.setBounds(330, 115, 100, 25);
        pais.addFocusListener(new AccionesFormUpdateTables(this));
        add(pais);

        duracion = new JTextField("duracion");
        duracion.setBounds(130, 150, 200, 25);
        duracion.addFocusListener(new AccionesFormUpdateTables(this));
        duracion.addKeyListener(new AccionesFormUpdateTables(this));
        add(duracion);

        genero = new JTextField("genero");
        genero.setBounds(30, 115, 100, 25);
        genero.addFocusListener(new AccionesFormUpdateTables(this));
        add(genero);


        insert = new JButton("Insertar");
        insert.setBounds(70, 210, 100, 30);
        insert.addActionListener(new AccionesFormUpdateTables(this));
        add(insert);

        update = new JButton("Updatear");
        update.setBounds(180, 210, 100, 30);
        update.addActionListener(new AccionesFormUpdateTables(this));
        add(update);

        delete = new JButton("Eliminar");
        delete.setBounds(290, 210, 100, 30);
        delete.addActionListener(new AccionesFormUpdateTables(this));
        add(delete);
    }

    public void cargarPeliculasOrDirectores() {
        ArrayList<String> listaElement;
        if (listTables.getSelectedItem() == NombreTable.pelicula) {
            listaElement = new EjecutarConsultaBBDD_FormUpdate().getTitleOfPeliculas();
        } else {
            listaElement = new EjecutarConsultaBBDD_FormUpdate().getTotalDirectores();
        }
        selectElementToChangeOrDelete.removeAllItems();
        selectElementToChangeOrDelete.addItem("");
        for(String elemento : listaElement)
            selectElementToChangeOrDelete.addItem(elemento);

    }

    public void cargarDirectores() {
        for (String director : new EjecutarConsultaBBDD_InterfazPrincipal().getTotalDirectores())
            directores.addItem(director);
    }

    public void cargarDatosPeliculas() {
        try {
            ResultSet respuestaConsulta = new EjecutarConsultaBBDD_FormUpdate().getPeliculas((String)selectElementToChangeOrDelete.getSelectedItem());
            titulo.setText(respuestaConsulta != null ? respuestaConsulta.getString("Titulo") : "");

            if(respuestaConsulta != null && respuestaConsulta.getInt("DirectorId") > 0) {
                if(directores.getItemCount() > 0)
                    directores.removeAllItems();
                cargarDirectores();
                directores.setSelectedIndex(respuestaConsulta.getInt("DirectorId") - 1);
            }

            pais.setText(respuestaConsulta != null ? respuestaConsulta.getString("Pais") : "");
            duracion.setText(respuestaConsulta != null ? String.valueOf(respuestaConsulta.getDouble("Duracion")) : "");
            this.genero.setText(respuestaConsulta != null ? respuestaConsulta.getString("Genero") : "");
            if(respuestaConsulta == null)
                return;
            respuestaConsulta.close();
        } catch (SQLException sqle) {
            sqle.printStackTrace();
        }

    }

    public void cargarDatosDirectores() {
        try {
            ResultSet respuestaConsulta = new EjecutarConsultaBBDD_FormUpdate().getDirectores((String)selectElementToChangeOrDelete.getSelectedItem());
            titulo.setText(respuestaConsulta != null ? respuestaConsulta.getString("Nombre") : "");
            genero.setText(respuestaConsulta != null ? respuestaConsulta.getString("Apellidos") : "");

            duracion.setText("");
            directores.removeAllItems();
            pais.setText("");
            if(respuestaConsulta == null)
                return;
            respuestaConsulta.close();
        } catch (SQLException sqle) {
            sqle.printStackTrace();
        }
    }

    // region Getters and Setters
    public JComboBox getListTables() {
        return listTables;
    }

    public void setListTables(JComboBox listTables) {
        this.listTables = listTables;
    }

    public JComboBox getSelectElementToChangeOrDelete() {
        return selectElementToChangeOrDelete;
    }

    public void setSelectElementToChangeOrDelete(JComboBox selectElementToChangeOrDelete) {
        this.selectElementToChangeOrDelete = selectElementToChangeOrDelete;
    }

    public JComboBox getDirectores() {
        return directores;
    }

    public void setDirectores(JComboBox directores) {
        this.directores = directores;
    }

    public JTextField getTitulo() {
        return titulo;
    }

    public void setTitulo(JTextField titulo) {
        this.titulo = titulo;
    }

    public JTextField getPais() {
        return pais;
    }

    public void setPais(JTextField pais) {
        this.pais = pais;
    }

    public JTextField getDuracion() {
        return duracion;
    }

    public void setDuracion(JTextField duracion) {
        this.duracion = duracion;
    }

    public JTextField getGenero() {
        return genero;
    }

    public void setGenero(JTextField genero) {
        this.genero = genero;
    }

    public JButton getInsert() {
        return insert;
    }

    public void setInsert(JButton insert) {
        this.insert = insert;
    }

    public JButton getUpdate() {
        return update;
    }

    public void setUpdate(JButton update) {
        this.update = update;
    }

    public JButton getDelete() {
        return delete;
    }

    public void setDelete(JButton delete) {
        this.delete = delete;
    }
    //endregion
}
