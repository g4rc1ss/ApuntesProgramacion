Aquí tienes una explicación detallada sobre las clases estáticas con ejemplos:

# Propiedades Estáticas:
Para definir una propiedad estática en Swift, utiliza la palabra clave `static` antes de la declaración de la propiedad.

Ejemplo:

```swift
class MiClase {
    static var contador: Int = 0
}
```

En este ejemplo, hemos creado una propiedad estática llamada `contador` dentro de la clase `MiClase`. Esta propiedad estática pertenece a la clase en sí y no a ninguna instancia particular.

Para acceder a la propiedad estática, utilizamos la notación de punto (`.`) con el nombre de la clase.

```swift
MiClase.contador = 10
print(MiClase.contador) // Salida: 10
```

# Métodos Estáticos:
Para definir un método estático en Swift, también utiliza la palabra clave `static` antes de la declaración del método.

Ejemplo:

```swift
class MiClase {
    static func saludar() {
        print("¡Hola desde el método estático!")
    }
}
```

En este ejemplo, hemos creado un método estático llamado `saludar()` dentro de la clase `MiClase`.

Para llamar al método estático, nuevamente utilizamos la notación de punto (`.`) con el nombre de la clase.

```swift
MiClase.saludar() // Salida: ¡Hola desde el método estático!
```

# Utilidad de Clases Estáticas:
Las clases estáticas son útiles cuando deseas tener propiedades o métodos que se compartan entre todas las instancias de una clase o cuando no es necesario tener una instancia de la clase para acceder a ciertos miembros.

Un ejemplo común de uso de clases estáticas es cuando necesitas llevar un contador global para todas las instancias de una clase.

```swift
class Persona {
    static var contador: Int = 0

    var nombre: String

    init(nombre: String) {
        self.nombre = nombre
        Persona.contador += 1
    }
}
```

En este ejemplo, hemos creado una propiedad estática `contador` en la clase `Persona`, y cada vez que se crea una nueva instancia de `Persona`, se incrementa el contador global.

```swift
let persona1 = Persona(nombre: "Juan")
let persona2 = Persona(nombre: "Maria")

print(Persona.contador) // Salida: 2
```

Como puedes ver, el contador se incrementa con cada instancia creada.
