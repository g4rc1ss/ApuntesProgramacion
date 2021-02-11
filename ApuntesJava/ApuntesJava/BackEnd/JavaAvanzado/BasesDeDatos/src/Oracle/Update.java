package Oracle;

import java.sql.*;

/*
Provincias con mas de 3 empresas
 */
public class Update {

    public void updateExecute() {
        Connection conn;
        Statement sentencia;
        ResultSet resultado;

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

        try {
            System.out.println("Seleccionando...");
            String sql = "UPDATE COMPANY set SALARY = 25000.00 where ID=1;";
            sentencia.executeUpdate(sql);
            // Se recorren las filas retornadas

            conn.close(); // Cierre de la conexi�n
        } catch (SQLException e) {
            System.out.println("Error: " + e.getMessage());
        }
        System.out.println("\n Consulta finalizada.");

    } // Fin del main
} // Fin de la clase
