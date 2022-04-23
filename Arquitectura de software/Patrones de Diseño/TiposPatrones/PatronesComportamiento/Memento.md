# Memento
También llamado: **Snapshot**

## Proposito

Patrón de diseño de comportamiento que te permite guardar y restaurar el estado previo de un objeto sin revelar los detalles de su implementación.

## Problema

A veces es necesario guardar el estado interno de un objeto. Esto es necesario cuando se implementan casillas de verificación o mecanismos de deshacer que permiten a los usuarios anular operaciones provisionales y recuperarse de los errores. Debe guardarse información del estado en algún sitio para que los objetos puedan volver a su estado anterior. Pero los objetos normalmente encapsulan parte de su estado, o todo, haciéndolo inaccesible a otros objetos e imposible de guardar externamente. Exponer este estado violaría la encapsulación, lo que puede comprometer la fiabilidad y extensibilidad de la aplicación.

Se aplica cuando:

- Hay que guardar una instantánea del estado de un objeto (o de parte de éste) para que pueda volver posteriormente a ese estado, y
- Una interfaz directa para obtener el estado exponga detalles de implementación y rompa la encapsulación del objeto

## Solucion

Un memento es un objeto que almacena una instantánea del estado interno de otro objeto -el creador del memento-. El mecanismo de deshacer solicitará un memento al creador cuando necesite comprobar el estado de éste. El creador inicializa el memento con información que representa su estado actual. Sólo el creador puede almacenar y recuperar información del memento -el memento es "opaco" a otros objetos-.

## Estructura

Implementación basada en clases anidadas
![image](https://user-images.githubusercontent.com/28193994/147789271-b374b76f-ce63-435d-9586-7bb83ec3403c.png)

Implementación con una encapsulación más estricta
![image](https://user-images.githubusercontent.com/28193994/147789278-8ac85aab-42c6-4380-90c0-6abdbd8e11d8.png)
