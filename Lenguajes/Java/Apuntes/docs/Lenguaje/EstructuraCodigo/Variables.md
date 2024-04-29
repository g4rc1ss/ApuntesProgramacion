# Declaración de variables

```java
int edad;
String nombre;
double salario;
```

# Asignación de valores
Puedes asignar un valor a una variable después de declararla utilizando el operador de asignación `=`. Por ejemplo:
```java
edad = 25;
nombre = "Juan";
salario = 1500.50;
```

# Declaración y asignación en una sola línea
También puedes declarar y asignar valores en una sola línea:
```java
int edad = 25;
String nombre = "Juan";
double salario = 1500.50;
```

# Tipos de datos
Java tiene diversos tipos de datos, incluyendo `int` (entero), `double` (decimal), `char` (carácter), `boolean` (booleano), etc.

# Convenciones de nomenclatura
Las variables en Java deben seguir ciertas convenciones de nomenclatura. Los nombres de variables deben comenzar con una letra o un guión bajo, seguidos de letras, números o guiones bajos adicionales. Los nombres de variables distinguen entre mayúsculas y minúsculas.

# Ejemplo de uso
```java
public class EjemploVariables {
    public static void main(String[] args) {
        int edad = 25;
        String nombre = "Juan";
        double salario = 1500.50;

        System.out.println("Nombre: " + nombre);
        System.out.println("Edad: " + edad);
        System.out.println("Salario: $" + salario);
    }
}
```