# Variables:

1. **Variables con `let`**: La palabra clave `let` se utiliza para declarar variables que pueden cambiar de valor. Puedes declarar una variable utilizando `let` seguido del nombre de la variable y, opcionalmente, asignarle un valor. Por ejemplo:

```typescript
let nombre: string = 'Juan';
let edad: number = 25;
let estaActivo: boolean = true;
```

Puedes modificar el valor de una variable declarada con `let` en cualquier momento:

```typescript
let contador: number = 0;
contador = contador + 1;
console.log(contador); // Output: 1
```

2. **Variables con `const`**: La palabra clave `const` se utiliza para declarar variables cuyo valor no puede cambiar una vez asignado.

```typescript
const PI: number = 3.14;
const SALUDO: string = 'Hola';
```

Intentar modificar el valor de una variable declarada con `const` generará un error en tiempo de compilación:

```typescript
const edad: number = 25;
edad = 30; // Error: No se puede asignar un nuevo valor a una variable constante
```

Es importante tener en cuenta que `const` no hace que el valor de la variable sea inmutable, sino que evita la reasignación de la variable completa.

3. **Inferencia de tipo**: TypeScript también admite la inferencia de tipo

```typescript
let nombre = 'Juan'; // TypeScript infiere que la variable es de tipo string
let edad = 25; // TypeScript infiere que la variable es de tipo number
let estaActivo = true; // TypeScript infiere que la variable es de tipo boolean
```