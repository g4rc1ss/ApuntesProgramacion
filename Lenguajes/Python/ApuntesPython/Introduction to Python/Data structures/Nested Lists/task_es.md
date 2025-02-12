## Listas Anidadas

Una lista puede contener cualquier tipo de objetos, incluso otras listas (sublistas). Esta 
estructura de datos se conoce como una lista anidada.

Puedes usar listas anidadas para organizar datos en estructuras jerárquicas.

Una lista anidada se puede crear escribiendo una secuencia separada por comas de sublistas:

```python
nested_list = [[1, 2, 3], [4, 5], 6]
```

Puedes acceder a los elementos en una lista anidada usando índices como antes:

```python
print(nested_list[1])
print(nested_list[2])
```
Salida:
```text
[4, 5]
6
```
Puedes acceder a los elementos dentro de las sublistas en una lista anidada utilizando múltiples índices.
Para acceder al número `1` de `nested_list`, usa el índice `0` dos veces. Primero, accedes al elemento `[1,2,3]` y luego, al primer elemento de esa sublista:

```python
print(nested_list[0][0])
```
Salida:
```text
1
```
Para obtener información más estructurada y detallada, puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6938?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, usa la indexación para acceder e imprimir los elementos `9` y `10` de la lista anidada `my_list`. 

<div class="hint">Si te quedas atascado, revisa nuevamente los ejemplos en la descripción de la tarea.</div>