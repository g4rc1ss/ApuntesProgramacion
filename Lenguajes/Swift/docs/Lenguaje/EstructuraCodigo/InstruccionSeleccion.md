
# Estructura `if`:
La estructura `if` se utiliza para ejecutar un bloque de código solo si la condición especificada es verdadera. El formato es el siguiente:

```swift
if condición {
    // Código a ejecutar si la condición es verdadera
}
```

Ejemplo:

```swift
var edad = 20

if edad >= 18 {
    print("Eres mayor de edad")
}
```

En este ejemplo, si la variable `edad` es mayor o igual a 18, se imprimirá "Eres mayor de edad".

# Estructura `else if`:
La estructura `else if` se utiliza para agregar más condiciones a evaluar si la primera condición no es verdadera. Puedes usar tantas cláusulas `else if` como necesites. El formato es el siguiente:

```swift
if condición1 {
    // Código a ejecutar si la condición1 es verdadera
} else if condición2 {
    // Código a ejecutar si la condición2 es verdadera
} else {
    // Código a ejecutar si ninguna de las condiciones anteriores es verdadera
}
```

Ejemplo:

```swift
var calificación = 85

if calificación >= 90 {
    print("Excelente")
} else if calificación >= 80 {
    print("Buen trabajo")
} else {
    print("Necesitas mejorar")
}
```

En este ejemplo, si la variable `calificación` es mayor o igual a 90, se imprimirá "Excelente". Si es mayor o igual a 80 pero menor que 90, se imprimirá "Buen trabajo". De lo contrario, se imprimirá "Necesitas mejorar".

# Estructura `else`:
La estructura `else` se utiliza como una última opción en una estructura condicional. Se ejecutará si ninguna de las condiciones anteriores es verdadera. No lleva una condición explícita, ya que se ejecuta en cualquier otro caso. El formato es el siguiente:

```swift
if condición {
    // Código a ejecutar si la condición es verdadera
} else {
    // Código a ejecutar si la condición es falsa
}
```

Ejemplo:

```swift
var hora = 14

if hora < 12 {
    print("Buenos días")
} else {
    print("Buenas tardes")
}
```

En este ejemplo, si la variable `hora` es menor que 12, se imprimirá "Buenos días". De lo contrario, se imprimirá "Buenas tardes".
