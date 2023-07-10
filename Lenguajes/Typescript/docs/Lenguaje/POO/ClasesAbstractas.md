# Clases Abstracta

Las clases abstractas son clases que no se pueden instanciar directamente, sino que se utilizan como base para otras clases. Ejemplo:
```typescript
abstract class Figura {
    abstract calcularArea(): number;
}

class Rectangulo extends Figura {
    base: number;
    altura: number;

    calcularArea(): number {
        return this.base * this.altura;
    }
}

let rectangulo = new Rectangulo();
rectangulo.base = 4;
rectangulo.altura = 5;
console.log(rectangulo.calcularArea()); // Output: 20
```