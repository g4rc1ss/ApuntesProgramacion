# Colas  (`Queue<T>`)
Coleccion de tipo **FIFO**(First in, First out), el primer elemento que insertamos, sera el primero que recogemos al recorrer la coleccion
> Para crear una Queue segura para subprocesos, usaremos `ConcurrentQueue<T>`

1. `Enqueue`: Agrega un nuevo elemento al final de la coleccion
1. `Dequeue`: Elimina el elemento mas antiguo, por tanto el primer elemento de la coleccion
1. `Peek`: Devuelve el elemento mas antiguo de la coleccion
1. `Clear`: Limpia todos los elementos de la coleccion
1. `Contains`: Comprobamos si la coleccion contiene un objeto especifico
