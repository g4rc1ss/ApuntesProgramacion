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

- **Patrones creacionales**: Proporcionan formas de creacion de objetos y permiten la reutilización de codigo existente.
    - [Factory Method](./TiposPatrones/PatronesCreacionales/FactoryMethod.md)
    - [Abstract Method](TiposPatrones/PatronesCreacionales/AbstractMethod.md)
    - [Builder](TiposPatrones/PatronesCreacionales/Builder.md)
    - [Prototype](TiposPatrones/PatronesCreacionales/Prototype.md)
    - [Singleton](TiposPatrones/PatronesCreacionales/Singleton.md)

- **Patrones estructurales**: Explican formas de linkar objetos y clases en estructuras mas grandes manteniendo la flexibilidad y la eficiencia de la estructura.
    - [Adapter](TiposPatrones/PatronesEstructurales/Adapter.md)
    - [Bridge](TiposPatrones/PatronesEstructurales/Bridge.md)
    - [Composite](TiposPatrones/PatronesEstructurales/Composite.md)
    - [Decorator](TiposPatrones/PatronesEstructurales/Decorator.md)
    - [Facade](TiposPatrones/PatronesEstructurales/Facade.md)
    - [Flyweight](TiposPatrones/PatronesEstructurales/Flyweight.md)
    - [Proxy](TiposPatrones/PatronesEstructurales/Proxy.md)


- **Patrones de comportamiento**: Tratan con algoritmos y asignacion de responsabilidades entre objetos.
    - [Chain of Responsability](TiposPatrones/PatronesComportamiento/ChainOfResponsability.md)
    - [Command](TiposPatrones/PatronesComportamiento/Command.md)
    - [Iterator](TiposPatrones/PatronesComportamiento/Iterator.md)
    - [Interpreter](TiposPatrones/PatronesComportamiento/Interpreter.md)
    - [Mediator](TiposPatrones/PatronesComportamiento/Mediator.md)
    - [Memento](TiposPatrones/PatronesComportamiento/Memento.md)
    - [Observer](TiposPatrones/PatronesComportamiento/Observer.md)
    - [State](TiposPatrones/PatronesComportamiento/State.md)
    - [Strategy](TiposPatrones/PatronesComportamiento/Strategy.md)
    - [Template Method](TiposPatrones/PatronesComportamiento/TemplateMethod.md)
    - [Visitor](TiposPatrones/PatronesComportamiento/Visitor.md)




La mayor parte de la info esta cogida de la web: [Refactoring Guru](https://refactoring.guru/es/design-patterns)
