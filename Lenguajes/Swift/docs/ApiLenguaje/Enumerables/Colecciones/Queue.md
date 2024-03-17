# Creación de una Cola:
Puedes crear una cola utilizando un array vacío o utilizando la función `init()`.

Ejemplo:

```swift
var cola1 = [Int]() // Creación de una cola vacía
var cola2 = Array<Int>() // Otra forma de crear una cola vacía
```

# Agregar Elementos a la Cola:
Puedes agregar elementos a la cola utilizando la función `append(_:)`.

Ejemplo:

```swift
var cola = [String]() // Creación de una cola vacía

cola.append("Persona 1")
cola.append("Persona 2")
cola.append("Persona 3")
```

En este ejemplo, hemos creado una cola vacía y luego hemos agregado tres elementos a la cola utilizando `append(_:)`.

# Eliminar Elementos del Principio de la Cola:
Puedes eliminar el elemento en el principio de la cola utilizando la función `removeFirst()`.

Ejemplo:

```swift
var cola = ["Primero", "Segundo", "Tercero"] // Creación de una cola con elementos

let primerElemento = cola.removeFirst()
print(primerElemento) // Salida: "Primero", ya que "Primero" fue el primer elemento agregado y ahora es eliminado de la cola
```

En este ejemplo, hemos creado una cola con tres elementos y luego hemos eliminado el primer elemento "Primero" de la cola utilizando `removeFirst()`.

# Acceso al Elemento en el Principio de la Cola:
Puedes acceder al elemento en el principio de la cola utilizando el índice `0`, ya que ese es el índice del primer elemento agregado.

Ejemplo:

```swift
var cola = ["A", "B", "C"] // Creación de una cola con elementos

let primerElemento = cola[0]
print(primerElemento) // Salida: "A", ya que "A" es el primer elemento agregado a la cola
```

En este ejemplo, hemos creado una cola con tres elementos y luego hemos accedido al primer elemento "A" de la cola utilizando el índice `0`.