Las propiedades son una forma de encapsular y controlar el acceso a los atributos de una clase. Las propiedades permiten definir métodos especiales llamados getters y setters, que se utilizan para obtener y asignar valores a los atributos, respectivamente. Las propiedades ofrecen una forma de controlar el acceso, validar los valores asignados y realizar acciones adicionales cuando se accede a los atributos.

1. Definir una propiedad en una clase:
Para definir una propiedad en una clase, utilizamos los decoradores `@property` y `@nombre_atributo.setter`. El decorador `@property` se coloca encima del método getter, y el decorador `@nombre_atributo.setter` se coloca encima del método setter correspondiente. Aquí tienes un ejemplo básico:

```python
class Persona:
    def __init__(self, nombre):
        self._nombre = nombre

    @property
    def nombre(self):
        return self._nombre

    @nombre.setter
    def nombre(self, nuevo_nombre):
        if len(nuevo_nombre) < 3:
            raise ValueError("El nombre debe tener al menos 3 caracteres.")
        self._nombre = nuevo_nombre

# Crear una instancia de la clase Persona
persona1 = Persona("Juan")

# Obtener el valor de la propiedad nombre
print(persona1.nombre)  # Imprime "Juan"

# Asignar un nuevo valor a la propiedad nombre
persona1.nombre = "Ana"

# Obtener el nuevo valor de la propiedad nombre
print(persona1.nombre)  # Imprime "Ana"

# Intentar asignar un valor inválido a la propiedad nombre
persona1.nombre = "Lu"  # Genera un ValueError
```

En este ejemplo, hemos definido una clase `Persona` con un atributo privado `_nombre`. Utilizamos el decorador `@property` encima del método `nombre()` para definir la propiedad de solo lectura. El método getter `nombre()` devuelve el valor del atributo `_nombre`. Luego, utilizamos el decorador `@nombre.setter` encima del método `nombre()` para definir el setter de la propiedad. El método setter `nombre()` valida que el nuevo nombre tenga al menos 3 caracteres antes de asignarlo al atributo `_nombre`.

2. Uso de propiedades con atributos calculados:
Las propiedades también se pueden utilizar para definir atributos calculados, que no se almacenan directamente en la instancia, sino que se calculan dinámicamente a partir de otros atributos.

```python
class Rectangulo:
    def __init__(self, ancho, altura):
        self._ancho = ancho
        self._altura = altura

    @property
    def area(self):
        return self._ancho * self._altura

    @property
    def perimetro(self):
        return 2 * (self._ancho + self._altura)

# Crear una instancia de la clase Rectangulo
rectangulo1 = Rectangulo(5, 3)

# Obtener el valor del atributo calculado area
print(rectangulo1.area)  # Imprime 15

# Obtener el valor del atributo calculado perimetro
print(rectangulo1.perimetro)  # Imprime 16
```

En este ejemplo, hemos definido una clase `Rectangulo` con atributos `_ancho` y `_altura`. Utilizamos las propiedades `area` y `perimetro` para definir atributos calculados que se calculan en función de los valores de `_ancho` y `_altura`. Los métodos getter correspondientes `area()` y `perimetro()` calculan y devuelven los valores respectivos.
