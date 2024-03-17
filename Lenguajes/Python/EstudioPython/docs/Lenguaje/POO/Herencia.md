La herencia es un concepto clave de la programación orientada a objetos que permite crear nuevas clases basadas en clases existentes. La herencia permite a una clase heredar los atributos y métodos de otra clase, lo que facilita la reutilización de código y la creación de jerarquías de clases.

## Definir una clase base (clase padre):
Una clase base (también llamada clase padre o superclase) es una clase existente de la cual otras clases pueden heredar atributos y métodos. Aquí tienes un ejemplo:

```python
class Animal:
    def __init__(self, nombre):
        self.nombre = nombre

    def hablar(self):
        raise NotImplementedError("Subclases deben implementar este método.")

# Crear una instancia de la clase Animal
animal1 = Animal("Animal")
print(animal1.nombre)  # Imprime "Animal"

# Llamar al método hablar() de la clase Animal
animal1.hablar()  # Genera un NotImplementedError
```

En este ejemplo, hemos definido una clase `Animal` que tiene un atributo `nombre` y un método `hablar()`. El método `hablar()` genera un error porque queremos que las clases derivadas (subclases) implementen su propia versión de ese método.

## Definir una clase derivada (clase hija):
Una clase derivada (también llamada clase hija o subclase) es una nueva clase que hereda atributos y métodos de una clase base. La clase derivada puede agregar nuevos atributos y métodos, o sobrescribir los existentes. Aquí tienes un ejemplo:

```python
class Perro(Animal):
    def hablar(self):
        return "Guau"

# Crear una instancia de la clase Perro
perro1 = Perro("Bobby")
print(perro1.nombre)  # Imprime "Bobby"

# Llamar al método hablar() de la clase Perro
print(perro1.hablar())  # Imprime "Guau"
```

En este ejemplo, hemos definido una clase `Perro` que hereda de la clase `Animal`. La clase `Perro` define su propia implementación del método `hablar()`, que devuelve "Guau". La instancia `perro1` tiene acceso tanto al atributo `nombre` heredado de la clase `Animal` como al método `hablar()` definido en la clase `Perro`.

## Utilizar métodos de la clase base en la clase derivada:
La clase derivada puede utilizar métodos de la clase base utilizando la función `super()`. Esto permite llamar a los métodos de la clase base y extender su funcionalidad. Aquí tienes un ejemplo:

```python
class Gato(Animal):
    def hablar(self):
        sonido_animal = super().hablar()
        return f"{sonido_animal}... ¡Miau!"

# Crear una instancia de la clase Gato
gato1 = Gato("Pelusa")
print(gato1.nombre)  # Imprime "Pelusa"

# Llamar al método hablar() de la clase Gato
print(gato1.hablar())  # Imprime "None... ¡Miau!"
```

En este ejemplo, hemos definido una clase `Gato` que hereda de la clase `Animal`. La clase `Gato` sobrescribe el método `hablar()` y utiliza `super().hablar()` para llamar al método `hablar()` de la clase `Animal`. Luego, extiende la funcionalidad agregando "¡Miau!" al final del sonido del animal.
