# Atributos Incorporados:
Swift tiene algunos atributos incorporados que puedes utilizar en tu código.

- `@available`: Indica la disponibilidad de una clase, propiedad o método en una versión específica de iOS o macOS.

```swift
@available(iOS 15, *)
func newFeature() {
    // Código de una nueva función disponible en iOS 15 y versiones posteriores
}
```

- `@discardableResult`: Indica que el resultado de una función puede ser ignorado sin generar advertencias.

```swift
@discardableResult
func doSomething() -> Int {
    // Realiza alguna operación y devuelve un valor
    return 42
}

let result = doSomething() // Ignorar el resultado no generará advertencias
```

# Atributos de Propiedades:
Los atributos también se pueden aplicar a propiedades, permitiendo configurar su comportamiento.

- `@IBOutlet`: Utilizado en la interfaz de usuario (Storyboard o XIB) para enlazar una propiedad a una vista.

```swift
class ViewController: UIViewController {
    @IBOutlet weak var nameLabel: UILabel!
    @IBOutlet weak var ageLabel: UILabel!
}
```

- `@lazy`: Indica que la propiedad se inicializará solo cuando sea accedida por primera vez.

```swift
class MiClase {
    @lazy var someProperty: Int = {
        // Código para inicializar la propiedad
        return 42
    }()
}
```

# Atributos de Acceso y Mutación:
Los atributos también se pueden aplicar a los métodos de acceso (getters) y mutación (setters) de una propiedad.

- `@getter`: Permite especificar un nombre personalizado para el método getter.

```swift
class MiClase {
    var someProperty: Int {
        @getter(getPropertyValue) get {
            return 42
        }
    }
}
```

- `@setter`: Permite especificar un nombre personalizado para el método setter.

```swift
class MiClase {
    var someProperty: Int {
        @setter(setPropertyValue) get {
            return 42
        }
    }
}
```

# Atributos Personalizados:
También puedes crear tus propios atributos personalizados utilizando la notación `@propertyWrapper`.

```swift
@propertyWrapper
struct MyWrapper {
    private var value: Int
    
    init(wrappedValue: Int) {
        self.value = wrappedValue
    }
    
    var wrappedValue: Int {
        get { return value }
        set { value = newValue }
    }
}

class MyClass {
    @MyWrapper var number: Int = 42
}

let obj = MyClass()
print(obj.number) // Salida: 42
obj.number = 24
print(obj.number) // Salida: 24
```

En este ejemplo, hemos creado un atributo personalizado `@MyWrapper` que envuelve una propiedad y le agrega funcionalidad adicional.
