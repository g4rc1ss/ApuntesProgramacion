import BBDD.EjecutarConsultaBBDD_InterfazPrincipal;
import GUI.InterfazPrincipal;

public class Main {
    public static void main(String[] args) {
        try {
            if (new EjecutarConsultaBBDD_InterfazPrincipal().seedCreateDatabaseAndTables())
                new InterfazPrincipal();
            else
                System.exit(-1);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
