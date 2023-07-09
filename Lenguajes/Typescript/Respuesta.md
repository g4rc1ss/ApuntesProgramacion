¡Claro! A continuación, te proporcionaré ejemplos básicos en TypeScript para cada punto del índice. Ten en cuenta que los ejemplos son breves y se enfocan en ilustrar conceptos clave. Puedes expandirlos y personalizarlos según tus necesidades.

## Estudio básico

1. **Estructura del Código**
   - [Variables](./docs/Lenguaje/EstructuraCodigo/Variables.md): 
   ```typescript
   let mensaje: string = "¡Hola, TypeScript!";
   console.log(mensaje);
   ```

   - [Condicionales](./docs/Lenguaje/EstructuraCodigo/InstruccionSeleccion.md):
   ```typescript
   let num: number = 10;
   if (num > 0) {
       console.log("El número es positivo");
   } else {
       console.log("El número es negativo");
   }
   ```

   - [Bucles](./docs/Lenguaje/EstructuraCodigo/InstruccionIteracion.md):
   ```typescript
   for (let i = 0; i < 5; i++) {
       console.log(i);
   }
   ```

   - [Operadores](./docs/Lenguaje/EstructuraCodigo/Operadores.md):
   ```typescript
   let a: number = 5;
   let b: number = 3;
   let suma: number = a + b;
   console.log(suma);
   ```

   - [Enumeradores](./docs/Lenguaje/EstructuraCodigo/Enums.md):
   ```typescript
   enum Color {
       Rojo,
       Verde,
       Azul
   }
   
   let color: Color = Color.Verde;
   console.log(color);  // 1
   ```

2. **Programación Orientada a Objetos**
   - [Clases](./docs/Lenguaje/POO/Clases.md):
   ```typescript
   class Persona {
       constructor(public nombre: string, public edad: number) {}
   
       saludar() {
           console.log(`Hola, mi nombre es ${this.nombre} y tengo ${this.edad} años.`);
       }
   }
   
   let persona = new Persona("Juan", 25);
   persona.saludar();
   ```

   - [Clases Estáticas](./docs/Lenguaje/POO/StaticClass.md):
   ```typescript
   class Utilidades {
       static sumar(a: number, b: number): number {
           return a + b;
       }
   }
   
   let resultado = Utilidades.sumar(3, 4);
   console.log(resultado);  // 7
   ```

   - [Métodos](./docs/Lenguaje/POO/Method.md):
   ```typescript
   class Calculadora {
       sumar(a: number, b: number): number {
           return a + b;
       }
   
       restar(a: number, b: number): number {
           return a - b;
       }
   }
   
   let calculadora = new Calculadora();
   let suma = calculadora.sumar(3, 4);
   console.log(suma);  // 7
   let resta = calculadora.restar(6, 2);
   console.log(resta);  // 4
   ```

   - [Propiedades](./docs/Lenguaje/POO/Properties.md):
   ```typescript
   class Rectangulo {
       constructor(public base: number, public altura: number) {}
   
       get area(): number {
           return this.base * this.altura;
       }
   }
   
   let rectangulo = new Rectangulo(5, 3);
   console.log(rectangulo.area);  // 15
   ```

   - [Herencia](./docs/Lenguaje/POO/Herencia.md):
   ```typescript
   class Animal {
       constructor(public nombre: string) {}
   
       hacerSonido() {
           console.log("Haciendo sonido...");
       }
   }
   
   class Perro extends Animal {
       hacerSonido() {
           console.log("Guau guau");
       }
   }
   
   let perro = new Perro("Firulais");
   perro.hacerSonido();  // Guau guau
   ```

   - [Clases Abstractas](./docs/Lenguaje/POO/ClasesAbstractas.md):
   ```typescript
   abstract class Figura {
       abstract calcularArea(): number;
   }
   
   class Circulo extends Figura {
       constructor(private radio: number) {
           super();
       }
   
       calcularArea(): number {
           return Math.PI * this.radio * this.radio;
       }
   }
   
   let circulo = new Circulo(5);
   console.log(circulo.calcularArea());  // 78.54
   ```

   - [Clases Selladas](./docs/Lenguaje/POO/SealedClass.md):
   ```typescript
   class Animal {
       hacerSonido() {
           console.log("Haciendo sonido...");
       }
   }
   
   let animal = new Animal();
   animal.hacerSonido();  // Haciendo sonido...
   // No se puede heredar de la clase Animal debido a que es sellada
   ```

   - [Interfaces](./docs/Lenguaje/POO/Interfaces.md):
   ```typescript
   interface Forma {
       calcularArea(): number;
   }
   
   class Rectangulo implements Forma {
       constructor(private base: number, private altura: number) {}
   
       calcularArea(): number {
           return this.base * this.altura;
       }
   }
   
   let rectangulo: Forma = new Rectangulo(5, 3);
   console.log(rectangulo.calcularArea());  // 15
   ```

   - [Polimorfismo](./docs/Lenguaje/POO/Polimorfismo.md):
   ```typescript
   class Animal {
       hacerSonido() {
           console.log("Haciendo sonido...");
       }
   }
   
   class Perro extends Animal {
       hacerSonido() {
           console.log("Guau guau");
       }
   }
   
   class Gato extends Animal {
       hacerSonido() {
           console.log("Miau miau");
       }
   }
   
   let perro: Animal = new Perro();
   perro.hacerSonido();  // Guau guau
   
   let gato: Animal = new Gato();
   gato.hacerSonido();  // Miau miau
   ```

   - [Covarianza y Contravarianza](./docs/Lenguaje/POO/CovarianzaContravarianza.md):
   ```typescript
   class Animal {}
   
   class Perro extends Animal {}
   
   class Gato extends Animal {}
   
   interface ContenedorAnimal {
       animal: Animal;
   }
   
   let perroContenedor: ContenedorAnimal = { animal: new Perro() };
   let gatoContenedor: ContenedorAnimal = { animal: new Gato() };
   ```

3. [Tratamiento de Excepciones](./docs/Lenguaje/Excepciones/Tr

atamientoExcepciones.md):
```typescript
try {
   // Código que puede generar una excepción
   let resultado = 10 / 0;
   console.log(resultado);
} catch (error) {
   // Manejo de la excepción
   console.log("Ocurrió un error:", error);
}
```

4. **Conceptos Avanzados**
   - [Atributos](./docs/Lenguaje/ConceptosAvanzados/Atributos.md):
   ```typescript
   class Persona {
       @validarTexto
       nombre: string;
   
       constructor(nombre: string) {
           this.nombre = nombre;
       }
   }
   
   function validarTexto(target: any, propertyKey: string) {
       let value = target[propertyKey];
   
       const getter = function () {
           return value;
       };
   
       const setter = function (nuevoValor: string) {
           if (typeof nuevoValor !== "string") {
               throw new Error("El valor debe ser una cadena de texto.");
           }
           value = nuevoValor;
       };
   
       Object.defineProperty(target, propertyKey, {
           get: getter,
           set: setter,
           enumerable: true,
           configurable: true,
       });
   }
   
   let persona = new Persona("Juan");
   console.log(persona.nombre);  // Juan
   persona.nombre = 123;  // Error: El valor debe ser una cadena de texto.
   ```

   - [Indizadores](./docs/Lenguaje/ConceptosAvanzados/Indizadores.md):
   ```typescript
   class ListaNumeros {
       private numeros: number[] = [];
   
       constructor(...numeros: number[]) {
           this.numeros = numeros;
       }
   
       obtenerNumero(index: number): number {
           return this.numeros[index];
       }
   }
   
   let lista = new ListaNumeros(1, 2, 3, 4, 5);
   console.log(lista.obtenerNumero(2));  // 3
   ```

   - [Genéricos](./docs/Lenguaje/ConceptosAvanzados/Generics.md):
   ```typescript
   function obtenerPrimero<T>(array: T[]): T {
       return array[0];
   }
   
   let numeros: number[] = [1, 2, 3, 4, 5];
   let primerNumero: number = obtenerPrimero(numeros);
   console.log(primerNumero);  // 1
   
   let nombres: string[] = ["Juan", "María", "Pedro"];
   let primerNombre: string = obtenerPrimero(nombres);
   console.log(primerNombre);  // Juan
   ```

   - [Yield](./docs/Lenguaje/ConceptosAvanzados/Yield.md):
   ```typescript
   function* generarNumeros(): Generator<number> {
       let i = 0;
       while (true) {
           yield i++;
       }
   }
   
   let generador = generarNumeros();
   console.log(generador.next().value);  // 0
   console.log(generador.next().value);  // 1
   console.log(generador.next().value);  // 2
   ```

   - [Eventos](./docs/Lenguaje/ConceptosAvanzados/Events.md):
   ```typescript
   class EventoClick {
       private listeners: (() => void)[] = [];
   
       suscribir(listener: () => void) {
           this.listeners.push(listener);
       }
   
       disparar() {
           this.listeners.forEach(listener => listener());
       }
   }
   
   let boton = new EventoClick();
   boton.suscribir(() => {
       console.log("Se hizo clic en el botón");
   });
   boton.disparar();  // Se hizo clic en el botón
   ```

## Estudio del API

1. **Cadenas**
   - [String](./docs/ApiLenguaje/Cadenas/String.md):
   ```typescript
   let mensaje: string = "¡Hola, TypeScript!";
   console.log(mensaje.length);  // 17
   console.log(mensaje.toUpperCase());  // ¡HOLA, TYPESCRIPT!
   ```

   - [StringBuilder](./docs/ApiLenguaje/Cadenas/StringBuilder.md):
   ```typescript
   class StringBuilder {
       private value: string = "";
   
       append(text: string): void {
           this.value += text;
       }
   
       toString(): string {
           return this.value;
       }
   }
   
   let builder = new StringBuilder();
   builder.append("Hola, ");
   builder.append("TypeScript!");
   console.log(builder.toString());  // Hola, TypeScript!
   ```

   - [Expresiones Regulares](./docs/ApiLenguaje/Cadenas/ExpresionesRegulares.md):
   ```typescript
   let texto: string = "Hola, 123 mundo!";
   let patron: RegExp = /\d+/g;
   let resultados: RegExpExecArray | null;
   while ((resultados = patron.exec(texto)) !== null) {
       console.log(resultados[0]);
   }
   // Resultado: 123
   ```

2. **Colecciones**
   - [Listas](./docs/ApiLenguaje/Enumerables/Colecciones/List.md):
   ```typescript
   let numeros: number[] = [1, 2, 3, 4, 5];
   console.log(numeros.length);  // 5
   console.log(numeros[2]);  // 3
   numeros.push(6);
   console.log(numeros);  // [1, 2, 3, 4, 5, 6]
   ```

   - [Diccionarios](./docs/ApiLenguaje/Enumerables/Colecciones/Dictionary.md):
   ```typescript
   let diccionario: { [clave: string]: string } = {
       "uno": "one",
       "dos": "two",
       "tres": "three"
   };
   
   console.log(diccionario["uno"]);  // one
   console.log(diccionario["tres"]);  // three
   ```

   - [Pilas](./docs/ApiLenguaje/Enumerables/Colecciones/Stack.md):
   ```typescript
   let pila: number[] = [];
   pila.push(1);
   pila.push(2);
   pila.push(3);
   console.log(pila.pop());  // 3
   console.log(pila);  // [1, 2]
   ```

   - [Colas](./docs/ApiLenguaje/Enumerables/Colecciones/Queue.md):
   ```typescript
   let cola: number[] = [];
   cola.push(1);
   cola.push(2);
   cola.push(3);
   console.log(cola.shift());  // 1
   console.log(cola);  // [2, 3]
   ```

3. [Consultas Acceso a Colecciones](./docs/ApiLenguaje/Enumerables/ConsultaDatos.md):
   ```typescript
   let numeros: number[] = [1, 2, 3, 4, 5];
   let numerosPares = numeros.filter(numero => numero % 2 === 0);
   console.log(numerosPares);  // [2, 4]

   let suma = numeros.reduce((acumulador, numero) => acumulador + numero, 0);
   console.log(suma);  // 15

   let existeTres = numeros.some(numero => numero === 3);
   console.log(existeTres);  // true

   let todosMayoresCero = numeros.every(numero => numero > 0);
   console.log(todosMayoresCero);  // true
   ```

1. **Threads** (continuación)
   - [MultiThreading](./docs/ApiLenguaje/Threading/MultiThreading.md):
   ```typescript
   function contarNumeros() {
       for (let i = 0; i <= 10; i++) {
           console.log(i);
       }
   }
   
   setTimeout(contarNumeros, 1000);  // Ejecutar después de 1 segundo
   console.log("Contando...");
   ```

   - [Sincronizar Hilos](./docs/ApiLenguaje/Threading/SyncThreads.md):
   ```typescript
   function contarNumeros() {
       for (let i = 0; i <= 10; i++) {
           console.log(i);
       }
   }
   
   setInterval(contarNumeros, 1000);  // Ejecutar cada 1 segundo
   console.log("Contando...");
   ```

   - [Async & await](./docs/ApiLenguaje/Threading/Async.md):
   ```typescript
   function esperar(ms: number): Promise<void> {
       return new Promise(resolve => setTimeout(resolve, ms));
   }
   
   async function proceso() {
       console.log("Inicio del proceso");
       await esperar(2000);  // Esperar 2 segundos
       console.log("Fin del proceso");
   }
   
   proceso();
   console.log("Continuando con otras tareas...");
   ```

2. **Escritura y Lectura** (continuación)
   - Archivos de Texto
       - [File](./docs/ApiLenguaje/InputOutput/TextFiles/File.md):
       ```typescript
       // Ejemplo de lectura y escritura de archivos de texto con 'fs' en Node.js
       import * as fs from "fs";
   
       fs.readFile("archivo.txt", "utf-8", (error, data) => {
           if (error) {
               console.error("Error al leer el archivo:", error);
           } else {
               console.log("Contenido del archivo:", data);
           }
       });
   
       fs.writeFile("archivo.txt", "Hola, Mundo!", "utf-8", error => {
           if (error) {
               console.error("Error al escribir en el archivo:", error);
           } else {
               console.log("Archivo escrito exitosamente.");
           }
       });
       ```

   - [Serializar objetos](./docs/ApiLenguaje/InputOutput/Serialization/Serializacion.md):
       - [JSON](./docs/ApiLenguaje/InputOutput/Serialization/JSON.md):
       ```typescript
       interface Persona {
           nombre: string;
           edad: number;
       }
       
       let persona: Persona = {
           nombre: "Juan",
           edad: 25
       };
       
       let personaJson: string = JSON.stringify(persona);
       console.log(personaJson);
       
       let personaDeserializada: Persona = JSON.parse(personaJson);
       console.log(personaDeserializada);
       ```

       - [XML](./docs/ApiLenguaje/InputOutput/Serialization/XML.md):
       ```typescript
       // Ejemplo de serialización y deserialización de XML omitido por simplicidad
       // Puedes usar librerías como 'xml2js' para trabajar con XML en TypeScript
       ```

3. **Uso de Internet**
   - [Consulta HTTP](./docs/ApiLenguaje/Network/HttpClient.md):
   ```typescript
   import axios from "axios";
   
   axios.get("https://api.example.com/data")
       .then(response => {
           console.log(response.data);
       })
       .catch(error => {
           console.error("Error al realizar la consulta HTTP:", error);
       });
   ```

4. [Delegados](./docs/ApiLenguaje/Delegados.md):
   ```typescript
   // Los delegados no están disponibles en TypeScript directamente, pero puedes usar funciones como alternativa
   
   type OperacionMatematica = (a: number, b: number) => number;
   
   function sumar(a: number, b: number): number {
       return a + b;
   }
   
   function multiplicar(a: number, b: number): number {
       return a * b;
   }
   
   let operacion: OperacionMatematica = sumar;
   console.log(operacion(2, 3));  // 5
   
   operacion = multiplicar;
   console.log(operacion(2, 3));  // 6
   ```

   ¡Por supuesto! Aquí tienes la continuación de la respuesta desde el punto de Caching:

8. Estudio de Librerías Externas (continuación)
   - [Caching](./docs/Librerias/Caching/CacheMemoriaMemory.md):
   ```typescript
   // Ejemplo de uso de una librería de caching en memoria omitido por simplicidad
   // Puedes utilizar librerías como 'node-cache' o 'lru-cache' para implementar el caching en TypeScript
   
   import NodeCache from "node-cache";
   
   const cache = new NodeCache();
   
   function obtenerDatos(key: string): any {
       const data = cache.get(key);
       if (data) {
           console.log("Obteniendo datos de la caché...");
           return data;
       } else {
           console.log("Obteniendo datos de la fuente...");
           // Obtener datos de la fuente de datos (por ejemplo, una base de datos o una API)
           const newData = { /* Datos obtenidos */ };
           cache.set(key, newData);
           return newData;
       }
   }
   
   console.log(obtenerDatos("datos-1"));  // Obteniendo datos de la fuente...
   console.log(obtenerDatos("datos-1"));  // Obteniendo datos de la caché...
   ```

9. [Pruebas Unitarias](./docs/Librerias/Testing/UnitTesting.md):
   ```typescript
   // Ejemplo de uso de una librería de pruebas unitarias omitido por simplicidad
   // Puedes utilizar librerías como 'Mocha' o 'Jest' para escribir y ejecutar pruebas unitarias en TypeScript
   
   import { sumar } from "./operaciones";
   import { expect } from "chai";
   
   describe("Operaciones", () => {
       it("debería sumar dos números correctamente", () => {
           const resultado = sumar(2, 3);
           expect(resultado).to.equal(5);
       });
   });
   ```

10. [Logging](./docs/Librerias/Logging/Logging.md):
   ```typescript
   import winston from "winston";
   
   const logger = winston.createLogger({
       level: "info",
       format: winston.format.json(),
       transports: [
           new winston.transports.Console(),
           new winston.transports.File({ filename: "logfile.log" })
       ]
   });
   
   logger.info("Mensaje de información");
   logger.warn("Mensaje de advertencia");
   logger.error("Mensaje de error");
   ```
