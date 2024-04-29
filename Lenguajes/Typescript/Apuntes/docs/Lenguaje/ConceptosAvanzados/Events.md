# Eventos 

En TypeScript, los eventos son una forma común de comunicación entre componentes o partes de una aplicación.

**Uso de eventos:**

El uso de eventos implica la emisión (o disparo) de un evento desde un componente y la suscripción (o escucha) a ese evento por parte de otros componentes interesados. Aquí tienes un ejemplo de cómo utilizar eventos en TypeScript:

```typescript
class EventoPersonalizado {
  private oyentes: ((datos: any) => void)[] = [];
  
  emitir(datos: any): void {
    this.oyentes.forEach((oyente) => oyente(datos));
  }
  
  suscribir(oyente: (datos: any) => void): void {
    this.oyentes.push(oyente);
  }
}

// Uso de eventos
const miEvento = new EventoPersonalizado();

miEvento.suscribir((datos) => {
  console.log("Evento recibido:", datos);
});

miEvento.emitir("Hola mundo");
// Salida: Evento recibido: Hola mundo
```

En este ejemplo, creamos una clase `EventoPersonalizado` que representa un evento personalizado. La clase tiene un array de oyentes, que son funciones que se suscriben al evento. El método `emitir()` se utiliza para emitir el evento y notificar a todos los oyentes, pasando los datos relacionados con el evento. El método `suscribir()` se utiliza para suscribirse al evento y registrar una función como oyente.

Luego, creamos una instancia de `EventoPersonalizado` llamada `miEvento`. Suscribimos una función como oyente utilizando el método `suscribir()`. Cuando llamamos al método `emitir()` con los datos "Hola mundo", se ejecutan todas las funciones de los oyentes suscritos al evento, y se muestra el mensaje "Evento recibido: Hola mundo" en la consola.

**Creación de eventos:**

Para crear tus propios eventos personalizados, puedes seguir el mismo enfoque utilizado en el ejemplo anterior. Aquí tienes un ejemplo de cómo crear un evento personalizado:

```typescript
class EventoPersonalizado {
  private oyentes: ((datos: string) => void)[] = [];
  
  emitir(datos: string): void {
    this.oyentes.forEach((oyente) => oyente(datos));
  }
  
  suscribir(oyente: (datos: string) => void): void {
    this.oyentes.push(oyente);
  }
}

// Uso de eventos personalizados
const miEvento = new EventoPersonalizado();

miEvento.suscribir((datos) => {
  console.log("Evento recibido:", datos);
});

miEvento.emitir("Hola mundo");
// Salida: Evento recibido: Hola mundo
```

En este ejemplo, creamos una clase `EventoPersonalizado` similar a la anterior, pero en este caso, se especifica que los datos emitidos por el evento serán de tipo `string` en lugar de `any`. Esto significa que los oyentes deben recibir y manejar datos de tipo `string`.

Luego, creamos una instancia de `EventoPersonalizado` llamada `miEvento`. Suscribimos una función como oyente y, al emitir el evento con los datos "Hola mundo", se muestra el mensaje "Evento recibido: Hola mundo" en la consola.

Creando tus propios eventos personalizados, puedes diseñar una arquitectura de aplicaciones más modular y flexible, permitiendo una comunicación efectiva y desacoplada entre componentes.