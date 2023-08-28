# Funciones Genéricas:
Una función genérica es aquella que utiliza uno o varios parámetros de tipo (placeholders) para trabajar con diferentes tipos de datos. Los parámetros de tipo se definen entre corchetes angulares `<T>`.

Ejemplo:

```swift
func intercambiar<T>(_ a: inout T, _ b: inout T) {
    let temp = a
    a = b
    b = temp
}

var a = 5
var b = 10
intercambiar(&a, &b)
print("a: \(a), b: \(b)") // Salida: "a: 10, b: 5"

var str1 = "Hola"
var str2 = "Mundo"
intercambiar(&str1, &str2)
print("str1: \(str1), str2: \(str2)") // Salida: "str1: Mundo, str2: Hola"
```

En este ejemplo, hemos definido una función genérica `intercambiar` que toma dos parámetros de tipo `T`. La función puede ser utilizada con cualquier tipo de dato, ya que se adaptará automáticamente al tipo específico proporcionado al llamarla.

# Clases Genéricas:
Las clases también pueden ser genéricas, lo que permite que trabajen con diferentes tipos de datos. Los parámetros de tipo en las clases se definen de manera similar a las funciones, usando corchetes angulares `<T>`.

Ejemplo:

```swift
class Pila<T> {
    var elementos: [T] = []

    func apilar(_ elemento: T) {
        elementos.append(elemento)
    }

    func desapilar() -> T? {
        return elementos.popLast()
    }
}

let pilaInt = Pila<Int>()
pilaInt.apilar(1)
pilaInt.apilar(2)
print(pilaInt.desapilar()) // Salida: Optional(2)

let pilaStr = Pila<String>()
pilaStr.apilar("Hola")
pilaStr.apilar("Mundo")
print(pilaStr.desapilar()) // Salida: Optional("Mundo")
```

En este ejemplo, hemos definido una clase genérica `Pila` que puede trabajar con cualquier tipo de dato `T`. Podemos crear instancias de `Pila` con diferentes tipos de datos y utilizar los métodos `apilar` y `desapilar` de manera transparente para esos tipos.

# Conformidad de Protocoles con Genéricos:
Los genéricos también se pueden usar en conformidad de protocolos. Esto nos permite crear protocolos genéricos que pueden ser adoptados por clases o estructuras específicas con diferentes tipos de datos.

Ejemplo:

```swift
protocol Imprimible {
    func imprimir()
}

class Caja<T>: Imprimible {
    var contenido: T

    init(contenido: T) {
        self.contenido = contenido
    }

    func imprimir() {
        print("Contenido: \(contenido)")
    }
}

let cajaInt = Caja(contenido: 42)
cajaInt.imprimir() // Salida: "Contenido: 42"

let cajaStr = Caja(contenido: "Hola")
cajaStr.imprimir() // Salida: "Contenido: Hola"
```

En este ejemplo, hemos definido un protocolo genérico `Imprimible` y una clase genérica `Caja` que adopta ese protocolo. La clase `Caja` puede trabajar con cualquier tipo de dato `T` que implemente el protocolo `Imprimible`, y automáticamente puede utilizar el método `imprimir`.
