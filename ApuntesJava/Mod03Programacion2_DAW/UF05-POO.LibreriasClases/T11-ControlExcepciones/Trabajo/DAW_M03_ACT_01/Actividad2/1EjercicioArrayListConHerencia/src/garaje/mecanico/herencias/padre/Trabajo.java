package garaje.mecanico.herencias.padre;

import garaje.mecanico.enums.*;

public class Trabajo {
    private int idTrabajo; // Autonumerico, con size de arraylist se puede hacer facil
    private String descripcion;
    private double numHoras = 0.0; // Al principio es 0, luego se aumentando
    private Estado estadoReparacion; // finalizado y num.horas y precioMaterial no se puede alterar mas, condicion
    private double precioMaterial = 0.0; // Al principio 0 e ira aumentando
    private double precioTotal = 0.0;

    public Trabajo() {
    }

    public double calcularPrecioTotal() {
        precioTotal = numHoras * 30;
        return precioTotal;
    }

    //region Getters and Setters

    public int getIdTrabajo() {
        return idTrabajo;
    }

    public void setIdTrabajo(int idTrabajo) {
        this.idTrabajo = idTrabajo;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public double getNumHoras() {
        return numHoras;
    }

    public void setNumHoras(double numHoras) {
        this.numHoras = numHoras;
    }

    public Estado getEstadoReparacion() {
        return estadoReparacion;
    }

    public void setEstadoReparacion(Estado estadoReparacion) {
        this.estadoReparacion = estadoReparacion;
    }

    public double getPrecioMaterial() {
        return precioMaterial;
    }

    public void setPrecioMaterial(double precioMaterial) {
        this.precioMaterial = precioMaterial;
    }

    //endregion
}
