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

