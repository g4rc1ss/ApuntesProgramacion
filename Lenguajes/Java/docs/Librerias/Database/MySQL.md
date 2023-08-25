# Configuración de la Base de Datos
Asegúrate de que tengas una base de datos MySQL en funcionamiento y que conozcas los detalles de conexión, como la URL de conexión, el nombre de usuario y la contraseña.

# Dependencias y Configuración del Proyecto
Agrega la biblioteca JDBC de MySQL a tu proyecto (por ejemplo, a través de Maven o Gradle). Importa la clase `java.sql.*`.

# Establecer Conexión y Realizar Operaciones
La API de JDBC permite establecer una conexión a la base de datos y realizar operaciones como consultas SQL.

```java
import java.sql.*;

public class ConexionMySQL {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/nombre_base_de_datos";
        String usuario = "usuario";
        String contraseña = "contraseña";

        try (Connection connection = DriverManager.getConnection(url, usuario, contraseña)) {
            // Realizar operaciones con la base de datos
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
```

# Ejemplo de Inserción de Datos
Puedes utilizar la interfaz `Statement` o `PreparedStatement` para ejecutar consultas SQL.

```java
public class InsercionDatos {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/nombre_base_de_datos";
        String usuario = "usuario";
        String contraseña = "contraseña";

        String nombre = "Juan";
        int edad = 25;

        try (Connection connection = DriverManager.getConnection(url, usuario, contraseña)) {
            String consulta = "INSERT INTO tabla (nombre, edad) VALUES (?, ?)";
            try (PreparedStatement preparedStatement = connection.prepareStatement(consulta)) {
                preparedStatement.setString(1, nombre);
                preparedStatement.setInt(2, edad);
                int filasAfectadas = preparedStatement.executeUpdate();
                System.out.println(filasAfectadas + " fila(s) insertada(s)");
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
```

# Ejemplo de Consulta de Datos
Puedes utilizar `Statement` o `PreparedStatement` para ejecutar consultas SELECT y obtener resultados.

```java
public class ConsultaDatos {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/nombre_base_de_datos";
        String usuario = "usuario";
        String contraseña = "contraseña";

        try (Connection connection = DriverManager.getConnection(url, usuario, contraseña)) {
            String consulta = "SELECT nombre, edad FROM tabla WHERE edad > ?";
            try (PreparedStatement preparedStatement = connection.prepareStatement(consulta)) {
                preparedStatement.setInt(1, 20);
                try (ResultSet resultSet = preparedStatement.executeQuery()) {
                    while (resultSet.next()) {
                        String nombre = resultSet.getString("nombre");
                        int edad = resultSet.getInt("edad");
                        System.out.println("Nombre: " + nombre + ", Edad: " + edad);
                    }
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
```

# Ejemplo de Actualización de Datos
Puedes utilizar `Statement` o `PreparedStatement` para ejecutar consultas UPDATE y modificar datos existentes.

```java
public class ActualizacionDatos {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/nombre_base_de_datos";
        String usuario = "usuario";
        String contraseña = "contraseña";

        int nuevaEdad = 30;
        String nombre = "Juan";

        try (Connection connection = DriverManager.getConnection(url, usuario, contraseña)) {
            String consulta = "UPDATE tabla SET edad = ? WHERE nombre = ?";
            try (PreparedStatement preparedStatement = connection.prepareStatement(consulta)) {
                preparedStatement.setInt(1, nuevaEdad);
                preparedStatement.setString(2, nombre);
                int filasAfectadas = preparedStatement.executeUpdate();
                System.out.println(filasAfectadas + " fila(s) actualizada(s)");
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
```

# Ejemplo de Eliminación de Datos
Puedes utilizar `Statement` o `PreparedStatement` para ejecutar consultas DELETE y eliminar registros de la base de datos.

```java
public class EliminacionDatos {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/nombre_base_de_datos";
        String usuario = "usuario";
        String contraseña = "contraseña";

        String nombre = "Juan";

        try (Connection connection = DriverManager.getConnection(url, usuario, contraseña)) {
            String consulta = "DELETE FROM tabla WHERE nombre = ?";
            try (PreparedStatement preparedStatement = connection.prepareStatement(consulta)) {
                preparedStatement.setString(1, nombre);
                int filasAfectadas = preparedStatement.executeUpdate();
                System.out.println(filasAfectadas + " fila(s) eliminada(s)");
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
```

Recuerda manejar las excepciones de manera adecuada y cerrar las conexiones y recursos en bloques `try-with-resources` para evitar posibles fugas de recursos.
