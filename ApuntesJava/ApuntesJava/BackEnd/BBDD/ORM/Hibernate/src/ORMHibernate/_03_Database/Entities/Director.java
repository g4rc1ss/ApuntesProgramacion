package ORMHibernate._03_Database.Entities;

import javax.persistence.*;

@Entity
@Table(name = "Director")
public class Director {
    public Director() {

    }

    public Director(String nombre, String apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }

    @Column(name = "Id")
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "Nombre")
    private String nombre;

    @Column(name = "Apellidos")
    private String apellidos;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    @Override
    public String toString() {
        return "Cliente{" +
                "id=" + id +
                ", nombre='" + nombre + '\'' +
                ", apellidos='" + apellidos + '\'' +
                '}';
    }
}
