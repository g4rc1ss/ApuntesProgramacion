# Patrones Creacionales

Los patrones creacionales proporcionan formas de creacion de objetos y permiten la reutilización de codigo existente.


## Factory Method
También llamado: **Metodo de fábrica**

### Proposito

Consiste en la creacion de instancias de una superclase o interface y poder devolverlas en instancias de la subclase

El patrón Factory Method sugiere que, en lugar de llamar al operador new para construir objetos directamente, se invoque a un método fábrica especial

### Problema

Suponiendo una aplicacion de control de logistica, en la primera versión del codigo, lo realizas pensando en que el metodo de transporte es, por ejemplo, `camion`, pero mas adelante tienes las necesidades de agregar mas metodos como maritimo, aereo, etc.

Al final te ves obligado a repetir codigo o tener que agregar condicionales extras, etc.


### Solucion

La solución es implementar un nivel de abstraccion creando una `interface Transporte`, las clases de transporte `Camion`, `Barco`, `Avion` por ejemplo y estas deberan de implementar la interface `Transporte`.

![transporte](../img/PatronCreacional/FactoryMethod/FactoryMethod1.png)

Una clase abstracta o interface `MedioTransporte` y tendra un metodo para crear un transporte y creamos subclases que sean referentes a `Tierra`, `Agua`, `Aire`. 

En el medio de transporte por tierra se pueden usar Camiones, trenes, etc.  
Entonces lo que se hace es crear un metodo de factoria que devuelva un `Transporte`(clase abstracta o interface) y ahi es donde se realizara la logica de devolver una instancia de la clase `Camion` o `Tren` o la correspondiente.

![transporte](../img/PatronCreacional/FactoryMethod/FactoryMethod2.png)


### Estructura

![transporte](../img/PatronCreacional/FactoryMethod/FactoryMethod3.png)


---
## Abstract Method

### Proposito



### Problema



### Solucion



### Estructura

---
## Builder

### Proposito



### Problema



### Solucion



### Estructura

---
## Prototype

### Proposito



### Problema



### Solucion



### Estructura

---
## Singleton

### Proposito



### Problema



### Solucion



### Estructura