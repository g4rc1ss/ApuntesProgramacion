# Yield
Lo que el operador yield realiza es pausar la ejecución de la iteración y devuelve el valor al método que realiza la llamada para que este continúe con su ejecución y cuando termine volverá al siguiente punto del iterador.

- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común

```Csharp
public class EnumerablePersonalizado<T> : IEnumerable<T>
{
    public T[] collection;

    public EnumerablePersonalizado(int maxIndex)
    {
        collection = new T[maxIndex];
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach(var collect in collection)
        {
            yield return collect;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```
