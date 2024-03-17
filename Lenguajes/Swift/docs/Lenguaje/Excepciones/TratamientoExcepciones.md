Aquí tienes una explicación detallada sobre cómo funcionan las excepciones en Swift con ejemplos:

# Lanzamiento de Excepciones:
Para lanzar una excepción en Swift, se utiliza la palabra clave `throw`, seguida de un error o un objeto que implemente el protocolo `Error`.

Ejemplo:

```swift
enum ErrorPersonalizado: Error {
    case divisionEntreCero
}

func dividir(_ a: Int, _ b: Int) throws -> Int {
    guard b != 0 else {
        throw ErrorPersonalizado.divisionEntreCero
    }
    return a / b
}
```

En este ejemplo, hemos definido un error personalizado llamado `ErrorPersonalizado` que implementa el protocolo `Error`. Luego, hemos creado una función `dividir(_:_:)` que intenta dividir dos números. Si el divisor es cero, lanzamos una excepción con el error `ErrorPersonalizado.divisionEntreCero`.

# Manejo de Excepciones:
Para manejar excepciones en Swift, utilizamos el bloque "do-try-catch". El bloque "do" contiene el código que podría lanzar una excepción. El bloque "try" indica que el código dentro del bloque "do" puede lanzar excepciones y debe ser tratado adecuadamente. Y el bloque "catch" se utiliza para capturar y manejar las excepciones.

Ejemplo:

```swift
func realizarDivision(_ a: Int, _ b: Int) {
    do {
        let resultado = try dividir(a, b)
        print("El resultado de la división es: \(resultado)")
    } catch ErrorPersonalizado.divisionEntreCero {
        print("Error: No se puede dividir entre cero.")
    } catch {
        print("Error desconocido: \(error)")
    }
}
```

En este ejemplo, hemos definido una función `realizarDivision(_:_:)` que intenta realizar una división llamando a la función `dividir(_:_:)`. Dentro del bloque "do", llamamos a la función `dividir(_:_:)` y utilizamos "try" para indicar que puede lanzar una excepción. En el bloque "catch", capturamos la excepción específica `ErrorPersonalizado.divisionEntreCero` y también manejamos cualquier otro error desconocido.

# Llamar a la Función de Manejo de Excepciones:

```swift
realizarDivision(10, 0) // Salida: "Error: No se puede dividir entre cero."
realizarDivision(10, 2) // Salida: "El resultado de la división es: 5"
```

En este ejemplo, hemos llamado a la función `realizarDivision(_:_:)` dos veces, una con el divisor igual a cero (causando una excepción) y otra con el divisor diferente de cero (sin excepción).
