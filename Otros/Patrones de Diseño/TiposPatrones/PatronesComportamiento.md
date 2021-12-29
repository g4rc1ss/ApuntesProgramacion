# Patrones de Comportamiento

## Chain of Responsability
También llamado: **Cadena de Responsabilidad**  
Ejemplo de uso: **Middleware**

### Proposito

Patrón de diseño de comportamiento que te permite pasar solicitudes a lo largo de una cadena de manejadores. Al recibir una solicitud, cada manejador decide si la procesa o si la pasa al siguiente manejador de la cadena.

### Problema

Cuando hay comunicación entre 2 objetos, normalmente estos se acoplan mediante una conexión. Pretendemos desacoplar el sistema, pero nuestro problema es que el receptor del mensaje no va a conocer directamente el origen del mismo. El patrón Chain of Resbonsability trata de resolver esta situación.

Se aplica cuando:

- Varios objetos pueden manejar cierta petición, y el manejador no se conoce a priori, sino que debería determinarse automáticamente.
- Pretendemos enviar un mensaje a un objeto entre varios sin especificar explícitamente el receptor.
- Los objetos que pueden tratar el mensaje deberían ser especificados dinámicamente.

### Solucion

Para solucionar este problema debemos encontrar un mecanismo mediante el cual pasar mensajes a través la cadena de objetos, para que si el que lo recibe no sabe procesarlo lo pase a otro objeto.

Para lograr esto, crearemos una interfaz Manejador que permite tratar las peticiones en general. Crearemos también algunos ManejadoresConcretos que son los que se encargan de procesar una petición concreta. El cliente que desea enviar el mensaje pasará el mismo a un Manejardor concreto, que se encargará o bien de procesarlo o bien de transferirlo a otros objetos que pertenezcan a la cadena.

### Estructura

![](../img/PatronComportamiento/ChainOfResponsability/ChainOfResponsabilityEstructura.png)


## Command
También llamado: **Transaction**

### Proposito

Patrón de diseño de comportamiento que convierte una solicitud en un objeto independiente que contiene toda la información sobre la solicitud. Esta transformación te permite parametrizar los métodos con diferentes solicitudes, retrasar o poner en cola la ejecución de una solicitud y soportar operaciones que no se pueden realizar.

### Problema

En el contexto de programación actual un simple programa puede ejecutar decenas, o incluso centenares, de invocaciones a subprocesos o subprogramas. En ocasiones es muy conveniente desacoplar la invocación de determinados procesos del contexto donde se encuentran, y ésto es precisamente el problema que viene a solucionar el patrón Command.

Además pueden surgir situaciones en las que las invocaciones deban de tratarse por medio de una cola, pila o estructura de datos similar. Mediante el patrón Command podemos realizar estas acciones de manera sencilla.

Se aplica cuando:

- Precisamos de colas, pilas u otras estructuras para gestionar las invocaciones.
- Exista la posibilidad de cancelar operaciones.
- Se necesite parametrizar de manera uniforme las invocaciones.
- El momento de ejecución del subprograma o subproceso deba de ser independiente del contexto en el que se invoca.
- Necesitemos realizar llamadas a órdenes cuyos parámetros puedan ser otras órdenes (callbacks).
- Las órdenes que debemos desarrollar son de alto nivel y por debajo son implementadas por órdenes simples (primitivas).

### Solucion

La solución consiste en crear una interfaz Command que contenga un método execute, permitiendo desde la misma ejecutar la operación a la que representa el comando. Adicionalmente, si se permite deshacer operaciones, deberemos añadir un método undo para poder hacerlo.

Las clases que implementen Command, a las que llamaremos ConcreteCommands, definirán la funcionalidad de la orden a la que representa el comando mediante la definición del método execute. Para ello utilizaremos los métodos del objeto que realmente implementa la funcionalidad, al que llamaremos Receiver.

La configuración de los ConcreteCommands y del Receiver se establecera mediante una entidad Client. Otra entidad llamada Invoker será la que utilizará la/las órden/órdenes implementadas.

### Estructura

![](../img/PatronComportamiento/Command/CommandEstructura.png)

## Iterator
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Iterator/IteratorEstructura.png)

## Mediator
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Mediator/MediatorEstructura.png)

## Memento
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Memento/MementoEstructura.png)

## Observer
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Observer/ObserverEstructura.png)

## State
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/State/StateEstructura.png)

## Strategy
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Strategy/StrategyEstructura.png)

## Template Method
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Method/MethodEstructura.png)

## Visitor
También llamado: ****

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronComportamiento/Visitor/VisitorEstructura.png)
