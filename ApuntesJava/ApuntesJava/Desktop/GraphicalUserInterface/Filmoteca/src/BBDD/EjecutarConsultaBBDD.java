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

    public boolean seedCreateDatabaseAndTables() throws SQLException {
        try {
            String sqlQuery = "" +
                    "SELECT SCHEMA_NAME\n" +
                    "FROM INFORMATION_SCHEMA.SCHEMATA\n" +
                    "WHERE SCHEMA_NAME = 'Peliculas'";
            ResultSet resultSet = connection.createStatement().executeQuery(sqlQuery);
            // Si hay contenido damos como valido porque la bbdd estaria ya creada en serv
            if (resultSet.next())
                return true;

            sqlQuery = "Create database if not exists Peliculas;";
            int result = connection.createStatement().executeUpdate(sqlQuery);
            sqlQuery =
                    "Create table if not exists `peliculas`.`Pelicula`(" +
                            "Id int primary key auto_increment," +
                            "Titulo varchar(100)," +
                            "Director varchar(100)," +
                            "Pais varchar(100)," +
                            "Duracion decimal," +
                            "Genero varchar(50)" +
                            ")";
            result = connection.createStatement().executeUpdate(sqlQuery);
            if (result != 0)
                return false;

            String[] titulos = {"Harry potter: la orden del fenix", "Vengadores: EndGame", "El rey leon",
                    "Animales fantasticos: Los crimenes de Grindelwald", "Jumaji 1995"};
            String[] director = {"David Yates", "Anthony Russo and Joe Russo", "Roger Alles",
                    "David Yates", "Joe Johnson"};
            String[] pais = {"UK", "USA", "USA", "USA", "USA"};
            float[] duracion = {(float) 2.22, (float) 3.02, (float) 1.29, (float) 2.13, (float) 1.44};
            String[] genero = {"fantasia", "ciencia ficcion", "musical", "fantasia", "Aventura"};

            for (int x = 0; x < 5; x++) {
                sqlQuery = "INSERT INTO `peliculas`.`Pelicula`(Titulo, Director, Pais, Duracion, Genero) VALUES (" +
                        "'" + titulos[x] + "', '" + director[x] + "', '" + pais[x] + "', " + duracion[x] + ", '" + genero[x] + "')";
                result += connection.createStatement().executeUpdate(sqlQuery);
            }
            if (result == 5)
                return true;
            else
                connection.createStatement().execute("DROP DATABASE `peliculas`");
            return false;
        } catch (Exception ex) {
            ex.printStackTrace();
            return false;
        } finally {
            connection.close();
        }
    }

    public ResultSet executeSelect(int pagina) throws SQLException {
        try {
            String sqlQuery = "" +
                    "SELECT * \n" +
                    "FROM peliculas.pelicula \n" +
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
                    "FROM peliculas.pelicula";
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
