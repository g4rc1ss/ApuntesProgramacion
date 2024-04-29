# Atributos y Métodos Estáticos
Los atributos y métodos estáticos pertenecen a la clase en sí, en lugar de a instancias individuales. Puedes acceder a ellos utilizando el nombre de la clase.

```java
public class MiClase {
    static int contador = 0;

    static void incrementarContador() {
        contador++;
    }
}
```

# Acceso a Atributos y Métodos Estáticos
Para acceder a atributos y métodos estáticos, no es necesario crear una instancia de la clase. Puedes hacerlo directamente a través del nombre de la clase.

```java
MiClase.contador = 5;  // Acceso al atributo estático
MiClase.incrementarContador();  // Acceso al método estático
```

# Métodos Estáticos y Constructores
Los métodos estáticos no pueden acceder a variables de instancia ni llamar a métodos de instancia, ya que no se aplican a instancias específicas de la clase.

```java
public class Utilidades {
    static int sumar(int a, int b) {
        return a + b;
    }
}
```

# Clases Estáticas Anidadas
Puedes definir clases estáticas dentro de otras clases. Estas clases anidadas no requieren una instancia de la clase principal para acceder a ellas.

```java
public class ClasePrincipal {
    static class ClaseAnidada {
        static void saludar() {
            System.out.println("Hola desde la clase anidada");
        }
    }
}
```

# Constantes Estáticas
Los atributos estáticos también se pueden utilizar para definir constantes en una clase, ya que su valor no cambia y es accesible a nivel de clase.

```java
public class Constantes {
    static final double PI = 3.14159;
}
```

# Bloques Estáticos
Puedes utilizar bloques estáticos para inicializar atributos estáticos o realizar otras operaciones al cargar la clase.

```java
public class ClaseConBloqueEstatico {
    static {
        System.out.println("La clase se ha cargado");
    }
}
```

Las clases estáticas son útiles para definir miembros que son compartidos por todas las instancias de una clase o para agrupar funcionalidades que no requieren el estado de objeto.