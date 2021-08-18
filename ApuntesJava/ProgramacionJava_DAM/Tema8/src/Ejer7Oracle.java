import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Ejer7Oracle {

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

		/*	sentencia.executeQuery("create table ejer7 (anyo number, cod varchar2(50), importe varchar2(50))");
			System.out.println("Tabla creada.\n");
			sentencia.executeUpdate("insert into ejer7 values (2013,'cod1','100')");
			sentencia.executeUpdate("insert into ejer7 values (2014,'cod2','200')");
			sentencia.executeUpdate("insert into ejer7 values (2015,'cod3','300')");
			System.out.println("Datos insertados."); */
            resultado = sentencia.executeQuery("select * from ejer7");
            // Se recorren las filas retornadas

        } catch (SQLException e) {
            System.out.println("Error: " + e.getMessage());
        }

    }

    public void resultadosSQL() {

        try {

            while (resultado.next()) {

                System.out.println();
                System.out.println("  A�o: " + resultado.getString(1));
                System.out.println("  Codigo: " + resultado.getString(2));
                System.out.println("  Importe: " + resultado.getString(3));

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

        Ejer7Oracle ejercicio = new Ejer7Oracle();

        ejercicio.conexionBD();
        ejercicio.comandosSQL();
        ejercicio.resultadosSQL();

    }

}
