# Propiedades
Las propiedades son variables asociadas a una clase. Pueden tener modificadores de acceso como `public`, `private` o `protected`.
```typescript
class Coche {
    private marca: string;

    constructor(marca: string) {
        this.marca = marca;
    }

    mostrarMarca() {
        console.log(this.marca);
    }
}

let coche = new Coche("Toyota");
coche.mostrarMarca(); // Output: Toyota
```