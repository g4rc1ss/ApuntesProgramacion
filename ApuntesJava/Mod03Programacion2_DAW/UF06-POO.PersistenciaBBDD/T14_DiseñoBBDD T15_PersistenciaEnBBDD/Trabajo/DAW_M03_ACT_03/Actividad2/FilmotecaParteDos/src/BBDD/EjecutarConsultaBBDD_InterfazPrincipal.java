package BBDD;

import EnumOptions.NombreTable;

import java.nio.file.Files;
import java.nio.file.Paths;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;


public class EjecutarConsultaBBDD_InterfazPrincipal extends EjecucionBBDD_Base {

    public EjecutarConsultaBBDD_InterfazPrincipal() {
        super();
    }

    public boolean seedCreateDatabaseAndTables() throws SQLException {
        try {
            String query = "SELECT TABLE_NAME\n" +
                    "FROM INFORMATION_SCHEMA.TABLES AS tab\n" +
                    "WHERE tab.TABLE_NAME = 'director';";

            ResultSet resultSet = connection.createStatement().executeQuery(query);
            // Si hay contenido damos como valido porque la bbdd estaria ya creada en serv
            if (resultSet.next())
                return true;

            StringBuilder sqlQuery = new StringBuilder();
            for (String line : Files.readAllLines(Paths.get("scriptBackupBBDD_Actividad2_FilmotecaParteDos.sql")))
                sqlQuery.append(line + "\n");
            for (String queryToExecute : sqlQuery.toString().trim().split(";"))
                connection.createStatement().execute(queryToExecute);
            return true;
        } catch (Exception ex) {
            ex.printStackTrace();
            return false;
        } finally {
            connection.close();
        }
    }

    public ResultSet getListaPeliculas(int pagina, String director, String genero) {
        try {
            String sqlQuery = "SELECT peli.Titulo, peli.Pais, peli.Duracion, peli.Genero, CONCAT(direc.Nombre, ' ', direc.Apellidos) AS nombreDirector\n" +
                    "FROM peliculas.pelicula AS peli, peliculas.director AS direc\n" +
                    "WHERE peli.DirectorId = direc.Id\n ";
            if (!director.isBlank() && !director.isEmpty())
                sqlQuery += "&& direc.Id = (" +
                        "SELECT direc.Id " +
                        "WHERE direc.Nombre = '" + director.split(" ")[0] + "' && direc.Apellidos = '" + director.split(" ")[1] + "')";
            if (!genero.isBlank() && !genero.isEmpty())
                sqlQuery += "&& peli.Genero = '" + genero + "'";
            sqlQuery += "LIMIT 1 \n" +
                    "OFFSET " + pagina + "\n";

            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            return respuesta.next() ? respuesta : null;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public ArrayList<String> getTotalGeneros() {
        try {
            String sqlQuery = "SELECT DISTINCT peli.Genero\n" +
                    "FROM peliculas.Pelicula AS peli\n";
            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            ArrayList<String> listaGeneros = new ArrayList();
            for (; respuesta.next(); )
                listaGeneros.add(respuesta.getString("Genero"));
            return listaGeneros;
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return null;
        }
    }

    public int getTotalRows(String director, String genero) {
        try {
            String sqlQuery = "" +
                    "SELECT COUNT(*) AS Counter\n" +
                    "FROM peliculas.pelicula AS peli, peliculas.director AS direc\n" +
                    "WHERE peli.DirectorId = direc.Id\n ";
            if (!director.isBlank() && !director.isEmpty())
                sqlQuery += "&& direc.Id = (" +
                        "SELECT direc.Id " +
                        "WHERE direc.Nombre = '" + director.split(" ")[0] + "' && direc.Apellidos = '" + director.split(" ")[1] + "')";
            if (!genero.isBlank() && !genero.isEmpty())
                sqlQuery += "&& peli.Genero = '" + genero + "'";
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
