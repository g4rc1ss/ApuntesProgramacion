# Creación de un Diccionario:
Puedes crear un diccionario utilizando la notación de llaves `{}` y separando los pares clave-valor con dos puntos `:`.

Ejemplo:

```swift
// Creación de un diccionario de edades
var edades: [String: Int] = ["Juan": 30, "María": 25, "Pedro": 35]

// Diccionario vacío
var diccionarioVacio: [String: Int] = [:]
```

En este ejemplo, hemos creado un diccionario llamado `edades` que almacena edades asociadas a nombres. También hemos creado un diccionario vacío llamado `diccionarioVacio`.

# Acceso y Modificación de Valores en el Diccionario:
Puedes acceder a los valores en el diccionario utilizando las claves y modificarlos si es necesario.

Ejemplo:

```swift
// Acceso a valores
let edadJuan = edades["Juan"] // 30

// Modificación de valores
edades["María"] = 26 // Cambia la edad de María a 26

// Añadir nuevos pares clave-valor
edades["Laura"] = 28
```

En este ejemplo, hemos accedido a la edad de "Juan" y modificado la edad de "María". También hemos añadido un nuevo par clave-valor para "Laura".

# Eliminación de Elementos del Diccionario:
Puedes eliminar elementos del diccionario utilizando el método `removeValue(forKey:)`.

Ejemplo:

```swift
// Eliminar elemento por clave
edades.removeValue(forKey: "Pedro") // Elimina el elemento asociado a la clave "Pedro"
```

En este ejemplo, hemos eliminado el elemento asociado a la clave "Pedro" del diccionario de edades.

# Recorrido del Diccionario:
Puedes recorrer un diccionario utilizando un bucle `for-in`. Al recorrer el diccionario, obtendrás pares clave-valor.

Ejemplo:

```swift
for (nombre, edad) in edades {
    print("\(nombre) tiene \(edad) años.")
}
```

En este ejemplo, hemos recorrido el diccionario `edades` y hemos impreso cada nombre con su respectiva edad.

# Comprobación de Existencia de Clave:
Puedes comprobar si una clave específica existe en el diccionario utilizando el operador `if let`.

Ejemplo:

```swift
if let edadLaura = edades["Laura"] {
    print("Laura tiene \(edadLaura) años.")
} else {
    print("Laura no está en el diccionario.")
}
```

En este ejemplo, estamos comprobando si la clave "Laura" existe en el diccionario de edades. Si existe, imprimimos la edad de Laura; de lo contrario, indicamos que no está en el diccionario.
