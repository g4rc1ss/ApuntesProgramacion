# Sintaxis básica de expresiones regulares
   Las expresiones regulares están compuestas por caracteres literales y metacaracteres que tienen significados especiales. Por ejemplo, el metacaracter `.` se utiliza para representar cualquier carácter.

# Funciones y métodos para trabajar con expresiones regulares
   En PHP, puedes utilizar funciones como `preg_match()`, `preg_replace()`, `preg_split()`, y clases como `RegexIterator` para trabajar con expresiones regulares.

`preg_match()`: Esta función verifica si un patrón de expresión regular coincide con una cadena dada.

   ```php
   $texto = "Hola, mundo!";
   if (preg_match("/mundo/", $texto)) {
       echo "Encontrado";
   }
   ```

`preg_replace()`: Esta función reemplaza partes de una cadena que coinciden con un patrón de expresión regular.

   ```php
   $texto = "Hola, mundo!";
   $nuevoTexto = preg_replace("/mundo/", "PHP", $texto);
   // $nuevoTexto será "Hola, PHP!"
   ```

`preg_split()`: Esta función divide una cadena en partes utilizando un patrón de expresión regular como delimitador.

   ```php
   $texto = "Manzana,Naranja,Pera";
   $frutas = preg_split("/,/", $texto);
   // $frutas será un array con ["Manzana", "Naranja", "Pera"]
   ```

# Uso de metacaracteres
   Los metacaracteres son caracteres con significados especiales en expresiones regulares. Por ejemplo:
   - `.` coincide con cualquier carácter.
   - `*` coincide con cero o más repeticiones del carácter anterior.
   - `+` coincide con una o más repeticiones del carácter anterior.
   - `\d` coincide con dígitos numéricos.

# Grupos y capturas
   Puedes utilizar paréntesis para agrupar partes de un patrón y capturar subcadenas.

   ```php
   $texto = "Fecha: 2023-08-07";
   preg_match("/Fecha: (\d{4}-\d{2}-\d{2})/", $texto, $matches);
   // $matches contendrá ["Fecha: 2023-08-07", "2023-08-07"]
   ```

# Modificadores y opciones
   Puedes utilizar modificadores como `i` para hacer que la búsqueda sea insensible a mayúsculas y minúsculas.

   ```php
   $texto = "Hola, mundo!";
   if (preg_match("/MUNDO/i", $texto)) {
       echo "Encontrado";
   }
   ```

# Uso de expresiones regulares en objetos
   Puedes utilizar la clase `RegexIterator` para realizar búsquedas y manipulaciones avanzadas en conjuntos de cadenas.

   ```php
   $array = ["Manzana", "Naranja", "Pera"];
   $iterator = new RegexIterator(new ArrayIterator($array), "/a/i");
   foreach ($iterator as $fruta) {
       echo $fruta . " ";
   }
   // Imprime: "Manzana Naranja Pera"
   ```
