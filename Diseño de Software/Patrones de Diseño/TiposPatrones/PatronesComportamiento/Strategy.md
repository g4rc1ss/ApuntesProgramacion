# Strategy
También llamado: **Estrategia**

## Proposito

Patrón de diseño de comportamiento que te permite definir una familia de algoritmos, colocar cada uno de ellos en una clase separada y hacer sus objetos intercambiables.

## Problema

Se debe utilizar el patrón Strategy cuando:
- Se quiera configurar una clase con un comportamiento determinado de entre varios.
- Se necesitan distintas variaciones de un algoritmo.
- Los distintos comportamientos de una clase aparecen como múltiples sentencias condicionales. El patrón Strategy permite mover cada rama de esos condicionales anidados a su propia clase.

## Solucion

El patrón Strategy sugiere que tomes esa clase que hace algo específico de muchas formas diferentes y extraigas todos esos algoritmos para colocarlos en clases separadas llamadas estrategias.

La clase original, llamada contexto, debe tener un campo para almacenar una referencia a una de las estrategias. El contexto delega el trabajo a un objeto de estrategia vinculado en lugar de ejecutarlo por su cuenta.

La clase contexto no es responsable de seleccionar un algoritmo adecuado para la tarea. En lugar de eso, el cliente pasa la estrategia deseada a la clase contexto. De hecho, la clase contexto no sabe mucho acerca de las estrategias. Funciona con todas las estrategias a través de la misma interfaz genérica, que sólo expone un único método para disparar el algoritmo encapsulado dentro de la estrategia seleccionada.

De esta forma, el contexto se vuelve independiente de las estrategias concretas, así que puedes añadir nuevos algoritmos o modificar los existentes sin cambiar el código de la clase contexto o de otras estrategias.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789326-451312a6-26a7-414a-871a-c8c388b941f8.png)
