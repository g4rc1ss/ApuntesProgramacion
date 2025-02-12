## Else con bucles 2

Este tipo de `else` es útil solo si hay una condición `if` presente dentro del bucle, que de alguna manera depende de la variable del bucle.
Veamos una vez más el ejemplo de la tarea anterior:

```python
for n in range(2, 10):
    for x in range(2, n):
        if n % x == 0:
            print(n, 'es igual a', x, '*', n//x)
            break
    else:
        # el bucle terminó sin encontrar un factor
        print(n, 'es un número primo')
```

La declaración `else` solo se ejecutará si `n` es un número primo, es decir, la declaración `if` no ha sido ejecutada para ninguna iteración del
bucle `for` interno.

### Tarea
Dentro de la [función](course://Bucles/Else con bucles 2) `contiene_numero_par()`, escribe un bucle `for` que iteraría sobre una lista `lst` y, si se encuentra un elemento par,
imprime `f"La lista {lst} contiene un número par."` y sale del bucle, si no se encuentra tal elemento, imprime `f"La lista {lst} no contiene un número par."`. 

<div class="hint">

Puedes usar `if i % 2 == 0:` para comprobar si un número dado es par.
</div>

<div class="hint">

Utiliza la declaración `break` para salir del bucle si se encuentra un número par.
</div>

<div class="hint">

Utiliza una cláusula `else` para imprimir `f"La lista {lst} no contiene un número par."`.
</div>