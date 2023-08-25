# Operadores aritméticos
   Estos operadores se utilizan para realizar operaciones matemáticas básicas.

   - `+`: Suma
   - `-`: Resta
   - `*`: Multiplicación
   - `/`: División
   - `%`: Módulo (resto de la división)

   Ejemplo:
   ```php
   $numero1 = 10;
   $numero2 = 5;

   $suma = $numero1 + $numero2;
   $resta = $numero1 - $numero2;
   $multiplicacion = $numero1 * $numero2;
   $division = $numero1 / $numero2;
   $modulo = $numero1 % $numero2;
   ```

# Operadores de asignación
   Estos operadores se utilizan para asignar valores a variables.

   - `=`: Asignación simple
   - `+=`, `-=`, `*=`, `/=`: Asignación con operación (por ejemplo, `$x += 5` equivale a `$x = $x + 5`)

   Ejemplo:
   ```php
   $x = 10;
   $x += 5; // Ahora $x es 15
   ```

# Operadores de comparación
   Estos operadores se utilizan para comparar valores.

   - `==`: Igual a
   - `!=`: Diferente de
   - `<`: Menor que
   - `>`: Mayor que
   - `<=`: Menor o igual que
   - `>=`: Mayor o igual que

   Ejemplo:
   ```php
   $numero = 8;

   if ($numero > 10) {
       echo "El número es mayor que 10.";
   } elseif ($numero == 10) {
       echo "El número es igual a 10.";
   } else {
       echo "El número es menor que 10.";
   }
   ```

# Operadores lógicos
   Estos operadores se utilizan para combinar o invertir condiciones.

   - `&&` o `and`: AND lógico
   - `||` o `or`: OR lógico
   - `!` o `not`: NOT lógico

   Ejemplo:
   ```php
   $edad = 25;
   $esEstudiante = true;

   if ($edad >= 18 && $esEstudiante) {
       echo "Eres mayor de edad y eres estudiante.";
   }
   ```

# Operadores de concatenación
   Estos operadores se utilizan para unir cadenas de texto.

   - `.`: Concatenación

   Ejemplo:
   ```php
   $nombre = "Juan";
   $apellido = "Pérez";

   $nombreCompleto = $nombre . " " . $apellido;
   ```
