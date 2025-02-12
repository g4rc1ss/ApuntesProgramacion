## de import

Una forma de la sentencia import importa nombres `desde` un módulo directamente. De esta manera, puedes 
usar el nombre importado sin el prefijo `nombre_del_modulo`. Por ejemplo:

```python
from calculadora import Add

calc = Add()    # nombre `Add` usado directamente sin el prefijo `calculadora`
```
Esto no introduce el nombre del módulo del cual se toman las importaciones en la 
tabla de símbolos local (entonces en nuestro ejemplo, `calculator` no está definida).

Incluso existe una opción para importar todos los nombres que un módulo define:
```python
from calculadora import *
calc = Multiply()
```
Esto importa todos los nombres excepto aquellos que comienzan con un guion bajo `_`. 
En la mayoría de los casos, los programadores de Python no usan esto, ya que introduce 
un conjunto desconocido de nombres en el intérprete, posiblemente ocultando algunas cosas 
que ya has definido.

Si el nombre del módulo es seguido por `as`, entonces el nombre siguiente a `as` está vinculado
directamente al módulo importado:

```python
import mi_modulo as mm
mm.hello_world()
```
Esto es esencialmente importar el módulo de la misma manera que `import my_module` lo hará, 
con la única diferencia de que estará disponible como `mm`. También se puede usar
cuando se utiliza `from` con efectos similares:

```python
from calculadora import Subtract as Minus
```

Para información más estructurada y detallada, puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6019#module-loading?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Importa la clase `Calculator` desde `calculator` y crea una instancia de esta clase. Recuerda cómo acceder correctamente en
este caso.


<div class="hint">Nota: La clase <code>Calculator</code> debe ser llamada sin un prefijo porque
la importaste directamente.</div>