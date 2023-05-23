# Factory Method
También llamado: **Metodo de fábrica**

## Proposito

Consiste en la creacion de instancias de una superclase o interface y poder devolverlas en instancias de la subclase

El patrón Factory Method sugiere que, en lugar de llamar al operador new para construir objetos directamente, se invoque a un método fábrica especial

## Problema

Suponiendo una aplicacion de control de logistica, en la primera versión del codigo, lo realizas pensando en que el metodo de transporte es, por ejemplo, `camion`, pero mas adelante tienes las necesidades de agregar mas metodos como maritimo, aereo, etc.

Al final te ves obligado a repetir codigo o tener que agregar condicionales extras, etc.


## Solucion

La solución es implementar un nivel de abstraccion creando una `interface Transporte`, las clases de transporte `Camion`, `Barco`, `Avion` por ejemplo y estas deberan de implementar la interface `Transporte`.

![image](https://user-images.githubusercontent.com/28193994/147788737-2b125613-939e-40c9-a029-0a58f382343c.png)

Una clase abstracta o interface `MedioTransporte` y tendra un metodo para crear un transporte y creamos subclases que sean referentes a `Tierra`, `Agua`, `Aire`. 

En el medio de transporte por tierra se pueden usar Camiones, trenes, etc.  
Entonces lo que se hace es crear un metodo de factoria que devuelva un `Transporte`(clase abstracta o interface) y ahi es donde se realizara la logica de devolver una instancia de la clase `Camion` o `Tren` o la correspondiente.

![image](https://user-images.githubusercontent.com/28193994/147788760-bf326659-9199-4cf6-9037-fd47bdeb02be.png)


## Estructura

![image](https://user-images.githubusercontent.com/28193994/147788771-8914e463-31ee-48aa-8e3e-5775586901eb.png)