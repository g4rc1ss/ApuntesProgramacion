# Dependency Injection

**Inyección de dependencias con librerías:**

Si deseas utilizar una librería para facilitar la inyección de dependencias en TypeScript, aquí tienes un ejemplo utilizando la librería `tsyringe`:

```typescript
import { container, injectable, inject } from 'tsyringe';

// Clase de servicio A
@injectable()
class ServicioA {
  public metodoA(): void {
    console.log('Método A ejecutado');
  }
}

// Clase de servicio B
@injectable()
class ServicioB {
  constructor(private servicioA: ServicioA) {}

  public metodoB(): void {
    console.log('Método B ejecutado');
    this.servicioA.metodoA();
  }
}

// Clase principal que utiliza los servicios A y B
class ClasePrincipal {
  constructor(@inject(ServicioB) private servicioB: ServicioB) {}

  public metodoPrincipal(): void {
    console.log('Método principal ejecutado');
    this.servicioB.metodoB();
  }
}

// Configuración y uso de las clases utilizando tsyringe
container.register(ServicioA);
container.register(ServicioB);
const clasePrincipal = container.resolve(ClasePrincipal);

clasePrincipal.metodoPrincipal();
```

En este ejemplo, utilizamos la librería `tsyringe` para simplificar la inyección de dependencias. Utilizamos los decoradores `@injectable()` para indicar que las clases son inyectables. Utilizamos el decorador `@inject()` para indicar las dependencias en los constructores. Luego, configuramos las clases y resolvemos las dependencias utilizando el contenedor `container` proporcionado por `tsyringe`.

**Consideraciones adicionales:**

Al utilizar inyección de dependencias en TypeScript, ten en cuenta las siguientes consideraciones:

- La inyección de dependencias ayuda a desacoplar las clases y facilita la reutilización y la prueba de unidades.
- Puedes utilizar la inyección de dependencias manualmente o aprovechar las librerías especializadas que brindan características adicionales, como resolución automática de dependencias, ciclos de vida personalizados y más.
- La inyección de dependencias también puede involucrar la configuración de contenedores y la administración de instancias. Las librerías de inyección de dependencias pueden proporcionar mecanismos para simplificar estos aspectos.
