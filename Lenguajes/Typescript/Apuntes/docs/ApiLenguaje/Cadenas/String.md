Los strings son utilizados para representar texto y se consideran un tipo de dato primitivo. Los strings pueden contener caracteres alfanuméricos, espacios, símbolos y otros caracteres especiales. 

**Declaración de strings:**

Puedes declarar strings utilizando comillas simples (`'`) o comillas dobles (`"`). Aquí tienes un ejemplo:

```typescript
let mensaje: string = "Hola";
let nombre: string = 'Juan';
```

En el ejemplo, declaramos las variables `mensaje` y `nombre` como strings utilizando comillas dobles y comillas simples, respectivamente.

**Concatenación de strings:**

Puedes concatenar strings utilizando el operador `+` o el método `concat()`. Aquí tienes un ejemplo:

```typescript
let saludo: string = "Hola";
let nombre: string = "Juan";
let mensaje: string = saludo + ", " + nombre;
console.log(mensaje); // Salida: Hola, Juan

let mensajeConcatenado: string = saludo.concat(", ", nombre);
console.log(mensajeConcatenado); // Salida: Hola, Juan
```

En el ejemplo, concatenamos los strings `saludo` y `nombre` utilizando el operador `+` y el método `concat()`, respectivamente. El resultado es el mismo en ambos casos: "Hola, Juan".

**Métodos comunes de strings:**

Existen varios métodos disponibles para manipular y trabajar con strings en TypeScript. Aquí tienes algunos métodos comunes:

- `length`: Devuelve la longitud del string.
- `charAt(index)`: Devuelve el carácter en la posición especificada por el índice.
- `substring(startIndex, endIndex)`: Devuelve una subcadena del string, desde la posición `startIndex` hasta `endIndex`.
- `toUpperCase()`: Convierte el string a mayúsculas.
- `toLowerCase()`: Convierte el string a minúsculas.
- `trim()`: Elimina los espacios en blanco al inicio y al final del string.
- `split(delimiter)`: Divide el string en un array de subcadenas, utilizando `delimiter` como separador.

Aquí tienes un ejemplo que muestra el uso de algunos de estos métodos:

```typescript
let mensaje: string = "   Hola, Juan   ";
console.log(mensaje.length); // Salida: 15
console.log(mensaje.charAt(0)); // Salida: " "
console.log(mensaje.substring(6, 10)); // Salida: "Juan"
console.log(mensaje.toUpperCase()); // Salida: "   HOLA, JUAN   "
console.log(mensaje.toLowerCase()); // Salida: "   hola, juan   "
console.log(mensaje.trim()); // Salida: "Hola, Juan"
console.log(mensaje.split(", ")); // Salida: ["Hola", "Juan"]
```
