## Definición

Las funciones son una forma conveniente de dividir tu código en bloques útiles, hacerlo más
legible, y reutilizarlo.
La palabra clave `def` introduce una definición de función.
Debe ser seguida por el nombre de la función y la lista de paréntesis de **parámetros formales** (que puede estar vacía).
Las declaraciones que forman el cuerpo de la función comienzan en la siguiente línea y deben estar indentadas.

<details>
Los parámetros formales están encerrados en paréntesis; son las variables definidas por la función, que reciben valores cuando la función es llamada. La lista consta de nombres de variables de todos los valores necesarios para el método. Cada parámetro formal está separado por una coma. Cuando el método no acepta ninguna entrada de valores, deberá tener un conjunto vacío de paréntesis después del nombre del método, por ejemplo, <code>suma()</code>.
</details>

Las funciones solo se ejecutan cuando son llamadas. Para llamar a una función, usa su nombre seguido de paréntesis:

```python
def mi_funcion():  # definición de función
  print("Hola desde una función")

mi_funcion()  # llamada a la función
```

Lee más sobre la definición de funciones en <a href="https://docs.python.org/3/tutorial/controlflow.html#defining-functions">esta sección</a> de la Documentación de Python.

Para información más estructurada y detallada, también puedes referirte a [esta página de base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/5900?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
 - Llama a la función `mi_funcion` dentro del bucle para repetir su invocación 5 veces
 - Define una función que pueda reemplazar las declaraciones `print` duplicadas en el archivo.  

<div class='hint'>Usa los <code>()</code> para llamar a la función <code>mi_funcion</code>.</div>
<div class='hint'>Usa la palabra clave <code>def</code> para definir la función <code>fun</code>.</div>
