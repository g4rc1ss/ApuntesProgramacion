# Polimorfismo de Tipo
El polimorfismo de tipo permite que una variable de un tipo pueda referirse a objetos de clases que sean subclases del tipo. Esto se logra a través de la herencia y las interfaces.

```java
public class Animal {
    void hacerSonido() {
        System.out.println("Animal hace un sonido");
    }
}

public class Perro extends Animal {
    @Override
    void hacerSonido() {
        System.out.println("El perro ladra");
    }
}

public class Gato extends Animal {
    @Override
    void hacerSonido() {
        System.out.println("El gato maulla");
    }
}
```

# Polimorfismo en Acción
Puedes crear un arreglo de tipo `Animal` y almacenar en él instancias de las subclases `Perro` y `Gato`.

```java
public class Main {
    public static void main(String[] args) {
        Animal[] animales = new Animal[2];
        animales[0] = new Perro();
        animales[1] = new Gato();

        for (Animal animal : animales) {
            animal.hacerSonido(); // Llama al método adecuado según el objeto
        }
    }
}
```

# Polimorfismo con Interfaces
El polimorfismo también se aplica a través de interfaces. Si varias clases implementan la misma interfaz, puedes tratarlas de manera uniforme a través de la interfaz.

```java
interface Volador {
    void volar();
}

class Pajaro implements Volador {
    @Override
    public void volar() {
        System.out.println("El pájaro vuela");
    }
}

class Avion implements Volador {
    @Override
    public void volar() {
        System.out.println("El avión vuela");
    }
}
```

# Uso de Polimorfismo
Puedes usar el polimorfismo para tratar objetos de diferentes clases de manera uniforme y lograr flexibilidad en tu código.

```java
public class Main {
    public static void main(String[] args) {
        Volador[] voladores = new Volador[2];
        voladores[0] = new Pajaro();
        voladores[1] = new Avion();

        for (Volador volador : voladores) {
            volador.volar(); // Llama al método adecuado según el objeto
        }
    }
}
```
