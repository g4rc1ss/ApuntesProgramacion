# Métodos de Acceso (Getters)
Los métodos de acceso son utilizados para obtener el valor de un atributo privado. Siguen una convención de nomenclatura `getNombreAtributo`.

```java
public class Persona {
    private String nombre;

    public String getNombre() {
        return nombre;
    }
}
```

# Métodos de Modificación (Setters)
Los métodos de modificación son utilizados para cambiar el valor de un atributo privado. Siguen una convención de nomenclatura `setNombreAtributo`.

```java
public class Persona {
    private String nombre;

    public void setNombre(String nuevoNombre) {
        nombre = nuevoNombre;
    }
}
```

# Uso de Getters y Setters
Estos métodos permiten controlar el acceso y la modificación de atributos privados de una clase, lo que puede ser útil para implementar validaciones o lógica adicional.

```java
public class Persona {
    private int edad;

    public int getEdad() {
        return edad;
    }

    public void setEdad(int nuevaEdad) {
        if (nuevaEdad > 0) {
            edad = nuevaEdad;
        }
    }
}
```

# Ventajas de Usar Getters y Setters
- **Encapsulación:** Permite ocultar los detalles internos de la implementación de una clase y controlar el acceso a sus atributos.
- **Validación y Lógica:** Puedes agregar lógica adicional dentro de los métodos de acceso y modificación para validar los valores asignados o realizar otras operaciones.

# Ejemplo Completo
```java
public class Main {
    public static void main(String[] args) {
        Persona persona = new Persona();
        persona.setEdad(25);
        System.out.println("Edad: " + persona.getEdad());
    }
}
```
