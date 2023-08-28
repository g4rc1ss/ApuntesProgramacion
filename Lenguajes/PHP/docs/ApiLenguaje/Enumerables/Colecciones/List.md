# Declaración de arrays
   Los arrays en PHP pueden ser indexados o asociativos. Los indexados utilizan números como índices, mientras que los asociativos utilizan cadenas.

   ```php
   // Array indexado
   $numeros = [1, 2, 3, 4, 5];

   // Array asociativo
   $persona = [
       "nombre" => "Juan",
       "edad" => 30,
       "ciudad" => "México"
   ];
   ```

# Acceso a elementos
   Puedes acceder a elementos en un array utilizando sus índices o claves.

   ```php
   $primerNumero = $numeros[0]; // 1
   $nombrePersona = $persona["nombre"]; // "Juan"
   ```

# Agregar elementos
   Puedes agregar elementos a un array asignándoles un nuevo índice o clave.

   ```php
   $numeros[] = 6; // Agrega 6 al final del array
   $persona["ocupacion"] = "Programador"; // Agrega la clave "ocupacion" al array asociativo
   ```

# Recorrer arrays
   Puedes recorrer un array utilizando bucles `foreach`.

   ```php
   foreach ($numeros as $numero) {
       echo $numero . " ";
   }
   // Imprime: 1 2 3 4 5 6

   foreach ($persona as $clave => $valor) {
       echo "$clave: $valor\n";
   }
   // Imprime: nombre: Juan
   //         edad: 30
   //         ciudad: México
   //         ocupacion: Programador
   ```

# Conteo de elementos
   Puedes contar los elementos de un array utilizando la función `count()`.

   ```php
   $cantidadNumeros = count($numeros); // 6
   ```

# Búsqueda en arrays
   Puedes buscar elementos en un array utilizando funciones como `in_array()`.

   ```php
   if (in_array(3, $numeros)) {
       echo "3 está en el array";
   }
   ```

# Eliminación de elementos
   Puedes eliminar elementos de un array utilizando `unset()`.

   ```php
   unset($persona["edad"]); // Elimina la clave "edad" del array asociativo
   ```

# Ordenamiento de arrays
   Puedes ordenar arrays utilizando funciones como `sort()`.

   ```php
   sort($numeros); // Ordena el array de números en orden ascendente
   ```

# Filtrado de arrays
   Puedes filtrar arrays utilizando funciones como `array_filter()`.

   ```php
   $numerosPares = array_filter($numeros, function ($numero) {
       return $numero % 2 == 0;
   });
   // $numerosPares contendrá [2, 4, 6]
   ```
