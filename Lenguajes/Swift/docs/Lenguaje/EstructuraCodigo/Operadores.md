# Operadores Aritméticos:
Los operadores aritméticos se utilizan para realizar operaciones matemáticas básicas.

- Suma `+`: Suma dos valores.

```swift
let a = 10
let b = 5
let suma = a + b // resultado: 15
```

- Resta `-`: Resta un valor de otro.

```swift
let a = 10
let b = 5
let resta = a - b // resultado: 5
```

- Multiplicación `*`: Multiplica dos valores.

```swift
let a = 10
let b = 5
let multiplicacion = a * b // resultado: 50
```

- División `/`: Divide un valor por otro.

```swift
let a = 10
let b = 5
let division = a / b // resultado: 2
```

- Módulo `%`: Devuelve el resto de la división de dos valores.

```swift
let a = 10
let b = 3
let modulo = a % b // resultado: 1
```

# Operadores de Asignación:
Los operadores de asignación se utilizan para asignar valores a variables.

- Asignación `=`: Asigna un valor a una variable.

```swift
var edad = 25
```

- Operadores Compuestos: Son una combinación de un operador aritmético y de asignación.

```swift
var a = 5
a += 3 // es igual a: a = a + 3, resultado: 8
```

# Operadores de Comparación:
Los operadores de comparación se utilizan para comparar dos valores y devuelven un valor booleano (verdadero o falso).

- Igual `==`: Comprueba si dos valores son iguales.

```swift
let a = 10
let b = 10
let esIgual = a == b // resultado: true
```

- Distinto `!=`: Comprueba si dos valores son diferentes.

```swift
let a = 5
let b = 10
let esDistinto = a != b // resultado: true
```

- Mayor que `>` y Menor que `<`: Comprueban si un valor es mayor o menor que otro.

```swift
let a = 5
let b = 10
let esMayor = b > a // resultado: true
let esMenor = a < b // resultado: true
```

- Mayor o igual que `>=` y Menor o igual que `<=`: Comprueban si un valor es mayor o igual, o menor o igual que otro.

```swift
let a = 5
let b = 10
let esMayorOIgual = b >= a // resultado: true
let esMenorOIgual = a <= b // resultado: true
```

# Operadores Lógicos:
Los operadores lógicos se utilizan para combinar expresiones lógicas y devuelven un valor booleano.

- AND `&&`: Devuelve verdadero si ambas expresiones son verdaderas.

```swift
let a = true
let b = false
let resultado = a && b // resultado: false
```

- OR `||`: Devuelve verdadero si al menos una de las expresiones es verdadera.

```swift
let a = true
let b = false
let resultado = a || b // resultado: true
```

- NOT `!`: Invierte el valor de una expresión.

```swift
let a = true
let resultado = !a // resultado: false
```