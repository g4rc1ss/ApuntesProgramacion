# Covarianza:
La covarianza se refiere a la relación de subtipo entre dos tipos, donde un tipo derivado (subtipo) puede ser utilizado en lugar de su tipo base (supertipo) sin necesidad de conversión explícita. En otras palabras, un tipo covariante es aquel que se puede sustituir por su tipo base.

Ejemplo de covarianza:

```swift
class Animal { }
class Perro: Animal { }

func obtenerAnimales() -> [Animal] {
    return [Perro(), Perro(), Animal()]
}

let animales: [Animal] = obtenerAnimales()
```

En este ejemplo, tenemos una jerarquía de clases `Animal` y `Perro`, donde `Perro` es una subclase de `Animal`. La función `obtenerAnimales()` devuelve un array de tipo `[Animal]`, pero en realidad, devuelve instancias de `Perro` y `Animal`. Al asignar el resultado de `obtenerAnimales()` a una variable de tipo `[Animal]`, se demuestra la covarianza, ya que podemos usar instancias de `Perro` como si fueran instancias de `Animal` sin necesidad de conversión explícita.

# Contravarianza:
La contravarianza se refiere a la relación de subtipo en sentido inverso, donde un tipo derivado (subtipo) puede ser utilizado como argumento en lugar de su tipo base (supertipo) en una función, permitiendo una mayor flexibilidad en los argumentos.

Ejemplo de contravarianza:

```swift
class Animal {
    func hacerSonido() {
        print("Un animal hace un sonido.")
    }
}

class Perro: Animal {
    override func hacerSonido() {
        print("El perro ladra.")
    }
}

func hacerSonidoDeAnimal(_ animal: Animal) {
    animal.hacerSonido()
}

let perro: Perro = Perro()
hacerSonidoDeAnimal(perro) // Salida: "El perro ladra."
```

En este ejemplo, tenemos las clases `Animal` y `Perro`, y una función `hacerSonidoDeAnimal(_:)` que acepta un argumento de tipo `Animal`. Sin embargo, podemos pasar una instancia de `Perro` como argumento, lo que muestra la contravarianza, ya que el argumento es un subtipo de `Animal`, lo que nos permite proporcionar una mayor flexibilidad en los argumentos.
