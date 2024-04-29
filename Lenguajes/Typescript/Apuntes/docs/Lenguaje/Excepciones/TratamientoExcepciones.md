# Excepciones

**Control de excepciones con bloques try-catch:**

En TypeScript, puedes usar bloques `try-catch` para envolver el código que podría generar una excepción y capturarla para manejarla adecuadamente. Aquí tienes un ejemplo:

```typescript
try {
    // Código que puede lanzar una excepción
    throw new Error("Ocurrió un error");
  } catch (error : any) {
    // Manejo de la excepción
    console.log("Se produjo una excepción:", error.message);
  }
```

En el ejemplo, el bloque `try` envuelve el código que puede generar una excepción, en este caso, se lanza un nuevo objeto `Error` con un mensaje. Si se produce una excepción, el bloque `catch` se ejecutará y se capturará el objeto de excepción en la variable `error`. Luego, puedes realizar el manejo de la excepción, como imprimir el mensaje de error.

**Creación de una excepción personalizada:**

Puedes crear tu propia excepción personalizada en TypeScript mediante la creación de una clase que extienda la clase base `Error`. Aquí tienes un ejemplo:

```typescript
class MiExcepcion extends Error {
    constructor(mensaje: string) {
      super(mensaje);
      this.name = "MiExcepcion";
    }
  }
  
  function lanzarExcepcion(): void {
    throw new MiExcepcion("Ocurrió un error personalizado");
  }
  
  try {
    lanzarExcepcion();
  } catch (error: any) {
    if (error instanceof MiExcepcion) {
      console.log("Se produjo una excepción personalizada:", error.message);
    } else {
      console.log("Se produjo una excepción:", error.message);
    }
  }
```

En este ejemplo, creamos una clase `MiExcepcion` que extiende la clase base `Error`. La clase personalizada tiene un constructor que acepta un mensaje de error y llama al constructor de la clase base utilizando `super(mensaje)`. También establecemos la propiedad `name` de la excepción personalizada como "MiExcepcion".

La función `lanzarExcepcion()` lanza una instancia de `MiExcepcion` con un mensaje personalizado.

En el bloque `try-catch`, intentamos ejecutar `lanzarExcepcion()`. Si se produce una excepción de tipo `MiExcepcion`, la capturamos en el bloque `catch` y realizamos un manejo específico para esa excepción personalizada. Si se produce una excepción de otro tipo, realizamos un manejo genérico.