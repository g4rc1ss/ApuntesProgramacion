package GUI;

import GUI.Acciones.AccionesInterfazPrincipal;

import javax.swing.*;
import java.awt.*;

public class InterfazPrincipal extends JFrame {
    private JLabel respuestaIncorrecto = null;
    private JLabel respuestaIntroducirDatos = null;
    private JTextField user = null;
    private JPasswordField pass = null;
    private JButton login = null;

    public InterfazPrincipal() {
        setBounds(0, 0, 300, 300);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("Actividad 3");
        cargarComponentes();
        setLayout(null);
        setVisible(true);
    }

    private void cargarComponentes() {
        JLabel mensajeInicio = new JLabel("INICIA SESION");
        mensajeInicio.setBounds(75, 30, 200, 50);
        mensajeInicio.setFont(new Font("TimesRoman", Font.PLAIN, 20));
        add(mensajeInicio);

        respuestaIntroducirDatos = new JLabel("DEBES INTRODUCIR LOS DATOS");
        respuestaIntroducirDatos.setBounds(65, 70, 200, 20);
        respuestaIntroducirDatos.setForeground(Color.red);
        respuestaIntroducirDatos.setVisible(false);
        add(respuestaIntroducirDatos);

        user = new JTextField();
        user.setBounds(80, 100, 130, 25);
        add(user);

        pass = new JPasswordField();
        pass.setBounds(80, 125, 130, 25);
        add(pass);

        login = new JButton("Iniciar Sesion");
        login.setBounds(80, 155, 130, 30);
        login.addActionListener(new AccionesInterfazPrincipal(this));
        add(login);

        respuestaIncorrecto = new JLabel("CREDENCIALES INCORRECTAS");
        respuestaIncorrecto.setBounds(65, 195, 200, 20);
        respuestaIncorrecto.setForeground(Color.red);
        respuestaIncorrecto.setVisible(false);
        add(respuestaIncorrecto);
    }

    //region Getters and Setters
    public JLabel getRespuestaIncorrecto() {
        return respuestaIncorrecto;
    }

    public void setRespuestaIncorrecto(JLabel respuestaIncorrecto) {
        this.respuestaIncorrecto = respuestaIncorrecto;
    }

    public JLabel getRespuestaIntroducirDatos() {
        return respuestaIntroducirDatos;
    }

    public void setRespuestaIntroducirDatos(JLabel respuestaIntroducirDatos) {
        this.respuestaIntroducirDatos = respuestaIntroducirDatos;
    }

    public JTextField getUser() {
        return user;
    }

    public void setUser(JTextField user) {
        this.user = user;
    }

    public JPasswordField getPass() {
        return pass;
    }

    public void setPass(JPasswordField pass) {
        this.pass = pass;
    }

    public JButton getLogin() {
        return login;
    }

    public void setLogin(JButton login) {
        this.login = login;
    }
    //endregion
}
