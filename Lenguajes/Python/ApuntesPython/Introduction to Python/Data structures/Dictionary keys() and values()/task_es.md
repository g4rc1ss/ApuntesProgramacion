## Claves de diccionario keys() y valores values()

Hay muchos métodos útiles en los diccionarios, como `keys()`, `values()` e `items()`.
El método `keys()` devuelve un objeto de vista que muestra una lista de todas las claves en el diccionario en orden de inserción.
`values()` devuelve una nueva vista de los valores del diccionario. Cuando se llama al método `items()`,
devuelve una nueva vista de los ítems del diccionario como tuplas en una lista (pares `(clave, valor)`).

Los objetos devueltos por `dict.keys()`, `dict.values()` y `dict.items()` proporcionan una
vista dinámica de las entradas del diccionario, lo que significa
que cuando el diccionario cambia, la vista refleja estos cambios.

Puedes explorar el resto utilizando &shortcut:CodeCompletion; después de `nombre_dict`
seguido de un punto.

Lee más sobre las operaciones que soportan los diccionarios <a href="https://docs.python.org/3/library/stdtypes.html#typesmapping">aquí</a>.

Para obtener información más estructurada y detallada, también puedes consultar [esta página de la base de conocimiento de Hyperskill](https://hyperskill.org/learn/step/11096?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Imprime todos los valores del `phone_book`.  

<div class='hint'>Usa el método <code>values()</code>.</div>