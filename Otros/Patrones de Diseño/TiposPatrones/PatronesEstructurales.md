# Patrones Estructurales
Los patrones estructurales explican cómo ensamblar objetos y clases en estructuras más grandes, a la vez que se mantiene la flexibilidad y eficiencia de estas estructuras

## Adapter
También llamado: **Adaptador**

### Proposito

Es un patron de diseño estructural que permite la colaboración entre objetos con interfaces incompatibles.

### Problema

Supongamos que estamos realizando una aplicacion en la que obtenemos datos en un formato, como `XML` y necesitamos enviar esos datos a un API de analisis, pero dicho API espera recibirlos en formato `JSON` para tratar los datos.  
Un error seria modificar el API, puesto que este espera el estandard JSON, pero si enviamos los datos en XML, logicamente no funcionaria.

![XML](../img/PatronEstructural/Adapter/Adapter1.png)

### Solucion

Se puede crear un *adaptador*. Un objeto que se convierte la interfaz de un objeto, de forma que otro pueda ser capaz de comprenderla.

Un adaptador se encargar de convertir un objeto a otro tipo de datos sin que este sea consciente ni siquiera de la existencia de tal proceso. Esta pensado para ocultar la complejidad del codigo correspondiente de realizar la conversión con la logica de codigo normal que se deberia de seguir.

El funcionamiento es el siguiente.

1. El adaptador obtiene una interfaz compatible con uno de los objetos.
2. Haciendo uso de esta interfaz, se pueden invocar los metodos del adaptador.
3. Al recibir una llamada, el adaptador pasa la solicitud al siguiente objeto, pero en el formato que este espera.


![XML](../img/PatronEstructural/Adapter/Adapter2.png)


### Estructura

**Adatador de Objetos**

Utiliza el principio de composicion de objetos, implementa la interfaz de un objeto y envuelve el otro

![XML](../img/PatronEstructural/Adapter/AdapterEstructura1.png)


**Clase Adaptadora**

Esta implementacion hace uso de la herencia, porque esta hereda interfaces de ambos objetos al mismo tiempo. ***Este metodo solo puede usarse en lenguajes con herencia multiple***

![XML](../img/PatronEstructural/Adapter/AdapterEstructura2.png)

## Bridge
También llamado: **Instancia única**

### Proposito



### Problema



### Solucion



### Estructura



## Composite
También llamado: **Instancia única**

### Proposito



### Problema



### Solucion



### Estructura



## Decorator
También llamado: **Instancia única**

### Proposito



### Problema



### Solucion



### Estructura



## Facade
También llamado: **Instancia única**

### Proposito



### Problema



### Solucion



### Estructura



## Flyweight
También llamado: **Instancia única**

### Proposito



### Problema



### Solucion



### Estructura



## Proxy
También llamado: **Instancia única**

### Proposito



### Problema



### Solucion



### Estructura




