# Decorator
También llamado: **Decorador**

## Proposito

Es un patron de diseño estructural que te permite añadir funcionalidades a objetos colocando estos objetos dentro de objetos encapsuladores especiales que contienen estas funcionalidades.

## Problema

Nuestro sistema requiere que la funcionalidad de ciertos componentes pueda extenderse y modificarse en tiempo de ejecución. Además pretendemos que esta característica no se implemente mediante herencia para poder aprovechar al máximo las clases existentes sin introducir jerarquías complejas y extensas.

Se aplica cuando:
- Necesitamos añadir responsabilidades a objetos individuales de forma dinámica y transparente
- Se pueden revocar responsabilidades antes asignadas a nuestros objetos.
- La extensión mediante herencia viola los principios SOLID.
- Necesitamos extender la funcionalidad de una clase pero la herencia no es una solución viable.
- Necesitamos extender la funcionalidad de un objeto en tiempo de ejecución e incluso eliminarla si fuera necesario.

## Solucion

Crearemos un nuevo peldaño en la jerarquía de clases llamado Decorator que encapsulará las nuevas responsabilidades. Esta nueva clase se encarga de redirigir las peticiones al componente original además de permitir la modificación de ciertos aspectos antes y después de dicha redirección. Con esta estructura, podremos añadir nuevas funcionalidades con forma de decoradores de manera recursiva.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789109-536dce79-cc09-4a44-8dad-9a1bafe31640.png)
