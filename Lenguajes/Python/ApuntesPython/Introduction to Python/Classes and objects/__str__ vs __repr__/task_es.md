## Métodos \_\_str__ vs \_\_repr__

Ambos métodos `str()` y `repr()` en Python se utilizan para la representación de cadenas de un objeto, pero existen algunas diferencias.
Por ejemplo:
```python
s = 'Hola Mundo'
print (str(s))
print(repr(s))
```
```text
Hola Mundo
'Hola Mundo'
```
Puedes ver que si imprimimos una cadena usando la función `repr()`, entonces se imprime con un par de comillas. `str()` se usa para crear una salida para el usuario, mientras que `repr()` normalmente se usa para depuración y desarrollo. `repr()` necesita ser inequívoco, y `str()` &mdash; ser legible.

Al igual que `__init__`, los métodos `__repr__` y `__str__` están reservados en Python. El enunciado `print()` y la función incorporada `str()` utilizan el método `__str__` definido en la clase del objeto para mostrar su representación de cadena. La función incorporada `repr()` utiliza el método `__repr__` definido en la clase del objeto. 

Nuestra propia clase definida debería tener un `__repr__` si necesitamos información detallada para la depuración. Además, si pensamos que sería útil tener una representación de cadena para los usuarios, deberíamos crear una función `__str__`. Echa un vistazo a otra implementación de la clase `Complex` en el editor de código. Ejecuta el código para ver lo que imprime cada uno de los dos enunciados `print`.

Para obtener información más estructurada y detallada, puedes referirte a [esta página del base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/7139#str__-vs-__repr?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Implementa los métodos `__str__` y `__repr__` para la clase `Cat`. El método `__str__` debería devolver una cadena como esta: `"Mi gato siamés se llama Lucy"`; El método `__repr__` debería devolver una cadena como esta: `"Gato, raza: siamés, nombre: Lucy"`. Usa [f-strings](course://Strings/F-strings).

<div class="hint">No olvides usar la sintaxis <code>self.attribute</code>.</div>
<div class="hint"> No olvides usar la escapatoria de caracteres para imprimir el apóstrofe.</div>