## Recursión

La palabra <b>recursión</b> proviene de la palabra latina <i>recurrere</i>, que significa volver, revertir o recurrir.
En programación, recursión se refiere a una técnica de codificación en la cual una función se llama a sí misma.

En la mayoría de los casos, la recursión no es necesaria, pero en algunas situaciones, 
la definición autorreferencial se justifica. Un buen ejemplo sería recorrer [estructuras de datos tipo árbol](https://en.wikipedia.org/wiki/Tree_(data_structure)). 
Dichas estructuras están [anidadas](course://Estructuras de datos/Listas anidadas), y se ajustan fácilmente a una definición recursiva. Un algoritmo no recursivo 
para la misma tarea sería bastante engorroso.

Aquí hay un simple ejemplo de una función recursiva. Toma un número como argumento 
e imprime los números desde el argumento especificado hasta cero. En la llamada recursiva, 
el argumento es uno menos que el valor actual de `n`, por lo que cada recursión se acerca
al caso base (que es cero).

```python
def cuenta_regresiva(n):
    print(n, end=' ')
    if n == 0:
        return             # Termina la recursión
    else:
        cuenta_regresiva(n - 1)   # Llamada recursiva


cuenta_regresiva(4)
```
```text
4 3 2 1 0 
```

<div class="hint">Esta función no comprueba la validez de su argumento: si <code>n</code> 
es no entero o negativo, obtendrías una excepción de <a href="https://docs.python.org/3/library/exceptions.html?highlight=recursionerror#RecursionError"><code>RecursionError</code></a> porque nunca se alcanza el caso base:

```python
cuenta_regresiva(-10)
```
```text
RecursionError: el límite máximo de recursión se ha superado al llamar un objeto Python
```
Se puede averiguar cuál el límite de recursión de Python con una función del módulo sys 
llamada [`getrecursionlimit()`](https://docs.python.org/3/library/sys.html#sys.getrecursionlimit), y se puede cambiar con [`setrecursionlimit()`](https://docs.python.org/3/library/sys.html#sys.setrecursionlimit):

```python
from sys import setrecursionlimit
setrecursionlimit(3000)
getrecursionlimit()
```
```text
3000
```
</div>

Ten en cuenta que la recursión no es útil en todas las situaciones. Para algunos problemas, una solución recursiva, aunque 
posible, será incómoda más que elegante. Las implementaciones recursivas a menudo consumen más 
memoria que las no recursivas y en algunos casos pueden dar lugar a una ejecución más lenta.

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/7665?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, implementa una función recursiva que calcule el [factorial](https://en.wikipedia.org/wiki/Factorial) de un número entero positivo.
Para 1 y 0 devuelve 1, para todos los demás números calcula el producto de este número (`n`) y
el factorial del número anterior (`n-1`).

<div class="hint">No olvides la llamada a la función recursiva.</div>
