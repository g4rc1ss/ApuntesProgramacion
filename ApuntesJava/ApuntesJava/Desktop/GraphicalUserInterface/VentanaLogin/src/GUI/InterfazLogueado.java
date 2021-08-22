package GUI;

import GUI.Acciones.AccionesInterfazLogueado;

import javax.swing.*;
import java.io.*;
import java.util.Properties;

public class InterfazLogueado extends JFrame {
    JButton cerrarVentana;
    JLabel mostrarNombreUsuario;

    public InterfazLogueado() {
        setBounds(0, 0, 300, 200);
        setResizable(false);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        setTitle("ESTAS LOGUEADO");
        cargarComponentes();
        setLayout(null);
        setVisible(true);
    }

    private void cargarComponentes() {
        mostrarNombreUsuario = new JLabel(LecturaArchivoUsuario.getNombre());
        mostrarNombreUsuario.setBounds(80, 10, 200, 20);
        add(mostrarNombreUsuario);

        cerrarVentana = new JButton("Cerrar");
        cerrarVentana.setBounds(80, 77, 130, 30);
        cerrarVentana.addActionListener(new AccionesInterfazLogueado(this));
        add(cerrarVentana);
    }

    //region getters and setters
    public JButton getCerrarVentana() {
        return cerrarVentana;
    }

    public JLabel getMostrarNombreUsuario() {
        return mostrarNombreUsuario;
    }
    //endregion
}
