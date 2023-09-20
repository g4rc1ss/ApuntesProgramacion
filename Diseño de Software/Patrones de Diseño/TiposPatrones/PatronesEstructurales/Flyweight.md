# Flyweight
También llamado: **Cache**

## Proposito

Patrón de diseño estructural que te permite mantener más objetos dentro de la cantidad disponible de RAM compartiendo las partes comunes del estado entre varios objetos en lugar de mantener toda la información en cada objeto.

## Problema

Nuestro sistema tiene un tipo de componente que se repite numerosas veces, y las instancias tienen una serie de características en común. Queremos optimizar el tamaño en memoria que ocupa para sacar el máximo partido al sistema y no desaprovechar los recursos con datos redundantes.

Se aplica cuando:
- Se necesita eliminar o reducir la redundancia cuando se tiene gran cantidad de objetos que comparten bastante información.
- Nuestro soporte tiene memoria limitada y esta necesita ser aprovechada óptimamente.
- La identidad propia de los objetos es irrelevante.

![image](https://user-images.githubusercontent.com/28193994/147789140-76f20d13-ea24-4731-8a5b-e4d837f5dac7.png)

## Solucion

Para solucionar este escenario, debemos de abstraer las características del elemento que se replica en 2 grupo: las intrínsecas y las extrínsecas. Las primeras hacen referencia a los estados comunes que tiene el objeto o grupo de objetos a replicar, mientras que las segundas aluden a las características propias de la instancia.

De esta manera, nuestor objetivo será estudiar las características comunes de los objetos y crear una clase extrínseca. Luego a la hora de realizar las diferentes instancias, cojeremos la parte común (intrínseca) y la complementaremos con los datos específicos de la instancia.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789154-308611f1-d74a-46c9-8bde-6ac30127d668.png)
