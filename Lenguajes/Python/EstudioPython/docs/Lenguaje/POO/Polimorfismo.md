El polimorfismo es un concepto de la programación orientada a objetos que permite que objetos de diferentes clases se comporten de manera similar en función de un conjunto común de métodos o atributos. En Python, el polimorfismo se logra mediante el uso de herencia y el principio de sustitución de Liskov.

Supongamos que tienes una clase base llamada `Animal` y dos clases derivadas llamadas `Perro` y `Gato`. Cada clase tiene su propio método `hacer_sonido()`, pero se comportan de manera similar.

```python
class Animal:
    def hacer_sonido(self):
        pass

class Perro(Animal):
    def hacer_sonido(self):
        print("Guau!")

class Gato(Animal):
    def hacer_sonido(self):
        print("Miau!")
```

En este ejemplo, `Animal` es la clase base que define el método `hacer_sonido()` como un método vacío. Las clases `Perro` y `Gato` heredan de `Animal` y proporcionan su propia implementación del método `hacer_sonido()`.

Ahora, puedes crear objetos de las clases `Perro` y `Gato` y llamar al método `hacer_sonido()` en cada uno de ellos.

```python
perro = Perro()
gato = Gato()

perro.hacer_sonido()  # Salida: Guau!
gato.hacer_sonido()  # Salida: Miau!
```

En este ejemplo, `perro` y `gato` son objetos de las clases `Perro` y `Gato`, respectivamente. A pesar de que ambos objetos se crean a partir de clases diferentes, puedes llamar al método `hacer_sonido()` en cada uno de ellos sin preocuparte por su tipo real. Esto es posible debido al polimorfismo, ya que ambos objetos se comportan de manera similar al tener un método común llamado `hacer_sonido()`.

El polimorfismo también permite el uso de herencia múltiple en Python. Puedes crear una clase que herede de varias clases base y aprovechar los métodos y atributos de todas ellas.

```python
class Ave:
    def volar(self):
        pass

class Pato(Animal, Ave):
    def hacer_sonido(self):
        print("Cuac!")

    def volar(self):
        print("Volando como un pato!")
```

En este ejemplo, `Ave` es otra clase base que define el método `volar()`. La clase `Pato` hereda tanto de `Animal` como de `Ave` y proporciona su propia implementación de los métodos `hacer_sonido()` y `volar()`. Puedes crear un objeto de la clase `Pato` y llamar a ambos métodos.

```python
pato = Pato()

pato.hacer_sonido()  # Salida: Cuac!
pato.volar()  # Salida: Volando como un pato!
```

En este ejemplo, el objeto `pato` se comporta tanto como un `Animal` (al llamar al método `hacer_sonido()`) como un `Ave` (al llamar al método `volar()`). Esto demuestra cómo el polimorfismo permite que un objeto sea tratado como diferentes tipos a través de la herencia y el uso de métodos comunes.
