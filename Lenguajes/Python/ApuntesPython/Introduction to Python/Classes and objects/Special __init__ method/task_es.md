## Método especial &#95;&#95;init&#95;&#95;

La operación de instanciación ("llamando" a un objeto de clase) crea un objeto vacío,
pero es útil para crear objetos con instancias personalizadas a un estado inicial específico.
Por lo tanto, una clase puede definir un método especial llamado `__init__()` de la siguiente manera:

```python
class MiClase:
    def __init__(self):
        self.data = []
```
`__init__` es uno de los métodos reservados en Python. Si se define, el método `__init__()` 
se invoca automáticamente cuando se crea una instancia de la clase,
e inicializa el objeto y sus atributos. Siempre toma al menos 
un argumento, `self`. Entonces, en nuestro ejemplo,
se puede obtener una nueva instancia inicializada así:

```python
x = MiClase()
```
El método `__init__()` puede recibir argumentos para mayor flexibilidad.
En ese caso, los argumentos dados al operador de instanciación de la clase se pasan
a `__init__()`. Por ejemplo:
```python
class Complejo:
    def __init__(self, parte_real, parte_imaginaria):
        self.r = parte_real
        self.i = parte_imaginaria
        self.num = complex(self.r, self.i)

x = Complejo(3.0, -4.5)  # Instanciando un número complejo
x.num
```
```text
(3-4.5j)
```

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6669#def-__init?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, añade parámetros al método `__init__()` de la clase `Car`, para que podamos
crearlo con un color y marca especificados.

<div class='hint'>Añade tres parámetros &mdash; <code>self</code>, <code>color</code> y <code>marca</code>.</div>