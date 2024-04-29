# Definición de Interfaces
Una interfaz en Java se define utilizando la palabra clave `interface`. Contiene solo métodos abstractos (sin implementación) y constantes (variables estáticas y finales).

```java
public interface Animal {
    void emitirSonido();
    String obtenerTipo();
    int NUM_PATAS = 4; // Constante
}
```

# Implementación de Interfaces
Para implementar una interfaz en una clase concreta, se utiliza la palabra clave `implements`. La clase debe proporcionar implementaciones para todos los métodos de la interfaz.

```java
public class Perro implements Animal {
    @Override
    public void emitirSonido() {
        System.out.println("El perro ladra");
    }

    @Override
    public String obtenerTipo() {
        return "Perro";
    }
}
```

# Múltiple Implementación
Una clase puede implementar múltiples interfaces, lo que permite lograr una forma de herencia múltiple en Java.

```java
public interface Volador {
    void volar();
}

public class Pajaro implements Animal, Volador {
    @Override
    public void emitirSonido() {
        System.out.println("El pájaro canta");
    }

    @Override
    public String obtenerTipo() {
        return "Pájaro";
    }

    @Override
    public void volar() {
        System.out.println("El pájaro vuela");
    }
}
```

# Utilizando Interfaces
Las interfaces permiten programar en función de la abstracción. Puedes tratar a objetos que implementan la misma interfaz de manera similar.

```java
public class Main {
    public static void main(String[] args) {
        Animal perro = new Perro();
        Animal pajaro = new Pajaro();

        perro.emitirSonido(); // "El perro ladra"
        pajaro.emitirSonido(); // "El pájaro canta"
    }
}
```

# Default Methods y Static Methods
Desde Java 8, las interfaces pueden contener métodos con implementación (default methods) y métodos estáticos.

```java
public interface Comportamiento {
    default void realizarAccion() {
        System.out.println("Realizando acción por defecto");
    }

    static void metodoEstatico() {
        System.out.println("Método estático en la interfaz");
    }
}
```
