package Dado;

public class Dado {

    byte cont = 0;
    int lanzamiento;

    void metodo() {
        lanzamiento = ((byte) (Math.random() * 3)) + 1;
        System.out.println("Tiramos el dado y la cara resultante es:  " + lanzamiento);
        cont++;
    }

    public static void main(String[] args) {

        Dado prac = new Dado();

        prac.metodo();
    }

}
