## Indexación de cadenas

Puedes acceder a un carácter en una cadena si conoces su posición. Por ejemplo,
`str[indice]` producirá el carácter en la posición `indice` en la cadena `str`.
Ten en cuenta que la indexación de cadenas siempre comienza en `0`. `indice` produce un `ValueError` 
cuando `x` no se encuentra en la cadena.

Los índices también pueden ser números negativos si necesitas comenzar a contar desde la derecha 
(es decir, desde el final de tu cadena).
Ten en cuenta que dado que `-0` es lo mismo que `0`, los índices negativos comienzan desde `-1`.

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6189?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Usa el operador de índice para obtener la letra `"P"` de `"Python"`.

<div class="hint">Ten en cuenta que los índices comienzan con 0.</div>