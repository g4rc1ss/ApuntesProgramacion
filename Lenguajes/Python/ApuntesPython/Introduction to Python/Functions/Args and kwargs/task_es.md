## Args y kwargs

Cuando un parámetro formal final en la forma `**nombre` está presente, este recibe un diccionario (ver [Estructuras de Datos — Diccionarios](course://Estructuras de Datos/Diccionarios)) que contiene todos los argumentos clave excepto aquellos que corresponden a un parámetro formal. Esto puede combinarse con un parámetro formal en la forma `*nombre` que recibe una tupla conteniendo cualquier número de argumentos posicionales más allá de la lista de parámetros formales (`*nombre` debe ocurrir antes de `**nombre`). Por ejemplo, si definimos una función como la que se encuentra en el editor de código, podría ser llamada como se muestra en la llamada 1, lo que imprimiría:
```text
-- ¿Sabes cómo llegar a la Biblioteca?
-- Lo siento, no soy de aquí, no tengo idea sobre la Biblioteca
¿Al menos tienes un cigarro, señor?
Claro, sírvete.
----------------------------------------
persona_perdida : viejo banquero
otro_tipo : payaso callejero
escena : en un parque
```
Esta función puede ser llamada con un número arbitrario de argumentos. Estos argumentos serán agrupados en una tupla o en una lista (ver [Tuplas](course://Estructuras de Datos/Tuplas), [Listas](course://Estructura de Datos/Introducción a Listas)). Antes del número variable de argumentos, pueden aparecer cero o más argumentos normales; en nuestro caso hay uno - `lugar`. Cualquier parámetro formal que ocurra después del parámetro `*args` son argumentos [‘solo-palabra clave’](https://peps.python.org/pep-3102/), lo que significa que solo pueden ser usados como palabras clave en lugar de argumentos posicionales. Otra forma de llamar a esta función se muestra en la llamada 2 y nos dará la misma salida.

Para información más estructurada y detallada, puedes referirte a [esta](https://hyperskill.org/learn/step/8560?utm_source=jba&utm_medium=jba_courses_links) y [esta](https://hyperskill.org/learn/step/9544?utm_source=jba&utm_medium=jba_courses_links) páginas de la base de conocimiento de Hyperskill.

### Tarea

En el editor de código, modifica el código debajo de la función `cat()` para que imprima lo siguiente:
```text
-- Este gato comería si le dieras cualquier cosa
-- Hermoso pelaje, el Maine Coon
-- ¡Está gordo!
ESTÁ DEMASIDADO GORDO.
ESTÁS ALIMENTANDO DEMASIADO A TU GATO.
```
<div class="hint">Recuerda desempaquetar argumentos posicionales adicionales con <code>*</code>.</div>

<div class="hint">Recuerda desempaquetar argumentos clave con <code>**</code>.</div>

<div class="hint">No olvides proporcionar el valor para el parámetro formal <code>comida</code>.</div>
