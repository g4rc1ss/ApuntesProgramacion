package com.example.ApiRestSpringJava.domain.models;

public class DirectorFilms {
    private String nombreDirector;
    private String apellidosDirector;
    private String tituloPelicula;

    public String getNombreDirector() {
        return nombreDirector;
    }

    public void setNombreDirector(String nombreDirector) {
        this.nombreDirector = nombreDirector;
    }

    public String getApellidosDirector() {
        return apellidosDirector;
    }

    public void setApellidosDirector(String apellidosDirector) {
        this.apellidosDirector = apellidosDirector;
    }

    public String getTituloPelicula() {
        return tituloPelicula;
    }

    public void setTituloPelicula(String tituloPelicula) {
        this.tituloPelicula = tituloPelicula;
    }
}
