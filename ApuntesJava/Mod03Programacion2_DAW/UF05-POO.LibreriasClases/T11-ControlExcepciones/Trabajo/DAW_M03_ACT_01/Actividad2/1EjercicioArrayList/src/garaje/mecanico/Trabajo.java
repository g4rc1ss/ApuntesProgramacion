package garaje.mecanico;

import garaje.mecanico.enums.*;

public class Trabajo {
    private int idTrabajo; // Autonumerico, con size de arraylist se puede hacer facil
    private String descripcion;
    private double numHoras; // Al principio es 0, luego se aumentando
    private Estado estadoReparacion; // finalizado y num.horas y precioMaterial no se puede alterar mas, condicion
    private TipoTrabajo tipoTrabajo;
    private double precioMaterial; // Al principio 0 e ira aumentando

    public Trabajo() {
    }

    public Trabajo(int idTrabajo, String descripcion, float numHoras, Estado estadoReparacion, TipoTrabajo tipoTrabajo, double precioMaterial) {
        this.idTrabajo = idTrabajo;
        this.descripcion = descripcion;
        this.numHoras = numHoras;
        this.estadoReparacion = estadoReparacion;
        this.tipoTrabajo = tipoTrabajo;
        this.precioMaterial = precioMaterial;
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

    public TipoTrabajo getTipoTrabajo() {
        return tipoTrabajo;
    }

    public void setTipoTrabajo(TipoTrabajo tipoTrabajo) {
        this.tipoTrabajo = tipoTrabajo;
    }

    public double getPrecioMaterial() {
        return precioMaterial;
    }

    public void setPrecioMaterial(double precioMaterial) {
        this.precioMaterial = precioMaterial;
    }

    //endregion
}
