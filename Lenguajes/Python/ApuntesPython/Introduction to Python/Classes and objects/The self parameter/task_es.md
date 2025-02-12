## El parámetro self

Es hora de explicar el parámetro `self` que vimos en tareas anteriores.
El primer argumento pasado a un método de clase es `self`. Esto no es más 
que una convención: el nombre `self` no tiene ningún significado especial para Python. 
Se aconseja seguir la convención, de lo contrario, su código puede ser menos legible 
para otros programadores de Python.

Python utilizará el parámetro `self` para referirse al objeto que se crea o se modifica.
Los métodos pueden llamar a otros métodos utilizando los atributos del método del argumento `self`:

```python
class Bolsa:
    def __init__(self):
        self.data = []

    def add(self, x):
        self.data.append(x)

    def addtwice(self, x):
        self.add(x)  # Llamando al método `add` desde otro método
        self.add(x)
```
  
Para obtener información más estructurada y detallada, puede consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6669#self?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, implementa el método `add` de la clase `Calculator`. Debería 
añadir `amount` al campo `current`. Además, completa el método `get_current`.
Ejecuta el código para ver cómo funciona.

<div class='hint'>Agrega <code>amount</code> a la variable <code>self.current</code>.</div>
<div class="hint">Usa el signo <code>+=</code>.</div>