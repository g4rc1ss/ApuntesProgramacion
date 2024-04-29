import BBDD.EjecutarConsultaBBDD_InterfazPrincipal;
import GUI.InterfazPrincipal;

public class Main {
    public static void main(String[] args) {
        try {
            new InterfazPrincipal();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
