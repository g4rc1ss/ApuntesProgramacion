# Serialización JSON
   Puedes convertir una estructura de datos en formato JSON utilizando la función `json_encode()`. Esta función convierte arrays o objetos en una cadena JSON.

   ```php
   $datos = [
       "nombre" => "Juan",
       "edad" => 30,
       "ciudad" => "México"
   ];

   $json = json_encode($datos);
   // $json contendrá '{"nombre":"Juan","edad":30,"ciudad":"México"}'
   ```

# Deserialización JSON
   Puedes convertir una cadena JSON en una estructura de datos en PHP utilizando la función `json_decode()`. Esta función convierte una cadena JSON en un array asociativo u objeto stdClass.

   ```php
   $json = '{"nombre":"Juan","edad":30,"ciudad":"México"}';
   $datos = json_decode($json, true); // Convierte en array asociativo
   // $datos contendrá ['nombre' => 'Juan', 'edad' => 30, 'ciudad' => 'México']
   ```

# Opciones de json_decode
   La función `json_decode()` también admite opciones para controlar el comportamiento de la deserialización, como convertir en objetos en lugar de arrays.

   ```php
   $json = '{"nombre":"Juan","edad":30,"ciudad":"México"}';
   $objeto = json_decode($json); // Convierte en objeto stdClass
   ```

# Tratamiento de errores
   Tanto `json_encode()` como `json_decode()` pueden arrojar errores en caso de problemas con los datos JSON. Puedes verificar y manejar los errores utilizando funciones como `json_last_error()` y `json_last_error_msg()`.

   ```php
   $json = '{"nombre":"Juan","edad":30,"ciudad":"México"';
   $datos = json_decode($json);
   if (json_last_error() === JSON_ERROR_NONE) {
       // El JSON se decodificó correctamente
   } else {
       echo "Error: " . json_last_error_msg();
   }
   ```