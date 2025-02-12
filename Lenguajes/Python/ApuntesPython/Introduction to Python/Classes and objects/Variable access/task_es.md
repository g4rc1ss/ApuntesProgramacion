## Acceso a variables

Puedes usar referencias de atributos para acceder a variables dentro de un objeto.
Las referencias de atributos utilizan la sintaxis estándar para todas las referencias de atributos
en Python: `obj.name`. Los nombres de atributos válidos son todos los nombres que estaban en 
el espacio de nombres de la clase cuando se creó el objeto de la clase. Por lo tanto, si la definición de la clase se veía así:

```python
class MyClass:
    year = 2021

    def say_hello(self):
        return 'hello world'
```
entonces `MyClass.year` y `MyClass.say_hello` son referencias de atributos válidas que devuelven un 
entero y un objeto de función, respectivamente. Se pueden asignar atributos de clase, por lo que puedes cambiar el valor de `MyClass.year` mediante asignación.

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6661#class-attribute?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Revisa nuestro ejemplo e imprime el valor de `variable1` desde `my_object`.
Llama al método `foo` del objeto `my_object`, imprime el resultado.

<div class='hint'>Accede a <code>variable1</code> usando la sintaxis <code>object.name</code>.</div>