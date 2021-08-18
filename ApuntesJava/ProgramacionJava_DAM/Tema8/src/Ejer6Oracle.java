import java.sql.*;

public class Ejer6Oracle {

    Connection conn;
    Statement sentencia;
    ResultSet resultado;

    String dato1 = "dato1";
    String dato2 = "dato2";
    String dato3 = "dato3";
    String dato4 = "dato4";

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

            sentencia.executeQuery("create table ejer6 (campo1 varchar2(50), campo2 varchar2(50), campo3 varchar2(50), campo4 varchar2(50))");
            System.out.println("Tabla creada.\n");
            sentencia.executeUpdate("insert into ejer6 values ('" + dato1 + "','" + dato2 + "','" + dato3 + "','" + dato4 + "')");
            System.out.println("Datos insertados.");
            resultado = sentencia.executeQuery("select * from ejer6");
            // Se recorren las filas retornadas

        } catch (SQLException e) {
            System.out.println("Error: " + e.getMessage());
        }

    }

    public void resultadosSQL() {

        try {

            while (resultado.next()) {

                System.out.println();
                System.out.println("  campo1 " + resultado.getString(1));
                System.out.println("  campo2 " + resultado.getString(2));
                System.out.println("  campo3 " + resultado.getString(3));
                System.out.println("  campo4 " + resultado.getString(4));

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

        Ejer6Oracle ejercicio = new Ejer6Oracle();

        ejercicio.conexionBD();
        ejercicio.comandosSQL();
        ejercicio.resultadosSQL();

    }

}
