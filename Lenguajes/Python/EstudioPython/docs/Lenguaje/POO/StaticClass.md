Las clases estáticas son métodos y atributos que pertenecen a la clase en sí misma en lugar de a una instancia específica de la clase. Esto significa que los métodos estáticos pueden ser llamados directamente desde la clase sin necesidad de crear una instancia. Las clases estáticas son útiles para agrupar funcionalidades relacionadas que no requieren acceso a los atributos de instancia.

## Definir una clase con un método estático:
Para definir un método estático en una clase, utilizamos el decorador `@staticmethod` seguido de la definición del método. Aquí tienes un ejemplo:

```python
class Calculadora:
    @staticmethod
    def sumar(a, b):
        return a + b

# Llamar al método estático directamente desde la clase
resultado = Calculadora.sumar(5, 3)
print(resultado)  # Imprime 8
```

En este ejemplo, hemos definido una clase `Calculadora` con un método estático `sumar()` que toma dos parámetros `a` y `b` y devuelve su suma. Podemos llamar directamente al método `sumar()` desde la clase sin necesidad de crear una instancia.

2. Acceder a atributos estáticos:
Los atributos estáticos son variables que pertenecen a la clase en sí misma. Se definen en la clase, fuera de cualquier método, y se pueden acceder directamente desde la clase o desde una instancia de la clase. Aquí tienes un ejemplo:

```python
class Punto:
    x = 0
    y = 0

    @staticmethod
    def mover(dx, dy):
        Punto.x += dx
        Punto.y += dy

# Acceder a los atributos estáticos directamente desde la clase
print(Punto.x, Punto.y)  # Imprime 0 0

# Llamar al método estático que actualiza los atributos estáticos
Punto.mover(2, 3)

# Acceder a los atributos estáticos desde una instancia de la clase
p = Punto()
print(p.x, p.y)  # Imprime 2 3
```

En este ejemplo, hemos definido una clase `Punto` con los atributos estáticos `x` e `y`. El método estático `mover()` actualiza los atributos estáticos `x` e `y` sumando los valores `dx` y `dy`. Podemos acceder a los atributos estáticos directamente desde la clase o desde una instancia de la clase.
