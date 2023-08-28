Declaración de arrays asociativos
   En PHP, puedes declarar un array asociativo utilizando una sintaxis similar a un array indexado, pero especificando claves en lugar de índices numéricos.

   ```php
   $persona = [
       "nombre" => "Juan",
       "edad" => 30,
       "ciudad" => "México"
   ];
   ```

Acceso a valores en un array asociativo
   Puedes acceder a los valores en un array asociativo utilizando las claves correspondientes.

   ```php
   $nombre = $persona["nombre"]; // "Juan"
   $edad = $persona["edad"]; // 30
   ```

Modificar y agregar valores
   Puedes modificar o agregar valores en un array asociativo asignando un valor a una clave existente o nueva.

   ```php
   $persona["edad"] = 31; // Modifica el valor de "edad"
   $persona["ocupacion"] = "Programador"; // Agrega una nueva clave-valor
   ```

Recorrer arrays asociativos
   Puedes recorrer un array asociativo utilizando un bucle `foreach` de manera similar a un array indexado.

   ```php
   foreach ($persona as $clave => $valor) {
       echo "$clave: $valor\n";
   }
   // Imprime: nombre: Juan
   //         edad: 31
   //         ciudad: México
   //         ocupacion: Programador
   ```

Conteo de elementos
   Puedes utilizar la función `count()` para contar la cantidad de pares clave-valor en un array asociativo.

   ```php
   $cantidadElementos = count($persona); // 4
   ```

Eliminación de valores
   Puedes eliminar valores de un array asociativo utilizando la función `unset()`.

   ```php
   unset($persona["ciudad"]); // Elimina la clave "ciudad"
   ```

Verificación de existencia de claves
   Puedes verificar si una clave existe en un array asociativo utilizando la función `array_key_exists()`.

   ```php
   if (array_key_exists("edad", $persona)) {
       echo "La clave 'edad' existe";
   }
   ```

Ordenamiento de claves
   Puedes ordenar las claves de un array asociativo utilizando la función `ksort()`.

   ```php
   ksort($persona); // Ordena las claves en orden alfabético
   ```
