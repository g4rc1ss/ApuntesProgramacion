## Comprensión de Listas Anidadas

Las comprensiones de listas anidadas son simplemente comprensiones de listas anidadas dentro de otras
comprensiones de listas. Esto es bastante similar a los [bucles anidados](curso://Loops/Bucle for anidado).
Aquí hay un programa que crea una [lista anidada](curso://Estructuras de datos/Listas Anidadas) usando un bucle anidado:

```python
matrix = []

for i in range(3):

    # Añade una sublista vacía dentro de la lista
    matrix.append([])

    for j in range(0, 10, 2):
        matrix[i].append(j)

print(matrix)
```
Salida:
```texto
[[0, 2, 4, 6, 8], [0, 2, 4, 6, 8], [0, 2, 4, 6, 8]]
```

Lo mismo se puede hacer en una sola línea utilizando la comprensión de listas anidadas:

```python
matrix = [[j for j in range(0, 10, 2)] for i in range(3)]
print(matrix)
```
Salida:
```texto
[[0, 2, 4, 6, 8], [0, 2, 4, 6, 8], [0, 2, 4, 6, 8]]
```

Para obtener información más estructurada y detallada, puede consultar [esta página del base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6938#comprension-de-listas-anidadas?utm_source=jba&utm_medium=links_del_curso_jba).

### Tarea

Crea una `matriz` de $10×10$ de tal manera que cada fila (sublista) contenga los **caracteres** del 0–9 de
`cadena`. Use comprensión de listas para completar la tarea en una línea de código.

<div class="hint">

Sigue el ejemplo en la descripción de la tarea. Simplemente necesitas usar `cadena` como iterable en lugar
de uno de los rangos.

</div>