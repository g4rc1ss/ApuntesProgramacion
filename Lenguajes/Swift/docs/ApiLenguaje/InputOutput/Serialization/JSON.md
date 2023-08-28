# Serializar un Objeto a JSON:

Para serializar un objeto Swift a JSON, primero necesitas asegurarte de que tu objeto implemente el protocolo `Codable`. Luego, puedes utilizar `JSONEncoder` para convertir el objeto en formato JSON.

Ejemplo:

```swift
import Foundation

struct Persona: Codable {
    let nombre: String
    let edad: Int
}

let persona = Persona(nombre: "Juan", edad: 30)

let jsonEncoder = JSONEncoder()
do {
    let jsonData = try jsonEncoder.encode(persona)
    if let jsonString = String(data: jsonData, encoding: .utf8) {
        print("JSON serializado: \(jsonString)")
    }
} catch {
    print("Error al serializar JSON: \(error)")
}
```

En este ejemplo, hemos creado una estructura `Persona` que implementa el protocolo `Codable`. Luego, hemos creado una instancia de `Persona` llamada `persona`. Utilizamos `JSONEncoder` para convertir el objeto `persona` en un objeto `Data` que representa el JSON. Finalmente, convertimos los bytes de `Data` en una cadena de texto legible por humanos utilizando `String(data:encoding:)` con la codificación `.utf8`.

# Deserializar JSON a un Objeto:

Para deserializar JSON a un objeto Swift, nuevamente necesitas asegurarte de que tu objeto implemente el protocolo `Codable`. Luego, puedes utilizar `JSONDecoder` para convertir el JSON en un objeto Swift.

Ejemplo:

```swift
import Foundation

let jsonString = """
{
    "nombre": "María",
    "edad": 25
}
"""

let jsonData = jsonString.data(using: .utf8)!
let jsonDecoder = JSONDecoder()

do {
    let persona = try jsonDecoder.decode(Persona.self, from: jsonData)
    print("Objeto deserializado: \(persona)")
} catch {
    print("Error al deserializar JSON: \(error)")
}
```

En este ejemplo, hemos definido una cadena de texto JSON llamada `jsonString` que representa un objeto `Persona`. Luego, convertimos la cadena de texto en un objeto `Data` utilizando `data(using:)`. Utilizamos `JSONDecoder` para convertir el JSON en un objeto `Persona`. La función `decode(_:from:)` toma dos argumentos: el tipo del objeto que deseamos deserializar (`Persona.self`) y el objeto `Data` que contiene el JSON.
