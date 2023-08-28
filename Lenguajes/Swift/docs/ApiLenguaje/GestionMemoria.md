# Referencias y Recuento de Referencias:
Cuando creas una instancia de una clase en Swift y asignas esa instancia a una variable o constante, estás creando una referencia a esa instancia. Cada referencia aumenta el recuento de referencias de la instancia en 1. Cuando la instancia ya no es accesible desde ninguna referencia, el recuento de referencias llega a cero y la instancia se libera automáticamente.

Ejemplo:

```swift
class Persona {
    let nombre: String
    
    init(nombre: String) {
        self.nombre = nombre
    }
}

var persona1: Persona? = Persona(nombre: "Juan")
var persona2: Persona? = persona1 // persona1 y persona2 ahora apuntan a la misma instancia

persona1 = nil // El recuento de referencias de la instancia se reduce a 1
persona2 = nil // El recuento de referencias llega a 0, la instancia se libera automáticamente
```

En este ejemplo, hemos creado una clase `Persona` con una propiedad `nombre`. Luego, hemos creado dos variables `persona1` y `persona2`, ambas apuntando a la misma instancia de `Persona`. Al establecer `persona1` y `persona2` como `nil`, reducimos el recuento de referencias a 0, lo que libera automáticamente la instancia.


# Ciclos de Referencia:
Los ciclos de referencia ocurren cuando dos o más objetos se mantienen referenciados mutuamente y, por lo tanto, su recuento de referencias nunca llega a cero, lo que provoca una fuga de memoria. Swift utiliza capturas débiles (weak) y sin retención (unowned) para resolver este problema.

Ejemplo:

```swift
class Persona {
    let nombre: String
    var amigo: Persona?
    
    init(nombre: String) {
        self.nombre = nombre
    }
}

var persona1: Persona? = Persona(nombre: "Juan")
var persona2: Persona? = Persona(nombre: "María")

persona1?.amigo = persona2
persona2?.amigo = persona1

persona1 = nil // El recuento de referencias de persona1 se reduce a 0, pero la instancia de persona2 aún está referenciada por la propiedad amigo
persona2 = nil // La instancia de persona2 aún está referenciada por la propiedad amigo de persona1, y viceversa, creando un ciclo de referencia y causando una fuga de memoria
```

En este ejemplo, hemos creado una clase `Persona` con una propiedad `amigo` que apunta a otra instancia de `Persona`. Al establecer `persona1` y `persona2` como `nil`, el recuento de referencias de las instancias de `Persona` se reduce a 0, pero la referencia mutua a través de la propiedad `amigo` crea un ciclo de referencia y evita que las instancias se liberen correctamente.

Para resolver este problema, podemos utilizar capturas débiles o sin retención en la propiedad `amigo`.

Ejemplo con captura débil:

```swift
class Persona {
    let nombre: String
    weak var amigo: Persona?
    
    init(nombre: String) {
        self.nombre = nombre
    }
}

var persona1: Persona? = Persona(nombre: "Juan")
var persona2: Persona? = Persona(nombre: "María")

persona1?.amigo = persona2
persona2?.amigo = persona1

persona1 = nil // La instancia de persona1 se libera automáticamente ya que la propiedad amigo es una captura débil
persona2 = nil // La instancia de persona2 se libera automáticamente ya que la propiedad amigo es una captura débil
```

Al utilizar una captura débil, permitimos que las instancias se liberen automáticamente cuando ya no son accesibles desde otras referencias.