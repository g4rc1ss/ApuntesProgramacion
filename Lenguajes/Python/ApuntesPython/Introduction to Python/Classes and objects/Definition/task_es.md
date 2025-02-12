## Definición

Las clases proporcionan un medio para agrupar datos y funcionalidad juntos. Crear una nueva
clase crea un nuevo tipo de objeto, permitiendo hacer nuevas instancias de ese tipo.
Las clases son esencialmente plantillas para crear objetos.
Cada instancia de la clase (objeto) puede tener atributos adjuntos a ella para mantener su estado.
Las funciones de los objetos se llaman métodos, y pueden modificar su estado. Los métodos son
definidos por la clase del objeto.

La forma generalizada de la definición de clase se ve así:

```
class NombreClase:
    <declaración-1>
    .
    .
    .
    <declaración-N>
```
Las definiciones de clase, al igual que las definiciones funcionales (`def` declaraciones) deben ser ejecutadas antes
de que tengan algún efecto.

Las declaraciones dentro de una definición de clase generalmente serán definiciones de funciones, 
pero a veces otras declaraciones son útiles. Las definiciones de funciones dentro de una 
clase suelen tener una forma peculiar de lista de argumentos, esto se explicará más adelante.

Los objetos de clase admiten dos tipos de operaciones: referencias de atributo e instanciación.
Las referencias de atributo se discutirán en las siguientes secciones. La instanciación de clase utiliza 
notación funcional. Simplemente imagina que el objeto de clase es una función sin parámetros que 
devuelve una nueva instancia de la clase. Por ejemplo:

```python
class AlgunaClase:
    """Un sencillo ejemplo de clase"""
    i = 12345

x = AlgunaClase()
```

`x = AlgunaClase()` crea una nueva instancia de la clase y asigna este objeto a la variable local `x`.

Puedes encontrar más información sobre la sintaxis de definición de clase en <a href="https://docs.python.org/3/tutorial/classes.html#class-definition-syntax">esta sección</a>
de la documentación de Python.

Para obtener información más estructurada y detallada, también puedes consultar [esta página de base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6661?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Asigna un valor a la `variable` dentro de `MyClass` y crea un objeto `my_object` de la clase `MyClass()`. 
Ejecuta el código y ve qué sucede!

<div class='hint'>Asigna cualquier valor a <code>variable</code>.</div>

<div class='hint'>Mira el ejemplo en el texto para descubrir cómo instanciar un objeto.</div>