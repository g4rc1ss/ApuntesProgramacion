package MySQL;

import java.sql.*;

public class DatabaseMetadata {
	public void databaseMetadataExecute() {
		try {
			Class.forName("com.mysql.jdbc.Driver"); // Cargar el driver
			// Establecemos la conexion con la BD
			Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/ceinmark" + "?&useSSL=false",
					"root", "root");

			DatabaseMetaData dbmd = conexion.getMetaData();// Creamos
			// objeto DatabaseMetaData
			ResultSet resul = null;

			String nombre = dbmd.getDatabaseProductName();
			String driver = dbmd.getDriverName();
			String url = dbmd.getURL();
			String usuario = dbmd.getUserName();

			System.out.println("INFORMACION SOBRE LA BASE DE DATOS:");
			System.out.println("===================================");
			System.out.printf("Nombre : %s %n", nombre);
			System.out.printf("Driver : %s %n", driver);
			System.out.printf("URL    : %s %n", url);
			System.out.printf("Usuario: %s %n", usuario);

			// Obtener informaci�n de las tablas y vistas que hay
			resul = dbmd.getTables(null, "ceinmark", null, null);// catalogo,esquema,patron,tipo
			// String[] tipos = {"TABLE"};
			// resul = dbmd.getTables(null, NULL, null, tipos);

			while (resul.next()) {
				String catalogo = resul.getString(1);// columna 1 resul.getString("TABLE_CAT2)
				String esquema = resul.getString(2); // columna 2 resul.getString("TABLE_SCHEM)
				String tabla = resul.getString(3); // columna 3 resul.getString("TABLE_NAME)
				String tipo = resul.getString(4); // columna 4 resul.getString("TABLE_TYPE)
				System.out.printf("%s - Catalogo: %s, Esquema: %s, Nombre: %s %n", tipo, catalogo, esquema, tabla);
			}
			conexion.close(); // Cerrar conexion
		} catch (ClassNotFoundException cn) {
			cn.printStackTrace();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}// fin de main
}// fin de la clase
