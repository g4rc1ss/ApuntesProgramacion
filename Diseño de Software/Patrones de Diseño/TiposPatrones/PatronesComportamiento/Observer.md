# Observer
También llamado: **Listener**  
Ejemplo de uso: **Las GUI, cuando pulsas un boton, internamente el estado de ese boton cambia, puesto que ha sido pulsado y se ejecuta la accion correspondiente a ese boton.**

## Proposito

Patrón de diseño de comportamiento que te permite definir un mecanismo de suscripción para notificar a varios objetos sobre cualquier evento que le suceda al objeto que están observando.

## Problema

Se necesita la ejecucion de unas serie de instrucciones cuando el estado de un objeto cambie.

Supongamos que necesitamos enviar un correo electronico o mostrar una notificacion por pantalla cuando el precio de un producto cambie.


## Solucion

Que el objeto del cual dependen los demás (observado) tenga un listado de ellos (observadores) y les notifique cuando sea necesario. Es decir, en un cambio de estado o acción.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789450-600abca4-0dd2-4b9d-ad6f-62472bebcbc6.png)
