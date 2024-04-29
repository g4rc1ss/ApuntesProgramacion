# Definición de Clases Abstractas
Una clase abstracta se declara utilizando la palabra clave `abstract`. Puedes tener atributos, métodos con o sin implementación, y métodos abstractos.

```java
abstract class Figura {
    double area;

    abstract double calcularArea(); // Método abstracto
}
```

# Métodos Abstractos
Los métodos abstractos no tienen una implementación en la clase abstracta, pero deben ser implementados en todas las subclases concretas.

```java
abstract class Figura {
    abstract double calcularArea();
}

class Circulo extends Figura {
    double radio;

    Circulo(double radio) {
        this.radio = radio;
    }

    @Override
    double calcularArea() {
        return Math.PI * radio * radio;
    }
}
```

# Clases Concretas
Las subclases de una clase abstracta son clases concretas que proporcionan implementaciones para los métodos abstractos.

```java
class Rectangulo extends Figura {
    double base;
    double altura;

    Rectangulo(double base, double altura) {
        this.base = base;
        this.altura = altura;
    }

    @Override
    double calcularArea() {
        return base * altura;
    }
}
```

# Herencia y Uso de Clases Abstractas
Puedes heredar de una clase abstracta y proporcionar implementaciones para los métodos abstractos en las subclases concretas.

```java
public class Main {
    public static void main(String[] args) {
        Figura circulo = new Circulo(5);
        Figura rectangulo = new Rectangulo(4, 6);

        double areaCirculo = circulo.calcularArea();
        double areaRectangulo = rectangulo.calcularArea();

        System.out.println("Área del círculo: " + areaCirculo);
        System.out.println("Área del rectángulo: " + areaRectangulo);
    }
}
```

# Ventajas de las Clases Abstractas
- Promueven la reutilización de código y establecen una estructura común para las subclases.
- Obligan a las subclases a proporcionar implementaciones para los métodos abstractos, garantizando una cierta consistencia en el comportamiento.

Las clases abstractas en Java son útiles cuando deseas crear una base común para varias clases relacionadas, pero no deseas que se creen instancias directas de la clase base.