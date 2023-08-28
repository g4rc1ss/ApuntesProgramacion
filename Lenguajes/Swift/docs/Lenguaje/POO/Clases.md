Para definir una clase en Swift, utiliza la siguiente sintaxis:

```swift
class NombreDeLaClase {
    // Propiedades de la clase
    // Métodos de la clase
}
```

Ejemplo de una clase `Persona`:

```swift
class Persona {
    var nombre: String
    var edad: Int

    init(nombre: String, edad: Int) {
        self.nombre = nombre
        self.edad = edad
    }

    func saludar() {
        print("Hola, mi nombre es \(nombre) y tengo \(edad) años.")
    }
}
```

En este ejemplo, hemos definido una clase `Persona` con dos propiedades: `nombre` y `edad`, ambas de tipo `String` e `Int`, respectivamente. También hemos definido un método `saludar()` que imprime un mensaje de saludo con el nombre y la edad de la persona.

Para crear un objeto a partir de una clase, utilizamos la inicialización con el constructor (`init`) de la clase.

Ejemplo de creación de un objeto `Persona`:

```swift
let persona1 = Persona(nombre: "Juan", edad: 30)
```

En este ejemplo, hemos creado un objeto `persona1` a partir de la clase `Persona`, pasando los valores `"Juan"` y `30` para las propiedades `nombre` y `edad`, respectivamente.

Una vez que tienes un objeto, puedes acceder a sus propiedades y métodos utilizando la notación de punto (`.`).

Ejemplo de acceso a propiedades y método de un objeto `Persona`:

```swift
print(persona1.nombre) // Salida: "Juan"
print(persona1.edad) // Salida: 30

persona1.saludar() // Salida: "Hola, mi nombre es Juan y tengo 30 años."
```

Además de las propiedades y métodos, las clases también pueden tener variables de clase (usando la palabra clave `static`), métodos de clase, inicializadores de clase y más.

Es importante tener en cuenta que las clases son tipos de referencia, lo que significa que cuando asignas un objeto a una variable o constante, estás haciendo referencia al mismo objeto en memoria. Si modificas un objeto, se verá reflejado en todas las variables que lo hacen referencia.

Ejemplo de referencia a la misma instancia de una clase:

```swift
let persona2 = persona1

persona2.nombre = "Maria"

print(persona1.nombre) // Salida: "Maria"
```

En este ejemplo, hemos asignado `persona1` a `persona2`, y al cambiar el nombre de `persona2`, también se modifica el nombre de `persona1`, ya que ambas variables hacen referencia a la misma instancia de la clase `Persona`.
