Todas las colecciones ofrecen métodos para agregar, quitar o buscar elementos.

# Listas (`List<T>`)
Una lista es un tipo de colección ordenada.
> Estos objetos no son seguros para subprocesos, para ello es mejor usar `ConcurrentBag<T>`

1. `Add`: Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
1. `IndexOf`: Devuelve la posicion de la lista donde se ubica el objeto a buscar
1. `Insert`: Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
1. `Remove`: Eliminar de la lista el objeto indicado
1. `Reverse`: Ordenas la lista al contra

# Diccionario (`Dictionary<TKey, TValue>`)
Es una estructura de datos que representa una colección de pares clave-valor

> - La clave tiene que ser única.  
> - No se soporta la concurrencia o multihilo. Para ello se debe de usar `ConcurrentDictionary<TKey, TValue>`

1. `Keys`: Devuelve una lista con las claves del diccionario
1. `Values`: Devuelve una lista con los valores del diccionario
1. `ContainsKey`: Devuelve un bool indicando si la clave existe en el diccionario
1. `Remove`: Elimina la Key del diccionario y por tanto, los valores asociados a la misma
1. `TryGetValue`: Metodo para obtener el valor asociado a la clave indicada

# Pilas  (`Stack<T>`)
Coleccion de tipo **LIFO**(Last in, First Out), los elementos mas recientes son los que iremos obteniendo en iteracion.
> Para crear un Stack seguro para subprocesos, usaremos `ConcurrentStack<T>`

1. `Push`: Inserta un elemento al principio de `Stack<T>`
1. `Pop`: Quita y devuelve el objeto situado al principio
1. `Peek`: Devuelve el objeto situado al principio de `Stack<T>` sin eliminarlo.
1. `Clear`: Quita todos los objetos de la coleccion
1. `Contains`: Comprueba si exite el item que le pasamos por parametro

# Colas  (`Queue<T>`)
Coleccion de tipo **FIFO**(First in, First out), el primer elemento que insertamos, sera el primero que recogemos al recorrer la coleccion
> Para crear una Queue segura para subprocesos, usaremos `ConcurrentQueue<T>`

1. `Enqueue`: Agrega un nuevo elemento al final de la coleccion
1. `Dequeue`: Elimina el elemento mas antiguo, por tanto el primer elemento de la coleccion
1. `Peek`: Devuelve el elemento mas antiguo de la coleccion
1. `Clear`: Limpia todos los elementos de la coleccion
1. `Contains`: Comprobamos si la coleccion contiene un objeto especifico

# IEnumerable
Expone un `Enumerator` para hacer un objeto iterable mediante instrucciones como `foreach` o el uso de librerias como `linq`
- **GetEnumerator**: Es el encargado de vincular el objeto con un enumerador para procesar su iteracion.
```Csharp
public class EnumerablePersonalizado<T> : IEnumerable<T>
{
    public T[] enumerable;

    public EnumerablePersonalizado(int maxIndex)
    {
        enumerable = new T[maxIndex];
    }

    public IEnumerator<T> GetEnumerator() => new EnumeradorPersonalizado<T>(enumerable);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```

# IEnumerator
Implementa el proceso de iteracion de un objeto.
- **MoveNext**: Donde se ubica la logica de la iteracion, se debe de devolver un true o false para indicar si es posible dicha iteracion
- **Reset**: Reseteamos el puntero de la interacion a la posicion inicial.

```Csharp
public class EnumeradorPersonalizado<T> : IEnumerator<T>
{
    public T Current { get; set; }

    public bool MoveNext()
    {
        if (++indiceActual >= collection.Length)
        {
            return false;
        }
        else
        {
            objetoActual = collection[indiceActual];
        }
        return true;
    }

    public void Reset()
    {
        indiceActual = -1;
    }
}
```

