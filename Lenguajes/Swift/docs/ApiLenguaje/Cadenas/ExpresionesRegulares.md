# Creación de Expresiones Regulares:

Para trabajar con expresiones regulares en Swift, primero debes crear una instancia de `NSRegularExpression`. Puedes utilizar la inicialización que recibe el patrón de expresión regular como un string, y opcionalmente opciones para configurar el comportamiento de la búsqueda.

Ejemplo:

```swift
import Foundation

let texto = "¡Hola! Este es un mensaje de ejemplo."
let patron = "Hola"
do {
    let expresionRegular = try NSRegularExpression(pattern: patron)
    let coincidencias = expresionRegular.matches(in: texto, range: NSRange(texto.startIndex..., in: texto))
    for coincidencia in coincidencias {
        print("Coincidencia encontrada en el rango: \(coincidencia.range)")
    }
} catch {
    print("Error al crear la expresión regular: \(error)")
}
```

En este ejemplo, hemos creado una expresión regular para buscar el patrón "Hola" en el texto dado utilizando `NSRegularExpression`. La función `matches(in:range:)` encuentra todas las coincidencias del patrón en el texto y devuelve un array de objetos `NSTextCheckingResult`, que contiene información sobre las coincidencias encontradas.

# Búsqueda de Coincidencias en el Texto:

Puedes usar diferentes métodos de `NSRegularExpression` para buscar coincidencias en el texto, como `matches(in:range:)`, `firstMatch(in:range:)`, `numberOfMatches(in:range:)`, entre otros.

Ejemplo:

```swift
let texto = "El número de teléfono es: 123-456-7890"
let patron = "\\d{3}-\\d{3}-\\d{4}" // Patrón para buscar números de teléfono en formato XXX-XXX-XXXX

do {
    let expresionRegular = try NSRegularExpression(pattern: patron)
    let coincidencias = expresionRegular.matches(in: texto, range: NSRange(texto.startIndex..., in: texto))
    for coincidencia in coincidencias {
        let numeroDeTelefono = (texto as NSString).substring(with: coincidencia.range)
        print("Número de teléfono encontrado: \(numeroDeTelefono)")
    }
} catch {
    print("Error al crear la expresión regular: \(error)")
}
```

En este ejemplo, hemos creado una expresión regular para buscar números de teléfono en formato "XXX-XXX-XXXX" en el texto. Utilizamos la función `substring(with:)` para extraer el número de teléfono encontrado.

# Reemplazo de Texto con Expresiones Regulares:

Además de buscar coincidencias, también puedes reemplazar texto utilizando expresiones regulares en Swift.

Ejemplo:

```swift
let texto = "¡Hola! Este es un mensaje de ejemplo."
let patron = "Hola"
let reemplazo = "¡Saludos!"

do {
    let expresionRegular = try NSRegularExpression(pattern: patron)
    let resultado = expresionRegular.stringByReplacingMatches(in: texto, range: NSRange(texto.startIndex..., in: texto), withTemplate: reemplazo)
    print(resultado) // Salida: "¡Saludos! Este es un mensaje de ejemplo."
} catch {
    print("Error al crear la expresión regular: \(error)")
}
```

En este ejemplo, hemos creado una expresión regular para buscar el patrón "Hola" en el texto y lo hemos reemplazado con "¡Saludos!" utilizando `stringByReplacingMatches(in:range:withTemplate:)`.
