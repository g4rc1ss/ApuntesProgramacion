**Consultas a colecciones con JavaScript incorporado:**
JavaScript proporciona una serie de métodos y funciones incorporados que puedes utilizar para realizar consultas en colecciones, como `filter()`, `map()`, `reduce()`, `find()`, `some()`, `every()`, etc. Aquí tienes un ejemplo que muestra cómo utilizar algunos de estos métodos:

```typescript
const numeros = [1, 2, 3, 4, 5];

const numerosPares = numeros.filter((numero) => numero % 2 === 0);
console.log(numerosPares); // Salida: [2, 4]

const numerosMultiplicados = numeros.map((numero) => numero * 2);
console.log(numerosMultiplicados); // Salida: [2, 4, 6, 8, 10]

const sumaTotal = numeros.reduce((acumulador, numero) => acumulador + numero, 0);
console.log(sumaTotal); // Salida: 15

const numeroEncontrado = numeros.find((numero) => numero === 3);
console.log(numeroEncontrado); // Salida: 3

const hayNumerosNegativos = numeros.some((numero) => numero < 0);
console.log(hayNumerosNegativos); // Salida: false

const todosSonPositivos = numeros.every((numero) => numero > 0);
console.log(todosSonPositivos); // Salida: true
```