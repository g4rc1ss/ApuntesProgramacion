package GUI.Acciones;

import GUI.InterfazLogueado;
import GUI.InterfazPrincipal;
import GUI.LecturaArchivoUsuario;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class AccionesInterfazPrincipal implements ActionListener {
    private InterfazPrincipal interfazPrincipal;

    public AccionesInterfazPrincipal(InterfazPrincipal interfazPrincipal) {
        this.interfazPrincipal = interfazPrincipal;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == interfazPrincipal.getLogin()) {
            boolean comprobar = interfazPrincipal.getUser().getText().isEmpty() ||
                    interfazPrincipal.getPass().getPassword().length < 1;
            if (comprobar)
                interfazPrincipal.getRespuestaIntroducirDatos().setVisible(true);
            else {
                interfazPrincipal.getRespuestaIntroducirDatos().setVisible(false);
                String user = interfazPrincipal.getUser().getText();
                char[] passArray = interfazPrincipal.getPass().getPassword();
                String pass = "";
                for (char i : passArray)
                    pass += i;
                if (LecturaArchivoUsuario.isUsuarioPassCorrecto(user, pass)) {
                    interfazPrincipal.getRespuestaIncorrecto().setVisible(false);
                    new InterfazLogueado();
                } else
                    interfazPrincipal.getRespuestaIncorrecto().setVisible(true);
            }
        }
    }
}
