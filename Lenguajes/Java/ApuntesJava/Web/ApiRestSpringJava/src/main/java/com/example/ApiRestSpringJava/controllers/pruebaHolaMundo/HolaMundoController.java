package com.example.ApiRestSpringJava.controllers.pruebaHolaMundo;

import com.example.ApiRestSpringJava.contracts.core.Films;
import com.example.ApiRestSpringJava.domain.models.DirectorFilms;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class HolaMundoController {
    private final Films peliculas;

    public HolaMundoController(Films peliculas) {
        this.peliculas = peliculas;
    }

    @GetMapping("/")
    public String hello() {
        return "Hola mundisimo";
    }

    @GetMapping("/GetDirectorFilms/{id}")
    public List<DirectorFilms> GetDirectorFilms(@PathVariable int id) {
        return peliculas.GetDirectorFilms(id);
    }
}
