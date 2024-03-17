# Declaración de cadenas
   Puedes declarar cadenas utilizando comillas simples (`'`) o comillas dobles (`"`).

   ```php
   $cadena1 = 'Hola, mundo!';
   $cadena2 = "¡Hola, PHP!";
   ```

# Interpolación de variables
   Dentro de las comillas dobles, puedes interpolar variables directamente en la cadena.

   ```php
   $nombre = "Juan";
   $saludo = "Hola, $nombre";
   // Resultado: "Hola, Juan"
   ```

# Concatenación de cadenas
   Puedes concatenar cadenas utilizando el operador `.`.

   ```php
   $cadena1 = "Hola, ";
   $cadena2 = "mundo!";
   $saludo = $cadena1 . $cadena2;
   // Resultado: "Hola, mundo!"
   ```

# Longitud de cadenas
   Puedes obtener la longitud de una cadena usando la función `strlen()`.

   ```php
   $cadena = "Hola, PHP!";
   $longitud = strlen($cadena);
   // $longitud es 10
   ```

# Acceso a caracteres
   Puedes acceder a caracteres individuales de una cadena utilizando la notación de corchetes `[]`.

   ```php
   $cadena = "Hola";
   echo $cadena[0]; // Imprime "H"
   ```

# Búsqueda y reemplazo
   Puedes buscar y reemplazar contenido dentro de una cadena utilizando `str_replace()`.

   ```php
   $texto = "Hola, mundo!";
   $nuevoTexto = str_replace("mundo", "PHP", $texto);
   // $nuevoTexto será "Hola, PHP!"
   ```

# Comparación de cadenas
   Puedes comparar cadenas utilizando los operadores `==` o `===`.

   ```php
   $cadena1 = "Hola";
   $cadena2 = "Hola";
   if ($cadena1 == $cadena2) {
       // Se ejecutará este bloque
   }
   ```

# Convertir a mayúsculas/minúsculas
   Puedes convertir cadenas a mayúsculas o minúsculas utilizando `strtoupper()` y `strtolower()`.

   ```php
   $cadena = "Hola, PHP!";
   $mayusculas = strtoupper($cadena);
   // $mayusculas será "HOLA, PHP!"
   ```

# Formateo de cadenas
   Puedes formatear cadenas utilizando `sprintf()`.

   ```php
   $nombre = "Juan";
   $edad = 30;
   $mensaje = sprintf("Hola, %s. Tienes %d años.", $nombre, $edad);
   // $mensaje será "Hola, Juan. Tienes 30 años."
   ```

1# Escapado de caracteres
   Puedes escapar caracteres especiales en una cadena utilizando la barra invertida `\`.

   ```php
   $cadena = "Este es un ejemplo de \"cadena\"";
   ```
