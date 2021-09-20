package GUI;

import BBDD.EjecutarConsultaBBDD;
import GUI.Acciones.AccionesInterfazPrincipal;

import javax.swing.*;
import java.awt.*;
import java.sql.ResultSet;
import java.sql.SQLException;

public class InterfazPrincipal extends JFrame {
    private JTextField titulo = null;
    private JTextField director = null;
    private JTextField pais = null;
    private JTextField duracion = null;
    private JTextField genero = null;
    private JButton next = null;
    private int pagina = 0;

    public InterfazPrincipal() {
        setBounds(0, 0, 500, 300);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("Actividad 1");
        cargarComponentes();
        cargarDatos(pagina);
        setLayout(null);
        setVisible(true);
    }

    private void cargarComponentes() {
        JLabel mensajeInicio = new JLabel("PELICULAS");
        mensajeInicio.setBounds(190, 10, 200, 50);
        mensajeInicio.setFont(new Font("TimesRoman", Font.PLAIN, 20));
        add(mensajeInicio);

        titulo = new JTextField();
        titulo.setBounds(30, 80, 400, 25);
        titulo.setEditable(false);
        add(titulo);

        pais = new JTextField();
        pais.setBounds(330, 115, 100, 25);
        pais.setEditable(false);
        add(pais);

        duracion = new JTextField();
        duracion.setBounds(130, 150, 200, 25);
        duracion.setEditable(false);
        add(duracion);

        genero = new JTextField();
        genero.setBounds(30, 115, 100, 25);
        genero.setEditable(false);
        add(genero);


        next = new JButton("Siguiente");
        next.setBounds(30, 210, 400, 30);
        next.addActionListener(new AccionesInterfazPrincipal(this));
        add(next);
    }

    // Recargamos los datos de la interfaz grafica con los nuevos datos
    public void cargarDatos(int pagina) {
        try {
            ResultSet respuestaConsulta = new EjecutarConsultaBBDD().executeSelect(pagina);
            if (respuestaConsulta == null)
                System.exit(-1);
            titulo.setText(respuestaConsulta.getString("Titulo"));
            pais.setText(respuestaConsulta.getString("Pais"));
            duracion.setText(String.valueOf(respuestaConsulta.getDouble("Duracion")));
            genero.setText(respuestaConsulta.getString("Genero"));
            respuestaConsulta.close();
        } catch (SQLException sqle){
            sqle.printStackTrace();
        }
    }

    //region Getters and Setters
    public JTextField getTitulo() {
        return titulo;
    }

    public void setTitulo(JTextField titulo) {
        this.titulo = titulo;
    }

    public JTextField getDirector() {
        return director;
    }

    public void setDirector(JTextField director) {
        this.director = director;
    }

    public JButton getNext() {
        return next;
    }

    public void setNext(JButton next) {
        this.next = next;
    }

    public int getPagina() {
        return pagina;
    }

    public void setPagina(int pagina) {
        this.pagina = pagina;
    }
    //endregion
}
