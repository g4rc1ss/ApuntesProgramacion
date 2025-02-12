## El método join()

`.join()` es, de hecho, un método de cadena, pero lo estamos discutiendo ahora porque requiere comprensión de objetos iterables, como cadenas, listas y tuplas.
Este [método](https://docs.python.org/3/library/stdtypes.html#str.join) proporciona una forma flexible de crear cadenas a partir de objetos iterables. 
Une cada elemento de un iterable (como una lista, cadena o tupla) mediante un separador de cadena (una cadena en la que se llama al método `join()`) y devuelve una cadena concatenada. Se generará un `TypeError` si hay valores no string dentro del iterable. 

La sintaxis del método `join()` es la siguiente:

```python
cadena.join(iterable)
```

Ejemplos:

```python
cadena_ = 'abcde'  # un iterable de cadena
tupla_ = ('aa', 'bb', 'cc')  # un iterable de tupla
lista_ = ['Python', 'lenguaje de programación']  # un iterable de lista

print(' + '.join(cadena_))  # unir con el separador ' + '
print(' = '.join(tupla_))  # unir con el separador ' = '

sep = ' es un '
print(sep.join(lista_))  # unir con el separador ' es un '
```
```text
a + b + c + d + e
aa = bb = cc
Python es un lenguaje de programación
```

Para información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6972#join-a-list?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Asigne un valor a la variable `joined` de tal manera que la declaración `print` imprima lo siguiente:
```text
Me gustan las manzanas y me gustan las bananas y me gustan los melocotones y me gustan las uvas
```

<div class="hint">¡Observa los ejemplos atentamente y haz lo mismo!</div>
<div class="hint"><code>frutas</code> son tus iterables aquí, y <code>separador</code> es la cadena separadora.</div>