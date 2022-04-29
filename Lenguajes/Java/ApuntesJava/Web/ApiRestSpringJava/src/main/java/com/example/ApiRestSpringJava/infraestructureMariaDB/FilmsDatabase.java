package com.example.ApiRestSpringJava.infraestructureMariaDB;

import com.example.ApiRestSpringJava.domain.models.DirectorFilms;
import org.springframework.stereotype.Component;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

@Component
public class FilmsDatabase implements com.example.ApiRestSpringJava.contracts.database.FilmsDatabase {

    private final Connection connection;

    public FilmsDatabase() throws SQLException {
        connection = DriverManager.getConnection("jdbc:mariadb://localhost:3306/", "root", "123456");
    }

    @Override
    public List<DirectorFilms> GetDirectorFilmsDatabase(int directorId) {
        var listaDirectores = new ArrayList<DirectorFilms>();
        String sqlQuery = """
                SELECT direc.Nombre as NombreDirector
                , direc.Apellidos as ApellidosDirector
                , peli.Titulo as TituloPelicula
                FROM apuntesjava.pelicula AS peli, apuntesjava.director AS direc
                WHERE direc.Id = ? and peli.DirectorId = ?
                """;
        try (PreparedStatement statement = connection.prepareStatement(sqlQuery) ) {
            statement.setInt(1, directorId);
            statement.setInt(2, directorId);

            ResultSet respuesta = statement.executeQuery();
            while (respuesta.next()) {
                var directorFilm = new DirectorFilms();
                directorFilm.setNombreDirector(respuesta.getString("NombreDirector"));
                directorFilm.setApellidosDirector(respuesta.getString("ApellidosDirector"));
                directorFilm.setTituloPelicula(respuesta.getString("TituloPelicula"));
                listaDirectores.add(directorFilm);
            }
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
        return listaDirectores;
    }
}
