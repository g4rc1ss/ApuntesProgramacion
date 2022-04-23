# Abstract Method
También llamado: **Fábrica Abstracta**

## Proposito

Permite producir familias de objetos relacionados sin especificar sus clases concretas.

El patrón Abstract Factory está aconsejado cuando se prevé la inclusión de nuevas familias de productos, pero puede resultar contraproducente cuando se añaden nuevos productos o cambian los existentes, puesto que afectaría a todas las familias creadas.

## Problema

Debemos crear diferentes objetos, todos pertenecientes a la misma familia. Por ejemplo: las bibliotecas para crear interfaces gráficas suelen utilizar este patrón y cada familia sería un sistema operativo distinto. Así pues, el usuario declara un Botón, pero de forma más interna lo que está creando es un BotónWindows o un BotónLinux, por ejemplo.

El problema que intenta solucionar este patrón es el de crear diferentes familias de objetos.

## Solucion

Crear una interfaz que declare las factorias que se tienen que implementar y mediante abstraccion, se podran usar varias clases que lleven a cabo de esa tarea.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147788794-42ab7799-31da-43c0-89a2-14fa9c4a7619.png)