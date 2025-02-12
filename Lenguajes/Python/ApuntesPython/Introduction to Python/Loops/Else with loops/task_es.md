## Else con bucles

Vimos que la instrucción `break` sale del bucle `for` o `while` que la contiene más internamente.

Python también permite que las instrucciones de bucle tengan una cláusula `else`. Se ejecuta cuando el bucle termina
por agotamiento del iterable (con `for`) o cuando la condición se convierte en `False`
(con `while`), pero no cuando el bucle es terminado por una instrucción `break`. Mira
este ejemplo de un bucle que busca números primos:

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
```text
2 es un número primo
3 es un número primo
4 es igual a 2 * 2
5 es un número primo
6 es igual a 2 * 3
7 es un número primo
8 es igual a 2 * 4
9 es igual a 3 * 3
```
En este código, la cláusula `else` pertenece al bucle `for`, no a la
instrucción `if`.

Recuerda, un `else` después de una instrucción `if` se omite y NO se ejecuta si la expresión que sigue a 
`if` es `True`, mientras que en el caso de los bucles, una cláusula `else` se ejecuta después de que el propio bucle
se completa (a menos que hubiera un `break` en algún lugar).

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6302?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, añade dos líneas de código al segundo bucle para asegurarte de que el bucle solo imprima
los números 1 y 2 y nunca imprima la frase `"el bucle for ha terminado"`.

<div class="hint">Debe terminar en el número 3.</div>