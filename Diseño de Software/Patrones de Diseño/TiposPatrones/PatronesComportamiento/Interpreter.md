# Interpreter
También llamado: **Interprete**

## Proposito

Lo que trata este patrón, como su propio nombre indica, es implementar un intérprete para un lenguaje concreto. Un ejemplo rápido de lenguaje para saber de lo que hablamos sería el de las expresiones aritméticas: dada una expresión aritmética debemos ser capaces de construir un intérprete que tomándola como entrada obtenga el resultado de evaluar dicha expresión.

## Problema

Nuestro sistema tiene que ser capaz de reconocer sentencias de un lenguaje previamente conocido (mediante su gramática), poder evaluar expresiones del mismo y ser capaz de ejecutar las sentencias recibidas.

Por ejemplo tenemos un sistema que recibe como entradas números romanos, y debemos de poder tratarlas como números enteros para poder trabajar computacionalmente con ellos.

Se aplica cuando:

- Debemos trabajar con sentencias de un lenguaje que nuestro lenguaje de programación no reconoce automáticamente.
- La gramática del lenguaje con el que debemos trabajar es sencilla. Para gramáticas complejas se deben emplear técnicas concretas de la Teoría de Gramáticas Formales (scanners y parsers).
- No debe utilizarse si ya existe alguna clase nativa que interprete éste lenguaje. Por ejemplo en Python, si recibimos una expresión aritmética mediante un String, utilizaremos la función eval() en lugar de implementar un Interpreter.


## Solucion

La solución es representar la gramática del lenguaje (previamente definida) mediante una jerarquía de objetos. Los nodos terminales de las producciones los representaremos creando clases TerminalExpression y los nodos no terminales con NonterminalExpression. Ambas clases implementan una interfaz común (o heredan de una clase abstracta común) llamada AbstractExpression y que contendrá la declaración del métdo interpret(), que se encargará de evaluar el nodo en concreto.

Además puede existir un contexto común a todas las expresiones que defina ciertos valores, funciones o características del lenguaje que estamos interpretando. Este contexto será representado con la clase Context. El cliente se encargará de construir el árbol sintáctico de la expresión y asignar el contexto en caso de haberlo.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789237-ed1f80d4-6aba-4c9c-9df9-a463c83e9a8d.png)
