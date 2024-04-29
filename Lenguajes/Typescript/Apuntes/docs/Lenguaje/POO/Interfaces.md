# Interfaces

Las interfaces se utilizan para definir la estructura de un objeto. Proporcionan una forma de describir los tipos de propiedades y métodos que debe tener un objeto, sin implementar ninguna lógica real.

```typescript
interface Animal {
  nombre: string;
  hacerSonido(): void;
}

class Perro implements Animal {
  nombre: string;
  
  constructor(nombre: string) {
    this.nombre = nombre;
  }
  
  hacerSonido(): void {
    console.log("Guau guau!");
  }
}

class Gato implements Animal {
  nombre: string;
  
  constructor(nombre: string) {
    this.nombre = nombre;
  }
  
  hacerSonido(): void {
    console.log("Miau!");
  }
}

// Uso de las interfaces
const perro: Animal = new Perro("Firulais");
perro.hacerSonido(); // Salida: Guau guau!

const gato: Animal = new Gato("Garfield");
gato.hacerSonido(); // Salida: Miau!
```

En el ejemplo, la interfaz `Animal` define la estructura que deben tener los objetos que se consideren animales. La interfaz especifica que debe haber una propiedad `nombre` de tipo `string` y un método `hacerSonido()` sin argumentos y sin valor de retorno.

Las clases `Perro` y `Gato` implementan la interfaz `Animal` al proporcionar una implementación para todas las propiedades y métodos requeridos. Esto significa que deben tener una propiedad `nombre` y un método `hacerSonido()` en su definición.

Luego, se crean instancias de `Perro` y `Gato`, pero se les asigna el tipo `Animal` para asegurarse de que cumplan con la estructura definida por la interfaz. Esto permite utilizar polimorfismo, tratando a los objetos `perro` y `gato` como objetos `Animal` y llamando al método `hacerSonido()` de forma consistente, independientemente de su implementación específica.