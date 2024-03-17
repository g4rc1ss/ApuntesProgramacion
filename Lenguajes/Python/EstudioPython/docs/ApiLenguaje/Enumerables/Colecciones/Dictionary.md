Los diccionarios son estructuras de datos que almacenan pares de clave-valor. A diferencia de las listas que se acceden mediante índices, los diccionarios se acceden mediante claves únicas

## Creación de diccionarios:
Puedes crear un diccionario en Python utilizando llaves `{}` y separando los pares clave-valor con dos puntos `:`. Aquí tienes algunos ejemplos:

```python
diccionario1 = {'nombre': 'Juan', 'edad': 25, 'ciudad': 'Madrid'}
diccionario2 = {1: 'uno', 2: 'dos', 3: 'tres'}
diccionario3 = {}   # Diccionario vacío
```

En estos ejemplos, hemos creado diccionarios con diferentes pares clave-valor. Las claves pueden ser cadenas, enteros u otros tipos de datos inmutables.

## Acceso a valores:
Puedes acceder a los valores de un diccionario utilizando las claves correspondientes. Utiliza la sintaxis `diccionario[clave]` para acceder al valor asociado a una clave específica. Aquí tienes un ejemplo:

```python
diccionario = {'nombre': 'Juan', 'edad': 25, 'ciudad': 'Madrid'}
print(diccionario['nombre'])    # Imprime 'Juan'
print(diccionario['edad'])      # Imprime 25
```

En este ejemplo, accedemos a los valores utilizando las claves `'nombre'` y `'edad'`.

## Operaciones y métodos de diccionarios:
Python proporciona una amplia gama de operaciones y métodos para trabajar con diccionarios. Algunas operaciones comunes incluyen la adición y eliminación de pares clave-valor, la verificación de la existencia de una clave, la obtención de las claves y los valores, y la iteración sobre el diccionario. Aquí tienes algunos ejemplos:

```python
diccionario = {'nombre': 'Juan', 'edad': 25, 'ciudad': 'Madrid'}
diccionario['profesion'] = 'ingeniero'   # Agregar un par clave-valor
del diccionario['edad']   # Eliminar un par clave-valor
print('nombre' in diccionario)   # Verificar si una clave existe
print(diccionario.keys())   # Obtener las claves: ['nombre', 'ciudad', 'profesion']
print(diccionario.values())   # Obtener los valores: ['Juan', 'Madrid', 'ingeniero']
for clave, valor in diccionario.items():   # Iterar sobre el diccionario
    print(clave, valor)
```

En estos ejemplos, hemos realizado diferentes operaciones y utilizado algunos métodos integrados para manipular diccionarios.
