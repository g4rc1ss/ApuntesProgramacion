package MariaDB;

import MariaDB.base.Inicializar;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class CreateTable extends Inicializar {

	public CreateTable() {
		super();
	}

	public void createTableExecute() throws ClassNotFoundException, SQLException{
		//creamos la sentencia
		Statement statement = connection.createStatement();
		
		//ejecutamos la consulta
		statement.executeQuery(
				"CREATE TABLE IF NOT EXISTS `apuntesjava`.`Empleado` (" +
				"`ID`         INT             NOT NULL    AUTO_INCREMENT," +
				"`Nombre`     VARCHAR(45)                 NULL," +
				"`Apellidos`  VARCHAR(45)                 NULL," +
				"`Salario`    DOUBLE                      NULL," +
				"PRIMARY KEY(`ID`))"
		);
	}
}
