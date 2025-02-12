## Segmentación

La segmentación se utiliza para extraer múltiples caracteres (una subcadena) de una cadena.
Su sintaxis es similar a la de la indexación, pero en lugar de utilizar un solo índice, se utilizan
dos índices (números) separados por dos puntos, p. Ej., `str[ind1:ind2]`. Estos dos 
índices corresponden al inicio y al final de la subcadena. Ten en cuenta que el símbolo 
con el índice `ind1` será incluido, mientras que el símbolo con el índice `ind2` - no se incluirá. 

Aquí tienes una visualización de cómo funciona la segmentación en Python:

```text
+---+---+---+---+---+---+
| P | y | t | h | o | n |
+---+---+---+---+---+---+
0   1   2   3   4   5   6
-6  -5  -4  -3  -2  -1
```

##### Ejemplo
<pre><code>
str[start:end] # elementos desde inicio hasta fin-1
str[start:]    # elementos desde inicio hasta el resto de la matriz
str[:end]      # elementos desde el principio hasta fin-1
str[:]         # una copia de toda la matriz
</code></pre>

Para obtener más información estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6177?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Utiliza la segmentación para obtener `"Python"` de la variable `monty_python`.

<div class='hint'>Puedes dejar uno de los índices vacío.</div>