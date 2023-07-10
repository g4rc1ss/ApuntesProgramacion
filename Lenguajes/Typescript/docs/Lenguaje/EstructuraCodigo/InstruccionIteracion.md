
1. **Bucle `for`**: El bucle `for` se utiliza para iterar sobre una secuencia de elementos con una cantidad de repeticiones específica. Aquí tienes un ejemplo de un bucle `for` que imprime los números del 1 al 5:

```typescript
for (let i = 1; i <= 5; i++) {
  console.log(i);
}
```

2. **Bucle `while`**: El bucle `while` se utiliza para repetir un bloque de código mientras una condición se evalúe como verdadera. Aquí tienes un ejemplo de un bucle `while` que imprime los números del 1 al 5:

```typescript
let i = 1;

while (i <= 5) {
  console.log(i);
  i++;
}
```

3. **Bucle `do...while`**: El bucle `do...while` es similar al bucle `while`, pero verifica la condición después de ejecutar el bloque de código, lo que garantiza que el bloque se ejecute al menos una vez. Aquí tienes un ejemplo de un bucle `do...while` que imprime los números del 1 al 5:

```typescript
let i = 1;

do {
  console.log(i);
  i++;
} while (i <= 5);
```

4. **Bucle `for...in`**: El bucle `for...in` se utiliza para iterar sobre las propiedades de un objeto. Aquí tienes un ejemplo de un bucle `for...in` que muestra las propiedades de un objeto:

```typescript
const obj = { a: 1, b: 2, c: 3 };

for (let prop in obj) {
  console.log(prop + ': ' + obj[prop]);
}
```

5. **Bucle `for...of`**: El bucle `for...of` se utiliza para iterar sobre elementos iterables, como arreglos o cadenas de texto. Aquí tienes un ejemplo de un bucle `for...of` que imprime los elementos de un arreglo:

```typescript
const arr = [1, 2, 3, 4, 5];

for (let element of arr) {
  console.log(element);
}
```