package com.example.ApiRestSpringJava.contracts.core;

import com.example.ApiRestSpringJava.domain.models.DirectorFilms;

import java.util.List;

public interface Films {
    List<DirectorFilms> GetDirectorFilms(int directorId);
}
