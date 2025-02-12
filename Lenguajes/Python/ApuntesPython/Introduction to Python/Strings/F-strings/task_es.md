## Cadenas de texto con formato

Una cadena de texto con formato, o una f-string, es una cadena literal que está precedida
por 'f' o 'F'. Estas cadenas pueden contener campos de reemplazo, los cuales son
expresiones delimitadas por llaves `{}`. 

Las partes de la cadena fuera de las llaves se tratan literalmente. 
Las secuencias de escape se decodifican como en las cadenas de texto ordinarias.
Las expresiones de reemplazo pueden contener saltos de línea (por ejemplo, en cadenas de texto con triple comilla), 
pero no pueden contener comentarios. Cada expresión se evalúa en el contexto 
en el que aparece la cadena de texto con formato, en orden de izquierda a derecha.

Aquí hay algunos ejemplos:
```python
name = "Fred"
f"Dijo que su nombre es {name}."
```
```text
'Dijo que su nombre es Fred.'
```

Hay más cosas interesantes que puedes hacer con las f-strings, por ejemplo:
```python
f"{name.lower()} es divertido."
```

```text
'fred es divertido.'
```
Para más información acerca de las cadenas de texto con formato puedes consultar en <a href="https://docs.python.org/3/reference/lexical_analysis.html#formatted-string-literals">Python Docs</a>.

Para una información más estructurada y detallada, también puedes consultar [esta página de la base de conocimiento de Hyperskill](https://hyperskill.org/learn/step/6037?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Intenta crear una f-string por ti mismo. También intenta ejecutar el código para ver qué imprime.

<div class="hint">El valor asignado a la variable <code>name</code> debe ser una cadena de texto, por lo que debe estar entre comillas,
así: <code>'Max'</code>.</div>