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