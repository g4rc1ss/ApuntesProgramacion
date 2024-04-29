# Definición de Herencia
La herencia es un mecanismo mediante el cual una clase (llamada "clase derivada" o "subclase") puede heredar atributos y métodos de otra clase (llamada "clase base" o "superclase"). La subclase puede extender la funcionalidad de la superclase o modificarla según sus necesidades.

# Sintaxis de Herencia
Para heredar de una clase en Java, se utiliza la palabra clave `extends` seguida del nombre de la superclase.

```java
public class Subclase extends Superclase {
    // ...
}
```

# Acceso a Miembros Heredados
Los miembros (atributos y métodos) públicos y protegidos de la superclase son heredados por la subclase. Los miembros privados no son accesibles directamente.

# Ejemplo de Herencia
```java
class Vehiculo {
    void arrancar() {
        System.out.println("El vehículo arrancó");
    }
}

class Coche extends Vehiculo {
    void acelerar() {
        System.out.println("El coche aceleró");
    }
}

public class Main {
    public static void main(String[] args) {
        Coche miCoche = new Coche();
        miCoche.arrancar();
        miCoche.acelerar();
    }
}
```

En este ejemplo, la clase `Coche` hereda el método `arrancar()` de la clase `Vehiculo`. La instancia de `Coche` puede acceder a ambos métodos.

# Sobrescritura de Métodos (Override)
Una subclase puede sobrescribir (override) los métodos de la superclase para cambiar su comportamiento. Se utiliza la anotación `@Override` para indicar que el método está siendo sobrescrito.

```java
class Vehiculo {
    void arrancar() {
        System.out.println("El vehículo arrancó");
    }
}

class Coche extends Vehiculo {
    @Override
    void arrancar() {
        System.out.println("El coche arrancó");
    }
}
```

# Llamada a Métodos de la Superclase
Dentro de la subclase, puedes llamar a un método de la superclase utilizando la palabra clave `super`.

```java
class Coche extends Vehiculo {
    @Override
    void arrancar() {
        super.arrancar(); // Llama al método de la superclase
        System.out.println("El coche arrancó");
    }
}
```
