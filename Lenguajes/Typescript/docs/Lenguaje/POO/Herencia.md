# Herencia
Puedes crear una jerarquía de clases donde una clase hija hereda propiedades y métodos de una clase padre. Ejemplo:
```typescript
class Animal {
    comer() {
        console.log("El animal está comiendo");
    }
}

class Perro extends Animal {
    ladrar() {
        console.log("¡Guau!");
    }
}

let perro = new Perro();
perro.comer(); // Output: El animal está comiendo
perro.ladrar(); // Output: ¡Guau!
```