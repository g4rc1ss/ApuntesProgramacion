package ConexionSocket.ClienteServidor;

import java.io.Serializable;

public class Alumno implements Serializable {

    String Nombre;
    String Apellidos;
    String NIF;
    String Telefono;
    String CicloForm;
    int Curso;

    public Alumno(String Nombre, String Apellidos, String NIF, String Telefono, String CicloForm, int Curso) {
        this.Nombre = Nombre;
        this.Apellidos = Apellidos;
        this.NIF = NIF;
        this.Telefono = Telefono;
        this.CicloForm = CicloForm;
        this.Curso = Curso;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        Nombre = nombre;
    }

    public String getApellidos() {
        return Apellidos;
    }

    public void setApellidos(String apellidos) {
        Apellidos = apellidos;
    }

    public String getNIF() {
        return NIF;
    }

    public void setNIF(String nIF) {
        NIF = nIF;
    }

    public String getTelefono() {
        return Telefono;
    }

    public void setTelefono(String telefono) {
        Telefono = telefono;
    }

    public String getCicloForm() {
        return CicloForm;
    }

    public void setCicloForm(String cicloForm) {
        CicloForm = cicloForm;
    }

    public int getCurso() {
        return Curso;
    }

    public void setCurso(int curso) {
        Curso = curso;
    }

}
