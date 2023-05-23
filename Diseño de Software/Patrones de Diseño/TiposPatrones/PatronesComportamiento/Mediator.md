# Mediator
También llamado: **Mediador, Intermediary, Controller**  
Ejemplo de uso: **Framework `Mediatr` de .Net**

## Proposito

Patrón de diseño de comportamiento que te permite reducir las dependencias caóticas entre objetos. El patrón restringe las comunicaciones directas entre los objetos, forzándolos a colaborar únicamente a través de un objeto mediador.

## Problema

En sistemas complejos en los que múltiples componentes actúan entre si, la complejidad de las dependencias puede crecer exponencialmente si tratamos de ampliarlo. Este escenario es típico de las interfaces gráficas y muchos otros prototipos software.

Además si hubiese que modificar un componente, habría que redefinir todas las dependencias explícitas en cada uno de los demás integrantes del sistema. También podemos ver las consecuencias que esto acarrearía si surge una excepción en uno de los componentes, esta se arrastraría a todos los que dependan de ella, y a su vez a los demás, pudiendo hacer caer el sistema si no se gestiona correctamente.

El contexto en el que actúa este patrón es en el de aplicaciones o sistemas cuyos integrantes se comunican activamente. Si la complejidad en la interacción es excesiva, encapsularla en una clase no contribuye demasiado al desacoplamiento, por lo que deberemos crear varios intermediarios.

 

Se aplica cuando:

- Nuestro sistema tiene gran número de objetos que se comunican de forma activa, y dicha comunicación es compleja y está bien definida.
La reutilización de un objeto es difícil ya que es dependiente de muchos otros.
- Si nuestro sistemas es excesivamente complejo deberemos subdividirlo en varios Mediator.

## Solucion

La solución consiste en crear una entidad intermediaria que se encargue de gestionar la comunicación entre objetos. En primer lugar definiremos una interfaz para exponer las operaciones que un intermediario puede realizar, la cual llamaremos Mediator. Como es evidente debemos implementar dicha interfaz mediante una clase ConcreteMediator para dotar a éste de funcionalidad.

El siguiente paso es definir la interfaz de los integrantes del sistema, la cual llamaremos Colleague (que significa literalmente colega). Aquí se expondrán todas las operaciones que un objeto perteneciente al sistema puede realizar para comunicarse. Podemos crear diferentes tipos de colegas siempre y cuando respeten la interfaz.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789257-7fcbff3c-79f9-4cb0-88ad-c15b3e270cd6.png)
