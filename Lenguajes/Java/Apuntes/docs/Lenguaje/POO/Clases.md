# Definición de Clases
Una clase es un plano o plantilla para crear objetos. Contiene atributos (variables) y métodos (funciones) que definen el comportamiento y las propiedades de los objetos que se crean a partir de ella.

```java
public class Persona {
    String nombre;
    int edad;

    void saludar() {
        System.out.println("Hola, mi nombre es " + nombre + " y tengo " + edad + " años.");
    }
}
```

# Creación de Objetos
Los objetos son instancias de una clase. Puedes crear objetos utilizando la palabra clave `new`.

```java
Persona persona1 = new Persona();
persona1.nombre = "Juan";
persona1.edad = 25;
persona1.saludar();
```

# Constructores
Los constructores son métodos especiales que se utilizan para inicializar objetos cuando se crean. Puedes crear constructores personalizados o utilizar el constructor predeterminado.

```java
public class Persona {
    String nombre;
    int edad;

    // Constructor personalizado
    public Persona(String nombre, int edad) {
        this.nombre = nombre;
        this.edad = edad;
    }

    void saludar() {
        System.out.println("Hola, mi nombre es " + nombre + " y tengo " + edad + " años.");
    }
}
```

# Encapsulación
La encapsulación implica ocultar los detalles internos de una clase y proporcionar acceso controlado a los atributos y métodos a través de modificadores de acceso (como `public`, `private` y otros).

```java
public class Persona {
    private String nombre;
    private int edad;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getEdad() {
        return edad;
    }

    public void setEdad(int edad) {
        this.edad = edad;
    }

    void saludar() {
        System.out.println("Hola, mi nombre es " + nombre + " y tengo " + edad + " años.");
    }
}
```
