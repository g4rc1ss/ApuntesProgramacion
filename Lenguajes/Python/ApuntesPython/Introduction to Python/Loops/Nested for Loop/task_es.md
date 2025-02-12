## Bucles Anidados

Un bucle anidado es un bucle dentro de otro bucle.
El bucle interno se ejecuta una vez por cada iteración del bucle externo.

```python
adjetivos = ["negro", "elegante", "caro"]
ropa = ["chaqueta", "camisa", "botas"]

for x in adjetivos:
  for y in ropa:
    print(x, y)
```
Salida:
```text
negro chaqueta
negro camisa
negro botas
elegante chaqueta
elegante camisa
elegante botas
caro chaqueta
caro camisa
caro botas
```
<details>

Tenga en cuenta que cualquier tipo de bucle puede anidarse dentro de otro bucle.
Por ejemplo, un bucle [`while`](course://Bucles/Bucle while) (ver más adelante) puede anidarse dentro de un bucle `for`, o viceversa.
</details>

Para obtener información más estructurada y detallada, puede consultar esta [página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6065#bucle-anidado?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Se te da un tablero de tic-tac-toe de 3x3, tu tarea es imprimir cada posición. Las coordenadas a lo largo de cada lado
se almacenan en la lista `coordenadas`. La salida debería ser:
```text
1 x 1
1 x 2
1 x 3
2 x 1
...
```
y así sucesivamente para cada combinación de coordenadas.

<div class="hint">

En el bucle `for` anidado, itera sobre la misma lista una vez más pero usando otro nombre de variable
esta vez (`coordenada2`).
</div>