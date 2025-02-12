## Introducción a las listas

Python tiene varios tipos de datos compuestos utilizados para agrupar datos.
El más versátil es la lista, que puede escribirse como una serie de valores separados por comas (elementos) encerrados en corchetes, por ejemplo, `lst = [item1, item2]`.
Las listas pueden contener elementos de diferentes tipos, pero generalmente todos los elementos de una lista son del mismo tipo. Al igual que las cadenas, las listas pueden ser indexadas y segmentadas (ver [Lección 3](course://Strings/String slicing)).
Todas las operaciones de segmentación devuelven una nueva lista que contiene los elementos solicitados.

Las listas también admiten operaciones como la concatenación:

```python
squares = [1, 4, 9, 16, 25]
squares + [36, 49, 64, 81, 100]
[1, 4, 9, 16, 25, 36, 49, 64, 81, 100]
```

Puedes explorar las listas con más detalle leyendo <a href="https://docs.python.org/3.9/tutorial/introduction.html#lists">esta página</a>.

Para obtener información más estructurada y detallada, también puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/5979?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Utiliza el segmento de listas para imprimir `[4, 9, 16]`.  

<div class='hint'>La sintaxis de segmentación de lista es similar a la utilizada para las cadenas: <code>lst[index1:index2]</code>.
¡No olvides que el elemento con el índice <code>index2</code> no está incluido!</div>