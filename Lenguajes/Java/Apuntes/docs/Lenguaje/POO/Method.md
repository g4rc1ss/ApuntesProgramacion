# Definición de Métodos
Un método en Java es una colección de declaraciones que realizan una acción. Puedes definir métodos dentro de una clase.

```java
public class Calculadora {
    int sumar(int a, int b) {
        return a + b;
    }
}
```

# Llamada a Métodos
Para llamar a un método, debes crear una instancia de la clase (si no es un método estático) y luego utilizar la notación de punto para acceder al método.

```java
Calculadora calculadora = new Calculadora();
int resultado = calculadora.sumar(5, 3); // Llama al método sumar
```

# Parámetros y Valores de Retorno
Los métodos pueden tomar parámetros (datos que se pasan al método) y pueden devolver un valor utilizando la palabra clave `return`.

```java
public class Calculadora {
    int sumar(int a, int b) {
        return a + b;
    }

    void saludar(String nombre) {
        System.out.println("¡Hola, " + nombre + "!");
    }
}
```

# Métodos Estáticos
Los métodos estáticos no requieren una instancia de la clase para ser llamados. Pueden acceder solo a atributos estáticos y otros métodos estáticos.

```java
public class Utilidades {
    static int sumar(int a, int b) {
        return a + b;
    }
}
```

# Sobrecarga de Métodos
Puedes definir varios métodos con el mismo nombre pero diferentes listas de parámetros. Esto se llama sobrecarga de métodos.

```java
public class Calculadora {
    int sumar(int a, int b) {
        return a + b;
    }

    double sumar(double a, double b) {
        return a + b;
    }
}
```

# Métodos con Valores Predeterminados
Puedes proporcionar valores predeterminados para los parámetros de un método, lo que permite llamar al método sin proporcionar todos los argumentos.

```java
public class Utilidades {
    static int sumar(int a, int b, int c) {
        return a + b + c;
    }

    static int sumar(int a, int b) {
        return sumar(a, b, 0);
    }
}
```

# Métodos Recursivos
Un método recursivo es aquel que se llama a sí mismo para resolver un problema. Debe tener una condición de parada para evitar la recursión infinita.

```java
public class Factorial {
    int calcularFactorial(int n) {
        if (n == 0) {
            return 1;
        } else {
            return n * calcularFactorial(n - 1);
        }
    }
}
```

Los métodos en Java permiten encapsular la lógica y la funcionalidad, lo que facilita la organización y reutilización del código.