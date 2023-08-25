# Atributos

Con TypeScript podemos usarlos activando la propiedad `experimentalDecorators` del `tsconfig.json`

**Atributos de clase:**
Los atributos de clase se aplican a la declaración de la clase en sí y se utilizan para proporcionar metadatos a nivel de clase.

```typescript
function atributoClase(constructor: Function) {
  constructor.prototype.saludo = "¡Hola!";
}

@atributoClase
class Ejemplo {
  nombre: string;
  
  constructor(nombre: string) {
    this.nombre = nombre;
  }
}

const instancia = new Ejemplo("Juan");
console.log(instancia.saludo); // Salida: ¡Hola!
```

En este ejemplo, creamos un atributo de clase llamado `atributoClase` utilizando un decorador. El decorador es una función que toma el constructor de la clase como parámetro y realiza una operación en su prototipo. En este caso, añadimos una propiedad `saludo` al prototipo de la clase.

Luego, aplicamos el atributo de clase `atributoClase` a la clase `Ejemplo` utilizando `@atributoClase`. Esto agrega la propiedad `saludo` a todas las instancias de la clase `Ejemplo`. Al crear una instancia de `Ejemplo` y acceder a la propiedad `saludo`, obtenemos el valor asignado por el atributo de clase.

**Atributos de miembros:**

Los atributos de miembros se aplican a los miembros individuales de una clase, como propiedades o métodos, y se utilizan para proporcionar metadatos específicos de esos miembros. Aquí tienes un ejemplo de cómo utilizar un atributo de miembro:

```typescript
function atributoMiembro(target: any, key: string) {
  console.log(`Atributo aplicado al miembro ${key}`);
}

class Ejemplo {
  @atributoMiembro
  nombre: string;
  
  constructor(nombre: string) {
    this.nombre = nombre;
  }
}

const instancia = new Ejemplo("Juan");
```

En este ejemplo, creamos un atributo de miembro llamado `atributoMiembro` utilizando un decorador. El decorador es una función que toma dos parámetros: `target`, que es el prototipo de la clase, y `key`, que es el nombre del miembro al que se aplica el atributo.

Luego, aplicamos el atributo de miembro `atributoMiembro` a la propiedad `nombre` de la clase `Ejemplo` utilizando `@atributoMiembro`. Al crear una instancia de `Ejemplo`, se ejecutará el atributo de miembro y mostrará un mensaje en la consola indicando a qué miembro se le ha aplicado el atributo.

Los atributos en TypeScript proporcionan una forma flexible de agregar metadatos y anotaciones a las clases y sus miembros. Pueden ser utilizados para diversos propósitos, como configurar opciones, habilitar características adicionales o implementar lógica personalizada basada en metadatos.