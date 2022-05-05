# Yield
El operador `yield` es una instruccion que se utiliza para realizar una ejecución diferida, eso significa, que se ejecutará el codigo de la funcion que contiene el `yield return x` cuando esta sea iterada, por ejemplo, mediante un foreach.

Internarmente en tiempo de compilación, yield se convierte en una clase, que implementará la interface `IEnumerable` y en el método nuestro, se retornara una instancia de la clase creada.

Codigo descompilado:
```Csharp
IEnumerable cosa = ObteniendoCosas();

IEnumerable ObteniendoCosas()
{
    <ObteniendoCosas>d__5 <ObteniendoCosas>d__ = new <ObteniendoCosas>d__5 (-2);
    <ObteniendoCosas>d__.<>4__this = this;
    return <ObteniendoCosas>d__;
}
```

Despues de esta instancia, nosotros usamos el bucle `foreach` para leer los obetos `IEnumerable`, pero en realidad se convierte en un bucle `While` que, como se ha obtenido el `IEnumerator`, se utiliza el metodo `MoveNext()` para mover el índice de la lista y devolver el objeto `Current` para su uso.

```Csharp
IEnumerator enumerator = cosa.GetEnumerator();
try
{
    while (enumerator.MoveNext ())
    {
        object item = enumerator.Current;
    }
}
finally
{
    IDisposable disposable = enumerator as IDisposable;
    if (disposable != null)
    {
        disposable.Dispose ();
    }
}
```

## Motivmos de uso
- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común

```Csharp
foreach(var collect in collection)
{
    yield return collect;
}
```
