## Comprensión de Listas

Puedes usar un bucle para construir una lista (u otra estructura de datos).
Por ejemplo:

```python
mi_lista = []
for i in range(5):
    mi_lista.append(i)

print(mi_lista)
```
Salida:
```texto
[0, 1, 2, 3, 4]
```

Esto es útil, pero bastante voluminoso. La comprensión de listas ofrece una sintaxis más compacta cuando quieres crear una nueva lista basada en los valores de una lista existente
o otro iterable (tupla, cadena, matriz, rango, etc.). Realiza la misma tarea y simplifica el programa. Típicamente, las comprensiones de listas se escriben en una sola línea de código.

```python
mi_lista = [i for i in range(5)]
print(mi_lista)
```
Salida:
```texto
[0, 1, 2, 3, 4]
```
Las comprensiones de listas también son más eficientes computacionalmente que un bucle `for`.

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6315?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, usa la comprensión de listas para construir `mi_lista_eficiente` a partir de los elementos de `mi_lista_ineficiente`
añadiendo $10$ a cada uno de ellos. Por ejemplo, el primer elemento de `mi_lista_ineficiente` es $1 + 10 = 11$,
entonces el primer elemento de `mi_lista_eficiente` debería ser $11 + 10 = 21$, y así sucesivamente.


<div class="pista">

En el ejemplo anterior, utilizamos `i para i en rango(5)`. Puedes modificar `i` como quieras 
directamente dentro de esta expresión. Por ejemplo, para restar `5` de cada `i`, puedes hacer 
`i - 5 para i en rango(5)`.
</div>