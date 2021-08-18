import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList lista = new ArrayList<Alumno>();
        try {
            for (int x = 0; x < 10; x++) {
                if (lista.size() >= 5)
                    throw new DemasiadosObjetos();
                lista.add(new Alumno("nombre numero: " + x, x + 10));
            }
        } catch (DemasiadosObjetos demasiados) {
            System.err.println(demasiados.getMessage());
        }

        System.out.println(lista);
    }
}
