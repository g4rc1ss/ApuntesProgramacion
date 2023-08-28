# URLSession: 
Es una API que te permite realizar solicitudes HTTP, como GET, POST, PUT o DELETE. Puedes utilizar URLSession para descargar datos, cargar archivos, realizar peticiones a APIs REST y más.

Ejemplo de solicitud GET utilizando URLSession:

```swift
import Foundation

let url = URL(string: "https://api.example.com/data")!

let tarea = URLSession.shared.dataTask(with: url) { datos, respuesta, error in
    if let error = error {
        print("Error al obtener los datos: \(error)")
        return
    }

    if let datos = datos {
        // Procesar los datos obtenidos
        if let texto = String(data: datos, encoding: .utf8) {
            print("Datos obtenidos: \(texto)")
        }
    }
}
tarea.resume()
```

En este ejemplo, hemos creado una URL para la solicitud GET. Utilizamos `URLSession.shared.dataTask(with:)` para realizar una solicitud HTTP a la URL especificada. Luego, dentro del bloque de finalización, procesamos los datos obtenidos si no hay errores.
