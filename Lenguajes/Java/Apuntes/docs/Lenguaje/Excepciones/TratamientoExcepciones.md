# Tipos de Excepciones
En Java, las excepciones se dividen en tres categorías principales: excepciones comprobadas (checked exceptions), excepciones no comprobadas (unchecked exceptions) y errores.

- **Excepciones Comprobadas:** Son aquellas que el compilador verifica y te obliga a manejar mediante un bloque `try-catch` o declarando que el método lanza la excepción.
- **Excepciones No Comprobadas:** Son subclases de `RuntimeException` y no requieren manejo explícito. Ocurren durante la ejecución y no se verifican en tiempo de compilación.
- **Errores:** Son condiciones graves que generalmente están fuera del control del programador y no deberían ser capturados ni manejados.

# Manejo de Excepciones
Para manejar excepciones, se utilizan bloques `try`, `catch` y `finally`.

- **try:** Encierra el código que puede lanzar una excepción.
- **catch:** Captura y maneja la excepción si ocurre.
- **finally:** Contiene código que se ejecuta siempre, independientemente de si se produce una excepción o no.

```java
public class Division {
    public static void main(String[] args) {
        int numerador = 10;
        int denominador = 0;

        try {
            int resultado = numerador / denominador;
            System.out.println("Resultado: " + resultado);
        } catch (ArithmeticException e) {
            System.out.println("Error: División por cero");
        } finally {
            System.out.println("Finalizando el bloque try-catch");
        }
    }
}
```

# Lanzamiento de Excepciones
Puedes lanzar tus propias excepciones utilizando la palabra clave `throw`. Esto es útil cuando deseas indicar que ocurrió un problema específico en tu código.

```java
public class MiClase {
    void metodo(int numero) throws MiExcepcion {
        if (numero < 0) {
            throw new MiExcepcion("Número negativo no permitido");
        }
    }
}

class MiExcepcion extends Exception {
    MiExcepcion(String mensaje) {
        super(mensaje);
    }
}
```

# Creación de Excepciones Personalizadas
Puedes crear tus propias clases de excepción personalizadas extendiendo `Exception` o `RuntimeException`.

# Utilizando try-with-resources
En Java 7 y posteriores, puedes utilizar `try-with-resources` para manejar automáticamente recursos que deben ser cerrados, como archivos o conexiones de red.

```java
try (FileReader fileReader = new FileReader("archivo.txt")) {
    // Código para leer el archivo
} catch (IOException e) {
    // Manejo de excepciones
}
```
