# La estructura de una sentencia condicional
En Java, los condicionales se implementan con la estructura `if`, que evalúa una expresión booleana y ejecuta un bloque de código si la expresión es verdadera. Puedes añadir `else` para ejecutar un bloque alternativo si la expresión es falsa. Aquí tienes un ejemplo básico:
```java
int edad = 18;

if (edad >= 18) {
    System.out.println("Eres mayor de edad");
} else {
    System.out.println("Eres menor de edad");
}
```

# Operadores de comparación
Puedes usar operadores de comparación como `==` (igual a), `!=` (diferente de), `<` (menor que), `>` (mayor que), `<=` (menor o igual que) y `>=` (mayor o igual que) para evaluar condiciones.

# Operadores lógicos
Java también tiene operadores lógicos como `&&` (AND lógico), `||` (OR lógico) y `!` (NOT lógico) para combinar múltiples condiciones.

# Else if
Puedes usar `else if` para evaluar múltiples condiciones en secuencia:
```java
int nota = 85;

if (nota >= 90) {
    System.out.println("Tienes una A");
} else if (nota >= 80) {
    System.out.println("Tienes una B");
} else if (nota >= 70) {
    System.out.println("Tienes una C");
} else {
    System.out.println("Tienes una D");
}
```

# Operador ternario
El operador ternario `? :` es una forma concisa de expresar una condición y asignar valores en una sola línea:
```java
int edad = 20;
String mensaje = (edad >= 18) ? "Eres mayor de edad" : "Eres menor de edad";
System.out.println(mensaje);
```

# Switch
La estructura `switch` permite tomar decisiones basadas en el valor de una expresión. Cada `case` representa un posible valor, y se ejecutará el bloque de código correspondiente al valor coincidente:
```java
int dia = 3;

switch (dia) {
    case 1:
        System.out.println("Lunes");
        break;
    case 2:
        System.out.println("Martes");
        break;
    // ...
    default:
        System.out.println("Día no válido");
}
```