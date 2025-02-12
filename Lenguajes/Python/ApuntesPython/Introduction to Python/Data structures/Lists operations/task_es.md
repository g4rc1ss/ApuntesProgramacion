## Operaciones con listas

A diferencia de las cadenas, las listas son un tipo mutable, es decir, es posible cambiar su contenido usando `lst[index] = new_item`.

```python
cubes = [1, 8, 27, 65, 125]  # algo está mal aquí
4 ** 3  # el cubo de 4 es 64, no 65!
```
```text
64
```
```python
cubes[3] = 64  # reemplaza el valor incorrecto
cubes
```
```text
[1, 8, 27, 64, 125]
```

Puedes agregar nuevos elementos al final de la lista utilizando el método `append()` o la concatenación de listas.

```python
squares = [1, 4, 9, 16, 25]
squares.append(6**2)
squares
```
```text
[1, 4, 9, 16, 25, 36]
```
  
Descubre muchos otros métodos de lista útiles en <a href="https://docs.python.org/3/tutorial/datastructures.html#more-on-lists">esta página</a>.

Para información más estructurada y detallada, también puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6031?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Reemplaza `"dino"` por `"dinosaurio"` en la lista `animals`.  
<div class='hint'>Usa la operación de indexación de listas y la asignación de valores.</div>