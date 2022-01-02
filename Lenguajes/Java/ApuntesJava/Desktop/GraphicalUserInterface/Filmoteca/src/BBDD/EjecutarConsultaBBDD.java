package BBDD;

import java.io.BufferedReader;
import java.io.FileReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;

public class EjecutarConsultaBBDD {
    private String cadenaConexion;
    private String usuario;
    private String password;
    private Connection connection;

    public EjecutarConsultaBBDD() {
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

    public ResultSet executeSelect(int pagina) throws SQLException {
        try {
            String sqlQuery = "" +
                    "SELECT * \n" +
                    "FROM apuntesjava.pelicula \n" +
                    "LIMIT 1 \n" +
                    "OFFSET " + pagina;
            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            return respuesta.next() ? respuesta : null;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public int getTotalRows() {
        try {
            String sqlQuery = "" +
                    "SELECT COUNT(*) AS Counter\n" +
                    "FROM apuntesjava.pelicula";
            ResultSet resultado = connection.createStatement().executeQuery(sqlQuery);
            resultado.next();
            int totalRows = resultado.getInt("Counter");
            connection.close();
            return totalRows;
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return -1;
        }
    }

}
