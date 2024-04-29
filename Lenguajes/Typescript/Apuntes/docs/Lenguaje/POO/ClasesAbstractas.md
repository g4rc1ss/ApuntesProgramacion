# Clases Abstracta

Una clase abstracta es una clase que no se puede instanciar directamente, pero se utiliza como una plantilla para otras clases derivadas. Se utiliza para definir una interfaz común y establecer un conjunto de métodos y propiedades que deben implementarse en las clases hijas.

```typescript
abstract class Vehiculo {
  protected marca: string;
  protected modelo: string;
  
  constructor(marca: string, modelo: string) {
    this.marca = marca;
    this.modelo = modelo;
  }
  
  abstract acelerar(): void;
  abstract frenar(): void;
  
  obtenerMarcaYModelo(): string {
    return `Marca: ${this.marca}, Modelo: ${this.modelo}`;
  }
}

class Coche extends Vehiculo {
  acelerar(): void {
    console.log("El coche está acelerando.");
  }
  
  frenar(): void {
    console.log("El coche está frenando.");
  }
}

class Moto extends Vehiculo {
  acelerar(): void {
    console.log("La moto está acelerando.");
  }
  
  frenar(): void {
    console.log("La moto está frenando.");
  }
}

// Uso de las clases
const coche = new Coche("Ford", "Focus");
coche.acelerar(); // Salida: El coche está acelerando.
coche.frenar(); // Salida: El coche está frenando.
console.log(coche.obtenerMarcaYModelo()); // Salida: Marca: Ford, Modelo: Focus

const moto = new Moto("Honda", "CBR");
moto.acelerar(); // Salida: La moto está acelerando.
moto.frenar(); // Salida: La moto está frenando.
console.log(moto.obtenerMarcaYModelo()); // Salida: Marca: Honda, Modelo: CBR
```

En el ejemplo, la clase `Vehiculo` es una clase abstracta que define propiedades (`marca` y `modelo`) y métodos (`acelerar` y `frenar`) que deben ser implementados en las clases hijas (`Coche` y `Moto`). La clase `Vehiculo` también proporciona un método `obtenerMarcaYModelo` que está implementado directamente en la clase abstracta y puede ser utilizado por las clases hijas.

Al definir una clase abstracta, se asegura que todas las clases hijas proporcionen una implementación consistente de los métodos requeridos. Además, se puede acceder a las propiedades y métodos comunes definidos en la clase abstracta a través de las instancias de las clases hijas.