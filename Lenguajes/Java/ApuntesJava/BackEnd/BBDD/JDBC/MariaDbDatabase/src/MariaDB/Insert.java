package MariaDB;

import MariaDB.base.Inicializar;

import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class Insert extends Inicializar {

    public Insert() {
        super();
    }

    public void InsertExecute() {
        try {
            // recuperar argumentos de main
            String nombre = "Loli";
            String apellido = "Garcia";
            String salario = "2000.00";

            // construir orden INSERT
            String sql = "INSERT INTO `apuntesjava`.`Empleado`(Nombre, Apellidos, Salario) VALUES ( ?, ?, ? )";

            System.out.println(sql);
            PreparedStatement sentencia = connection.prepareStatement(sql);
            sentencia.setString(1, nombre);
            sentencia.setString(2, apellido);
            sentencia.setDouble(3, Double.parseDouble(salario));

            int filas;//
            try {
                filas = sentencia.executeUpdate();
                System.out.println("Filas afectadas: " + filas);
            } catch (SQLException e) {
                System.out.println("HA OCURRIDO UNA EXCEPCI�N:");
                System.out.println("Mensaje:    " + e.getMessage());
                System.out.println("SQL estado: " + e.getSQLState());
                System.out.println("Cod error:  " + e.getErrorCode());
            }
            sentencia.close();
            connection.close();

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }// fin de main
}// fin de la clase
