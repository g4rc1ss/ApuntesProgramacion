package GUI;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class LecturaArchivoUsuario {
    private static boolean usuarioPass = false;

    public static boolean isUsuarioPassCorrecto(String user, String pass) {
        InputStream inputStream;
        try {
            Properties properties = new Properties();
            inputStream = new FileInputStream("credenciales.config");
            properties.load(inputStream);
            inputStream.close();
            String usuario = properties.getProperty("usuario").trim();
            String password = properties.getProperty("password").trim();
            if (usuario.equals(user) && password.equals(pass)){
                usuarioPass = true;
                return true;
            }
        } catch (IOException iEx) {
            iEx.printStackTrace();
        }
        return false;
    }

    public static String getNombre() {
        if (usuarioPass) {
            InputStream inputStream;
            try {
                Properties properties = new Properties();
                inputStream = new FileInputStream("credenciales.config");
                properties.load(inputStream);
                inputStream.close();
                return properties.getProperty("nombrePersona");
            } catch (IOException iEx) {
                iEx.printStackTrace();
            }
        }
        return null;
    }

    public static boolean getUsuarioPass() {
        return usuarioPass;
    }
}
