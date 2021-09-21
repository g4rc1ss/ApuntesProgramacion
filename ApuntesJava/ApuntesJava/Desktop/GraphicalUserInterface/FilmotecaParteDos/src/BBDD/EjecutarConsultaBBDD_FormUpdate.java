package BBDD;

import EnumOptions.NombreTable;

import javax.swing.*;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class EjecutarConsultaBBDD_FormUpdate extends EjecucionBBDD_Base {
    public EjecutarConsultaBBDD_FormUpdate() {
        super();
    }

    public ArrayList<String> getTitleOfPeliculas() {
        try {
            String sqlQuery = "SELECT Titulo\n" +
                    "FROM apuntesjava.pelicula\n";
            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            ArrayList<String> listaTitulosPeliculas = new ArrayList();
            for (; respuesta.next(); )
                listaTitulosPeliculas.add(respuesta.getString("Titulo"));
            return listaTitulosPeliculas;
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return null;
        }
    }

    public ResultSet getPeliculas(String tituloPelicula) {
        try {
            if (tituloPelicula == null || tituloPelicula == "")
                return null;

            String sqlQuery = "SELECT *\n" +
                    "FROM apuntesjava.pelicula\n" +
                    "WHERE Titulo = '" + tituloPelicula + "'";
            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            return respuesta.next() ? respuesta : null;
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return null;
        }
    }

    public ResultSet getDirectores(String nombreDirector) {
        try {
            if (nombreDirector == null || nombreDirector.equals(""))
                return null;

            String sqlQuery = "SELECT *\n" +
                    "FROM apuntesjava.director\n" +
                    "WHERE Nombre = '" + nombreDirector.split(" ")[0] + "'" + "&& Apellidos = '" + nombreDirector.split(" ")[1] + "'";
            ResultSet respuesta = connection.createStatement().executeQuery(sqlQuery);
            return respuesta.next() ? respuesta : null;
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return null;
        }
    }

    public int insertInto(NombreTable tabla, String titulo_Nombre, String genero_Apellidos, double duracion, String pais, int indexDirector) {
        if (titulo_Nombre.equals("titulo") || genero_Apellidos.equals("genero") || (tabla == NombreTable.pelicula && (duracion <= 0.0 || pais.equals("pais") || indexDirector < 0)))
            return -1;
        try {
            String sqlQuery;
            if (tabla == NombreTable.pelicula) {
                sqlQuery = "INSERT INTO apuntesjava.pelicula(Titulo, DirectorId, Pais, Duracion, Genero) " +
                        "VALUES('" + titulo_Nombre + "'," + indexDirector + ", '" + pais + "'," + duracion + ", '" + genero_Apellidos + "')";
            } else if (tabla == NombreTable.director) {
                sqlQuery = "INSERT INTO apuntesjava.director(Nombre, Apellidos) VALUES ('" + titulo_Nombre + "', '" + genero_Apellidos + "');";
            } else
                return -1;
            return connection.createStatement().executeUpdate(sqlQuery);
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return -1;
        }
    }

    public int updateTable(NombreTable tabla, String titulo_Nombre, String genero_Apellidos, double duracion, String pais,
                           int indexDirector, String titulo_Nombre_Origen, String apellidos_Origen) {
        if (titulo_Nombre.isEmpty() || genero_Apellidos.isEmpty() || (tabla == NombreTable.pelicula && (duracion <= 0.0 || pais.isEmpty() || indexDirector < 0)))
            return -1;
        try {
            StringBuilder sqlQuery = new StringBuilder();
            if (tabla == NombreTable.pelicula) {
                sqlQuery.append(" UPDATE apuntesjava.pelicula SET");
                sqlQuery.append(" Titulo = '" + (titulo_Nombre.isEmpty() ? "" : titulo_Nombre) + "',");
                sqlQuery.append(" Genero = '" + (genero_Apellidos.isEmpty() ? "" :  genero_Apellidos) + "',");
                sqlQuery.append(" Duracion = " + duracion + ",");
                sqlQuery.append(" Pais = '" + (pais.isEmpty() ? "" :  pais) + "',");
                sqlQuery.append(" DirectorId = " + indexDirector);
                sqlQuery.append(" WHERE Id = (SELECT Id WHERE Titulo = '" + titulo_Nombre_Origen + "');");

            } else if (tabla == NombreTable.director) {
                sqlQuery.append(" UPDATE apuntesjava.director SET");
                sqlQuery.append(" Nombre = '" + (titulo_Nombre.isEmpty() ? "" : titulo_Nombre) + "',");
                sqlQuery.append(" Apellidos = '" + (genero_Apellidos.isEmpty() ? "" : genero_Apellidos) + "'");
                sqlQuery.append(" WHERE Id = (SELECT Id WHERE Nombre = '" + titulo_Nombre_Origen + "' && Apellidos = '" + apellidos_Origen + "');");
            } else
                return -1;
            return connection.createStatement().executeUpdate(sqlQuery.toString());
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return -1;
        }
    }

    public int deleteRow(NombreTable tabla, String titulo_Nombre, String genero_Apellidos) {
        try {
            StringBuilder sqlQuery = new StringBuilder();
            if (tabla == NombreTable.pelicula) {
                sqlQuery.append(" DELETE FROM apuntesjava.pelicula");
                sqlQuery.append(" WHERE Id = (SELECT Id WHERE Titulo = '" + titulo_Nombre + "');");

            } else if (tabla == NombreTable.director) {
                ResultSet respuesta = connection.createStatement().executeQuery(
                        "SELECT Id from apuntesjava.director where Nombre = '" + titulo_Nombre + "' AND Apellidos = '" + genero_Apellidos + "'"
                );
                respuesta.next();
                int id = respuesta.getInt("Id");

                sqlQuery.append(" DELETE FROM apuntesjava.director");
                // Condicionamos para controlar que no se puede borrar un director si esta asignado a una pelicula
                sqlQuery.append(" WHERE Id = " + id + " AND 1 > (SELECT COUNT(*) FROM apuntesjava.pelicula WHERE DirectorId = " + id + ")");
            } else
                return -1;
            return connection.createStatement().executeUpdate(sqlQuery.toString());
        } catch (SQLException sqle) {
            sqle.printStackTrace();
            return -1;
        }
    }

}
