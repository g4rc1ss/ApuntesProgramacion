package MySQL;

import java.sql.*;

public class Select {
	public void SelecExecute() throws ClassNotFoundException, SQLException {
		
		//cargamos la base de datos indicando el driver
		Class.forName("com.mysql.jdbc.Driver");
		//Generamos la conexion
		Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/EXAMEN_AD" + "?&useSSL=false", "ceinmark", "ceinmark");
		
		//creamos la sentencia
		Statement statement = conexion.createStatement();
		
		//Escribimos la consulta
		String consulta = "SELECT * FROM AlumnoCeinmark;";
		
		//ejecutamos la consulta
		ResultSet resultado = statement.executeQuery(consulta);
		
		//comprobamos si hay mas lineas y con el metodo getInt() o getString() indicamos la columna que leemos
		while(resultado.next())
			System.out.println(
					"id: " + resultado.getInt(1) +
					" Nombre: " + resultado.getString(2) +
					" Edad: " + resultado.getInt(3)
			);

	}
}
