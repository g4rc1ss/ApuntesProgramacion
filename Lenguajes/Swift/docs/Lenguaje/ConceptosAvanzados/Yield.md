# Secuencias (Sequences):
En Swift, las secuencias son una forma de representar una serie de valores que pueden ser generados uno a la vez. Las secuencias son comúnmente representadas por tipos que implementan el protocolo `Sequence`.

Ejemplo:

```swift
struct Contador: Sequence {
    let limite: Int

    func makeIterator() -> ContadorIterator {
        return ContadorIterator(limite: limite)
    }
}

struct ContadorIterator: IteratorProtocol {
    let limite: Int
    var contador: Int

    init(limite: Int) {
        self.limite = limite
        contador = 0
    }

    mutating func next() -> Int? {
        guard contador < limite else {
            return nil
        }
        let valor = contador
        contador += 1
        return valor
    }
}

let miContador = Contador(limite: 5)
for numero in miContador {
    print(numero)
}
```

En este ejemplo, hemos creado una secuencia `Contador` que genera números enteros desde 0 hasta un límite específico. La secuencia implementa el protocolo `Sequence`, y la función `makeIterator()` retorna un iterador (implementado por `ContadorIterator`) que se encarga de generar los valores de la secuencia.

# Generadores (Generators):
Los generadores son una forma de implementar secuencias y proporcionar valores bajo demanda. Puedes pensar en ellos como una manera de simular el comportamiento de `yield` en otros lenguajes de programación.

Ejemplo:

```swift
func contador(limite: Int) -> AnyIterator<Int> {
    var contador = 0
    return AnyIterator {
        defer { contador += 1 }
        return contador < limite ? contador : nil
    }
}

let miContador = contador(limite: 5)
for numero in miContador {
    print(numero)
}
```

En este ejemplo, hemos definido una función `contador(limite:)` que retorna un generador (`AnyIterator<Int>`) que genera números enteros desde 0 hasta un límite específico. La función del generador es invocada cada vez que se necesita un nuevo valor, y podemos pausar y reanudar la generación de valores de manera similar a cómo lo haría `yield`.
