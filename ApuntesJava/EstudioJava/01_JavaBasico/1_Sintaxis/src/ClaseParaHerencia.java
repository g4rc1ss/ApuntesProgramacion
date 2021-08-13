public class ClaseParaHerencia {
    protected String nombre;
    protected int edad;

    public void Imprimir(){
        System.out.println("Nombre: " + getNombre());
        System.out.println("Edad: " + getEdad());
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
}

class heredando extends ClaseParaHerencia{
    protected float sueldo;

    @Override
    public void Imprimir(){
        super.Imprimir();
        System.out.println("Sueldo: " + sueldo);
    }

    public float getSueldo() {
        return sueldo;
    }

    public void setSueldo(float sueldo) {
        this.sueldo = sueldo;
    }
}