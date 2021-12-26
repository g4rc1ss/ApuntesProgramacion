# Patrones de Diseño

Los **patrones de diseño** son soluciones a problemas que ocurren de manera habitual en la programación. Es el equivalente a un plano que se puede personalizar para resolver un problema en cuestión.

Los patrones son conceptos existentes de como solucionar un caso en concreto. No es una porción de código que se pueda copiar y pegar y se solucione como si de una libreria o Framework se tratara.

Un patrón y un Algoritmo no es lo mismo.  
**Un algoritmo** es utilizado para resolver algo en concreto y dicho algoritmo no cambia, por ejemplo, el algoritmo de busqueda binaria, es un codigo que se ejecuta de la misma forma sobre un array para obtener el resultado.  
**Un Patron** es una solucion a un problema, pero el codigo y la solucion varia, puesto que es algo personalizable, por ejemplo, [el Patron Builder](TiposPatrones/PatronesCreacionales.md#Builder), depende de para que se implemente, el codigo y la ejecución será de una forma u otra.

Los patrones están explicados de la siguiente forma:

- **Proposito** Breve explicación del patrón
- **Problema** El problema al que esta enfocado el patrón
- **Solucion** La solución propuesta por el patrón
- **Estructura** La relación entre las clases


## Tipos de Patrones

Los patrones varian en el uso que se les da y para que estan destinados, por eso se pueden clasificar por propositos.

- [**Patrones creacionales**](TiposPatrones/PatronesCreacionales.md) proporcionan formas de creacion de objetos y permiten la reutilización de codigo existente.
    - [Factory Method](TiposPatrones/PatronesCreacionales.md#Factory-Method)
    - [Abstract Method](TiposPatrones/PatronesCreacionales.md#Abstract-Method)
    - [Builder](TiposPatrones/PatronesCreacionales.md#Builder)
    - [Prototype](TiposPatrones/PatronesCreacionales.md#Prototype)
    - [Singleton](TiposPatrones/PatronesCreacionales.md#Singleton)

- [**Patrones estructurales**](TiposPatrones/PatronesEstructurales.md) explican formas de linkar objetos y clases en estructuras mas grandes manteniendo la flexibilidad y la eficiencia de la estructura.
    - [Adapter](TiposPatrones/PatronesEstructurales.md#Adapter)
    - [Bridge](TiposPatrones/PatronesEstructurales.md#Bridge)
    - [Composite](TiposPatrones/PatronesEstructurales.md#Composite)
    - [Decorator](TiposPatrones/PatronesEstructurales.md#Decorator)
    - [Facade](TiposPatrones/PatronesEstructurales.md#Facade)
    - [Flyweight](TiposPatrones/PatronesEstructurales.md#Flyweight)
    - [Proxy](TiposPatrones/PatronesEstructurales.md#Proxy)


- [**Patrones de comportamiento**](TiposPatrones/PatronesComportamiento.md) tratan con algoritmos y asignacion de responsabilidades entre objetos.
    - [Chain of Responsability](TiposPatrones/PatronesComportamiento.md#Chain-of-Responsability)
    - [Command](TiposPatrones/PatronesComportamiento.md#Command)
    - [Iterator](TiposPatrones/PatronesComportamiento.md#Iterator)
    - [Mediator](TiposPatrones/PatronesComportamiento.md#Mediator)
    - [Memento](TiposPatrones/PatronesComportamiento.md#Memento)
    - [Observer](TiposPatrones/PatronesComportamiento.md#Observer)
    - [State](TiposPatrones/PatronesComportamiento.md#State)
    - [Strategy](TiposPatrones/PatronesComportamiento.md#Strategy)
    - [Template Method](TiposPatrones/PatronesComportamiento.md#Template-Method)
    - [Visitor](TiposPatrones/PatronesComportamiento.md#Visitor)




La mayor parte de la info esta cogida de la web: [Refactoring Guru](https://refactoring.guru/es/design-patterns)