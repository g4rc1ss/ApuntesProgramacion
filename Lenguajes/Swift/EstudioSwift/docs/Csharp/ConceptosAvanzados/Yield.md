# Yield
El operador `yield` es una instruccion que se utiliza para realizar una ejecución diferida, eso significa, que se ejecutará el codigo de la funcion que contiene el `yield return x` cuando esta sea iterada, por ejemplo, mediante un foreach.

Para hacer uso de `yield` tenemos que declarar un método el cual tiene que devolver la interfaz `IEnumerable` para que el compilador pueda detectar lo que se esta indicando. Teniendo un codigo como el siguiente:
```Csharp
IEnumerable ObteniendoCosas()
{
	Console.WriteLine("Primera linea de codigo");
	Console.WriteLine("Segunda linea de codigo");
	Console.WriteLine("Tercera linea de codigo");
	Console.WriteLine("Cuarta linea de codigo");
	Console.WriteLine("Quinta linea de codigo");
	
	for(var i = 0; i < 10; i++)
	{
		yield return i;
	}
}
```

Internarmente en tiempo de compilación, `yield` se convierte en una clase, que implementará la interface `IEnumerable` y en nuestro método, se retornara una instancia de esa clase.

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

Despues de esta instancia, nosotros usamos el bucle `foreach` para leer los objetos `IEnumerable`, pero en realidad el compilador utiliza un bucle `While` que, leyendo el `IEnumerator`, se utiliza el metodo `MoveNext()` para mover el índice de la lista y retornar un `true` o un `false` en funcion de si hay mas elementos.

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

El método `MoveNext()` como podemos comprobar contiene la lógica del metodo declarado al principio.

De una forma simple, el objeto contiene una variable para gestionar los diferentes estados, de esta forma, la primera vez que iteremos el código, se obtiene el `State` a 0 y por tanto se ejecutarán los `Console.WriteLine()`, se asignará al objeto `Current` el primer valor y se modificará el estado en función de donde vaya entrando hasta que devuelva un `true` o un `false`

```Csharp
<ObteniendoCosas>d__5.MoveNext()
{
    int num = <>1__state;
    if (num != 0)
    {
        if (num != 1)
        {
                return false;
        }
        <>1__state = -1;
        <i>5__1++;
    }
    else
    {
        <>1__state = -1;
        Console.WriteLine ("Primera linea de codigo");
        Console.WriteLine ("Segunda linea de codigo");
        Console.WriteLine ("Tercera linea de codigo");
        Console.WriteLine ("Cuarta linea de codigo");
        Console.WriteLine ("Quinta linea de codigo");
        <i>5__1 = 0;
    }
    if (<i>5__1 < 10)
    {
        <>2__current = <i>5__1;
        <>1__state = 1;
        return true;
    }
    return false;
}
```

## Motivmos de uso
- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común

