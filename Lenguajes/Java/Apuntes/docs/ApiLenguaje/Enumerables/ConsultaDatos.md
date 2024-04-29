# Introducción a Stream API
La Stream API fue introducida en Java 8 y permite operar en colecciones de una manera más funcional y eficiente. Los streams son secuencias de elementos que se pueden procesar en paralelo o en secuencia.

# Crear un Stream
Puedes crear un stream a partir de una colección utilizando el método `stream()`.

```java
import java.util.List;
import java.util.stream.Stream;
import java.util.ArrayList;

public class ConsultasColecciones {
    public static void main(String[] args) {
        List<Integer> numeros = new ArrayList<>();
        numeros.add(5);
        numeros.add(10);
        numeros.add(15);

        Stream<Integer> streamNumeros = numeros.stream();
    }
}
```

# Operaciones de Filtrado
Puedes filtrar elementos en un stream utilizando el método `filter()`.

```java
Stream<Integer> streamFiltrado = streamNumeros.filter(num -> num > 7);
```

# Operaciones de Transformación
Puedes transformar elementos en un stream utilizando el método `map()`.

```java
Stream<String> streamDobles = streamNumeros.map(num -> "Doble: " + (num * 2));
```

# Operaciones de Reducción
Puedes reducir los elementos en un stream utilizando operaciones como `reduce()`.

```java
int suma = streamNumeros.reduce(0, (acumulador, num) -> acumulador + num);
```

# Operaciones Terminales
Las operaciones terminales producen un resultado final o un valor no stream. Algunos ejemplos son `forEach()`, `collect()`, `toArray()`, `min()`, `max()`, `count()` y `anyMatch()`.

```java
streamNumeros.forEach(System.out::println);

List<Integer> listaPares = streamNumeros.filter(num -> num % 2 == 0)
                                       .collect(Collectors.toList());

long cantidadElementos = streamNumeros.count();
```

# Operaciones en Paralelo
Una de las ventajas de Stream API es la capacidad de realizar operaciones en paralelo para un mejor rendimiento.

```java
long cantidadPares = streamNumeros.parallel()
                                  .filter(num -> num % 2 == 0)
                                  .count();
```
