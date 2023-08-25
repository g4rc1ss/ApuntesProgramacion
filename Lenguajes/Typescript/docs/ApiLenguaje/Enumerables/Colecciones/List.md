Las listas son estructuras de datos que te permiten almacenar y manipular una colección ordenada de elementos. Hay varias formas de representar y trabajar con listas en TypeScript, como utilizando arrays y la clase `Array`

**Arrays y la clase `Array`:**

En TypeScript, los arrays son la forma más común de representar y trabajar con listas. Puedes declarar un array utilizando la sintaxis `tipo[]` o la clase `Array<tipo>`. Aquí tienes un ejemplo:

```typescript
// Declaración de un array de números
let numeros: number[] = [1, 2, 3, 4, 5];

// Declaración de un array de strings utilizando la clase Array
let palabras: Array<string> = ["Hola", "Mundo"];
```

En este ejemplo, declaramos un array de números utilizando la sintaxis `number[]` y un array de strings utilizando la clase `Array<string>`. Ambos arrays están inicializados con valores.

Puedes realizar varias operaciones con los arrays, como acceder a los elementos por índice, agregar elementos, eliminar elementos y recorrer los elementos utilizando bucles. Aquí tienes algunos ejemplos:

```typescript
let numeros: number[] = [1, 2, 3, 4, 5];

console.log(numeros[0]); // Salida: 1
numeros.push(6);
console.log(numeros); // Salida: [1, 2, 3, 4, 5, 6]
numeros.pop();
console.log(numeros); // Salida: [1, 2, 3, 4, 5]
numeros.forEach((numero) => {
  console.log(numero);
});
```

En este ejemplo, accedemos al primer elemento del array utilizando `numeros[0]`, agregamos un nuevo elemento al final del array utilizando `push()`, eliminamos el último elemento del array utilizando `pop()`, y recorremos los elementos del array utilizando `forEach()`.
