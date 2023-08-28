# Funciones Asíncronas
Puedes declarar una función como asíncrona utilizando la palabra clave `async` antes del tipo de retorno. Esto indica que la función puede contener operaciones asíncronas y se puede usar `await` dentro de ella.

```swift
func descargarDatos() async -> [String] {
    // Simulación de una tarea asíncrona
    await Task.sleep(1_000_000_000) // Espera 1 segundo (tiempo expresado en nanosegundos)
    
    return ["Juan", "María", "Pedro"]
}
```

# Await:

```swift
func procesarDatos() async {
    do {
        let datos = try await descargarDatos()
        print("Datos descargados: \(datos)")
    } catch {
        print("Error al descargar los datos: \(error)")
    }
}
```

En este ejemplo, hemos declarado una función `procesarDatos()` como asíncrona. Dentro de esta función, hemos utilizado `await` para esperar a que se completen los datos descargados de la función `descargarDatos()`. Si ocurre algún error durante la descarga, se maneja mediante el bloque `catch`.

# Funciones Async/Await con `async let`:

```swift
func descargarDatos() async -> [String] {
    await Task.sleep(1_000_000_000)
    return ["Juan", "María", "Pedro"]
}

func procesarDatos() async {
    async let datos = descargarDatos()
    // Otras tareas que no dependen de los datos descargados
    
    do {
        let resultado = try await datos
        print("Datos descargados: \(resultado)")
    } catch {
        print("Error al descargar los datos: \(error)")
    }
}
```

En este ejemplo, hemos utilizado `async let` para ejecutar la función `descargarDatos()` en un hilo diferente y continuar con otras tareas mientras se espera que se completen los datos descargados. Luego, utilizamos `await` para obtener el resultado de los datos descargados y procesarlos en la sección marcada con el bloque `do-catch`.
