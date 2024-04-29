# Importancia de los Diccionarios
Los diccionarios son útiles para almacenar asociaciones entre claves y valores. Son especialmente útiles cuando necesitas acceder rápidamente a un valor utilizando su clave, como almacenar información de usuario en una base de datos, configuraciones, etc.

# Creación y Uso Básico de HashMap
`HashMap` es una implementación de la interfaz `Map` que almacena pares clave-valor utilizando una función hash. Proporciona un acceso rápido a los valores.

```java
import java.util.HashMap;
import java.util.Map;

public class Diccionarios {
    public static void main(String[] args) {
        Map<String, Integer> edades = new HashMap<>();

        edades.put("Juan", 25);
        edades.put("María", 30);
        edades.put("Carlos", 28);

        System.out.println("Edades: " + edades); // {Juan=25, María=30, Carlos=28}

        int edadDeMaria = edades.get("María");
        System.out.println("Edad de María: " + edadDeMaria); // 30

        edades.remove("Juan");
        System.out.println("Edades después de eliminar: " + edades); // {María=30, Carlos=28}
    }
}
```

# Creación y Uso Básico de TreeMap
`TreeMap` es otra implementación de `Map` que almacena los pares clave-valor en un orden natural (orden ascendente de las claves).

```java
import java.util.TreeMap;
import java.util.Map;

public class Diccionarios {
    public static void main(String[] args) {
        Map<String, Integer> edades = new TreeMap<>();

        edades.put("Juan", 25);
        edades.put("María", 30);
        edades.put("Carlos", 28);

        System.out.println("Edades ordenadas: " + edades); // {Carlos=28, Juan=25, María=30}
    }
}
```

# Iteración a través de un Diccionario
Puedes recorrer un diccionario utilizando bucles `for-each` y métodos como `keySet()`, `values()` y `entrySet()`.

```java
Map<String, Double> precios = new HashMap<>();
precios.put("Manzana", 1.5);
precios.put("Banana", 0.8);
precios.put("Naranja", 1.0);

for (String fruta : precios.keySet()) {
    double precio = precios.get(fruta);
    System.out.println(fruta + ": $" + precio);
}

for (double precio : precios.values()) {
    System.out.println("Precio: $" + precio);
}
```

# Métodos Adicionales
La interfaz `Map` proporciona varios métodos para manipular diccionarios, como `put()`, `get()`, `remove()`, `containsKey()`, `isEmpty()` y `size()`.

# Diferencias en Implementaciones
Cada implementación de `Map` tiene sus propias características. `HashMap` ofrece un acceso rápido y no garantiza un orden particular. `TreeMap` mantiene las claves ordenadas. `LinkedHashMap` mantiene el orden de inserción.
