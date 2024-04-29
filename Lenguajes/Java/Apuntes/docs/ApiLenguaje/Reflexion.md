# Obtener la Clase de un Objeto
Puedes obtener la clase de un objeto utilizando el método `getClass()`.

```java
public class ReflectionEjemplo {
    public static void main(String[] args) {
        String texto = "Hola, mundo!";
        Class<?> clase = texto.getClass();
        System.out.println("Nombre de la clase: " + clase.getName());
    }
}
```

# Obtener Métodos de una Clase
Puedes obtener los métodos de una clase utilizando el objeto `Class` y el método `getMethods()`.

```java
import java.lang.reflect.Method;

public class ReflectionMetodos {
    public static void main(String[] args) {
        Class<?> clase = String.class;
        Method[] metodos = clase.getMethods();

        for (Method metodo : metodos) {
            System.out.println("Nombre del método: " + metodo.getName());
        }
    }
}
```

# Acceder a Campos de una Clase
Puedes acceder a los campos (variables miembro) de una clase utilizando el objeto `Class` y el método `getFields()`.

```java
import java.lang.reflect.Field;

public class ReflectionCampos {
    public static void main(String[] args) {
        Class<?> clase = String.class;
        Field[] campos = clase.getFields();

        for (Field campo : campos) {
            System.out.println("Nombre del campo: " + campo.getName());
        }
    }
}
```

# Crear una Instancia de Clase
Puedes crear una instancia de una clase utilizando el método `newInstance()`.

```java
public class ReflectionInstancia {
    public static void main(String[] args) {
        try {
            Class<?> clase = String.class;
            Object instancia = clase.newInstance();
            System.out.println("Instancia creada: " + instancia);
        } catch (InstantiationException | IllegalAccessException e) {
            e.printStackTrace();
        }
    }
}
```

# Invocar un Método en Tiempo de Ejecución
Puedes invocar métodos en tiempo de ejecución utilizando el objeto `Method` y el método `invoke()`.

```java
public class ReflectionInvocacionMetodo {
    public static void main(String[] args) {
        try {
            Class<?> clase = String.class;
            Method metodo = clase.getMethod("toUpperCase");
            String resultado = (String) metodo.invoke("hola");
            System.out.println("Resultado: " + resultado);
        } catch (ReflectiveOperationException e) {
            e.printStackTrace();
        }
    }
}
```
