import java.io.Serializable;

public class Empleado implements Serializable {
    private String nombre;
    private int edad;
    private double sueldo;
    // Marcamos la variable como transient para que no se serialice en el fichero de objeto
    private transient String claveDefecto = "patata";

    Empleado(String nombre, int edad, double sueldo) {
        this.nombre = nombre;
        this.edad = edad;
        this.sueldo = sueldo;
    }

    //region Getter and Setters

    public String getClaveDefecto() {
        return claveDefecto;
    }

    public void setClaveDefecto(String claveDefecto) {
        this.claveDefecto = claveDefecto;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getEdad() {
        return edad;
    }

    public void setEdad(int edad) {
        this.edad = edad;
    }

    public double getSueldo() {
        return sueldo;
    }

    public void setSueldo(double sueldo) {
        this.sueldo = sueldo;
    }
    //endregion
}
