# Operadores Aritméticos
- `+`: Suma dos valores.
- `-`: Resta el segundo valor del primero.
- `*`: Multiplica dos valores.
- `/`: Divide el primer valor por el segundo.
- `%`: Devuelve el resto de la división del primer valor por el segundo.

```java
int a = 10;
int b = 3;
int suma = a + b;
int resta = a - b;
int multiplicacion = a * b;
int division = a / b;
int modulo = a % b;
```

# Operadores de Asignación
- `=`: Asigna un valor a una variable.
- `+=`, `-=`, `*=`, `/=`, `%=`: Realizan una operación y luego asignan el resultado a la variable.

```java
int x = 5;
x += 3; // x ahora es 8
x -= 2; // x ahora es 6
x *= 4; // x ahora es 24
x /= 3; // x ahora es 8
x %= 5; // x ahora es 3
```

# Operadores de Comparación
- `==`: Comprueba si dos valores son iguales.
- `!=`: Comprueba si dos valores son diferentes.
- `<`, `>`, `<=`, `>=`: Comprueban si un valor es menor, mayor, menor o igual, o mayor o igual que otro valor.

```java
int p = 10;
int q = 15;
boolean igual = p == q;   // false
boolean diferente = p != q; // true
boolean menorQue = p < q;  // true
boolean mayorQue = p > q;  // false
boolean menorIgual = p <= q; // true
boolean mayorIgual = p >= q; // false
```

# Operadores Lógicos
- `&&` (AND lógico): Devuelve verdadero si ambas condiciones son verdaderas.
- `||` (OR lógico): Devuelve verdadero si al menos una de las condiciones es verdadera.
- `!` (NOT lógico): Niega el valor de una condición.

```java
boolean a = true;
boolean b = false;
boolean resultadoAND = a && b; // false
boolean resultadoOR = a || b;  // true
boolean resultadoNOT = !a;     // false
```

# Operador Ternario
El operador ternario `? :` permite evaluar una condición y devolver un valor en función de la misma.

```java
int edad = 17;
String mensaje = (edad >= 18) ? "Eres mayor de edad" : "Eres menor de edad";
```

# Operadores de Incremento y Decremento
- `++`: Incrementa el valor de una variable en 1.
- `--`: Decrementa el valor de una variable en 1.

```java
int contador = 5;
contador++; // contador ahora es 6
contador--; // contador ahora es 5
```

Los operadores son fundamentales para realizar diversas operaciones en Java y forman la base para la construcción de expresiones y lógica en los programas.