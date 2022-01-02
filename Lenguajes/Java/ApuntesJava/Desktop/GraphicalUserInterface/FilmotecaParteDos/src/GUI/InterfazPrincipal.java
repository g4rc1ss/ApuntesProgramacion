package GUI;

import BBDD.EjecutarConsultaBBDD_InterfazPrincipal;
import GUI.Acciones.AccionesFormUpdateTables;
import GUI.Acciones.AccionesInterfazPrincipal;

import javax.swing.*;
import java.awt.*;
import java.sql.ResultSet;
import java.sql.SQLException;

public class InterfazPrincipal extends JFrame {
    private JComboBox listDirectorFilter;
    private JComboBox listGeneroFilter;
    private JTextField titulo = null;
    private JTextField director = null;
    private JTextField pais = null;
    private JTextField duracion = null;
    private JTextField genero = null;
    private JButton next = null;
    private JButton insertUpdateDelete = null;
    private int pagina = 0;

    public InterfazPrincipal() {
        setBounds(0, 0, 500, 300);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("Actividad 2");
        cargarComponentes();
        cargarDatos(pagina, (String) listDirectorFilter.getSelectedItem(), (String) listGeneroFilter.getSelectedItem());
        setLayout(null);
        setVisible(true);
    }

    private void cargarComponentes() {
        JLabel mensajeInicio = new JLabel("PELICULAS");
        mensajeInicio.setBounds(190, 10, 200, 50);
        mensajeInicio.setFont(new Font("TimesRoman", Font.PLAIN, 20));
        add(mensajeInicio);

        listDirectorFilter = new JComboBox<String>();
        listDirectorFilter.setBounds(30, 25, 120, 20);
        cargarDatosDirectores();
        listDirectorFilter.addActionListener(new AccionesInterfazPrincipal(this));
        add(listDirectorFilter);

        listGeneroFilter = new JComboBox<String>();
        listGeneroFilter.setBounds(340, 25, 120, 20);
        cargarDatosGeneros();
        listGeneroFilter.addActionListener(new AccionesInterfazPrincipal(this));
        add(listGeneroFilter);

        titulo = new JTextField();
        titulo.setBounds(30, 80, 400, 25);
        add(titulo);

        director = new JTextField();
        director.setBounds(180, 115, 100, 25);
        add(director);

        pais = new JTextField();
        pais.setBounds(330, 115, 100, 25);
        add(pais);

        duracion = new JTextField();
        duracion.setBounds(130, 150, 200, 25);
        add(duracion);

        genero = new JTextField();
        genero.setBounds(30, 115, 100, 25);
        add(genero);


        next = new JButton("Siguiente");
        next.setBounds(30, 210, 100, 30);
        next.addActionListener(new AccionesInterfazPrincipal(this));
        add(next);

        insertUpdateDelete = new JButton("Insertar/Eliminar");
        insertUpdateDelete.setBounds(320, 210, 150, 30);
        insertUpdateDelete.addActionListener(new AccionesInterfazPrincipal(this));
        add(insertUpdateDelete);
    }


    private void cargarDatosGeneros() {
        listGeneroFilter.addItem("");
        for (String genero : new EjecutarConsultaBBDD_InterfazPrincipal().getTotalGeneros()) {
            listGeneroFilter.addItem(genero);
        }
    }

    private void cargarDatosDirectores() {
        listDirectorFilter.addItem("");
        for (String director : new EjecutarConsultaBBDD_InterfazPrincipal().getTotalDirectores()) {
            listDirectorFilter.addItem(director);
        }
    }

    // Recargamos los datos de la interfaz grafica con los nuevos datos
    public void cargarDatos(int pagina, String director, String genero) {
        try {
            ResultSet respuestaConsulta = new EjecutarConsultaBBDD_InterfazPrincipal().getListaPeliculas(pagina, director, genero);
            titulo.setText(respuestaConsulta != null ? respuestaConsulta.getString("Titulo") : "");
            this.director.setText(respuestaConsulta != null ? respuestaConsulta.getString("nombreDirector") : "");
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

    //region Getters and Setters
    public JButton getNext() {
        return next;
    }

    public int getPagina() {
        return pagina;
    }

    public JButton getInsertUpdateDelete() {
        return insertUpdateDelete;
    }
    public void setPagina(int pagina) {
        this.pagina = pagina;
    }

    public JComboBox getListDirectorFilter() {
        return listDirectorFilter;
    }

    public void setListDirectorFilter(JComboBox listDirectorFilter) {
        this.listDirectorFilter = listDirectorFilter;
    }

    public JComboBox getListGeneroFilter() {
        return listGeneroFilter;
    }

    public void setListGeneroFilter(JComboBox listGeneroFilter) {
        this.listGeneroFilter = listGeneroFilter;
    }
    //endregion
}
