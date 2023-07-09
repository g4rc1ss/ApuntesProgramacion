
1. **Estructura del Código**
    - Variables: En TypeScript, puedes declarar variables utilizando la palabra clave `let` o `const`. Por ejemplo:
    ```typescript
    let edad: number = 25;
    const nombre: string = "Juan";
    ```
    - Condicionales: Puedes utilizar estructuras de control como `if`, `else if` y `else` para ejecutar diferentes bloques de código según condiciones. Aquí tienes un ejemplo:
    ```typescript
    if (edad >= 18) {
        console.log("Eres mayor de edad");
    } else {
        console.log("Eres menor de edad");
    }
    ```
    - Bucles: TypeScript admite bucles como `for`, `while` y `do-while` para repetir bloques de código. Aquí tienes un ejemplo con un bucle `for`:
    ```typescript
    for (let i = 0; i < 5; i++) {
        console.log(i);
    }
    ```
    - Operadores: TypeScript proporciona diversos operadores como aritméticos, de asignación, de comparación, lógicos, entre otros. Por ejemplo:
    ```typescript
    let resultado = (5 + 3) * 2;
    console.log(resultado); // Output: 16
    ```
    - Enumeradores: Los enumeradores te permiten definir un conjunto de constantes con nombres descriptivos. Aquí tienes un ejemplo:
    ```typescript
    enum DiaSemana {
        Lunes,
        Martes,
        Miércoles,
        Jueves,
        Viernes,
        Sábado,
        Domingo
    }
    let dia: DiaSemana = DiaSemana.Martes;
    console.log(dia); // Output: 1
    ```

2. **Programación Orientada a Objetos**:
    - Clases: Puedes definir clases en TypeScript para encapsular propiedades y métodos relacionados. Aquí tienes un ejemplo básico:
    ```typescript
    class Persona {
        nombre: string;
        edad: number;

        constructor(nombre: string, edad: number) {
            this.nombre = nombre;
            this.edad = edad;
        }

        saludar() {
            console.log(`Hola, mi nombre es ${this.nombre}`);
        }
    }

    let persona = new Persona("Juan", 25);
    persona.saludar(); // Output: Hola, mi nombre es Juan
    ```
    - Clases Estáticas: Puedes utilizar la palabra clave `static` para definir miembros estáticos en una clase, los cuales pertenecen a la clase en sí misma en lugar de las instancias individuales. Ejemplo:
    ```typescript
    class MathUtils {
        static PI: number = 3.1416;

        static calcularAreaCirculo(radio: number): number {
            return MathUtils.PI * radio * radio;
        }
    }

    console.log(MathUtils.calcularAreaCirculo(5)); // Output: 78.54
    ```
    - Métodos: En TypeScript, los métodos son funciones dentro de una clase que pueden realizar ciertas acciones o cálculos. Aquí tienes un ejemplo:
    ```typescript
    class Calculadora {
        sumar(a: number, b: number): number {
            return a + b;
        }
    }

    let calculadora = new Calculadora();
    console.log(calculadora.sumar(3, 4)); // Output: 7
    ```
    - Propiedades: Las propiedades son variables asociadas a una clase. Pueden tener modificadores de acceso como `public`, `private` o `protected`. Ejemplo:
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
    - Herencia: Puedes crear una jerarquía de clases donde una clase hija hereda propiedades y métodos de una clase padre. Ejemplo:
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
    - Clases Abstractas: Las clases abstractas son clases que no se pueden instanciar directamente, sino que se utilizan como base para otras clases. Ejemplo:
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
    - Clases Selladas: Las clases selladas (o `sealed`) son clases que no pueden tener clases hijas adicionales. Ejemplo:
    ```typescript
    class Vehiculo {
        // Código de la clase Vehiculo
    }

    class Coche extends Vehiculo {
        // Código de la clase Coche
    }

    sealed class Moto extends Vehiculo {
        // Código de la clase Moto
    }

    // No se puede crear una clase hija de Moto
    ```

3. Tratamiento de Excepciones:
    En TypeScript, puedes manejar excepciones utilizando bloques `try`, `catch` y `finally`. Aquí tienes un ejemplo:
    ```typescript
    try {
        // Código que puede generar una excepción
        throw new Error("¡Ha ocurrido un error!");
    } catch (error) {
        console.log("Se produjo un error:", error.message);
    } finally {
        console.log("Bloque finally ejecutado siempre");
    }
    ```

4. **Conceptos Avanzados**:
    - Atributos: Los atributos son variables asociadas a una clase que representan características o datos de un objeto. Ejemplo:
    ```typescript
    class Persona {
        nombre: string;
        edad: number;
    }

    let persona = new Persona();
    persona.nombre = "Juan";
    persona.edad = 25;
    ```

    - Indizadores: Los indizadores permiten acceder a los elementos de una clase como si fueran un array. Ejemplo:
    ```typescript
    class ListaNumeros {
        private numeros: number[] = [];

        setNumero(index: number, valor: number) {
            this.numeros[index] = valor;
        }

        getNumero(index: number): number {
            return this.numeros[index];
        }
    }

    let lista = new ListaNumeros();
    lista.setNumero(0, 10);
    console.log(lista.getNumero(0)); // Output: 10
    ```

    - Generics: Los generics permiten crear componentes reutilizables y flexibles que pueden trabajar con diferentes tipos de datos. Ejemplo:
    ```typescript
    class Lista<T> {
        private elementos: T[] = [];

        agregar(elemento: T) {
            this.elementos.push(elemento);
        }

        obtener(indice: number): T {
            return this.elementos[indice];
        }
    }

    let listaNumeros = new Lista<number>();
    listaNumeros.agregar(1);
    listaNumeros.agregar(2);
    console.log(listaNumeros.obtener(0)); // Output: 1

    let listaStrings = new Lista<string>();
    listaStrings.agregar("Hola");
    listaStrings.agregar("Mundo");
    console.log(listaStrings.obtener(1)); // Output: Mundo
    ```

    - Yield: La palabra clave `yield` se utiliza en funciones generadoras para pausar y reanudar la ejecución de una función. Ejemplo:
    ```typescript
    function* generarSecuencia() {
        yield 1;
        yield 2;
        yield 3;
    }

    let secuencia = generarSecuencia();
    console.log(secuencia.next().value); // Output: 1
    console.log(secuencia.next().value); // Output: 2
    console.log(secuencia.next().value); // Output: 3
    ```

    - Events: TypeScript admite el uso de eventos para notificar o responder a acciones o cambios en el sistema. Ejemplo:
    ```typescript
    class EventoClick {
        private listeners: ((data: string) => void)[] = [];

        agregarListener(listener: (data: string) => void) {
            this.listeners.push(listener);
        }

        dispararEvento(data: string) {
            this.listeners.forEach(listener => listener(data));
        }
    }

    let evento = new EventoClick();
    evento.agregarListener(data => console.log(`Se hizo clic en ${data}`));
    evento.dispararEvento("botón");
    // Output: Se hizo clic en botón
    ```

# API
1. **Cadenas**:
   - String: En TypeScript, el tipo `string` representa una cadena de texto. Puedes utilizar métodos y propiedades integrados para manipular cadenas. Ejemplo:
   ```typescript
   let mensaje: string = "Hola, mundo!";
   console.log(mensaje.length); // Output: 12
   console.log(mensaje.toUpperCase()); // Output: HOLA, MUNDO!
   ```

   - Expresiones Regulares: Las expresiones regulares son patrones utilizados para buscar y manipular texto. TypeScript admite el uso de expresiones regulares mediante la clase `RegExp`. Ejemplo:
   ```typescript
   let texto: string = "¡Hola mundo!";
   let patron: RegExp = /mundo/;

   if (patron.test(texto)) {
       console.log("Se encontró la palabra 'mundo' en el texto.");
   } else {
       console.log("No se encontró la palabra 'mundo' en el texto.");
   }
   ```

2. **Colecciones**:
   - Listas: En TypeScript, puedes utilizar la clase `Array` para crear y manipular listas de elementos. Ejemplo:
   ```typescript
   let listaNumeros: number[] = [1, 2, 3, 4];
   console.log(listaNumeros.length); // Output: 4
   console.log(listaNumeros[2]); // Output: 3
   ```

   - Diccionarios: TypeScript no tiene una clase `Diccionario` integrada, pero puedes utilizar objetos literales como diccionarios para almacenar pares clave-valor. Ejemplo:
   ```typescript
   let diccionario: { [clave: string]: number } = {
       "uno": 1,
       "dos": 2,
       "tres": 3
   };

   console.log(diccionario["dos"]); // Output: 2
   ```

   - Pilas: Puedes implementar una pila (stack) en TypeScript utilizando un array y operaciones como `push` y `pop`. Ejemplo:
   ```typescript
   let pila: number[] = [];
   pila.push(1);
   pila.push(2);
   pila.push(3);
   console.log(pila.pop()); // Output: 3
   ```

   - Colas: Puedes implementar una cola (queue) en TypeScript utilizando un array y operaciones como `push` y `shift`. Ejemplo:
   ```typescript
   let cola: number[] = [];
   cola.push(1);
   cola.push(2);
   cola.push(3);
   console.log(cola.shift()); // Output: 1
   ```

3. Consultas Acceso a Colecciones: TypeScript proporciona métodos y funciones integradas para realizar consultas y acceder a elementos en colecciones, como `map`, `filter`, `find`, `forEach`, entre otros. Ejemplo:
   ```typescript
   let numeros: number[] = [1, 2, 3, 4, 5];

   let numerosDobles = numeros.map(numero => numero * 2);
   console.log(numerosDobles); // Output: [2, 4, 6, 8, 10]

   let numerosPares = numeros.filter(numero => numero % 2 === 0);
   console.log(numerosPares); // Output: [2, 4]
   ```

4. **Threads**:
   - MultiThreading: TypeScript se ejecuta en un entorno de un solo hilo, por lo que no es compatible con el multihilo directamente. Sin embargo, puedes trabajar con hilos utilizando APIs externas o módulos específicos.
   
   - Sincronizar Hilos: Para sincronizar hilos y evitar problemas de concurrencia en TypeScript, puedes utilizar mecanismos como bloqueo de exclusión mutua (mutex), semáforos, promesas o eventos para garantizar la sincronización y la exclusión mutua.

   - Async & await: TypeScript admite las palabras clave `async` y `await` para trabajar con código asíncrono de manera más sencilla. Ejemplo:
   ```typescript
   function esperar(ms: number) {
       return new Promise(resolve => setTimeout(resolve, ms));
   }

   async function hacerTarea() {
       console.log("Iniciando tarea...");
       await esperar(2000);
       console.log("Tarea completada.");
   }

   hacerTarea();
   ```

5. **Escritura y Lectura**:
   - Archivos de Texto: TypeScript no proporciona funcionalidades directas para trabajar con archivos de texto, pero puedes utilizar APIs del entorno de ejecución, como Node.js, para leer y escribir archivos de texto. Aquí tienes un ejemplo básico de lectura de un archivo de texto utilizando Node.js:
   ```typescript
   import fs from 'fs';

   fs.readFile('archivo.txt', 'utf8', (error, data) => {
       if (error) {
           console.error(error);
           return;
       }

       console.log(data);
   });
   ```

   - Archivos Binarios: Para leer y escribir archivos binarios en TypeScript, puedes utilizar las mismas APIs del entorno de ejecución, como Node.js, y trabajar con flujos de bytes.

   - Serializar objetos: Puedes utilizar formatos como JSON o XML para serializar objetos en TypeScript.
      - JSON: TypeScript proporciona funciones integradas `JSON.stringify` y `JSON.parse` para convertir objetos JavaScript en cadenas JSON y viceversa. Ejemplo:
      ```typescript
      let persona = { nombre: "Juan", edad: 25 };
      let jsonString = JSON.stringify(persona);
      console.log(jsonString); // Output: {"nombre":"Juan","edad":25}

      let parsedObject = JSON.parse(jsonString);
      console.log(parsedObject.nombre); // Output: Juan
      ```
      - XML: TypeScript no tiene una funcionalidad incorporada para trabajar con XML, pero puedes utilizar bibliotecas o APIs externas para manipular y serializar objetos en formato XML.

6. **Uso de Internet**:
   - Consulta HTTP: Para realizar consultas HTTP en TypeScript, puedes utilizar bibliotecas como Axios o las funcionalidades integradas en el entorno de ejecución, como Node.js. Aquí tienes un ejemplo básico utilizando Axios:
   ```typescript
   import axios from 'axios';

   axios.get('https://api.example.com/data')
       .then(response => {
           console.log(response.data);
       })
       .catch(error => {
           console.error(error);
       });
   ```

   - HttpMessageHandler: TypeScript no tiene una funcionalidad integrada para trabajar directamente con `HttpMessageHandler`, pero puedes utilizar bibliotecas y frameworks como Express.js para manejar solicitudes y respuestas HTTP.

7. Delegados: TypeScript no tiene un concepto directo de delegados como en algunos lenguajes, pero puedes lograr comportamientos similares utilizando funciones como parámetros o devoluciones de llamada.

8. Reflexión: TypeScript no proporciona una API de reflexión incorporada, pero puedes utilizar bibliotecas como `reflect-metadata` para acceder a metadatos y realizar operaciones de reflexión.

9. Gestión de Memoria: TypeScript es un lenguaje de programación con recolección automática de basura (garbage collection), lo que significa que no necesitas administrar manualmente la memoria. El recolector de basura se encarga de liberar la memoria de los objetos que ya no están en uso.

10. Interoperabilidad: TypeScript puede interactuar con otros lenguajes y plataformas a través de APIs y bibliotecas externas, como utilizar JavaScript existente o utilizar TypeScript en proyectos web y Node.js.





