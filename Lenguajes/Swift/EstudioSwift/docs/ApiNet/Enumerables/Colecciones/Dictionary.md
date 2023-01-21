# Diccionario (`Dictionary<TKey, TValue>`)
Es una estructura de datos que representa una colección de pares clave-valor

> - La clave tiene que ser única.  
> - No se soporta la concurrencia o multihilo. Para ello se debe de usar `ConcurrentDictionary<TKey, TValue>`

1. `Keys`: Devuelve una lista con las claves del diccionario
1. `Values`: Devuelve una lista con los valores del diccionario
1. `ContainsKey`: Devuelve un bool indicando si la clave existe en el diccionario
1. `Remove`: Elimina la Key del diccionario y por tanto, los valores asociados a la misma
1. `TryGetValue`: Metodo para obtener el valor asociado a la clave indicada