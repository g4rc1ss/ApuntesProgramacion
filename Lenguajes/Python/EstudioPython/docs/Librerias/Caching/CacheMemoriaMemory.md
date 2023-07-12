La caché en memoria local es una técnica utilizada para almacenar temporalmente los resultados de operaciones costosas en memoria, con el fin de mejorar el rendimiento y evitar repetir cálculos innecesarios. En Python, puedes implementar una caché en memoria local utilizando estructuras de datos como diccionarios o la biblioteca `functools.lru_cache`.

## Implementación de una caché básica con un diccionario:
Puedes utilizar un diccionario para almacenar los resultados en caché. Cada vez que se necesita el resultado de una operación, se verifica si ya está en la caché. Si está presente, se devuelve el resultado almacenado. De lo contrario, se realiza la operación y se guarda en la caché para su uso posterior.

```python
cache = {}

def operacion_costosa(n):
    if n in cache:
        return cache[n]

    # Operación costosa
    resultado = n * 2

    # Almacenar el resultado en caché
    cache[n] = resultado

    return resultado

print(operacion_costosa(5))  # Realiza la operación y almacena el resultado en caché
print(operacion_costosa(5))  # Devuelve el resultado almacenado en caché sin repetir la operación
```

En este ejemplo, hemos creado un diccionario `cache` para almacenar los resultados de la operación `operacion_costosa()`. La primera vez que se llama a la función con un valor de `n`, se realiza la operación y se guarda el resultado en la caché. Las siguientes veces que se llama con el mismo valor de `n`, se devuelve el resultado almacenado en la caché, evitando así la repetición de la operación costosa.

## Implementación de una caché con `functools.lru_cache`:
La biblioteca `functools` de Python proporciona el decorador `lru_cache`, que permite implementar una caché en memoria local con una política de "menos recientemente utilizado" (Least Recently Used - LRU). La caché tiene un tamaño máximo y automáticamente descarta los elementos menos utilizados cuando se alcanza ese límite.

```python
from functools import lru_cache

@lru_cache(maxsize=100)
def operacion_costosa(n):
    # Operación costosa
    resultado = n * 2

    return resultado

print(operacion_costosa(5))  # Realiza la operación y almacena el resultado en caché
print(operacion_costosa(5))  # Devuelve el resultado almacenado en caché sin repetir la operación
```

En este ejemplo, hemos decorado la función `operacion_costosa()` con `@lru_cache(maxsize=100)`. Esto crea una caché con un tamaño máximo de 100 elementos y automáticamente almacena y recupera los resultados según sea necesario. La primera vez que se llama a la función con un valor de `n`, se realiza la operación y se guarda el resultado en la caché. Las siguientes veces que se llama con el mismo valor de `n`, se devuelve el resultado almacenado en la caché sin repetir la operación.
