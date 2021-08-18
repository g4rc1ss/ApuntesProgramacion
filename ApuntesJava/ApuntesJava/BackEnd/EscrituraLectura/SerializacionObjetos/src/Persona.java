import java.io.Serializable;

public class Persona implements Serializable {
    private String nombre;
    private int edad;

    // clase con dos atributos nombre y edad
    public Persona(String nombre, int edad) {
        this.nombre = nombre;
        this.edad = edad;
    }

    public Persona() {
        this.nombre = null;
    }

    public void setNombre(String nom) {
        nombre = nom;
    } // set para darle valor

    public void setEdad(int ed) {
        edad = ed;
    }

    public String getNombre() {
        return nombre;
    } // get para obtener el valor

    public int getEdad() {
        return edad;
    }
}// fin Persona
