# Escritura de Datos en un Archivo de Texto:

Para escribir datos en un archivo de texto, primero necesitas convertir tus datos en una cadena de texto y luego escribir esa cadena en el archivo utilizando `FileManager`.

Ejemplo:

```swift
import Foundation

let texto = "Esto es un ejemplo de texto que será escrito en un archivo de texto."

let url = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask).first!.appendingPathComponent("archivo.txt")

do {
    try texto.write(to: url, atomically: true, encoding: .utf8)
    print("Texto escrito en el archivo de texto")
} catch {
    print("Error al escribir el texto: \(error)")
}
```

En este ejemplo, hemos creado una cadena de texto llamada `texto`. Luego, hemos obtenido la URL del directorio de documentos y hemos creado un archivo llamado "archivo.txt". Finalmente, hemos escrito el texto en el archivo utilizando `write(to:atomically:encoding:)` con la codificación `.utf8`.

# Lectura de Datos desde un Archivo de Texto:

Para leer datos desde un archivo de texto, necesitas abrir el archivo y leer la cadena de texto.

Ejemplo:

```swift
let url = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask).first!.appendingPathComponent("archivo.txt")

do {
    let textoLeido = try String(contentsOf: url, encoding: .utf8)
    print("Texto leído del archivo de texto: \(textoLeido)")
} catch {
    print("Error al leer el texto: \(error)")
}
```

En este ejemplo, hemos abierto el archivo "archivo.txt" utilizando `String(contentsOf:encoding:)` y hemos leído la cadena de texto en una variable llamada `textoLeido`.

Es importante tener en cuenta que al trabajar con archivos de texto, debes asegurarte de manejar adecuadamente el manejo de errores y la administración de recursos utilizando bloques `do-catch`.
