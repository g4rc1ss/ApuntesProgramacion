# Declaración de variables
   En PHP, puedes crear una variable simplemente asignándole un nombre y un valor usando el operador de asignación `=`. Los nombres de variables deben comenzar con un signo de dólar `$` seguido de letras, números o guiones bajos, pero no pueden comenzar con un número.

   ```php
   $nombre = "Juan";
   $edad = 25;
   $esEstudiante = true;
   ```

# Tipos de datos
   PHP es un lenguaje débilmente tipado, lo que significa que no es necesario declarar el tipo de dato al crear una variable. Los tipos de datos en PHP incluyen:
   
   - `int` (entero): números enteros como 1, 100, -42.
   - `float` (flotante): números decimales o de punto flotante como 3.14, -0.5.
   - `string` (cadena de texto): texto encerrado entre comillas simples o dobles, como "Hola".
   - `bool` (booleano): valores verdaderos (`true`) o falsos (`false`).
   
# Concatenación de cadenas
   Puedes combinar cadenas y variables usando el operador de concatenación (`.`). Esto te permite construir cadenas más grandes a partir de partes variables.

   ```php
   $saludo = "Hola, mi nombre es " . $nombre . " y tengo " . $edad . " años.";
   ```

# Uso de variables en texto
   Puedes incluir el valor de una variable dentro de una cadena usando comillas dobles (`"`) y la sintaxis de llaves `{}`. Esto se llama "interpolación de variables".

   ```php
   $mensaje = "Mi nombre es $nombre y tengo $edad años.";
   ```

# Ámbito de las variables
   El ámbito de una variable define dónde puede ser accedida. Las variables pueden ser locales (definidas dentro de una función) o globales (definidas fuera de cualquier función).

   ```php
   $globalVar = 10;

   function ejemploFuncion() {
       $localVar = 5;
       global $globalVar; // Acceder a la variable global dentro de la función
       // ...
   }
   ```

# Variables superglobales
   PHP también proporciona variables superglobales predefinidas que almacenan información sobre el entorno del script, como `$_GET`, `$_POST`, `$_SESSION`, entre otras.

   ```php
   $nombreUsuario = $_POST['username'];
   ```
