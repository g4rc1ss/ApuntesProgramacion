# Caché de memoria con NSCache:
NSCache es una clase de Foundation que también se puede utilizar para implementar la caché de memoria en Swift. NSCache ofrece ventajas adicionales, como la capacidad de establecer límites de capacidad y manejo automático de memoria.

Ejemplo:

```swift
import Foundation

let memoryCache = NSCache<NSString, NSData>()

func cargarDatosDesdeFuenteExterna(clave: String) -> Data? {
    // Simulación de carga de datos desde una fuente externa
    return Data() // En un caso real, aquí se cargaría la data desde una fuente externa, como una base de datos o una red
}

func obtenerDatosDesdeCache(clave: String) -> Data? {
    if let datosEnCache = memoryCache.object(forKey: clave as NSString) as Data? {
        print("Datos obtenidos desde la caché de memoria.")
        return datosEnCache
    } else {
        print("Datos no encontrados en la caché de memoria. Cargando desde la fuente externa.")
        let datos = cargarDatosDesdeFuenteExterna(clave: clave)
        memoryCache.setObject(datos as NSData, forKey: clave as NSString)
        return datos
    }
}
```

En este ejemplo, hemos utilizado NSCache con una clave de tipo `NSString` y un valor de tipo `NSData`. La función `obtenerDatosDesdeCache(clave:)` verifica si los datos están presentes en la caché utilizando `object(forKey:)`. Si los datos están en caché, los devuelve. Si no están en caché, carga los datos desde la fuente externa y los almacena en NSCache utilizando `setObject(_:forKey:)`.
