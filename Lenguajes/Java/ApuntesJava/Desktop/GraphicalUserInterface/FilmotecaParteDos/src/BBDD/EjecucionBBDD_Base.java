package BBDD;

import java.io.BufferedReader;
import java.io.FileReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class EjecucionBBDD_Base {
    protected String cadenaConexion;
    protected String usuario;
    protected String password;
    protected Connection connection;

    public EjecucionBBDD_Base() {
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

    public ArrayList<String> getTotalDirectores() {
        try {
            String sqlQuery = "SELECT CONCAT(direc.Nombre, ' ', direc.Apellidos) AS Director\n" +
                    "FROM apuntesjava.director AS direc\n";
            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            ArrayList<String> listaDirectores = new ArrayList();
            for (; respuesta.next(); )
                listaDirectores.add(respuesta.getString("Director"));
            return listaDirectores;
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return null;
        }
    }
}
