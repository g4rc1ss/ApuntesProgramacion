# Sintaxis de Python
## Declaración de variables
```python

print(f"{a} {b} {c} {d}") #formatear salida menos liosa que concatenar
```
---
---
## En las cadenas para rutas se puede usar r""
```python
raw = r"c\git"
masLineas = """hola
                Adios"""
```
---
## Métodos habituales en cadenas
- ``cadena.count(x)`` -> Devuelve el numero de veces que encuentra la letra "x" en la cadena

- ``cadena.find(x)`` -> Devuelve la posición en la que se encuentra por primera vez "x", sino devuelve -1

- ``cadena.partition()`` -> Busca un separador y devuelve una tupla con el string separado hasta el final de la cadena sino devolverá una tupla con la cadena y dos vacías

- ``cadena.replace(x, y)`` -> Devuelve una cadena en la que se reemplazan las letras o asi metidas en "x" por las de "y"

- ``cadena.split(x)`` -> Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'

- ``cadena.strip(x)`` -> Devuelve una cadena con los elementos de "x" eliminados, si esta vacío eliminara espacios

- ``cadena.startswith(x)`` -> Devuelve true o false si inicia la cadena por "x", usado mucho en menus de opciones

---
## Listas:

Una lista es un tipo de colección ordenada(un array)

### Métodos habituales Listas

- ``lista.append(x)`` -> Agrega al ultimo elemento de la lista "x"

- ``lista.count(x)`` -> Devuelve el numero de veces que se encuentra "x" en la lista

- ``lista.extend(x)`` -> Agrega los elementos de x a la lista, se suele usar para juntar varias listas

- ``lista.index(x)`` -> Devuelve la posición en laque se encuentra la primera x. se pueden poner los parámetros "start", "stop" que indican desde donde hasta donde del array recorrer

- ``lista.insert(x, y)`` -> Inserta el objeto "y" en la posición "x"

- ``lista.pop(x)`` -> Devuelve el valor de la posición x y lo elimina

- ``lista.remove(X)`` -> Elimina el primer valor "x" de la lista

- ``lista.reverse()`` -> Invierta la lista. Se trabaja sobre la lista real, no sobre copia
    
- ``lista.sort(cmp=None, key=None, reverse=False)`` -> Ordena la lista
    - ``cmp=`` debe ser una función que tome como parámetro dos valores "x" e "y" y de la lista y devuelva -1 si "x" es menor que "y", 0 si son iguales y 1 si es mayor

    - ``key=`` debe ser una función que tome un elemento de la lista y devuelva una clave a utilizar

    - ``reverse=`` un booleano que indica si se debe ordenar la lista de forma inversa

```python
Ejemplo de lista.sort:
lista = [1, 3, 4, 2]
lista.sort() -> devuelve [1, 2, 3, 4]
lista.sort(reverse=True) -> devuelve [4, 3, 2, 1]
lista2Dimensiones.sort(key= lambda x: x[0]) el x[0] es la columna, solo hay 1 elemento por fila, asique 0
```
```python
lista = [22, True, "Una lista", [1, 2]]
```
```python
lista2Dimensiones = [["hola"], ["adios"], ["good"]]
print(f"{lista2Dimensiones.sort()}")
lista2Dimensiones[1].append("hio")
print(f"{lista} \n \
    {lista2Dimensiones[1][1]} \t {len(lista2Dimensiones)}")
```
---
## Tuplas:
Una tupla es una lista, pero como una constante, osea que una vez agregados los datos, no se pueden modificar y es mas rápido que las listas, por tanto es recomendable si no tienes que agregar datos nuevos ni nada. Las tuplas se identifican mediante paréntesis y comas
````python
tupla = (1, 2, True, "Python")
tupla2 = tuple()
print(f"{tupla[1]} \t {tupla} tuplaVacía {tupla2}")
````
---
## Diccionarios:

Un diccionario o tabla de hashes(en otros lenguajes) son colecciones que relacionan una clave y valor. osea que se asocia una especia de significado
----
### Métodos habituales de diccionario:
- ``diccionario.get(k)`` -> Devuelve el valor de la key
- ``diccionario.has_key(k)`` -> Comprueba si existe esa key
- ``diccionario.items()`` -> Devuelve una lista de tuplas con pares clave-valor
- ``diccionario.keys()`` -> Devuelve una lista de claves
- ``diccionario.pop(k)`` -> Borra la clave k del diccionario y devuelve su valor
- ``diccionario.values()`` -> Devuelve una lista de los valores del diccionario

```python
diccionario = {"Clave":"resultado", 1:"asier", "apellido":"garcia"}
diccionario['Clave'] = 2#asignación de nuevos valores
print(f"{diccionario} \t {diccionario['Clave']} \t {diccionario[1]}")
```

----
## Funciones
```python
def imprimir(texto, veces = 1):
    print(f"{veces * texto}")
    return True
print(f"{imprimir('textoFunción ', 2)}")
```
----
## Funciones superiores
```python
def lenguaje(lang):
    def saludar_es():
        print("Hola", end='  --  ')
    def saludar_en():
        print("Hi", end='  --  ')
    def saludar_eus():
        print("Kaixo")
    lang_func = {
        'es': saludar_es,
        'en': saludar_en,
        'eus': saludar_eus
    }
    return lang_func[lang]
spanish = lenguaje("es"); english = lenguaje("en"); euskera = lenguaje("eus")
spanish(); english(); euskera()
```
---
## Uso de ``map(funcion, sequencia)``

La función ``map`` aplica una función a cada elemento de una lista y devuelve una nueva va pasando a cada elemento la función como tal, ejemplo:

````python
listaMap = [1, 2, 3, 4]
listaMapeada = []
listaMapeada.extend(map(lambda x: x * 2, listaMap))
print(listaMapeada)
````
---
## Uso de ``Filter(function, sequence)``

``filter`` verifica que los elementos de una secuencia cumplan una condición a cada uno se le pasa una función y si es True pues se añade a una nueva lista
````python
listaParaFilter = [["asier", 22], ["pedro", 23]]
listaBuenaFilter = []
listaBuenaFilter.extend(filter(lambda x: [x for nombre in x if nombre=="asier"], listaParaFilter))
````

Creamos la lambda a la que le pasamos x como parámetro(la lista) y luego ejecutamos un for ternario para recorrer la lista y comparamos con un if, si encuentra en la lista el nombre "asier" devuelve x que x es de la lista la posición, osea el primer [] o segundo Recuerda a las consultas LinQ filtrando una lista para que te devuelva resultados específicos, aunque es mas complicado que las consultas LinQ

````python
print(listaBuenaFilter)
````
---
## Comprensión de listas
En python 3 map y filter no estarán aconsejadas y se usaran las comprensiones de listas. Cada una de estas expresiones determinan como modificar el elemento de la lista original y se usaran una o varias clausulas "for" y una o varias if

````python
listaComprension = [1, 2, 3, 4, 5]

print(f"{listaComprension} \t {[n*2 for n in listaComprension]}")

listaComprension = [["asier", 22], ["pedro", 23]]
print(f"{listaComprension} \t {[array for array in listaComprension for nombre in array if nombre == 'asier']}")
````

Aquí como tenemos que recorrer una lista con dos listas, osea un array bidimensional, pues requerimos de dos for asique con uno accedemos a la lista 1 y con el otro accedemos al contenido para comprar con el if y devolver la lista

---
## Excepciones
Las excepciones son errores durante la ejecución del programa y lo que se hace es intentar solucionar el error o mostrar un mensaje mas claro sobre el problema al usuario, por ejemplo: se necesita ser super usuario, se esta dividiendo entre 0, no hay conexión a internet...

````python
resultado = 21
try:
    resultado = 2/0
except ZeroDivisionError:
    print("divides entre 0")
except ValueError:
    print("error de valor")

#Crear nuestras propias excepciones

class MiError(Exception):
    def __init__(self, valor):
        self.valor = valor
    def __str__(self):
        return "Error " + str(self.valor)

try:
    if resultado > 20:
        raise MiError(33)
except MiError as e:
    print(e)
````
---
## Instrucción ``del``
Se pueden borrar objetos usados que están en memoria ubicados para liberar ese espacio o por seguridad. 

Por ejemplo, guardo una contraseña en una variable para usarla, pues segun haya sido usada y no necesite mas usare el del variable para no dejar rastro sobre la pass

````python
del lista, lista2Dimensiones, listaBuenaFilter, listaComprension, listaMap, listaMapeada, listaParaFilter
````