# Yield

La palabra clave `yield` se utiliza en una función generadora para pausar y reanudar la ejecución de la función en diferentes puntos. Permite generar una secuencia de valores que se pueden iterar de forma iterativa. Aquí tienes una explicación detallada sobre el uso de `yield` en TypeScript con un ejemplo:

```typescript
let index = 0;
function* generarNumeros(): IterableIterator<number> {

    while (index < 100) {
        index++;
        yield index;
    }
}


let generador : IteratorResult<number, any>;
do {
    generador = generarNumeros().next();

    console.log(generador.value);

} while (!generador.done);
```

En este ejemplo, definimos una función generadora `generarNumeros` utilizando la sintaxis `function*`. La función generadora utiliza la palabra clave `yield` para devolver valores en cada llamada y pausar su ejecución.

El uso de `yield` en TypeScript es útil cuando necesitas generar secuencias de valores de forma iterativa sin tener que generar todos los valores de una vez. Esto puede ser útil para tareas como el procesamiento de grandes conjuntos de datos, el beneficio mas destacable del uso de yield, es que al pausar la iteracion e ir elemento por elemento cada vez que se le es llamado, permite optimizar los recursos de memoria utilizada