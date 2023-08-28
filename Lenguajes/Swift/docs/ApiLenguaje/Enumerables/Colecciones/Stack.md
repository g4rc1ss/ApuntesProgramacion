# Creación de una Pila:
Puedes crear una pila utilizando un array vacío o utilizando la función `init()`.

Ejemplo:

```swift
var pila1 = [Int]() // Creación de una pila vacía
var pila2 = Array<Int>() // Otra forma de crear una pila vacía
```

# Agregar Elementos a la Pila:
Puedes agregar elementos a la pila utilizando la función `append(_:)`.

Ejemplo:

```swift
var pila = [String]() // Creación de una pila vacía

pila.append("Manzana")
pila.append("Naranja")
pila.append("Plátano")
```

En este ejemplo, hemos creado una pila vacía y luego hemos agregado tres elementos a la pila utilizando `append(_:)`.

# Eliminar Elementos de la Pila:
Puedes eliminar el elemento en la parte superior de la pila utilizando la función `removeLast()`.

Ejemplo:

```swift
var pila = ["A", "B", "C"] // Creación de una pila con elementos

let elementoEliminado = pila.removeLast()
print(elementoEliminado) // Salida: "C", ya que "C" fue el último elemento agregado y ahora es eliminado de la pila
```

En este ejemplo, hemos creado una pila con tres elementos y luego hemos eliminado el último elemento "C" de la pila utilizando `removeLast()`.

# Acceso al Elemento en la Parte Superior de la Pila:
Puedes acceder al elemento en la parte superior de la pila utilizando el índice `count - 1`, ya que ese es el índice del último elemento agregado.

Ejemplo:

```swift
var pila = ["Rojo", "Verde", "Azul"] // Creación de una pila con elementos

let ultimoElemento = pila[pila.count - 1]
print(ultimoElemento) // Salida: "Azul", ya que "Azul" es el último elemento agregado a la pila
```

En este ejemplo, hemos creado una pila con tres elementos y luego hemos accedido al último elemento "Azul" de la pila utilizando el índice `pila.count - 1`.
