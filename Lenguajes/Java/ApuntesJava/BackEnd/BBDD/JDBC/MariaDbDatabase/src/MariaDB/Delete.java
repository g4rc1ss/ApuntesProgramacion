package MariaDB;

import MariaDB.base.Inicializar;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class Delete extends Inicializar {

    public Delete() {
        super();
    }

    public void deleteExecute() {
        try {
            String sql = "DELETE FROM `apuntesjava`.`Empleado` WHERE ID = 1";

            System.out.println(sql);

            Statement sentencia = connection.createStatement();
            int filas = sentencia.executeUpdate(sql);
            System.out.printf("Empleados modificados: %d %n", filas);

            sentencia.close(); // Cerrar Statement
            connection.close(); // Cerrar conexion
        } catch (SQLException e) {
            if (e.getErrorCode() == 1062)
                System.out.println("CLAVE PRIMARIA DUPLICADA");
            else if (e.getErrorCode() == 1452)
                System.out.println("CLAVE AJENA NO EXISTE");
            else {
                System.out.println("HA OCURRIDO UNA EXCEPCION:");
                System.out.println("Mensaje:    " + e.getMessage());
                System.out.println("SQL estado: " + e.getSQLState());
                System.out.println("Cod error:  " + e.getErrorCode());
            }
        }
    }
}
	
	