# Listas (`List<T>`)
Una lista es un tipo de colección ordenada.
> Estos objetos no son seguros para subprocesos, para ello es mejor usar `ConcurrentBag<T>`

1. `Add`: Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
1. `IndexOf`: Devuelve la posicion de la lista donde se ubica el objeto a buscar
1. `Insert`: Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
1. `Remove`: Eliminar de la lista el objeto indicado
1. `Reverse`: Ordenas la lista al contra
