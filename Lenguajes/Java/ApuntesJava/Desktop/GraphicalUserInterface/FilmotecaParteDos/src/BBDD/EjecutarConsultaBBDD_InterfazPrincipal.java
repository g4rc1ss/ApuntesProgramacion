package BBDD;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;


public class EjecutarConsultaBBDD_InterfazPrincipal extends EjecucionBBDD_Base {

    public EjecutarConsultaBBDD_InterfazPrincipal() {
        super();
    }

    public ResultSet getListaPeliculas(int pagina, String director, String genero) {
        try {
            String sqlQuery = "SELECT peli.Titulo, peli.Pais, peli.Duracion, peli.Genero, CONCAT(direc.Nombre, ' ', direc.Apellidos) AS nombreDirector\n" +
                    "FROM apuntesjava.pelicula AS peli, apuntesjava.director AS direc\n" +
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
                    "FROM apuntesjava.pelicula AS peli\n";
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
                    "FROM apuntesjava.pelicula AS peli, apuntesjava.director AS direc\n" +
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
