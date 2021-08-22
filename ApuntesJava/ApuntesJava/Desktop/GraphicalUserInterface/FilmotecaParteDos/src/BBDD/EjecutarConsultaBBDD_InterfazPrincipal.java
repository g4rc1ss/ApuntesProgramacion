package BBDD;

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
            sqlQuery.append("-- Se podria hacer un ALTER TABLE, pero considero que es mejor borrar la base de datos\n");
            sqlQuery.append("-- y crearla de nuevo con las modificaciones\n");
            sqlQuery.append("DROP DATABASE IF EXISTS `peliculas`;\n");
            sqlQuery.append("CREATE DATABASE IF NOT EXISTS `peliculas`;\n" + "\n");

            sqlQuery.append("-- Crear table de los directores\n" + "\n");
            sqlQuery.append("CREATE TABLE IF NOT EXISTS `peliculas`.`Director`(\n");
            sqlQuery.append("\tId INT PRIMARY KEY AUTO_INCREMENT,\n");
            sqlQuery.append("\tNombre VARCHAR(50),\n");
            sqlQuery.append("\tApellidos VARCHAR(50)\n");
            sqlQuery.append(");\n");

            sqlQuery.append("-- Crear table si no existe de peliculas\n");
            sqlQuery.append("CREATE TABLE IF NOT EXISTS `peliculas`.`Pelicula`(\n");
            sqlQuery.append("\tId INT AUTO_INCREMENT,\n");
            sqlQuery.append("\tTitulo VARCHAR(100),\n");
            sqlQuery.append("\tDirectorId INT,\n");
            sqlQuery.append("\tPais VARCHAR(100),\n");
            sqlQuery.append("\tDuracion DECIMAL,\n");
            sqlQuery.append("\tGenero VARCHAR(50), FOREIGN KEY(DirectorId) REFERENCES Director(Id), PRIMARY KEY(Id)\n");
            sqlQuery.append(");\n");

            sqlQuery.append("-- Insertar datos los datos de prueba de director\n");
            sqlQuery.append("INSERT INTO `peliculas`.`Director`(`Nombre`, `Apellidos`) VALUES\n");
            sqlQuery.append("\t('David', 'Yates'),\n");
            sqlQuery.append("\t('Anthony', 'Russo'),\n");
            sqlQuery.append("\t('Roger', 'Alles'),\n");
            sqlQuery.append("\t('Joe', 'Johson');\n");

            sqlQuery.append("-- Insertar datos de peliculas relacionando con la clave foranea al director\n");
            sqlQuery.append("INSERT INTO `peliculas`.`Pelicula` (`Id`, `Titulo`, `DirectorId`, `Pais`, `Duracion`, `Genero`) VALUES\n");
            sqlQuery.append("\t(1, 'Harry potter: la orden del fenix', 1, 'UK', 2, 'fantasia'),\n");
            sqlQuery.append("\t(2, 'Vengadores: EndGame', 2, 'USA', 3, 'ciencia ficcion'),\n");
            sqlQuery.append("\t(3, 'El rey leon', 3, 'USA', 1, 'musical'),\n");
            sqlQuery.append("\t(4, 'Animales fantasticos: Los crimenes de Grindelwald', 1, 'USA', 2, 'fantasia'),\n");
            sqlQuery.append("\t(5, 'Jumaji 1995', 4, 'USA', 1, 'Aventura');\n");

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
