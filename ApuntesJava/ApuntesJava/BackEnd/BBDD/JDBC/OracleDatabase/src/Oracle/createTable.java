package Oracle;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

/*
Provincias con mas de 3 empresas
 */
public class createTable {

    public void createTableExecute() {
        Connection conn;
        Statement sentencia;

        System.out.println("Conexion a la base de datos...");

        try { // Se carga el driver JDBC-ODBC
            Class.forName("oracle.jdbc.OracleDriver");

        } catch (Exception e) {
            System.out.println("No se pudo cargar el driver JDBC");
            return; // termina la ejecucion del programa
        }

        try { // Se establece la conexion con la base de datos
            conn = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:xe", "multi", "multi");
            sentencia = conn.createStatement();
        } catch (SQLException e) {
            System.out.println("No hay conexi�n con la base de datos.");
            return;
        }

        try {
            sentencia.executeQuery(
                    "CREATE TABLE ejer6 (" +
                            "campo1 varchar2(50)," +
                            "campo2 varchar2(50)," +
                            "campo3 varchar2(50)," +
                            "campo4 varchar2(50)" +
                            ")"
            );

            conn.close(); // Cierre de la conexi�n
        } catch (SQLException e) {
            System.out.println("Error: " + e.getMessage());
        }
        System.out.println("\n Consulta finalizada.");

    } // Fin del main
} // Fin de la clase
