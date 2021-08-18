package MariaDB;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class CreateTable {
	public void createTableExecute() throws ClassNotFoundException, SQLException {
		
		//cargamos la base de datos indicando el driver
		Class.forName("com.mysql.jdbc.Driver");
		//Generamos la conexion
		Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/EXAMEN_AD" + "?&useSSL=false", "ceinmark", "ceinmark");
		
		//creamos la sentencia
		Statement statement = conexion.createStatement();
		
		//Escribimos la consulta
		String consulta = "SELECT * FROM AlumnoCeinmark;";
		
		//ejecutamos la consulta
		statement.executeQuery(
				"CREATE TABLE `datosPrueba`.`Empleado` (" +
				"`ID`         INT             NOT NULL    AUTO_INCREMENT," +
				"`Nombre`     VARCHAR(45)                 NULL," +
				"`Apellidos`  VARCHAR(45)                 NULL," +
				"`Salario`    DOUBLE                      NULL," +
				"PRIMARY KEY(`ID`))"
		);
	}
}
