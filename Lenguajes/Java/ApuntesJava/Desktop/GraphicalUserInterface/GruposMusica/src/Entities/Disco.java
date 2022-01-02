package Entities;

import Enums.EstilosMusica;

public class Disco {
    private String nombreGrupo;
    private String titulo;
    private String estiloMusica;
    private int numCanciones;
    private int anioPublicacion;

    public Disco() {
    }

    public Disco(String nombreGrupo, String titulo, EstilosMusica estiloMusica, int numCanciones, int anioPublicacion) {
        this.nombreGrupo = nombreGrupo;
        this.titulo = titulo;
        this.estiloMusica = estiloMusica.toString();
        this.numCanciones = numCanciones;
        this.anioPublicacion = anioPublicacion;
    }

    @Override
    public boolean equals(Object obj) {
        return super.equals(obj);
    }

    @Override
    public String toString() {
        System.out.println(nombreGrupo);
        return nombreGrupo;
    }

    // region Getters and Setters
    public String getNombreGrupo() {
        return nombreGrupo;
    }

    public void setNombreGrupo(String nombreGrupo) {
        this.nombreGrupo = nombreGrupo;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public EstilosMusica getEstiloMusica() {
        return EstilosMusica.valueOf(estiloMusica);
    }

    public void setEstiloMusica(EstilosMusica estiloMusica) {
        this.estiloMusica = estiloMusica.toString();
    }

    public int getNumCanciones() {
        return numCanciones;
    }

    public void setNumCanciones(int numCanciones) {
        this.numCanciones = numCanciones;
    }

    public int getAnioPublicacion() {
        return anioPublicacion;
    }

    public void setAnioPublicacion(int anioPublicacion) {
        this.anioPublicacion = anioPublicacion;
    }
    // endregion
}
