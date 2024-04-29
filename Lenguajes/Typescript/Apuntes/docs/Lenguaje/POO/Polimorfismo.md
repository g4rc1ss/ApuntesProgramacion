# Polimorfismo

El polimorfismo es un concepto que se refiere a la capacidad de un objeto de comportarse y ser tratado como otros tipos de objetos relacionados.

```typescript
interface Animal {
  hacerSonido(): void;
}

class Perro implements Animal {
  hacerSonido(): void {
    console.log("Guau guau!");
  }
}

class Gato implements Animal {
  hacerSonido(): void {
    console.log("Miau!");
  }
}

class Vaca implements Animal {
  hacerSonido(): void {
    console.log("Muu!");
  }
}

// Función que acepta un objeto de tipo Animal
function hacerSonarAnimal(animal: Animal): void {
  animal.hacerSonido();
}

// Uso de polimorfismo
const perro: Animal = new Perro();
const gato: Animal = new Gato();
const vaca: Animal = new Vaca();

hacerSonarAnimal(perro); // Salida: Guau guau!
hacerSonarAnimal(gato); // Salida: Miau!
hacerSonarAnimal(vaca); // Salida: Muu!
```

En este ejemplo, la interfaz `Animal` define el método `hacerSonido()`. Luego, las clases `Perro`, `Gato` y `Vaca` implementan la interfaz `Animal`, lo que significa que deben proporcionar una implementación para el método `hacerSonido()`.

La función `hacerSonarAnimal()` acepta un parámetro de tipo `Animal`, lo que significa que puede recibir cualquier objeto que implemente la interfaz `Animal`. Esto es posible gracias al polimorfismo. Dentro de la función, se llama al método `hacerSonido()` del objeto, independientemente de su tipo concreto.

Luego, se crean instancias de `Perro`, `Gato` y `Vaca`, y se les pasa como argumento a la función `hacerSonarAnimal()`. A pesar de que los objetos tienen tipos diferentes (`Perro`, `Gato` y `Vaca`), se comportan como `Animal` debido al polimorfismo. Esto significa que el método `hacerSonido()` apropiado de cada clase se invoca correctamente.

El polimorfismo permite tratar a diferentes objetos de manera uniforme, lo que facilita la creación de código más flexible, mantenible y extensible. Además, se pueden agregar nuevos tipos de animales en el futuro sin tener que modificar la función `hacerSonarAnimal()`.