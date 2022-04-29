package com.example.ApiRestSpringJava.contracts.database;

import com.example.ApiRestSpringJava.domain.models.DirectorFilms;

import java.util.List;

public interface FilmsDatabase {
    List<DirectorFilms> GetDirectorFilmsDatabase(int id);
}
