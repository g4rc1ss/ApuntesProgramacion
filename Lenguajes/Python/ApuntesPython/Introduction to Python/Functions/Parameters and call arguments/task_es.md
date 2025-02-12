## Parámetros y argumentos de llamada

Los parámetros de función se definen dentro de los paréntesis `()` que siguen al nombre de la función. Un parámetro actúa como un nombre de variable para un argumento que se pasa a la función.

Los términos parámetro y argumento se refieren a lo mismo: información que se pasa a una función. Sin embargo, un parámetro es la variable que se enumera dentro de los paréntesis en la definición de la función, mientras que un argumento es el valor que se envía a la función cuando se llama.

Por defecto, una función debe ser llamada con el número correcto de argumentos. Si tu función espera 2 argumentos, tienes que llamarla con 2 argumentos:

```python
def mi_funcion(nombre, apellido):
    print(nombre + " " + apellido)

mi_funcion("Jon", "Snow")
```
Resultado:
```text
Jon Snow
```
Sin embargo, si la provees con solo un argumento durante la llamada:
```python
mi_funcion("Sam")
```
Se generará un `TypeError`:
```text
TypeError                                 Traceback (most recent call last)
<ipython-input-29-40eb74e4b26a> in <module>
----> 1 mi_funcion('Jon')

TypeError: mi_funcion() falta 1 argumento posicional requerido: 'apellido'
```
Para obtener información más estructurada y detallada, puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/7248?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, define una función que imprime el cuadrado de un parámetro pasado.

<div class='hint'>Añade el parámetro <code>x</code> dentro de los paréntesis en la definición de la función.</div>