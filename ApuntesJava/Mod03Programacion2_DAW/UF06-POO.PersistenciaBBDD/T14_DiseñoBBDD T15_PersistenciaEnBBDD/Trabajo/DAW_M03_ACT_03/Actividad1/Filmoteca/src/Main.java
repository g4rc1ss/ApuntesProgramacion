import BBDD.EjecutarConsultaBBDD;
import GUI.InterfazPrincipal;

public class Main {
    public static void main(String[] args) {
        try {
            if (new EjecutarConsultaBBDD().seedCreateDatabaseAndTables())
                new InterfazPrincipal();
            else
                System.exit(-1);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
