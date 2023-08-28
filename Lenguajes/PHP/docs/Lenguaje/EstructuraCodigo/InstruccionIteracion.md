# Bucle while
   El bucle `while` ejecuta un bloque de código mientras se cumpla una condición.

   ```php
   $contador = 1;
   while ($contador <= 5) {
       echo "Iteración $contador <br>";
       $contador++;
   }
   ```

# Bucle do-while
   El bucle `do-while` es similar al `while`, pero se asegura de que el bloque de código se ejecute al menos una vez antes de verificar la condición.

   ```php
   $contador = 1;
   do {
       echo "Iteración $contador <br>";
       $contador++;
   } while ($contador <= 5);
   ```

# Bucle for
   El bucle `for` se utiliza para iterar un número específico de veces.

   ```php
   for ($i = 1; $i <= 5; $i++) {
       echo "Iteración $i <br>";
   }
   ```

# Bucle foreach
   El bucle `foreach` se utiliza para iterar sobre elementos en arrays o colecciones.

   ```php
   $colores = array("rojo", "verde", "azul");
   foreach ($colores as $color) {
       echo "Color: $color <br>";
   }
   ```

# Instrucciones break y continue
   Puedes usar la instrucción `break` para salir de un bucle prematuramente y la instrucción `continue` para saltar una iteración y pasar a la siguiente.

   ```php
   for ($i = 1; $i <= 10; $i++) {
       if ($i == 5) {
           break; // Salir del bucle cuando $i sea igual a 5
       }
       echo "Iteración $i <br>";
   }
   ```

   ```php
   for ($i = 1; $i <= 10; $i++) {
       if ($i % 2 == 0) {
           continue; // Saltar esta iteración si $i es par
       }
       echo "Iteración $i <br>";
   }
   ```
