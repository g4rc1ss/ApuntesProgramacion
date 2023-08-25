# Estructura básica de una condición
   En PHP, puedes usar la estructura `if`, `else if` y `else` para implementar condiciones. La sintaxis es la siguiente:

   ```php
   if (condición) {
       // Código a ejecutar si la condición es verdadera
   } elseif (otra_condición) {
       // Código a ejecutar si la primera condición es falsa y esta condición es verdadera
   } else {
       // Código a ejecutar si ninguna de las condiciones anteriores es verdadera
   }
   ```

# Operadores de comparación
   Puedes usar operadores de comparación para evaluar condiciones. Algunos operadores comunes son:
   
   - `==`: Igual a
   - `!=`: Diferente de
   - `<`: Menor que
   - `>`: Mayor que
   - `<=`: Menor o igual que
   - `>=`: Mayor o igual que

# Operadores lógicos
   Los operadores lógicos te permiten combinar múltiples condiciones. Los principales operadores lógicos son:
   
   - `&&` o `and`: AND lógico
   - `||` o `or`: OR lógico
   - `!` o `not`: NOT lógico

# Ejemplos
   Aquí tienes algunos ejemplos de condiciones en PHP:

   ```php
   $edad = 18;

   if ($edad >= 18) {
       echo "Eres mayor de edad.";
   } else {
       echo "Eres menor de edad.";
   }
   ```

   ```php
   $num = 7;

   if ($num % 2 == 0) {
       echo "El número es par.";
   } else {
       echo "El número es impar.";
   }
   ```

   ```php
   $usuario = "admin";
   $contraseña = "secreta";

   if ($usuario == "admin" && $contraseña == "secreta") {
       echo "Acceso concedido.";
   } else {
       echo "Acceso denegado.";
   }
   ```

   ```php
   $color = "verde";

   if ($color == "rojo" || $color == "verde") {
       echo "El color es rojo o verde.";
   } else {
       echo "El color no es rojo ni verde.";
   }
   ```
