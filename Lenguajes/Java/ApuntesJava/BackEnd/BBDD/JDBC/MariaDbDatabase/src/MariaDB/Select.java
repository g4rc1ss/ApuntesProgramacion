package MariaDB;

import MariaDB.base.Inicializar;

import java.sql.*;

public class Select extends Inicializar {

	public Select() {
		super();
	}

	public void SelecExecute() throws ClassNotFoundException, SQLException {
		//creamos la sentencia
		Statement statement = connection.createStatement();
		
		//Escribimos la consulta
		String consulta = "SELECT * FROM `apuntesjava`.`Empleado`;";
		
		//ejecutamos la consulta
		ResultSet resultado = statement.executeQuery(consulta);
		
		//comprobamos si hay mas lineas y con el metodo getInt() o getString() indicamos la columna que leemos
		while(resultado.next())
			System.out.println(
					"ID: " + resultado.getInt(1) +
					" Nombre: " + resultado.getString(2) +
					" Apellidos: " + resultado.getString(3)
			);
	}
}
