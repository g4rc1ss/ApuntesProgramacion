# Asignación de Memoria en Java
En Java, los objetos se crean utilizando el operador `new`. Java aloca automáticamente memoria para los objetos en el "heap", una región de memoria dinámica administrada por el GC.

```java
class Persona {
    private String nombre;

    public Persona(String nombre) {
        this.nombre = nombre;
    }
}

public class GestionMemoria {
    public static void main(String[] args) {
        Persona persona = new Persona("Juan"); // Se asigna memoria para un objeto Persona
        // ...
    }
}
```

# Garbage Collection (GC)
El GC en Java es responsable de identificar y liberar la memoria ocupada por objetos que ya no son accesibles. Esto reduce la posibilidad de fugas de memoria.

```java
public class GCMemoria {
    public static void main(String[] args) {
        for (int i = 0; i < 100000; i++) {
            new Persona("Nombre" + i); // Se crean objetos Persona
        }
        System.gc(); // Se sugiere al GC que realice la recolección de basura
    }
}
```

# Objetos Inaccesibles y Recolectables
Los objetos que ya no son accesibles desde el punto de entrada principal del programa (como variables locales y referencias) son elegibles para la recolección de basura.

```java
public class ObjetosInaccesibles {
    public static void main(String[] args) {
        for (int i = 0; i < 100000; i++) {
            new Persona("Nombre" + i); // Se crean objetos Persona
        }
        System.gc(); // No se recomienda llamar a System.gc() explícitamente
    }
}
```

# Objetos con Referencias Fuertes y Débiles
Las referencias fuertes (strong references) son las que previenen que un objeto sea recolectado. Las referencias débiles (weak references) permiten que un objeto sea recolectado si no hay referencias fuertes que lo mantengan vivo.

```java
import java.lang.ref.WeakReference;

public class ReferenciasDebiles {
    public static void main(String[] args) {
        Persona persona = new Persona("Juan");
        WeakReference<Persona> referenciaDebil = new WeakReference<>(persona);

        persona = null; // Se elimina la referencia fuerte

        // Se intenta acceder al objeto a través de la referencia débil
        if (referenciaDebil.get() != null) {
            System.out.println("Objeto aún vivo");
        } else {
            System.out.println("Objeto recolectado");
        }
    }
}
```
