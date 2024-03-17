# Creación de Strings:
Puedes crear un `String` en Swift utilizando comillas dobles ("") o comillas triples (""").

Ejemplo:

```swift
let nombre = "Juan"
let mensaje = """
Hola,
¿Cómo estás?
Espero que bien.
"""
```

En este ejemplo, hemos creado dos strings: uno con comillas dobles y otro con comillas triples. Los strings creados con comillas triples pueden abarcar múltiples líneas y conservar el formato del texto.

# Interpolación de Strings:
Swift permite la interpolación de strings, que es la capacidad de incluir valores de variables o expresiones dentro de un string utilizando el operador `\()`.

Ejemplo:

```swift
let edad = 30
let mensaje = "Mi nombre es \(nombre) y tengo \(edad) años."
print(mensaje) // Salida: "Mi nombre es Juan y tengo 30 años."
```

En este ejemplo, hemos interpolado las variables `nombre` y `edad` dentro del string `mensaje`.

# Concatenación de Strings:
Puedes concatenar strings utilizando el operador `+` o el operador de asignación `+=`.

Ejemplo:

```swift
let saludo = "Hola, "
let nombre = "María"
let mensaje = saludo + nombre
print(mensaje) // Salida: "Hola, María"
```

# Métodos y Propiedades de Strings:
Swift proporciona una variedad de métodos y propiedades para trabajar con strings, como contar caracteres, obtener una subcadena, convertir a mayúsculas o minúsculas, entre otros.

Ejemplo:

```swift
let frase = "Hola, Mundo!"

print(frase.count) // Cuenta el número de caracteres: 12

print(frase.lowercased()) // Convierte a minúsculas: "hola, mundo!"
print(frase.uppercased()) // Convierte a mayúsculas: "HOLA, MUNDO!"

print(frase.hasPrefix("Hola")) // Comprueba si comienza con "Hola": true
print(frase.hasSuffix("Mundo!")) // Comprueba si termina con "Mundo!": true

let subcadena = frase.prefix(4) // Obtiene los primeros 4 caracteres: "Hola"
```

# Acceso a Caracteres:
Puedes acceder a caracteres individuales de un string utilizando la indexación de corchetes y el tipo `Character`.

Ejemplo:

```swift
let mensaje = "Hola"

let primerCaracter = mensaje[mensaje.startIndex] // Acceso al primer caracter: "H"
let tercerCaracter = mensaje[mensaje.index(mensaje.startIndex, offsetBy: 2)] // Acceso al tercer caracter: "l"
```

En este ejemplo, hemos accedido al primer y tercer caracter del string `mensaje`.
