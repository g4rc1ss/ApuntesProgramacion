# Bucle `for`
El bucle `for` se utiliza para ejecutar un bloque de código un número específico de veces. Tiene tres partes: la inicialización, la condición y la expresión de actualización. Aquí tienes un ejemplo:
```java
for (int i = 1; i <= 5; i++) {
    System.out.println("Iteración " + i);
}
```

# Bucle `while`
El bucle `while` se ejecuta mientras una condición específica sea verdadera. El bloque de código se repetirá mientras la condición sea cierta. Aquí tienes un ejemplo:
```java
int contador = 1;
while (contador <= 5) {
    System.out.println("Iteración " + contador);
    contador++;
}
```

# Bucle `do-while`
El bucle `do-while` es similar al bucle `while`, pero garantiza que el bloque de código se ejecute al menos una vez, ya que la condición se verifica al final del bucle. Aquí tienes un ejemplo:
```java
int contador = 1;
do {
    System.out.println("Iteración " + contador);
    contador++;
} while (contador <= 5);
```

# Instrucción `break`
La instrucción `break` se utiliza para salir de un bucle antes de que se complete su ciclo normal. Puede usarse para detener un bucle en función de una condición específica.

# Instrucción `continue`
La instrucción `continue` se utiliza para saltar a la siguiente iteración del bucle, omitiendo el resto del bloque de código para esa iteración en particular.

# Ejemplo de bucle con arreglo
```java
int[] numeros = { 1, 2, 3, 4, 5 };
for (int num : numeros) {
    System.out.println(num);
}
```

En este ejemplo, el bucle `for-each` recorre cada elemento del arreglo `numeros` e imprime su valor.