# Lanzar una excepción
   Puedes lanzar una excepción en tu código utilizando la palabra clave `throw` seguida de una instancia de una clase de excepción. Las excepciones son objetos que representan situaciones inusuales o errores.

   ```php
   if ($divisor == 0) {
       throw new Exception("División por cero no permitida");
   }
   ```

# Capturar excepciones
   Para capturar y manejar excepciones, utiliza bloques `try` y `catch`. El bloque `try` contiene el código que podría lanzar una excepción, mientras que el bloque `catch` maneja la excepción si ocurre.

   ```php
   try {
       $resultado = dividir(10, 0);
   } catch (Exception $e) {
       echo "Ha ocurrido un error: " . $e->getMessage();
   }
   ```

# Múltiples bloques `catch`
   Puedes tener múltiples bloques `catch` para manejar diferentes tipos de excepciones de manera específica.

   ```php
   try {
       $resultado = dividir(10, 0);
   } catch (DivisionByZeroException $e) {
       echo "División por cero: " . $e->getMessage();
   } catch (Exception $e) {
       echo "Error general: " . $e->getMessage();
   }
   ```

# Definir tus propias excepciones
   Puedes crear tus propias clases de excepción personalizadas al extender la clase `Exception` o alguna de sus subclases.

   ```php
   class MiExcepcion extends Exception {
       public function __construct($mensaje) {
           parent::__construct($mensaje);
       }
   }

   try {
       if (condicion) {
           throw new MiExcepcion("Ha ocurrido algo inusual");
       }
   } catch (MiExcepcion $e) {
       echo "Error personalizado: " . $e->getMessage();
   }
   ```

# Finalmente (`finally`)
   Puedes usar el bloque `finally` para ejecutar código independientemente de si se lanzó o no una excepción.

   ```php
   try {
       // Código que podría lanzar una excepción
   } catch (Exception $e) {
       // Manejar la excepción
   } finally {
       // Código que se ejecuta siempre
   }
   ```

# Excepciones en funciones
   Si una función lanza una excepción y no la maneja, puedes declarar que la función lanza una excepción específica utilizando la palabra clave `throws`.

   ```php
   function dividir($numerador, $denominador): float {
       if ($denominador == 0) {
           throw new DivisionByZeroException("División por cero no permitida");
       }
       return $numerador / $denominador;
   }
   ```
