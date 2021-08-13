package MySQL;

import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

	public class Insert {
		public void InsertExecute() {
			try {
			Class.forName("com.mysql.jdbc.Driver");// Cargar el driver
				// Establecemos la conexion con la BD
				var conexion = DriverManager.getConnection(
						"jdbc:mysql://localhost/Ceinmark",
						"root",
						"root"
				);
											
				// recuperar argumentos de main
				String dep = "45"; // num. departamento
				String dnombre = "Loli"; // nombre
				String loc = "Bilbao"; // localidad
				
				// construir orden INSERT
				String sql = "INSERT INTO departamentos VALUES ( ?, ?, ? )";
  			    
				System.out.println(sql);  			    
				PreparedStatement sentencia = 
						conexion.prepareStatement(sql);				
				sentencia.setInt(1, Integer.parseInt(dep));
				sentencia.setString(2, dnombre);
				sentencia.setString(3, loc);
				
				int filas;//
				try {
				  filas = sentencia.executeUpdate();
				  System.out.println("Filas afectadas: " + filas);
				} catch (SQLException e) {
					System.out.println("HA OCURRIDO UNA EXCEPCI�N:"); 
				    System.out.println("Mensaje:    "+ e.getMessage()); 
				    System.out.println("SQL estado: "+ e.getSQLState()); 
			    	System.out.println("Cod error:  "+ e.getErrorCode());
				}
				sentencia.close(); // Cerrar Statement
				conexion.close(); // Cerrar conexi�n

			} catch (ClassNotFoundException cn) {
				cn.printStackTrace();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}// fin de main
	}// fin de la clase
