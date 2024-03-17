# Uso básico de `yield`
   En lugar de usar `return` para finalizar una función, usamos `yield` para "pausar" la función y devolver un valor. La función se reanudará cuando el valor sea solicitado.

   ```php
   function numerosPares($limite) {
       for ($i = 0; $i <= $limite; $i += 2) {
           yield $i;
       }
   }

   foreach (numerosPares(10) as $numero) {
       echo $numero . " ";
   }
   // Imprime: 0 2 4 6 8 10
   ```

# Generadores y ahorro de memoria
   En lugar de generar y almacenar todos los números pares en un arreglo, el generador produce cada número bajo demanda, ahorrando memoria.

# Pasando valores al generador
   Puedes usar `yield` para recibir valores de afuera y usarlos en el generador.

   ```php
   function repetir($valor, $veces) {
       for ($i = 0; $i < $veces; $i++) {
           $resultado = yield;
           echo "Iteración $i: $valor (Resultado: $resultado)\n";
       }
   }

   $gen = repetir("Hola", 3);
   $gen->send("Saludos"); // Iteración 0: Hola (Resultado: Saludos)
   $gen->send("¡Hola de nuevo!"); // Iteración 1: Hola (Resultado: ¡Hola de nuevo!)
   ```

# Finalización del generador
   Puedes finalizar un generador utilizando `return`.

   ```php
   function generarNumeros() {
       yield 1;
       yield 2;
       return 3;
   }

   foreach (generarNumeros() as $numero) {
       echo $numero . " ";
   }
   // Imprime: 1 2
   ```

# Generadores infinitos
   Los generadores pueden utilizarse para generar secuencias infinitas de valores.

   ```php
   function numerosNaturales() {
       $i = 1;
       while (true) {
           yield $i++;
       }
   }

   foreach (numerosNaturales() as $numero) {
       if ($numero > 10) {
           break;
       }
       echo $numero . " ";
   }
   // Imprime: 1 2 3 4 5 6 7 8 9 10
   ```
