Las clases abstractas son clases que no pueden ser instanciadas directamente, sino que se utilizan como clases base para otras clases. Las clases abstractas se definen utilizando el módulo `abc` (Abstract Base Classes) de la biblioteca estándar de Python. Las clases abstractas permiten definir métodos que deben ser implementados en las clases derivadas, lo que ayuda a establecer una estructura común y garantizar que las clases hijas cumplan con ciertos requisitos.

## Importar el módulo `abc` y definir una clase abstracta:
Para utilizar clases abstractas, primero debemos importar el módulo `abc` de la biblioteca estándar de Python. Luego, definimos una clase que herede de `abc.ABC` o tenga el decorador `@abc.ABC` para indicar que es una clase abstracta. Aquí tienes un ejemplo básico:

```python
import abc

class FiguraGeometrica(abc.ABC):
    @abc.abstractmethod
    def calcular_area(self):
        pass

# Intentar crear una instancia de la clase abstracta
figura = FiguraGeometrica()  # Genera un TypeError
```

En este ejemplo, hemos definido una clase abstracta `FiguraGeometrica` que hereda de `abc.ABC`. También hemos definido un método abstracto `calcular_area()`, que debe ser implementado en las clases derivadas. Intentar crear una instancia directa de la clase abstracta generará un `TypeError`.

## Crear una clase derivada e implementar los métodos abstractos:
Las clases derivadas de una clase abstracta deben implementar los métodos abstractos definidos en la clase base. Aquí tienes un ejemplo:

```python
class Rectangulo(FiguraGeometrica):
    def __init__(self, ancho, altura):
        self.ancho = ancho
        self.altura = altura

    def calcular_area(self):
        return self.ancho * self.altura

# Crear una instancia de la clase derivada
rectangulo = Rectangulo(5, 3)

# Llamar al método implementado en la clase derivada
area = rectangulo.calcular_area()
print(area)  # Imprime 15
```

En este ejemplo, hemos creado una clase `Rectangulo` que hereda de la clase abstracta `FiguraGeometrica`. La clase `Rectangulo` implementa el método abstracto `calcular_area()` para calcular el área del rectángulo. Podemos crear instancias de la clase derivada y llamar al método implementado.
