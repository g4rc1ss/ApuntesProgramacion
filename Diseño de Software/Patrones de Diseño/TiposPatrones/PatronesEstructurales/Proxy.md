# Proxy

## Proposito

Patrón de diseño estructural que te permite proporcionar un sustituto o marcador de posición para otro objeto. Un proxy controla el acceso al objeto original, permitiéndote hacer algo antes o después de que la solicitud llegue al objeto original.

## Problema
El patrón proxy trata de proporcionar un objeto intermediario que represente o sustituya al objeto original con motivo de controlar el acceso y otras características del mismo.

Se aplica cuando:

El patrón Proxy se usa cuando se necesita una referencia a un objeto más flexible o sofisticada que un puntero. Según la funcionalidad requerida podemos encontrar varias aplicaciones:

- Proxy remoto: representa un objeto en otro espacio de direcciones.
- Proxy virtual: retrasa la creación de objetos costosos.
- Proxy de protección: controla el acceso a un objeto.
- Referencia inteligente: tiene la misma finalidad que un puntero pero además ejecuta acciones adicionales sobre el objeto, como por ejemplo el control de concurrencia.

## Solucion

La solución a este problema es crear una interfaz Subject que defina toda la funcionalidad que nuestro objeto ha de proveer. Esta interfaz, evidentemente, ha de ser implementada por el objeto real. Crearemos también un Objeto Proxy que mantendrá una referencia al objeto real, y que además implementará la interfaz Subject, de modo que a la hora de precisar la funcionalidad sea indiferente si se está ejecutando el Proxy o el objeto real.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789165-0edbff46-f05e-4061-beb3-1b0a95e0e360.png)
