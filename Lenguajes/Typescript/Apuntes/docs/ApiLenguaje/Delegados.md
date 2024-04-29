# Delegados

**Delegados o funciones anónimas:**

En TypeScript, puedes utilizar delegados o funciones anónimas para crear funciones sin nombre que se pueden utilizar en diferentes contextos. Los delegados o funciones anónimas se definen utilizando la sintaxis de funciones sin nombre. Aquí tienes un ejemplo básico:

```typescript
// Delegado o función anónima
const saludar = function (nombre: string): void {
  console.log(`¡Hola, ${nombre}!`);
};

// Llamada al delegado o función anónima
saludar('Juan'); // Salida: ¡Hola, Juan!
```

En este ejemplo, hemos creado un delegado o función anónima `saludar` que toma un argumento `nombre` de tipo `string` y muestra un saludo personalizado en la consola. Luego, llamamos al delegado o función anónima pasando el argumento `'Juan'`.

**Delegados como argumentos:**

Una forma común de utilizar delegados o funciones anónimas es pasarlos como argumentos a otras funciones. Esto permite definir comportamientos personalizados dentro de las funciones. Aquí tienes un ejemplo:

```typescript
function procesarDatos(datos: string[], procesador: (dato: string) => void): void {
  for (const dato of datos) {
    procesador(dato);
  }
}

const imprimirDato = function (dato: string): void {
  console.log(dato);
};

const datos = ['dato1', 'dato2', 'dato3'];

procesarDatos(datos, imprimirDato);
```

En este ejemplo, tenemos una función `procesarDatos` que toma un array de datos y una función `procesador` como argumentos. Dentro de `procesarDatos`, iteramos sobre cada dato y llamamos a la función `procesador` pasando el dato actual. Luego, definimos una función anónima `imprimirDato` que muestra el dato en la consola. Finalmente, llamamos a `procesarDatos` pasando el array de datos y la función `imprimirDato`.

**Delegados como valores de retorno:**

Otra forma útil de utilizar delegados o funciones anónimas es devolverlos como valores de otras funciones. Esto permite crear funciones que generan y devuelven comportamientos personalizados. Aquí tienes un ejemplo:

```typescript
function crearOperador(op: string): (a: number, b: number) => number {
  switch (op) {
    case '+':
      return function (a: number, b: number): number {
        return a + b;
      };
    case '-':
      return function (a: number, b: number): number {
        return a - b;
      };
    default:
      throw new Error('Operador no válido');
  }
}

const suma = crearOperador('+');
console.log(suma(3, 5)); // Salida: 8

const resta = crearOperador('-');
console.log(resta(10, 7)); // Salida: 3
```

En este ejemplo, tenemos una función `crearOperador` que toma un operador como argumento y devuelve una función anónima que realiza la operación correspondiente. Dependiendo del operador proporcionado, `crearOperador` devuelve una función de suma o resta. Luego, asignamos las funciones devueltas a las variables `suma` y `resta` y las utilizamos para realizar operaciones aritméticas.

**Consideraciones adicionales:**

Al utilizar delegados o funciones anónimas en TypeScript, ten en cuenta las siguientes consideraciones:

- Las funciones anónimas pueden capturar variables del ámbito externo en el que se definen. Esto se conoce como "cierre" (closure) y puede ser útil en determinadas situaciones, pero también debes tener cuidado con los posibles problemas de rendimiento y manejo de memoria.
- TypeScript te permite definir tipos para los delegados o funciones anónimas, lo que puede ayudar a garantizar un uso adecuado y una mejor comprensión del código.
