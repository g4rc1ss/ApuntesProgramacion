Los decoradores son una forma de modificar o extender el comportamiento de una función o clase sin modificar su implementación original. Los decoradores se definen utilizando la sintaxis del signo `@` seguido del nombre del decorador y se colocan encima de la función o clase a la que se desea aplicar. Los decoradores son funciones que toman otra función como argumento y devuelven una nueva función o clase modificada

## Decoradores de funciones:
Los decoradores de funciones se aplican a funciones individuales y pueden modificar su comportamiento, agregar funcionalidades adicionales o envolver la función original en una nueva lógica. Aquí tienes un ejemplo básico:

```python
def decorador(funcion):
    def funcion_modificada():
        print("Antes de llamar a la función.")
        funcion()
        print("Después de llamar a la función.")
    return funcion_modificada

@decorador
def saludar():
    print("Hola, ¡bienvenido!")

# Llamar a la función decorada
saludar()
```

En este ejemplo, hemos definido un decorador llamado `decorador()`, que toma una función como argumento y devuelve una nueva función modificada. Utilizamos el decorador `@decorador` encima de la función `saludar()`, lo que implica que queremos aplicar el decorador a esa función. Cuando llamamos a `saludar()`, en realidad estamos llamando a la función modificada `funcion_modificada()`, que envuelve la función original y agrega mensajes antes y después de llamar a la función.

## Decoradores de clases:
Los decoradores también se pueden aplicar a clases, lo que permite modificar el comportamiento o agregar funcionalidades a una clase. Aquí tienes un ejemplo:

```python
def decorador(clase):
    class ClaseModificada:
        def __init__(self, *args, **kwargs):
            self.instancia = clase(*args, **kwargs)
        
        def metodo_modificado(self):
            print("Antes de llamar al método.")
            self.instancia.metodo()
            print("Después de llamar al método.")
    
    return ClaseModificada

@decorador
class MiClase:
    def metodo(self):
        print("¡Hola desde el método original!")

# Crear una instancia de la clase decorada
objeto = MiClase()
objeto.metodo_modificado()
```

En este ejemplo, hemos definido un decorador llamado `decorador()`, que toma una clase como argumento y devuelve una nueva clase modificada. Utilizamos el decorador `@decorador` encima de la clase `MiClase`, lo que implica que queremos aplicar el decorador a esa clase. Al crear una instancia de `MiClase` y llamar al método `metodo_modificado()`, en realidad estamos llamando al método modificado `metodo_modificado()` en la clase modificada `ClaseModificada`, que envuelve la clase original y agrega mensajes antes y después de llamar al método.
