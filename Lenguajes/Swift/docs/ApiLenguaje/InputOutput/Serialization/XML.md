# Serializar un Objeto a XML:

Para serializar un objeto Swift a XML, primero necesitas asegurarte de que tu objeto implemente el protocolo `Codable`. Luego, puedes utilizar `XMLEncoder` para convertir el objeto en formato XML.

Ejemplo:

```swift
import Foundation

struct Persona: Codable {
    let nombre: String
    let edad: Int
}

let persona = Persona(nombre: "Juan", edad: 30)

let xmlEncoder = XMLEncoder()
xmlEncoder.outputFormatting = .prettyPrinted

do {
    let xmlData = try xmlEncoder.encode(persona)
    if let xmlString = String(data: xmlData, encoding: .utf8) {
        print("XML serializado: \n\(xmlString)")
    }
} catch {
    print("Error al serializar XML: \(error)")
}
```

En este ejemplo, hemos creado una estructura `Persona` que implementa el protocolo `Codable`. Luego, hemos creado una instancia de `Persona` llamada `persona`. Utilizamos `XMLEncoder` para convertir el objeto `persona` en un objeto `Data` que representa el XML. `outputFormatting` se utiliza para mejorar la legibilidad del XML resultante al agregar sangrías y saltos de línea. Finalmente, convertimos los bytes de `Data` en una cadena de texto legible por humanos utilizando `String(data:encoding:)` con la codificación `.utf8`.

# Deserializar XML a un Objeto:

Para deserializar XML a un objeto Swift, nuevamente necesitas asegurarte de que tu objeto implemente el protocolo `Codable`. Luego, puedes utilizar `XMLDecoder` para convertir el XML en un objeto Swift.

Ejemplo:

```swift
import Foundation

let xmlString = """
<persona>
    <nombre>Juan</nombre>
    <edad>30</edad>
</persona>
"""

let xmlData = xmlString.data(using: .utf8)!
let xmlDecoder = XMLDecoder()

do {
    let persona = try xmlDecoder.decode(Persona.self, from: xmlData)
    print("Objeto deserializado: \(persona)")
} catch {
    print("Error al deserializar XML: \(error)")
}
```

En este ejemplo, hemos definido una cadena de texto XML llamada `xmlString` que representa un objeto `Persona`. Luego, convertimos la cadena de texto en un objeto `Data` utilizando `data(using:)`. Utilizamos `XMLDecoder` para convertir el XML en un objeto `Persona`. La función `decode(_:from:)` toma dos argumentos: el tipo del objeto que deseamos deserializar (`Persona.self`) y el objeto `Data` que contiene el XML.
