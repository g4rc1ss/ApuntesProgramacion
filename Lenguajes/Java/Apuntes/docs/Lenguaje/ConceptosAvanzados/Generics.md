# Definición de Genéricos
Los genéricos se definen utilizando el parámetro de tipo `<T>` que actúa como un marcador de posición para el tipo real que se utilizará más tarde.

```java
public class Caja<T> {
    private T contenido;

    public T getContenido() {
        return contenido;
    }

    public void setContenido(T nuevoContenido) {
        contenido = nuevoContenido;
    }
}
```

# Utilización de Genéricos
Puedes utilizar la clase genérica `Caja` con diferentes tipos de datos sin necesidad de crear una clase por separado para cada tipo.

```java
public class Main {
    public static void main(String[] args) {
        Caja<Integer> cajaDeEnteros = new Caja<>();
        cajaDeEnteros.setContenido(42);
        int contenidoEntero = cajaDeEnteros.getContenido();

        Caja<String> cajaDeCadenas = new Caja<>();
        cajaDeCadenas.setContenido("Hola, mundo");
        String contenidoCadena = cajaDeCadenas.getContenido();
    }
}
```

# Múltiples Parámetros de Tipo
Puedes definir clases genéricas con varios parámetros de tipo.

```java
public class Par<T, U> {
    private T primerElemento;
    private U segundoElemento;

    public Par(T primero, U segundo) {
        primerElemento = primero;
        segundoElemento = segundo;
    }

    // Métodos getters y setters
}
```

# Restricciones de Tipo
Puedes restringir los tipos que se pueden usar como argumentos de tipo utilizando la palabra clave `extends`.

```java
public class Caja<T extends Number> {
    // ...
}
```

# Métodos Genéricos
Además de clases genéricas, también puedes definir métodos genéricos.

```java
public class Utilidades {
    public static <T> void imprimirArreglo(T[] arreglo) {
        for (T elemento : arreglo) {
            System.out.print(elemento + " ");
        }
        System.out.println();
    }
}
```

# Wildcards (Comodines)
Los comodines (`?`) permiten trabajar con tipos desconocidos en genéricos.

```java
public void imprimirCaja(Caja<?> caja) {
    System.out.println(caja.getContenido());
}
```
