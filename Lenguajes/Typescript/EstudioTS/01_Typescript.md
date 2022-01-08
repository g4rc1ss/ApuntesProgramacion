# Estructura del código

```Typescript
namespace Prueba {
    import { Clase } from "./EspacioNombres/";
    /*
    *
    */   
}
```
- ``namespace`` -> indica la ubicación del programa

- ``import`` -> Para importar librerías y módulos

---
## Declaración de variables
```Typescript
let cadena: string = "";
let numero: number = 0;
let booleano: boolean = true;
let sinTipo: any;
```


# Programación Orientada a Objetos

## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Typescript
class Clase {
    nombre: string;
    apellidos: string;

    constructor(nombre: string, apellidos: string) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }

    nombreFuncion(): void {
        // Code
    }

    nombreRetorno(): string {
        return "";
    }
}
```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```Typescript
interface Gato {
    nombre: string;
    raza: string;
    color: string;
}
```

---
## Type
Un type nos permite definir el tipo de dato que vamos a usar en nuestras propiedades y métodos; pero a diferencia de las interfaces no podemos extender un type, ni ampliar sus capacidades. Pero si podemos declarar tipos personalizados y puede tener varios tipos de datos.

```Typescript
type Gato = {
    nombre: string;
    raza: string;
    color: string;
}
```
