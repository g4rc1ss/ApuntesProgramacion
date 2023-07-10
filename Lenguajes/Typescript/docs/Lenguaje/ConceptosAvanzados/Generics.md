Los genéricos en TypeScript son una característica que permite crear componentes y funciones reutilizables que pueden trabajar con diferentes tipos de datos sin perder información de tipo.

**Genéricos en clases:**
Puedes usar genéricos en clases para crear componentes reutilizables que funcionen con diferentes tipos de datos. Aquí tienes un ejemplo:

```typescript
class Caja<T> {
  contenido: T;
  
  constructor(contenido: T) {
    this.contenido = contenido;
  }
  
  obtenerContenido(): T {
    return this.contenido;
  }
}

const cajaDeTexto = new Caja<string>("Hola");
console.log(cajaDeTexto.obtenerContenido()); // Salida: Hola

const cajaDeNumero = new Caja<number>(42);
console.log(cajaDeNumero.obtenerContenido()); // Salida: 42
```

En este ejemplo, creamos una clase `Caja` que tiene un parámetro de tipo `T`. El parámetro de tipo se utiliza para definir el tipo del contenido de la caja. Dentro de la clase, podemos utilizar `T` como un tipo genérico para propiedades y métodos.

Luego, creamos una instancia de `Caja` utilizando diferentes tipos de datos: una caja de texto con el tipo `string` y una caja de número con el tipo `number`. Al llamar al método `obtenerContenido()`, obtenemos el contenido específico de cada caja correctamente tipado.

**Genéricos en funciones:**

También puedes usar genéricos en funciones para crear funciones reutilizables que trabajen con diferentes tipos de datos. Aquí tienes un ejemplo:

```typescript
function intercambiar<T>(a: T, b: T): [T, T] {
  return [b, a];
}

const resultado = intercambiar<string>("Hola", "Mundo");
console.log(resultado); // Salida: ["Mundo", "Hola"]
```

En este ejemplo, creamos una función `intercambiar` que tiene un parámetro de tipo `T` y devuelve un array de tipo `[T, T]`. El parámetro de tipo `T` se utiliza para definir el tipo de los argumentos de la función y el tipo del array devuelto.

Luego, llamamos a la función `intercambiar` con tipos de datos `string` y obtenemos un array con los elementos intercambiados.