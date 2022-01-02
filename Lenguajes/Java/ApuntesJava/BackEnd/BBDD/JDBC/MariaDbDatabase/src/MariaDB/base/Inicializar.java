package MariaDB.base;

import java.io.BufferedReader;
import java.io.FileReader;
import java.sql.Connection;
import java.sql.DriverManager;

public class Inicializar {
    protected String cadenaConexion;
    protected String usuario;
    protected String password;
    protected Connection connection;

    public Inicializar() {
        initializeConnection();
    }

    private void initializeConnection() {
        try {
            BufferedReader read = new BufferedReader(new FileReader("cadenaDeConexion.txt"));
            cadenaConexion = read.readLine();
            usuario = read.readLine();
            password = read.readLine();
            connection = DriverManager.getConnection(cadenaConexion, usuario, password);

            read.close();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
