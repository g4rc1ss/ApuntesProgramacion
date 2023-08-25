# Colas 
Una cola es una estructura de datos que sigue el principio FIFO (First-In, First-Out), lo que significa que el primer elemento que se agrega a la cola es el primero en ser eliminado. Puedes utilizar la clase `queue.Queue` del módulo `queue` para trabajar con colas en Python.

1. Importar el módulo `queue`:
Para utilizar colas en Python, primero debes importar el módulo `queue`. Aquí tienes un ejemplo:

```python
import queue
```

2. Creación y manipulación de colas:
Puedes crear una cola utilizando la clase `queue.Queue()`. Luego, puedes agregar elementos a la cola utilizando el método `put()` y eliminar elementos de la cola utilizando el método `get()`. Aquí tienes un ejemplo:

```python
cola = queue.Queue()

cola.put(10)   # Agregar elementos a la cola
cola.put(20)
cola.put(30)

elemento = cola.get()   # Eliminar un elemento de la cola
print(elemento)   # Imprime 10
```

En este ejemplo, hemos creado una cola utilizando `queue.Queue()`. Luego, hemos agregado elementos a la cola utilizando `put()` y hemos eliminado un elemento de la cola utilizando `get()`.

3. Verificación del estado de la cola:
Puedes utilizar el método `empty()` para verificar si la cola está vacía y el método `qsize()` para obtener el tamaño actual de la cola. Aquí tienes un ejemplo:

```python
cola = queue.Queue()

print(cola.empty())   # Verificar si la cola está vacía (True)

cola.put(10)
cola.put(20)
cola.put(30)

print(cola.qsize())   # Imprime el tamaño de la cola (3)
print(cola.empty())   # Verificar si la cola está vacía (False)
```

En este ejemplo, verificamos si la cola está vacía utilizando `empty()` (que devuelve `True` si la cola está vacía). Luego, agregamos elementos a la cola y verificamos el tamaño de la cola utilizando `qsize()`.
