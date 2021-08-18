import java.sql.*;

/*
Provincias con mas de 3 empresas
 */
public class Ejer1Oracle {

    static public void main(String[] args) {

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

            resultado = sentencia.executeQuery("SELECT *   FROM empresas where provincia='bizkaia' ");
            // Se recorren las filas retornadas

            while (resultado.next()) {

                System.out.println();
                System.out.println("CIF: " + resultado.getString(1));
                System.out.println("  nombre: " + resultado.getString(2));// getString(�nombre�)
                System.out.println("  direccion:  " + resultado.getString(3));
                System.out.println("  Empleados_Fijos:  " + resultado.getString(4));
                System.out.println("  Empleados_Eventuales  " + resultado.getString(5));
                System.out.println("  telefono  " + resultado.getString(6));
                System.out.println("  Fecha_Creacion  " + resultado.getString(7));
                System.out.println("  Email  " + resultado.getString(8));
                System.out.println("  Provincia  " + resultado.getString(9));
                // para num�ricos existen: getInt(�salario�),
                // getFloat(�salario�), getFloat(3),�

            }

            conn.close(); // Cierre de la conexi�n

        } catch (SQLException e) {

            System.out.println("Error: " + e.getMessage());
        }

        System.out.println("\n Consulta finalizada.");

    } // Fin del main

} // Fin de la clase
