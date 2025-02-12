## Clase y Variables de Instancia

En general, las variables de instancia son para datos únicos de cada instancia,
y las variables de clase son para atributos y métodos compartidos por todas las instancias de la clase:

```python
class Cat:

    species = "Felis catus"  
    
    def __init__(self, breed, name):
        self.breed = breed  
        self.name = name

cleo = Cat('mix', 'Cleo')
furry = Cat('bengal', 'Furry')

print(cleo.name)
print(cleo.species)
print(furry.name)
print(furry.species)
```

```text
Cleo
Felis catus
Furry
Felis catus
```
Puede ver que `species` es una variable de clase compartida por todas las instancias, mientras
`name` y `breed` son variables de instancia únicas para cada instancia.

Los datos compartidos pueden tener efectos posiblemente sorprendentes cuando involucran objetos mutables,
como listas y diccionarios. Si una variable de clase es una lista y la modificas para
un objeto, se cambiará para todos los objetos de la clase (revisa el ejemplo en el código
editor, mira lo que imprimirá `print(barsik.favorite_food)`). Si tienes la intención de usar una lista para llevar un registro
de características únicas para cada instancia, necesitas hacerlo un atributo de instancia.

Para información más estructurada y detallada, puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6677?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, completa la implementación de la clase `Animals` para que la declaración `print`
a continuación imprima una línea como esta: `"Este es Doggy el perro, una de mis mascotas."` para cada una de las mascotas.

<div class="hint">La variable de clase debe contener información compartida entre todas las instancias (es una de las <code>"mascotas"</code>).</div>
<div class="hint">Las variables de instancia deben contener información única para las instancias (el nombre es único).</div>