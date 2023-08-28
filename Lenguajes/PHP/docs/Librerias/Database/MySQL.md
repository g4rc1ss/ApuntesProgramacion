# Conexión a la Base de Datos
   Antes de interactuar con MySQL, debes establecer una conexión a la base de datos. Utiliza la extensión MySQLi (MySQL Improved) o PDO (PHP Data Objects) para realizar la conexión.

   **MySQLi:**
   ```php
   $conexion = new mysqli('localhost', 'usuario', 'contraseña', 'nombre_basededatos');
   if ($conexion->connect_error) {
       die("Error de conexión: " . $conexion->connect_error);
   }
   ```

   **PDO:**
   ```php
   $dsn = 'mysql:host=localhost;dbname=nombre_basededatos';
   $usuario = 'usuario';
   $contraseña = 'contraseña';

   try {
       $conexion = new PDO($dsn, $usuario, $contraseña);
       $conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
   } catch (PDOException $e) {
       die("Error de conexión: " . $e->getMessage());
   }
   ```

# Ejecución de Consultas
   Puedes ejecutar consultas SQL utilizando la extensión MySQLi o PDO. Asegúrate de utilizar consultas preparadas para prevenir la inyección de SQL.

   **MySQLi:**
   ```php
   $consulta = "SELECT nombre, edad FROM usuarios WHERE id = ?";
   $stmt = $conexion->prepare($consulta);
   $idUsuario = 1;
   $stmt->bind_param("i", $idUsuario);
   $stmt->execute();
   $resultado = $stmt->get_result();
   $fila = $resultado->fetch_assoc();
   ```

   **PDO:**
   ```php
   $consulta = "SELECT nombre, edad FROM usuarios WHERE id = ?";
   $stmt = $conexion->prepare($consulta);
   $idUsuario = 1;
   $stmt->bindParam(1, $idUsuario, PDO::PARAM_INT);
   $stmt->execute();
   $fila = $stmt->fetch(PDO::FETCH_ASSOC);
   ```

# Recuperación de Datos
   Puedes recuperar los resultados de las consultas utilizando el método `fetch()`.

   ```php
   echo "Nombre: " . $fila['nombre'];
   echo "Edad: " . $fila['edad'];
   ```

# Inserción de Datos
   Inserta datos en la base de datos utilizando consultas INSERT.

   ```php
   $nombre = "Juan";
   $edad = 30;
   $consulta = "INSERT INTO usuarios (nombre, edad) VALUES (?, ?)";
   $stmt = $conexion->prepare($consulta);
   $stmt->bind_param("si", $nombre, $edad);
   $stmt->execute();
   ```

# Actualización de Datos
   Actualiza datos en la base de datos utilizando consultas UPDATE.

   ```php
   $nuevaEdad = 31;
   $idUsuario = 1;
   $consulta = "UPDATE usuarios SET edad = ? WHERE id = ?";
   $stmt = $conexion->prepare($consulta);
   $stmt->bind_param("ii", $nuevaEdad, $idUsuario);
   $stmt->execute();
   ```

# Eliminación de Datos
   Elimina datos de la base de datos utilizando consultas DELETE.

   ```php
   $idUsuario = 1;
   $consulta = "DELETE FROM usuarios WHERE id = ?";
   $stmt = $conexion->prepare($consulta);
   $stmt->bind_param("i", $idUsuario);
   $stmt->execute();
   ```

# Cierre de la Conexión
   Siempre cierra la conexión a la base de datos cuando hayas terminado.

   ```php
   $conexion->close(); // Para MySQLi
   // O
   $conexion = null; // Para PDO
   ```
