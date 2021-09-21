package MariaDB;

import MariaDB.base.Inicializar;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class Update extends Inicializar {

    public Update() {
        super();
    }

    public void updateExecute() {
        try {
            var sql = "UPDATE `apuntesjava`.`Empleado` SET Salario = Salario + ? WHERE Salario < 2500";

            System.out.println(sql);

            var sentencia = connection.prepareStatement(sql);
            sentencia.setDouble(1, 100);
            int filas = sentencia.executeUpdate();
            System.out.printf("Empleados modificados: %d %n", filas);

            sentencia.close();
            connection.close();

        } catch (SQLException e) {
            if (e.getErrorCode() == 1062)
                System.out.println("CLAVE PRIMARIA DUPLICADA");
            else if (e.getErrorCode() == 1452)
                System.out.println("CLAVE AJENA NO EXISTE");

            else {
                System.out.println("HA OCURRIDO UNA EXCEPCI�N:");
                System.out.println("Mensaje:    " + e.getMessage());
                System.out.println("SQL estado: " + e.getSQLState());
                System.out.println("C�d error:  " + e.getErrorCode());
            }
        }
    }// fin de main
}// fin de la clase
	
	