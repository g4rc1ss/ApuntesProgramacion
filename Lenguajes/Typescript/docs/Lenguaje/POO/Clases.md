# Clases
Puedes definir clases en TypeScript para encapsular propiedades y métodos relacionados. Aquí tienes un ejemplo básico:
```typescript
class Persona {
    nombre: string;
    edad: number;

    constructor(nombre: string, edad: number) {
        this.nombre = nombre;
        this.edad = edad;
    }

    saludar() {
        console.log(`Hola, mi nombre es ${this.nombre}`);
    }
}

let persona = new Persona("Juan", 25);
persona.saludar(); // Output: Hola, mi nombre es Juan
```