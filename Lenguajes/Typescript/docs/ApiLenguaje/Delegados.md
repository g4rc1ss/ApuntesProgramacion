Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

```Csharp
delegate void DelegadoNormal(string texto);
delegate void DelegadoGeneric<in T>(T objeto);
delegate string DelegadoRetorna(string textp);
delegate TResult DelegadoGenericCompleto<in TSource, out TResult>(TSource objeto);

var ejemplo = new DelegadoNormal(Console.WriteLine);
ejemplo("Hola, soy el delegado normal");
```

# Delegados como Parametros
El uso de delegados como parametros permite agregar flexibilidad a la hora de desarrollar, por ejemplo, una clase que realiza una consulta a base de datos y queremos mapear el resultado. Nosotros realizamos la consulta y el mapeo nos lo puede pasar el usuario, puesto que no tenemos por que saber el nombre de los campos que nos devolverá

## Action
Permite ejecutar un delegado siempre que este no retorne nigun resultado.

Si el delegado tiene que recibir parametros, se indicaran a traves de `generics`, por ejemplo, `Action<T1> action` o `Action<string> action`
```Csharp
public static void Run(Action action) => action();

persona.Run(x => Imprimir("Soy un action"));
persona.Run(x =>
{
    Console.WriteLine("Soy un action");
});
```

## Func
Permite devolver un resultado en la ejecucion del delegado.
```Csharp
public static TResult Run<TResult>(Func<TResult> func) => func();
public static TResult Run<T1, TResult>(this T1 x, Func<T1, string, TResult> func) => func(x, "");

ClaseFunc.Run(() => string.Empty);
```

