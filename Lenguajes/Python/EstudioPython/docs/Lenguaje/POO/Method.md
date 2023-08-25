Los métodos son funciones que están asociadas a una clase y se utilizan para definir el comportamiento de los objetos creados a partir de esa clase. Los métodos son similares a las funciones, pero se definen dentro de la definición de la clase y pueden acceder a los atributos y otros métodos de la clase

## Definir un método en una clase:
Para definir un método en una clase, lo hacemos dentro de la definición de la clase. El primer parámetro de un método siempre es `self`, que hace referencia a la instancia del objeto en sí. Aquí tienes un ejemplo básico:

```python
class Persona:
    def saludar(self):
        print("Hola, ¡bienvenido!")

# Crear una instancia de la clase Persona
persona1 = Persona()

# Llamar al método saludar() de la instancia
persona1.saludar()  # Imprime "Hola, ¡bienvenido!"
```

En este ejemplo, hemos definido una clase `Persona` con un método `saludar()`. Cuando creamos una instancia de la clase y llamamos al método `saludar()`, se ejecuta el código dentro del método.

## Acceder a los atributos de la instancia dentro de un método:
Dentro de un método, podemos acceder a los atributos de la instancia utilizando el parámetro `self`. Aquí tienes un ejemplo:

```python
class Persona:
    def __init__(self, nombre):
        self.nombre = nombre

    def presentarse(self):
        print(f"Hola, mi nombre es {self.nombre}.")

# Crear una instancia de la clase Persona
persona1 = Persona("Juan")

# Llamar al método presentarse() de la instancia
persona1.presentarse()  # Imprime "Hola, mi nombre es Juan."
```

En este ejemplo, hemos definido una clase `Persona` con un método especial `__init__()` y otro método `presentarse()`. El método `__init__()` se ejecuta automáticamente cuando se crea una instancia y se utiliza para inicializar el atributo `nombre`. Luego, el método `presentarse()` accede al atributo `nombre` de la instancia utilizando `self`.

## Pasar argumentos a los métodos:
Los métodos pueden recibir argumentos adicionales, aparte del parámetro `self`, para realizar cálculos o modificar el estado de la instancia. Aquí tienes un ejemplo:

```python
class Calculadora:
    def sumar(self, a, b):
        resultado = a + b
        print(f"El resultado de la suma es: {resultado}.")

# Crear una instancia de la clase Calculadora
calculadora1 = Calculadora()

# Llamar al método sumar() con argumentos
calculadora1.sumar(5, 3)  # Imprime "El resultado de la suma es: 8."
```

En este ejemplo, hemos definido una clase `Calculadora` con un método `sumar()` que recibe dos argumentos `a` y `b`. El método suma los valores y muestra el resultado.
