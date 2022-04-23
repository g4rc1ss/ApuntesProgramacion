# Facade
También llamado: **Fachada**

## Proposito

Patrón de diseño estructural que proporciona una interfaz simplificada a una biblioteca, un framework o cualquier otro grupo complejo de clases.

## Problema

Imagina que debes lograr que tu código trabaje con un amplio grupo de objetos que pertenecen a una sofisticada biblioteca o framework. Normalmente, debes inicializar todos esos objetos, llevar un registro de las dependencias, ejecutar los métodos en el orden correcto y así sucesivamente.

Como resultado, la lógica de negocio de tus clases se vería estrechamente acoplada a los detalles de implementación de las clases de terceros, haciéndola difícil de comprender y mantener.

Se aplica cuando:
- Nuestro sistema cliente tiene que acceder a parte de la funcionalidad de un sistema complejo.
- Hay tareas o configuraciones muy frecuentes y es conveniente simplificar el código de uso.
- Necesitamos hacer que una librería sea más legible.
- Nuestros sistemas clientes tienen que acceder a varias APIs y queremos simplificar dicho acceso.

## Solucion

La solución consiste en crear una clase fachada que proporcione la funcionalidad de manera sencilla a nuestro sistema cliente. Dicha clase utilizará la clase compleja o los distintos componentes de los sistemas requeridos y los ofrecerá por medio de operaciones más simples.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789126-ea578001-d7bf-4d84-b23c-9e5e78a498ff.png)
