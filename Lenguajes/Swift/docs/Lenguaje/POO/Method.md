
# Métodos de Instancia:
Los métodos de instancia son aquellos que se llaman en una instancia particular de una clase, estructura o enumerador. Pueden acceder a las propiedades y otros métodos de la instancia utilizando la palabra clave `self`.

Ejemplo de un método de instancia en una clase:

```swift
class Persona {
    var nombre: String

    init(nombre: String) {
        self.nombre = nombre
    }

    func saludar() {
        print("¡Hola, mi nombre es \(nombre)!")
    }
}
```

En este ejemplo, hemos definido una clase `Persona` con una propiedad `nombre` y un método de instancia `saludar()`. El método `saludar()` imprime un mensaje de saludo con el nombre de la persona.

Para llamar a un método de instancia, necesitas crear una instancia de la clase y luego usar la notación de punto (`.`) para llamar al método.

```swift
let persona = Persona(nombre: "Juan")
persona.saludar() // Salida: ¡Hola, mi nombre es Juan!
```

# Métodos de Clase:
Los métodos de clase son aquellos que están asociados con la clase en sí, no con una instancia particular. Se definen utilizando la palabra clave `class` o `static`.

Ejemplo de un método de clase en una clase:

```swift
class Utilidades {
    class func suma(_ a: Int, _ b: Int) -> Int {
        return a + b
    }
}
```

En este ejemplo, hemos definido una clase `Utilidades` con un método de clase `suma(_:_:)`. El método `suma(_:_:)` toma dos argumentos de tipo `Int` y devuelve la suma de ambos.

Para llamar a un método de clase, utilizamos la notación de punto (`.`) con el nombre de la clase.

```swift
let resultado = Utilidades.suma(5, 3)
print(resultado) // Salida: 8
```

# Autenticadores y Mutadores:
Los métodos también se utilizan para realizar acciones más complejas, como autenticación y mutación de datos. Por ejemplo, en una clase de `Usuario`, podríamos tener un método para autenticar las credenciales y otro para cambiar la contraseña.

```swift
class Usuario {
    var nombreUsuario: String
    var contraseña: String

    init(nombreUsuario: String, contraseña: String) {
        self.nombreUsuario = nombreUsuario
        self.contraseña = contraseña
    }

    func autenticar(nombreUsuario: String, contraseña: String) -> Bool {
        return self.nombreUsuario == nombreUsuario && self.contraseña == contraseña
    }

    func cambiarContraseña(nuevaContraseña: String) {
        self.contraseña = nuevaContraseña
    }
}
```

En este ejemplo, hemos definido una clase `Usuario` con un método de instancia `autenticar(nombreUsuario:contraseña:)`, que verifica si las credenciales coinciden, y un método de instancia `cambiarContraseña(nuevaContraseña:)`, que permite cambiar la contraseña del usuario.

```swift
let usuario = Usuario(nombreUsuario: "juan123", contraseña: "secreto")

if usuario.autenticar(nombreUsuario: "juan123", contraseña: "secreto") {
    print("Usuario autenticado.")
} else {
    print("Credenciales inválidas.")
}

usuario.cambiarContraseña(nuevaContraseña: "nuevaclave")
```
