# Arrays:
Un array es una colección ordenada de elementos del mismo tipo. Puedes usar un array para representar una lista de elementos y acceder a sus elementos mediante un índice numérico.

Ejemplo:

```swift
// Creación de un array
var listaDeNombres = ["Juan", "María", "Pedro", "Laura"]

// Acceso a elementos
let primerNombre = listaDeNombres[0] // "Juan"
let tercerNombre = listaDeNombres[2] // "Pedro"

// Modificación de elementos
listaDeNombres[1] = "Lucía" // ["Juan", "Lucía", "Pedro", "Laura"]

// Añadir elementos al final
listaDeNombres.append("Carlos") // ["Juan", "Lucía", "Pedro", "Laura", "Carlos"]

// Eliminar elementos
listaDeNombres.remove(at: 2) // ["Juan", "Lucía", "Laura", "Carlos"]
```

En este ejemplo, hemos utilizado un array para representar una lista de nombres. Hemos accedido a elementos utilizando índices, modificado elementos existentes, añadido elementos al final y eliminado elementos específicos.

# Sets:
Un set es una colección no ordenada de elementos únicos del mismo tipo. Puedes utilizar un set para representar una lista de elementos donde no se permiten duplicados.

Ejemplo:

```swift
// Creación de un set
var listaDeNombresUnicos: Set<String> = ["Juan", "María", "Pedro", "Laura"]

// Añadir elementos
listaDeNombresUnicos.insert("María") // El set no permitirá duplicados

// Eliminar elementos
listaDeNombresUnicos.remove("Juan") // El elemento "Juan" es eliminado
```

En este ejemplo, hemos utilizado un set para representar una lista de nombres únicos. Al intentar añadir un nombre duplicado, el set no permite duplicados, por lo que el segundo intento de añadir "María" es ignorado.
