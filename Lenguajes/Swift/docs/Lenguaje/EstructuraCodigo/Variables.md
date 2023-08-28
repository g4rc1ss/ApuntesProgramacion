```swift
var edad: Int = 25
```

En este ejemplo, hemos declarado una variable llamada `edad` con el tipo de dato `Int` y le hemos asignado el valor 25. Swift infiere automáticamente el tipo de dato en muchos casos, por lo que también podríamos haber escrito simplemente:

```swift
var edad = 25
```

Swift también admite el uso de anotaciones de tipo explícitas cuando se desea especificar el tipo de dato de una variable de manera clara.

Una vez que has declarado una variable, puedes cambiar su valor asignándole un nuevo valor. Por ejemplo:

```swift
edad = 30
```

También puedes realizar operaciones matemáticas y utilizar el valor de una variable en expresiones. Aquí tienes otro ejemplo:

```swift
var cantidad = 10
var precio = 5.99
var total = Double(cantidad) * precio
```

En este caso, hemos declarado una variable `cantidad` de tipo `Int` y una variable `precio` de tipo `Double`. Luego, hemos multiplicado `cantidad` por `precio`, convirtiendo `cantidad` a `Double` para que la multiplicación funcione correctamente.

Además, puedes combinar variables y cadenas de texto utilizando la interpolación de cadenas. Por ejemplo:

```swift
var nombre = "Juan"
var saludo = "Hola, \(nombre)!"
```

En este caso, hemos declarado una variable `nombre` de tipo `String` y una variable `saludo` que utiliza interpolación de cadenas para combinar el valor de `nombre` en una cadena de saludo.
