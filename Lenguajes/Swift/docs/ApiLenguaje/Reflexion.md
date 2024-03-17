# Obtener la Reflexión de un Objeto:
Puedes utilizar la función `Mirror(reflecting:)` para obtener un espejo (mirror) de un objeto específico y examinar sus propiedades y valores.

Ejemplo:

```swift
struct Persona {
    let nombre: String
    let edad: Int
}

let persona = Persona(nombre: "Juan", edad: 30)

let espejo = Mirror(reflecting: persona)
print("Tipo del objeto: \(espejo.subjectType)")

for propiedad in espejo.children {
    print("Propiedad: \(propiedad.label ?? "Desconocido") - Valor: \(propiedad.value)")
}
```

En este ejemplo, hemos creado una estructura `Persona` con propiedades `nombre` y `edad`. Luego, hemos obtenido un espejo de la instancia `persona` utilizando `Mirror(reflecting:)`. Utilizamos el espejo para imprimir el tipo del objeto y recorrer todas las propiedades junto con sus valores.

# Utilizar Reflexión en Funciones Genéricas:
Puedes aprovechar la reflexión para trabajar con funciones genéricas que pueden adaptarse a diferentes tipos de datos en tiempo de ejecución.

Ejemplo:

```swift
func imprimirPropiedades<T>(_ objeto: T) {
    let espejo = Mirror(reflecting: objeto)
    print("Tipo del objeto: \(espejo.subjectType)")

    for propiedad in espejo.children {
        print("Propiedad: \(propiedad.label ?? "Desconocido") - Valor: \(propiedad.value)")
    }
}

struct Persona {
    let nombre: String
    let edad: Int
}

let persona = Persona(nombre: "María", edad: 25)
imprimirPropiedades(persona)

let datos = ["Apple", 3.14, true]
imprimirPropiedades(datos)
```

En este ejemplo, hemos definido una función genérica `imprimirPropiedades(_:)` que utiliza reflexión para inspeccionar los objetos y imprimir sus propiedades y valores. Luego, hemos utilizado la función con diferentes tipos, incluida la estructura `Persona` y un array de datos.
