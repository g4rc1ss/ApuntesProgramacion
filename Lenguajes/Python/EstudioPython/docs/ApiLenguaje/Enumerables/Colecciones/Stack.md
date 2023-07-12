# Pilas
Una pila es una estructura de datos que sigue el principio LIFO (Last-In, First-Out), lo que significa que el último elemento que se agrega a la pila es el primero en ser eliminado. Puedes utilizar una lista de Python y sus métodos `append()` y `pop()` para simular el comportamiento de una pila.

1. Creación y manipulación de pilas:
Puedes crear una pila utilizando una lista vacía `[]`. Luego, puedes agregar elementos a la pila utilizando el método `append()` y eliminar elementos de la pila utilizando el método `pop()`. Aquí tienes un ejemplo:

```python
pila = []

pila.append(10)   # Agregar elementos a la pila
pila.append(20)
pila.append(30)

elemento = pila.pop()   # Eliminar un elemento de la pila
print(elemento)   # Imprime 30
```

En este ejemplo, hemos creado una pila utilizando una lista vacía `[]`. Luego, hemos agregado elementos a la pila utilizando `append()` y hemos eliminado un elemento de la pila utilizando `pop()`.

2. Verificación del estado de la pila:
Puedes utilizar la función `len()` para obtener el tamaño actual de la pila y verificar si la pila está vacía. Aquí tienes un ejemplo:

```python
pila = []

print(len(pila))   # Imprime el tamaño de la pila (0)

pila.append(10)
pila.append(20)
pila.append(30)

print(len(pila))   # Imprime el tamaño de la pila (3)
print(len(pila) == 0)   # Verificar si la pila está vacía (False)
```

En este ejemplo, utilizamos `len()` para obtener el tamaño de la pila. Si el tamaño es 0, la pila está vacía.

