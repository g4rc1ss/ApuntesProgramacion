# Covarianza:

La covarianza se refiere a la relación de subtipos entre los tipos de retorno en los métodos de una jerarquía de clases. En otras palabras, si un método se sobrescribe en una subclase, el tipo de retorno en la subclase puede ser un subtipo del tipo de retorno en la superclase.

```java
class Animal {}
class Perro extends Animal {}

class Zoologico {
    Animal obtenerAnimal() {
        return new Animal();
    }
}

class ZoologicoDePerros extends Zoologico {
    @Override
    Perro obtenerAnimal() {  // Covarianza
        return new Perro();
    }
}
```

En este ejemplo, `ZoologicoDePerros` sobrescribe el método `obtenerAnimal()` de la superclase `Zoologico`, y el tipo de retorno en la subclase es un subtipo (`Perro`) del tipo de retorno en la superclase (`Animal`). Esto es un ejemplo de covarianza.

# Contravarianza:

La contravarianza se refiere a la relación de subtipos entre los tipos de parámetros en los métodos de una jerarquía de clases. En otras palabras, si un método se sobrescribe en una subclase, el tipo de parámetro en la subclase puede ser un supertipo del tipo de parámetro en la superclase.

```java
class Animal {}
class Perro extends Animal {}

class Veterinario {
    void examinar(Perro perro) {
        // Examinar al perro
    }
}

class VeterinarioDeAnimales extends Veterinario {
    @Override
    void examinar(Animal animal) {  // Contravarianza
        // Examinar al animal (incluyendo perros)
    }
}
```

En este ejemplo, `VeterinarioDeAnimales` sobrescribe el método `examinar()` de la superclase `Veterinario`, y el tipo de parámetro en la subclase (`Animal`) es un supertipo del tipo de parámetro en la superclase (`Perro`). Esto es un ejemplo de contravarianza.

# Consideraciones:

Covarianza y contravarianza son conceptos avanzados que permiten un mayor grado de flexibilidad en la programación orientada a objetos. Estos conceptos son especialmente relevantes cuando se trabaja con tipos genéricos, como en las colecciones de Java, y cuando se trata de garantizar que los métodos de subclases cumplan con las expectativas de los métodos en superclases.