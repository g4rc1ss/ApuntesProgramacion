# Abrir un archivo
   Puedes abrir un archivo utilizando la función `fopen()`. Debes proporcionar la ruta del archivo y el modo en el que deseas abrirlo (por ejemplo, "r" para lectura).

   ```php
   $archivo = fopen("archivo.txt", "r");
   ```
# Lectura de todo el contenido
   Puedes leer todo el contenido de un archivo utilizando la función `file_get_contents()`. Esta función carga el contenido completo del archivo en una cadena.

   ```php
   $contenido = file_get_contents("archivo.txt");
   ```
# Lectura línea por línea
   Puedes leer un archivo línea por línea utilizando un bucle `while` y la función `fgets()`.

   ```php
   $archivo = fopen("archivo.txt", "r");
   while (($linea = fgets($archivo)) !== false) {
       echo $linea;
   }
   fclose($archivo);
   ```
# Lectura de caracteres
   Puedes leer un archivo carácter por carácter utilizando la función `fgetc()`.

   ```php
   $archivo = fopen("archivo.txt", "r");
   while (($caracter = fgetc($archivo)) !== false) {
       echo $caracter;
   }
   fclose($archivo);
   ```
# Cierre del archivo
   Siempre debes cerrar un archivo después de leerlo utilizando la función `fclose()`.

   ```php
   fclose($archivo);
   ```
# Lectura segura con `file()` y `file()` con líneas**: Otra forma de leer un archivo línea por línea es usando `file()` o `file()` con la opción `FILE_IGNORE_NEW_LINE

   ```php
   $lineas = file("archivo.txt", FILE_IGNORE_NEW_LINES);
   foreach ($lineas as $linea) {
       echo $linea;
   }
   ```
