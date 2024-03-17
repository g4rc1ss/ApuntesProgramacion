# Escritura de Datos en un Archivo Binario:

Para escribir datos en un archivo binario, primero necesitas convertir tus datos en un formato binario y luego escribir esos bytes en el archivo utilizando `Data` y `FileManager`.

Ejemplo:

```swift
import Foundation

let datos = "Esto es un ejemplo de datos binarios".data(using: .utf8)

let url = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask).first!.appendingPathComponent("datos.bin")

do {
    try datos?.write(to: url)
    print("Datos escritos en el archivo binario")
} catch {
    print("Error al escribir los datos: \(error)")
}
```

En este ejemplo, hemos convertido la cadena de texto en un objeto `Data` utilizando `data(using:)` con la codificación `.utf8`. Luego, hemos obtenido la URL del directorio de documentos y hemos creado un archivo llamado "datos.bin". Finalmente, hemos escrito los datos binarios en el archivo utilizando `write(to:)`.

# Lectura de Datos desde un Archivo Binario:

Para leer datos desde un archivo binario, necesitas abrir el archivo y leer los bytes en un objeto `Data`, luego puedes convertir esos bytes en el formato de datos que desees.

Ejemplo:

```swift
let url = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask).first!.appendingPathComponent("datos.bin")

do {
    let datosLeidos = try Data(contentsOf: url)
    if let texto = String(data: datosLeidos, encoding: .utf8) {
        print("Datos leídos del archivo binario: \(texto)")
    } else {
        print("No se pudo convertir los datos leídos en texto")
    }
} catch {
    print("Error al leer los datos: \(error)")
}
```

En este ejemplo, hemos abierto el archivo "datos.bin" utilizando `Data(contentsOf:)` y hemos leído los datos binarios en un objeto `Data`. Luego, hemos convertido esos bytes en una cadena de texto utilizando `String(data:encoding:)` con la codificación `.utf8`.

Es importante tener en cuenta que al trabajar con archivos binarios, debes asegurarte de manejar adecuadamente el manejo de errores y la administración de recursos utilizando bloques `do-catch` y asegurándote de cerrar los archivos después de usarlos.
