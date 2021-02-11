package MySQL;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class Delete {
    public void deleteExecute() {

        String dep = "40";
        String subida = "100";

        try {
            Class.forName("com.mysql.jdbc.Driver");// Cargar el driver
            // Establecemos la conexion con la BD
            Connection conexion = DriverManager.getConnection(
                    "jdbc:mysql://localhost/Ceinmark", "root", "root");

            String sql = String.format("DELETE empleados WHERE dept_no => %s", dep);

            System.out.println(sql);

            Statement sentencia = conexion.createStatement();
            int filas = sentencia.executeUpdate(sql);
            System.out.printf("Empleados modificados: %d %n", filas);

            sentencia.close(); // Cerrar Statement
            conexion.close(); // Cerrar conexion

        } catch (ClassNotFoundException cn) {
            cn.printStackTrace();
        } catch (SQLException e) {
            if (e.getErrorCode() == 1062)
                System.out.println("CLAVE PRIMARIA DUPLICADA");
            else if (e.getErrorCode() == 1452)
                System.out.println("CLAVE AJENA " + dep + " NO EXISTE");

            else {
                System.out.println("HA OCURRIDO UNA EXCEPCION:");
                System.out.println("Mensaje:    " + e.getMessage());
                System.out.println("SQL estado: " + e.getSQLState());
                System.out.println("Cod error:  " + e.getErrorCode());
            }
        }
    }// fin de main
}// fin de la clase
	
	