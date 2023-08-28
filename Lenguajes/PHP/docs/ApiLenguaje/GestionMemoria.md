# Recolector de Basura
   PHP utiliza un recolector de basura interno para gestionar la memoria automáticamente. Cuando una variable ya no tiene referencias a ella, el recolector de basura se encarga de liberar la memoria ocupada por esa variable.

# Referencias
   En PHP, las variables son asignadas por valor o por referencia. Cuando asignas una variable por referencia, varias variables pueden referir al mismo valor en memoria. Es importante entender cómo funcionan las referencias, ya que pueden afectar la vida útil de los datos.

   ```php
   $a = 42;
   $b = &$a; // $b hace referencia a $a
   unset($a); // $b sigue siendo accesible
   ```

# Ciclos de Referencia
   Los ciclos de referencia ocurren cuando dos o más objetos se referencian mutuamente, lo que puede evitar que el recolector de basura libere memoria. Para evitar esto, puedes utilizar la función `unset()` o establecer las referencias a `null`.

   ```php
   class Objeto {
       public $otroObjeto;
   }

   $objeto1 = new Objeto();
   $objeto2 = new Objeto();
   $objeto1->otroObjeto = $objeto2;
   $objeto2->otroObjeto = $objeto1;

   // Para liberar memoria, establece las referencias a null
   $objeto1->otroObjeto = null;
   $objeto2->otroObjeto = null;
   ```

# Liberación de Memoria Manual
   Aunque el recolector de basura hace la mayor parte del trabajo, en situaciones especiales puedes liberar memoria manualmente utilizando `unset()`.

   ```php
   $datosGrandes = "Datos muy grandes..."; // Ocupa mucha memoria
   unset($datosGrandes); // Libera la memoria ocupada por $datosGrandes
   ```

# Memoria en Ciclos o Bucles
   Al trabajar con bucles, es importante asegurarte de que las variables no acumulen memoria innecesariamente.

   ```php
   $resultados = [];
   foreach ($datos as $dato) {
       $resultado = procesar($dato);
       $resultados[] = $resultado;
   }
   ```

# Uso de Funciones de Memoria
   PHP proporciona funciones como `memory_get_usage()` y `memory_get_peak_usage()` para obtener información sobre el uso de memoria en un momento dado.

   ```php
   $usoActual = memory_get_usage(); // Uso actual de memoria
   $usoPico = memory_get_peak_usage(); // Uso máximo de memoria durante la ejecución
   ```
