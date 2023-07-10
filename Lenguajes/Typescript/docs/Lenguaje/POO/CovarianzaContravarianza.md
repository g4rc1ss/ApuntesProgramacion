# Covarianza y Contravarianza

**Covarianza:**

La covarianza se refiere a la relación entre tipos de retorno en la jerarquía de herencia. En términos simples, si un tipo A es un subtipo de un tipo B, entonces una función que devuelve A también puede ser tratada como una función que devuelve B. Esto permite que el tipo de retorno sea más específico en las clases derivadas.

```typescript
class Animal {
  comer(): void {
    console.log("El animal está comiendo.");
  }
}

class Perro extends Animal {
  ladrar(): void {
    console.log("El perro está ladrando.");
  }
}

// Covarianza en tipos de retorno
type FuncionAnimal = () => Animal;
type FuncionPerro = () => Perro;

function obtenerAnimal(): Animal {
  return new Animal();
}

function obtenerPerro(): Perro {
  return new Perro();
}

let funcionAnimal: FuncionAnimal;
funcionAnimal = obtenerPerro; // Covarianza permitida

let funcionPerro: FuncionPerro;
funcionPerro = obtenerAnimal; // Error: No se permite asignación covariante
```

En el ejemplo, tenemos una clase base `Animal` y una clase derivada `Perro`. La función `obtenerAnimal()` devuelve un objeto `Animal`, mientras que la función `obtenerPerro()` devuelve un objeto `Perro`. Debido a la covarianza, la asignación `funcionAnimal = obtenerPerro;` es válida, ya que un `Perro` es un subtipo de `Animal`. Sin embargo, la asignación inversa `funcionPerro = obtenerAnimal;` no es válida, ya que un `Animal` no es necesariamente un `Perro`.

**Contravarianza:**

La contravarianza se refiere a la relación entre los tipos de los parámetros en la jerarquía de herencia. En términos simples, si un tipo A es un subtipo de un tipo B, entonces una función que acepta un parámetro de tipo B también puede ser tratada como una función que acepta un parámetro de tipo A. Esto permite que el tipo de parámetro sea más genérico en las clases derivadas. Aquí tienes un ejemplo de contravarianza con funciones:

```typescript
class Animal {
  comer(): void {
    console.log("El animal está comiendo.");
  }
}

class Perro extends Animal {
  ladrar(): void {
    console.log("El perro está ladrando.");
  }
}

// Contravarianza en tipos de parámetros
type FuncionComer = (animal: Animal) => void;
type FuncionLadrar = (perro: Perro) => void;

function alimentarAnimal(animal: Animal): void {
  console.log("Alimentando al animal.");
}

function ladrarPerro(perro: Perro): void {
  console.log("El perro está ladrando.");
}

let funcionComer: FuncionComer;
funcionComer = alimentarAnimal; // Contravarianza permitida

let funcionLadrar: FuncionLadrar;
funcionLadrar = ladrarPerro; // Error: No se permite asignación contravariante
```

En este ejemplo, la función `alimentarAnimal()` acepta un parámetro de tipo `Animal`, mientras que la función `ladrarPerro()` acepta un parámetro de tipo `Perro`. Debido a la contravarianza, la asignación `funcionComer = alimentarAnimal;` es válida, ya que una función que acepta un `Animal` puede ser tratada como una función que acepta un `Perro`. Sin embargo, la asignación inversa `funcionLadrar = ladrarPerro;` no es válida, ya que una función que acepta un `Perro` no puede ser tratada como una función que acepta un `Animal`.
