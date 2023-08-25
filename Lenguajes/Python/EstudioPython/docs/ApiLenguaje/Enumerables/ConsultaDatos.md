Las consultas de acceso a colecciones se refieren a la capacidad de buscar, filtrar y obtener subconjuntos de elementos de una colección, como listas, diccionarios o conjuntos, utilizando criterios específicos. Puedes utilizar varias técnicas y métodos disponibles en Python para realizar consultas de acceso a colecciones.

## Búsqueda y filtrado de elementos:
Puedes utilizar métodos como `for` loops y condicionales para buscar y filtrar elementos en una colección. Aquí tienes un ejemplo:

```python
lista = [10, 20, 30, 40, 50]

# Búsqueda de un elemento
elemento = 30
if elemento in lista:
    print("Elemento encontrado")

# Filtrado de elementos
elementos_filtrados = [x for x in lista if x > 30]
print(elementos_filtrados)  # Imprime [40, 50]
```

En este ejemplo, buscamos un elemento específico en una lista utilizando el operador `in`. Además, filtramos los elementos de la lista utilizando una comprensión de lista y una condición `if`.

## Métodos de filtrado y mapeo:
Python proporciona funciones y métodos integrados para realizar consultas más complejas en colecciones. Algunos ejemplos son `filter()`, `map()`, `reduce()`, `list comprehension` y `generator expression`. Aquí tienes un ejemplo que utiliza `filter()` y `map()`:

```python
def es_par(numero):
    return numero % 2 == 0

def duplicar(numero):
    return numero * 2

lista = [1, 2, 3, 4, 5]

# Filtrado de elementos pares
elementos_filtrados = list(filter(es_par, lista))
print(elementos_filtrados)  # Imprime [2, 4]

# Duplicar elementos
elementos_duplicados = list(map(duplicar, lista))
print(elementos_duplicados)  # Imprime [2, 4, 6, 8, 10]
```

En este ejemplo, utilizamos `filter()` para filtrar elementos en base a una función que determina si un número es par. Luego, utilizamos `map()` para duplicar cada elemento de la lista.

## Consultas con expresiones lambda:
Las expresiones lambda te permiten crear funciones anónimas en línea y son útiles para consultas de acceso a colecciones. Aquí tienes un ejemplo que utiliza expresiones lambda:

```python
lista = [1, 2, 3, 4, 5]

# Filtrado de elementos pares utilizando expresión lambda
elementos_filtrados = list(filter(lambda x: x % 2 == 0, lista))
print(elementos_filtrados)  # Imprime [2, 4]

# Duplicar elementos utilizando expresión lambda
elementos_duplicados = list(map(lambda x: x * 2, lista))
print(elementos_duplicados)  # Imprime [2, 4, 6, 8, 10]
```

En este ejemplo, utilizamos expresiones lambda en línea dentro de `filter()` y `map()` para realizar las consultas de filtrado y mapeo de elementos.
