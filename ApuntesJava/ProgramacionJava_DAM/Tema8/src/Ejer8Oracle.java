import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Ejer8Oracle {

    Connection conn;
    Statement sentencia;
    ResultSet resultado;

    public void conexionBD() {
        System.out.println("Conexi�n a la base de datos...");

        try { // Se carga el driver JDBC-ODBC

            Class.forName("oracle.jdbc.OracleDriver");

        } catch (Exception e) {

            System.out.println("No se pudo cargar el driver JDBC");
            return; // termina la ejecuci�n del programa

        }

        try { // Se establece la conexi�n con la base de datos

            conn = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:xe", "multi", "multi");
            sentencia = conn.createStatement();

        } catch (SQLException e) {

            System.out.println("No hay conexi�n con la base de datos.");
            return;

        }

    }

    public void comandosSQL() {

        try {

            System.out.println("Seleccionando...\n");


            System.out.println("Datos insertados.");
            resultado = sentencia.executeQuery("select sum (importe) from ejer7 group by anyo");
            // Se recorren las filas retornadas

        } catch (SQLException e) {
            System.out.println("Error: " + e.getMessage());
        }

    }

    public void resultadosSQL() {

        try {

            while (resultado.next()) {

                System.out.println();
                System.out.println("  El importe de las ventas del a�o 2013 son:  " + resultado.getString(1));
                System.out.println("  El importe de las ventas del a�o 2014 son:  " + resultado.getString(2));
                System.out.println("  El importe de las ventas del a�o 2015 son:  " + resultado.getString(3));

                // para num�ricos existen: getInt(�salario�),
                // getFloat(�salario�), getFloat(3),�

            }

            conn.close(); // Cierre de la conexi�n

        } catch (SQLException e) {

            System.out.println("Error: " + e.getMessage());
        }

        System.out.println("\n Consulta finalizada.");

    }

    public static void main(String[] args) {

        Ejer8Oracle ejercicio = new Ejer8Oracle();

        ejercicio.conexionBD();
        ejercicio.comandosSQL();
        ejercicio.resultadosSQL();

    }


}
