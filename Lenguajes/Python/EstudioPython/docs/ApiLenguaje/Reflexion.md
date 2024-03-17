La reflexión (reflection) se refiere a la capacidad de un programa para examinar, modificar y obtener información sobre su propia estructura y objetos en tiempo de ejecución. Python proporciona varias funciones y métodos para realizar tareas de reflexión, lo que permite a los desarrolladores escribir código más dinámico y flexible.

## Obtener información sobre objetos:
Puedes utilizar las funciones `type()` y `dir()` para obtener información sobre un objeto, como su tipo y sus atributos. Aquí tienes un ejemplo:

```python
class Persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad

p = Persona("Juan", 30)

print(type(p))  # Imprime <class '__main__.Persona'>
print(dir(p))  # Imprime una lista de atributos y métodos del objeto
```

En este ejemplo, hemos creado una clase `Persona` con atributos `nombre` y `edad`. Luego, creamos una instancia de `Persona` llamada `p`. Utilizamos `type()` para obtener el tipo de `p`, que es `Persona`. Luego, utilizamos `dir()` para obtener una lista de atributos y métodos disponibles en `p`.

## Acceder a atributos y métodos dinámicamente:
Puedes utilizar la función `getattr()` para acceder a atributos y métodos de un objeto utilizando su nombre en forma de cadena. Aquí tienes un ejemplo:

```python
class Persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad

    def saludar(self):
        print(f"Hola, mi nombre es {self.nombre}.")

p = Persona("Juan", 30)

nombre = getattr(p, "nombre")
print(nombre)  # Imprime "Juan"

saludar_metodo = getattr(p, "saludar")
saludar_metodo()  # Imprime "Hola, mi nombre es Juan."
```

En este ejemplo, utilizamos `getattr()` para acceder al atributo `nombre` y almacenarlo en la variable `nombre`. Luego, utilizamos `getattr()` para acceder al método `saludar` y almacenarlo en la variable `saludar_metodo`. Finalmente, llamamos a `saludar_metodo()` para invocar el método `saludar()` en `p`.

## Modificar atributos y métodos dinámicamente:
Puedes utilizar las funciones `setattr()` y `delattr()` para modificar o eliminar atributos de un objeto en tiempo de ejecución. Aquí tienes un ejemplo:

```python
class Persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad

p = Persona("Juan", 30)

setattr(p, "nombre", "Pedro")
print(p.nombre)  # Imprime "Pedro"

delattr(p, "edad")
print(p.edad)  # Genera un error: AttributeError: 'Persona' object has no attribute 'edad'
```

En este ejemplo, utilizamos `setattr()` para modificar el atributo `nombre` de `p` y cambiarlo a "Pedro". Luego, utilizamos `delattr()` para eliminar el atributo `edad` de `p`. Al intentar acceder a `p.edad` posteriormente, se genera un error ya que el atributo ha sido eliminado.
