## Escapar caracteres

La barra invertida se utiliza para escapar símbolos especiales, como las comillas simples o dobles, 
por ejemplo, `"It\'s me"` o `"She said \"Hello\""`. Si necesitas escribir el carácter <code>\\</code>
como parte de tu cadena, también tendrás que escaparlo. Por ejemplo, aquí te mostramos cómo 
puedes imprimir una sola barra invertida:

```python
print('\\')
```

El símbolo especial `'\n'` se utiliza para añadir un salto de línea a una cadena, mientras que `'\t'` significa tabulación.

Las comillas tienen significados especiales y también pueden ser escapadas con una barra invertida. 
Si necesitas imprimir comillas dentro de una cadena, utiliza un tipo diferente de comillas: las comillas simples 
pueden ser utilizadas en una cadena con comillas dobles sin necesidad de escaparlas, y viceversa. Además, como nota al margen, 
es una buena idea elegir tu tipo de comillas favorito y utilizarlo de manera consistente.

Puedes aprender más sobre cómo escapar caracteres desde <a href="https://docs.python.org/3/reference/lexical_analysis.html#string-and-bytes-literals">esta sección</a> de la documentación de Python.

Para obtener información más estructurada y detallada, también puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/7130?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Imprime el siguiente texto usando una sola cadena:  
```text
The name of this ice cream is "Sweet'n'Tasty"  
```

<div class='hint'>Usa la barra invertida para escapar las comillas.</div>