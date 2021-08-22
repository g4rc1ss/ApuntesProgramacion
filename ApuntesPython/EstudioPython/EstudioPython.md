1. [Estructura del código](#estructura-del-código)

	 1. [Declaración de variables](#declaración-de-variables)

	 1. [Convertir tipos](#convertir-tipos)

	 1. [Sentencias de flujo](#sentencias-de-flujo)

	 1. [Operador ternario](#operador-ternario)

	 1. [Bucles](#bucles)

1. [Cadenas](#cadenas)

	 1. [String](#string)

		 1. [Literales](#literales)

		 1. [Interpolacion de Cadenas](#interpolacion-de-cadenas)

		 1. [Métodos de string](#métodos-de-string)

1. [Colecciones](#colecciones)

	 1. [Listas](#listas)

		 1. [Métodos de listas](#métodos-de-listas)

	 1. [Diccionarios](#diccionarios)

		 1. [Métodos de diccionarios](#métodos-de-diccionarios)

	 1. [Tuplas](#tuplas)

1. [Programación Orientada a Objetos](#programación-orientada-a-objetos)

	 1. [Class](#class)

	 1. [Abstract Class](#abstract-class)

	 1. [Metodos](#metodos)

	 1. [Metodos estaticos](#metodos-estaticos)

	 1. [Encapsulamiento](#encapsulamiento)

	 1. [Herencia](#herencia)

1. [Conceptos Avanzados](#conceptos-avanzados)

	 1. [Liberacion de Memoria](#liberacion-de-memoria)

	 1. [Enumerador](#enumerador)

	 1. [Codigo no Administrado](#codigo-no-administrado)

		 1. [Ctypes para cargar dll nativas](#ctypes-para-cargar-dll-nativas)

1. [Tratamiento de Excepciones](#tratamiento-de-excepciones)

	 1. [Excepciones](#excepciones)

		 1. [Capurando las excepciones](#capurando-las-excepciones)

		 1. [Provocando una excepcion](#provocando-una-excepcion)

		 1. [Creando excepciones propias](#creando-excepciones-propias)

1. [MultiThreading & Multiprocessing](#multithreading--multiprocessing)

	 1. [Multithreading](#multithreading)

		 1. [Thread](#thread)

		 1. [ThreadPoolExecutor](#threadpoolexecutor)

	 1. [Multiprocessing](#multiprocessing)

		 1. [ProcessPoolExecutor](#processpoolexecutor)

1. [Comprension de Listas](#comprension-de-listas)


# Estructura del código

```Python
from platform import system
import os as operativeSystem
from sys import exit as ex


if __name__ == "__main__":
    print(system())
    print(operativeSystem.name)
    ex(0)
    print("Se ha cerrado antes")
```
- `from` -> Se usa para indicar el paquete que queremos importar
- `import` -> Se usa para indicar el metodo, clase o paquete a importar.  
Si se usa con from se importaran clases o funciones, sino, se importaran paquetes.
- `as` -> Se usa para indicar un alias de la importacion que hacemos, se usa para que sea mas claro en el codigo, hay veces que las librerias no tienen nombres tan claros.
- ` __name__ == "__main__"` -> Como python es un lenguaje de script, no hay un metodo main como tal, igual que por ejemplo hay en Java, por tanto, para poder definir el punto de entrada del programa, se realiza ese if y generalmente se llama a un metodo main() para la ejecucion del programa

---
## Declaración de variables
```Python
variableString = "Hola"
variableInteger = 2
variableFloat = 2.5
variableBooleana = False
```

---
## Convertir tipos
```Python
int(variableString)
str(variableInteger)
int(variableFloat)
int(variableBooleana)
```

----
## Sentencias de flujo
```Python
if variableString == variableInteger or variableFloat == variableBooleana and not bool(variableInteger):
    print("pasa por verdadero")
elif variableBooleana != variableInteger:
    print("diferente")
else:
    print("pues nah!")
```

---
## Operador ternario
````Python
ternario = variableString if variableString is not None else ""
````

----
## Bucles
```Python
while edad < 3:
    edad += 1
    print(f"{edad}")

for i in range(0, 3):
    edad += 1
    print(f"{edad} rango: {i}")

for i in lista:
    print(f"{i}")
```


# Cadenas

## String
Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el 
texto se almacena como una colección secuencial de solo lectura de 
objetos Char.

### Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| \\' | Comilla simple | 0x0027
| \\" | Comilla doble  | 0x0022
| \\\\ | Barra diagonal inversa | 0x005C
| \\0 | Null | 0x0000
| \\a | Alerta | 0x0007
| \\b | Retroceso | 0x0008
| \\f | Avance de página | 0x000C
| \\n | Nueva línea | 0x000A
| \\r | Retorno de carro | 0x000D
| \\t | Tabulación horizontal | 0x0009
| \\v | Tabulación vertical | 0x000B

### Interpolacion de Cadenas
---
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con las concatenaciones, pero es mas claro y mejor.
```Python
print(f"El contenido de la variable es: {variableBooleana}")
```

### Métodos de string
---

```Python
''' Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor '''
cadena.replace(" ", "\n")

''' Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-' '''
cadena.split('m')

''' Devuelve el indice donde se encuentra el caracter indicado '''
cadena.index("l")

''' Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial '''
cadena[3:5]
```


# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Listas

Una lista es un tipo de colección ordenada(un array)

### Métodos de listas

```Python
''' Agrega al ultimo elemento de la lista "x" '''
lista.append(x)

''' Devuelve el numero de veces que se encuentra "x" en la lista '''
lista.count(x)

''' Agrega los elementos de x a la lista, se suele usar para juntar varias listas '''
lista.extend(x)

''' Devuelve la posición en laque se encuentra la primera x. se pueden poner los parámetros "start", "stop" que indican desde donde hasta donde del array recorrer '''
lista.index(x)

''' Inserta el objeto "y" en la posición "x" '''
lista.insert(x, y)

''' Devuelve el valor de la posición x y lo elimina '''
lista.pop(x)

''' Elimina el primer valor "x" de la lista '''
lista.remove(X)

''' Invierta la lista. Se trabaja sobre la lista real, no sobre copia '''
lista.reverse()

''' Ordena la lista por orden alfabetico o numerico '''
lista.sort()

''' Indica si se debe ordenar la lista de forma inversa '''
lista.sort(reverse=True)
```

```python
lista2Dimensiones = [["hola"], ["adios"], ["good"]]
lista2Dimensiones[1].append("aloh")
```

---
## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede tener como máximo un valor en el diccionario

### Métodos de diccionarios

```Python
diccionario = {"Clave": "resultado", 1: "asier", "apellido": "garcia"}

''' Devuelve una lista con las claves del diccionario '''
diccionario.keys()

''' Devuelve una lista con los valores del diccionario '''
diccionario.values()

''' Devuelve un bool indicando si la clave existe en el diccionario '''
diccionario.has_key(k)

''' Elimina la Key del diccionario y por tanto, los valores asociados a  la misma'''
diccionario.pop(k)

''' Metodo para obtener el valor asociado a la clave indicada '''
diccionario.get(k)
```

----
## Tuplas
Una tupla es una estructura de datos que contiene una secuencia de elementos de diferentes tipos, esta estructura es de solo lectura, por tanto se usa para almacenar objetos que no van a ser modificados después.

```Python
tupla = (1, 2, True, "Python")

tupla[0]
tupla[1]
tupla[2]
tupla[3]
```


# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```Python
class ClasePython(object):
    def __init__(self):
        super().__init__()
```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```Python
import abc
class ClaseMetodosAbstractos(abc.ABC):
    @abc.abstractmethod
    def MetodoAbstracto(self):
        pass


class ClaseHereda(ClaseMetodosAbstractos):
    def MetodoAbstracto(self):
        pass
```

----
## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Python
''' Funciones normales, sin clase '''
def funcion(param1, param2 = 2, param3 = True, param4 = ""):
    pass


class Clase(object):
    def __init__(self):
        super().__init__()

    ''' Metodos de clase '''
    def metodo(self, param1, param2 = 2, param3 = True, param4 = ""):
        pass
```

----
## Metodos estaticos
Un método es un bloque de código que contiene una serie de instrucciones.
```Python
@staticmethod
def metodoEstatico():
    print("Metodo estatico")
```

----
## Encapsulamiento
La encapsulacion se utiliza para no dar demasiada información sobre la implementacion de las clases y los atributos que contiene, para ello se hace uso de las funciones.  
En python los atributos que empiezan por `__` se usan para indicar que son privados de la clase a la que accedemos.
```Python

class ClaseEncapsular(object):
    __cadena = str()

    def __init__(self):
        super().__init__()

    def getCadena(self):
        return self.__cadena
    
    def setCadena(self, nuevaCadena):
        self.__cadena = nuevaCadena
```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Python
class ClasePadre(object):
    pass

class ClasePadreDos(object):
    pass

class ClaseHija(ClasePadre, ClasePadreDos):
    pass
```

# Conceptos Avanzados

## Liberacion de Memoria
Para evitar que el programa se quede sin memoria, tenemos que liberar o borrar la memoria borrando la variable o los datos, que ya no son necesarios en el programa. Podemos borrar la memoria en Python usando los siguientes métodos.


El método `gc.collect()` se utiliza para borrar o liberar la memoria no referenciada en Python. La memoria no referenciada es la memoria que es inaccesible y no se puede utilizar.

En Python, los objetos de corta duración se almacenan en la generación `0` y los objetos con una vida útil más larga se almacenan en la generación `1` o `2`.  
El valor predeterminado de la llamada es la generacion `2`.
```Python
import gc
gc.collect()
gc.collect(generation=2)
```

En Python se pueden eliminar variables especificas con la palabra reservada `del`.  
Un uso de ejemplo para esta instruccion sera la eliminacion de una lista muy grande en memoria por ejemplo, de esta forma liberariamos ese espacio.

```python
del edad, variableBooleana
```

---
## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Python
import enum
class TipoCartas(enum.Enum):
    oro = 0,
    bastos = 1,
    copas = 2,
    espadas = 3
```

---
## Codigo no Administrado
El codigo no administrado es un tipo de codigo al que no puede acceder el `Garbage Collector` para realizar el proceso de limpieza de memoria, por tanto hay que hacerlo manualmente.

### Ctypes para cargar dll nativas
Es una tecnologia que permite hacer uso de librerias compiladas de forma nativa con Python como `Rust`, `Cpp`, etc.
De esta forma permite realizar interoperabilidad con librerias de los diferentes sitemas como Windows, por ejemplo se puede hacer uso de esto para ejecutar librerias como el diseño de las GUi nativas.

```rust
#[no_mangle]
pub extern fn add_numbers(number1: i32, number2: i32) -> i32 {
    println!("Hola con Rust");
    number1 + number2
}

/*
> cargo new lib
> cd lib
Creamos el archivo lib.rs
Editamos el archivo cargo.toml y agregamos:
    [lib]
    name="libreriaEjemploRust"
    crate-type = ["dylib"]
> cargo build
```

```Python
import ctypes
import os
dll = ctypes.cdll.LoadLibrary(os.path.dirname(os.path.abspath(__file__)) + "\\libreriaEjemploRust.dll")
dll.add_numbers(3, 4)
```

# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Python
try:
    pass
except Exception as ex:
    print(ex)
```

### Provocando una excepcion
```Python
raise Exception("Hola, soy una excepcion jajaaa")
```

### Creando excepciones propias
```Python
class ExcepcionMia(Exception):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

try:
    raise ExcepcionMia("Holaaaaa, he vueltoooooooooooooo")
except ExcepcionMia as ex:
    print(ex)
```

# MultiThreading & Multiprocessing
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer esas consultas de forma paralelizada y reducir los tiempos.

## Multithreading
En python, el uso de los Threads son mas aconsejable para el uso de conexiones simultaneas a, por ejemplo, una solicitud a una api web o una consulta a BBDD.
 
El motivo es que esta clase, aunque de la sensacion de que el codigo se ejecuta sobre el resto de núcleos, la realidad es que lo que realiza es crear un hilo sobre el nucleo que estamos usando en la aplicacion principal y ejecutarse en dicho núcleo en segundo plano, por tanto, si requerimos de una potencia de procesamiento muy fuerte, no seria muy útil.

### Thread
```Python
import threading
import time
def metodoUno():
    print("1")
    time.sleep(10)

def metodoDos():
    print("2")
    time.sleep(10)

threading.Thread(target=metodoUno).start()
threading.Thread(target=metodoDos).start()
```

Otra forma de crear los threads se puede hacer uso de uns instruccion lambda para agregar las instrucciones que se quieren iniciar.

```Python
threading.Thread(target=lambda : time.sleep(10)).start()
threading.Thread(target=lambda : time.sleep(10)).start()
```

### ThreadPoolExecutor
```Python
import concurrent.futures

with concurrent.futures.ThreadPoolExecutor(max_workers=3) as executor:
    executor.submit(metodoUno)
    executor.submit(metodoDos, 1, 2)
```

## Multiprocessing
El uso del `multiprocessing` es una clase que se utiliza mas habitualmente para las operaciones E/S o que requieran de una potencia mayor de procesamiento.  
A diferencia de la clase `Thread`, la libreria de multiprocessing ejecuta las tareas en los núcleos de la CPU y por tanto es mas recomendable para la ejecucion de procesos mas costosos.

### ProcessPoolExecutor
```Python
def main():
    with ProcessPoolExecutor(max_workers=2) as executor:
        executor.submit(metodoUno)
        executor.submit(metodoDos, 1, 2)

if __name__ == "__main__":
    main()
```

---
# Comprension de Listas
La comprensión de listas, es una funcionalidad que nos permite crear listas avanzadas en una misma línea de código.  
Son muy utiles para realizar filtrados de listas, por ejemplo, obtenemos una consulta de la BBDD y queremos obtener un dato especifico de la lista recibida, se puede usar la compresion de listas para realizar el filtro.

```Python
''' Método tradicional '''
lista = []
for numero in range(0,11):
    lista.append(numero**2)
print(lista)

''' Con comprensión de listas '''
lista = [numero**2 for numero in  range(0,11)]
print(lista)


''' Método tradicional '''
lista = []
for numero in range(0,11):
    if numero % 2 == 0:
        lista.append(numero)
print(lista)

''' Con comprensión de listas '''
lista = [numero for numero in range(0,11) if numero % 2 == 0 ]
print(lista)
```
