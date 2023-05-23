# Iterator
También llamado: **Iterador**  
Ejemplo de uso: **`IEnumerable<T>`**

## Proposito

patrón de diseño de comportamiento que te permite recorrer elementos de una colección sin exponer su representación subyacente (lista, pila, árbol, etc.).

## Problema

El patrón Iterator se usa en el contexto de las listas y conjuntos. Tenemos una serie de objetos que internamente trabajan con conjuntos de elementos y necesitamos manipularlos abstrayéndonos de cómo están implementados internamente.

De esta manera si por alguna razón de eficiencia o funcionalidad necesitáramos cambiar la implementación interna del conjunto de elementos, el resto de nuestro sistema seguiría funcionando sin problemas.

Se aplica cuando:

- Debemos aplicar este patrón cuando tengamos que trabajar con objetos que internamente trabajan sobre un grupo de elementos y debamos poder manejar dichos elementos sin que un cambio en la implementación de la lista o cojunto afecte al sistema global.
- Otra situación en la que este patrón resulta de utilidad es cuando los elementos de una lista pueden ser recorridos de diferentes maneras. Por ejemplo tenemos una lista de números la cual podemos recorrer secuencialmente e inversamente, pero nuestro sistema debe hacerlo de la misma manera, sin necesidad de utilizar índices ni variables adicionales.

## Solucion

La solución consiste en crear una interfaz Iterator que estandarice los métodos para tratar la colección de elementos. Esta interfaz definirá una serie de operaciones para manipular los elementos del conjunto, como puede ser next() para obtener el siguiente elemento, hasNext() para comprobar que sigue habiendo elementos en el conjunto, current() para obtener el elemento actual o first() para mover el cursor al primer elemento y a la obtener una referencia al mismo.

Para implementar la interfaz Iterator utilizaremos una clase ConcreteIterator que implemente dicha interfaz, la cual se encargará de controlar la posición del cursor y manejar los elementos según las operaciones definidas por la interfaz.

Para crear objetos Iterator utilizaremos otra interfaz llamada Aggregate, que se encargará de devolver objetos Iterator a partir de nuestros objetos que manejan colecciones. A su vez se necesita un ConcreteAgreggate para definir de qué manera se crea cada Iterador en particular.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789249-70671cbc-adb6-4875-8c34-3fd9e6dc107a.png)
