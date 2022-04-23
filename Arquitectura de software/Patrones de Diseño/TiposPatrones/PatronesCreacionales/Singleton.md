# Singleton
También llamado: **Instancia única**

## Proposito

Es un patron que nos permite asegurarnos de que una clase, tenga solamente una instancia unica, proporcionando un acceso global a dicha instancia

## Problema

1. **Garantizar que una clase tenga una unica instancia.** Lo habitual de esto es controlar el acceso a algun recurso compartido, como Bases de datos, etc.

2. **Proporcionar un punto de acceso global a dicha instancia** Gracias a este patrón, se podra acceder a la instancia desde cualquier parte del codigo y se evita que se sobreescriba.

## Solucion

Todas las implementaciones de Singleton se realizan de la siguiente forma:

- Hacer el contructor de la clase privado, para que no se pueda realizar un `new X()` desde ningun lado, puesto que romperia el patron.
- Crear un método static que cree la instancia de la clase y guardar el objeto generado en una variable privada que actue como `cache`, cuando se requiera volver a instanciar el metodo, se devolvera directamente el objeto guardado.

Un ejemplo de un patron Singleton, podria ser la implementacion de una Caché, para tener datos en memoria

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147788845-31e1fb20-c822-43ce-acb7-3ae4122a5fcd.png)
