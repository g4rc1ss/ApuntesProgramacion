 # Métodos
 En TypeScript, los métodos son funciones dentro de una clase que pueden realizar ciertas acciones o cálculos. Aquí tienes un ejemplo:
```typescript
class Calculadora {
    sumar(a: number, b: number): number {
        return a + b;
    }
}

let calculadora = new Calculadora();
console.log(calculadora.sumar(3, 4)); // Output: 7
```