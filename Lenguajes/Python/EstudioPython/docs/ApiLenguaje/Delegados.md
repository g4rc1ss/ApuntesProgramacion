Los delegados o funciones anónimas se conocen como "funciones lambda". Las funciones lambda son funciones pequeñas y sin nombre que se definen en línea y se utilizan para realizar tareas simples sin necesidad de crear una función completa.

## Sintaxis de las funciones lambda:
La sintaxis básica de una función lambda es la siguiente:
```python
lambda argumentos: expresión
```

- `lambda` es la palabra clave que indica que se está definiendo una función lambda.
- `argumentos` son los parámetros de la función lambda.
- `expresión` es el código que se ejecuta y devuelve un resultado.

## Uso de funciones lambda:
Las funciones lambda se utilizan generalmente en situaciones en las que se requiere una función simple y de corta duración. Se pueden utilizar en combinación con funciones como `map()`, `filter()`, `reduce()`, así como en expresiones donde se requiera una función como argumento. Aquí tienes algunos ejemplos:

- Ejemplo 1: Función lambda simple:
```python
suma = lambda a, b: a + b
resultado = suma(3, 5)
print(resultado)  # Imprime 8
```
En este ejemplo, hemos definido una función lambda llamada `suma` que toma dos argumentos (`a` y `b`) y devuelve su suma.

- Ejemplo 2: Uso de función lambda con `map()`:
```python
numeros = [1, 2, 3, 4, 5]
dobles = list(map(lambda x: x * 2, numeros))
print(dobles)  # Imprime [2, 4, 6, 8, 10]
```
En este ejemplo, utilizamos `map()` junto con una función lambda para aplicar la multiplicación por 2 a cada elemento de la lista `numeros`.

- Ejemplo 3: Uso de función lambda con `filter()`:
```python
numeros = [1, 2, 3, 4, 5]
pares = list(filter(lambda x: x % 2 == 0, numeros))
print(pares)  # Imprime [2, 4]
```
En este ejemplo, utilizamos `filter()` junto con una función lambda para filtrar los elementos pares de la lista `numeros`.