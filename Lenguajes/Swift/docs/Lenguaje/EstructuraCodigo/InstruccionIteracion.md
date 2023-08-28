# Bucle `for-in`:
El bucle `for-in` se utiliza para iterar sobre una secuencia de elementos, como un rango de números o una colección (por ejemplo, un array o un diccionario). El formato es el siguiente:

```swift
for elemento in secuencia {
    // Código a ejecutar para cada elemento
}
```

Ejemplo con un rango de números:

```swift
for i in 1...5 {
    print(i)
}
```

En este ejemplo, el bucle `for-in` itera desde 1 hasta 5 (ambos inclusive) e imprime cada número en una nueva línea.

Ejemplo con un array:

```swift
let frutas = ["manzana", "plátano", "naranja"]

for fruta in frutas {
    print("Me gusta la \(fruta)")
}
```

En este caso, el bucle `for-in` itera sobre cada elemento del array `frutas` e imprime una frase para cada fruta en la colección.

# Bucle `while`:
El bucle `while` se utiliza para repetir un bloque de código mientras una condición específica sea verdadera. La condición se verifica antes de cada iteración. El formato es el siguiente:

```swift
while condición {
    // Código a ejecutar mientras la condición sea verdadera
}
```

Ejemplo:

```swift
var contador = 1

while contador <= 5 {
    print(contador)
    contador += 1
}
```

En este ejemplo, el bucle `while` se ejecutará mientras `contador` sea menor o igual a 5. En cada iteración, se imprimirá el valor del contador y luego se incrementará en 1.

# Bucle `repeat-while`:
El bucle `repeat-while`, también conocido como bucle `do-while` en otros lenguajes, es similar al bucle `while`, pero la condición se verifica después de cada iteración. Esto garantiza que el bloque de código se ejecute al menos una vez. El formato es el siguiente:

```swift
repeat {
    // Código a ejecutar
} while condición
```

Ejemplo:

```swift
var x = 1

repeat {
    print(x)
    x += 1
} while x <= 5
```

En este ejemplo, el bucle `repeat-while` imprimirá el valor de `x` y lo incrementará en 1 en cada iteración hasta que `x` sea mayor que 5.

Recuerda tener cuidado al utilizar bucles para evitar bucles infinitos. Es importante asegurarse de que la condición cambie adecuadamente en cada iteración para que eventualmente el bucle termine.
