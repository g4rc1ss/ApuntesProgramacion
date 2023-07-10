La combinación de `async` y `await` en TypeScript proporciona una forma más sencilla y legible de trabajar con código asincrónico basado en promesas. `async` y `await` son palabras clave que te permiten escribir código asincrónico de forma síncrona, evitando el anidamiento excesivo de callbacks y mejorando la legibilidad del código.

**Uso de `async` y `await`:**

1. `async`: La palabra clave `async` se utiliza para declarar una función asincrónica. Cuando una función se declara como `async`, significa que la función devuelve una promesa implícita. Dentro de una función `async`, puedes utilizar la palabra clave `await` para esperar a que se resuelva una promesa antes de continuar la ejecución. Aquí tienes un ejemplo de una función asincrónica:

```typescript
async function obtenerDatos(): Promise<number> {
  return new Promise<number>((resolve) => {
    setTimeout(() => {
      resolve(42);
    }, 1000);
  });
}
```

En este ejemplo, la función `obtenerDatos()` es una función asincrónica que devuelve una promesa que se resuelve con el número `42`. El código dentro de la función asincrónica se ejecuta de forma síncrona, pero puedes utilizar `await` para esperar a que se resuelva la promesa dentro de la función.

2. `await`: La palabra clave `await` solo se puede utilizar dentro de una función `async`. Se utiliza para esperar a que una promesa se resuelva antes de continuar la ejecución. Cuando se encuentra una expresión `await`, la función `async` se pausa y espera hasta que la promesa se resuelva antes de continuar con la siguiente línea de código. Aquí tienes un ejemplo de cómo utilizar `await` dentro de una función `async`:

```typescript
async function obtenerResultado(): Promise<number> {
  const resultado = await obtenerDatos();
  console.log(resultado);
  return resultado * 2;
}

obtenerResultado().then((valor) => {
  console.log(valor); // Salida: 84
});
```

En este ejemplo, la función `obtenerResultado()` es una función `async` que utiliza `await` para esperar a que se resuelva la promesa devuelta por la función `obtenerDatos()`. Después de que la promesa se resuelva, se imprime el resultado y se devuelve el valor multiplicado por 2.

**Beneficios de `async` y `await`:**

- Legibilidad mejorada: `async` y `await` permiten escribir código asincrónico de manera similar a código síncrono, lo que mejora la legibilidad y reduce el anidamiento excesivo de callbacks.
- Manejo de errores simplificado: Puedes utilizar `try...catch` para manejar errores en el código asincrónico, lo que facilita la gestión de errores y el flujo de control.
- Cadena de promesas: Puedes encadenar fácilmente múltiples llamadas asincrónicas utilizando `await`, lo que permite un código más limpio y mantenible.
