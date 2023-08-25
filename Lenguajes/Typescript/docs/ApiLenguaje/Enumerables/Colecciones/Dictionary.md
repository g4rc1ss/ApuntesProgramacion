Los diccionarios o tablas hash se usan para almacenar pares clave-valor. Los diccionarios son estructuras de datos que te permiten acceder rápidamente a un valor utilizando una clave única.

**Declaración de un diccionario:**

Puedes declarar un diccionario en TypeScript utilizando la siguiente sintaxis:

```typescript
let diccionario: { [clave: TipoClave]: TipoValor } = {};
```

En esta declaración, `[clave: TipoClave]` representa el tipo de la clave y `TipoValor` representa el tipo del valor asociado a esa clave. Aquí tienes un ejemplo:

```typescript
let edades: { [nombre: string]: number } = {};
```

En este ejemplo, hemos declarado un diccionario llamado `edades`, donde la clave es una cadena (`nombre`) y el valor asociado a cada clave es un número (`number`).

**Asignación y acceso a valores:**

Puedes asignar y acceder a valores en un diccionario utilizando la sintaxis de corchetes `[]`. Aquí tienes un ejemplo:

```typescript
let edades: { [nombre: string]: number } = {};

edades["Juan"] = 30;
edades["María"] = 25;

console.log(edades["Juan"]); // Salida: 30
console.log(edades["María"]); // Salida: 25
```

En este ejemplo, asignamos valores al diccionario `edades` utilizando las claves "Juan" y "María". Luego, accedemos a los valores asociados a esas claves utilizando la sintaxis de corchetes `[]`.

**Recorrido de un diccionario:**

Puedes recorrer un diccionario utilizando bucles `for...in`. Aquí tienes un ejemplo:

```typescript
let edades: { [nombre: string]: number } = {
  "Juan": 30,
  "María": 25,
  "Pedro": 35
};

for (let nombre in edades) {
  console.log(nombre + " tiene " + edades[nombre] + " años.");
}
```

En este ejemplo, utilizamos un bucle `for...in` para recorrer el diccionario `edades`. En cada iteración, accedemos al nombre y la edad asociada a través de la clave `nombre` y `edades[nombre]`.

**Verificación de existencia de una clave:**

Puedes verificar si una clave existe en un diccionario utilizando el operador `in` o el método `hasOwnProperty()`. Aquí tienes un ejemplo:

```typescript
let edades: { [nombre: string]: number } = {
  "Juan": 30,
  "María": 25
};

console.log("Juan" in edades); // Salida: true
console.log("Pedro" in edades); // Salida: false

console.log(edades.hasOwnProperty("Juan")); // Salida: true
console.log(edades.hasOwnProperty("Pedro")); // Salida: false
```

En este ejemplo, utilizamos el operador `in` y el método `hasOwnProperty()` para verificar si las claves "Juan" y "Pedro" existen en el diccionario `edades`.

Los diccionarios o tablas hash son útiles cuando necesitas almacenar y acceder a valores utilizando claves únicas. Puedes utilizarlos para organizar y acceder a datos de manera eficiente.