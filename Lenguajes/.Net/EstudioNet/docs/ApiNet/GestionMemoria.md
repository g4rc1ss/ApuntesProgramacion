La administración de memoria automática es uno de los servicios que proporciona el CLR durante la ejecución. Los programadores no tienen que escribir código para realizar tareas de administración de memoria al programar aplicaciones administradas. La administración automática de la memoria puede eliminar problemas frecuentes, como olvidar liberar un objeto y causar una pérdida de memoria.

# Garbage Collector
El recolector de elementos no utilizados administra la asignación y liberación de la memoria de una aplicación.

## Asignar memoria
Cuando inciamos la aplicacion, se reserva un espacio para las direcciones de memoria denominado montón administrado, que contiene un puntero a la dirección que se asignará al siguiente objeto. Todos los tipos de referencia se asignan en el montón administrado. Cuando creamos el primer tipo de referencia, se le asigna la memoria base del montón. Cuando creamos el resto de objetos se va asignando memoria en los espacios que siguen inmediatamente despues a la asignacion del ultimo objeto.

La asignación de memoria desde el montón administrado es más rápida que la asignación de memoria no administrada. Como el JIT asigna memoria a los objetos agregando un valor a un puntero, este método es casi tan rápido como la asignación de memoria desde la pila. Además, puesto que los nuevos objetos que se asignan consecutivamente se almacenan uno junto a otro en el montón administrado, la aplicación puede tener un acceso muy rápido a los objetos.


## Liberar memoria
El **GC** determina cuál es el mejor momento para realizar una recolección basándose en las asignaciones. Cuando lleva a cabo una recolección, libera la memoria de los objetos que no se usan. 

**GC** determina qué objetos ya no se usan examinando las **raíces** de la aplicación. Todas las aplicaciones tienen un conjunto de **raíces**. Cada raíz hace referencia a un objeto del montón, o bien se establece en `null`. Las **raíces** de una aplicación incluyen campos estáticos, variables locales y parámetros de pila de un subproceso y registros de la CPU. El **GC** tiene acceso a la lista de **raíces** activas que **Just-In-Time (JIT)** y el runtime mantienen. Se examinan las **raíces** de la aplicación y, durante este proceso, crea un gráfico que contiene todos los objetos que no se pueden alcanzar. Durante el proceso de recolección, usa una función de copia de memoria para compactar los objetos **alcanzables** en la memoria y libera los bloques de espacios **inalcanzables**. 

Una vez que se ha compactado la memoria de los objetos alcanzables, el **GC** hace las correcciones de puntero necesarias para que las raíces de la aplicación señalen a los objetos en sus nuevas ubicaciones. También sitúa el puntero del montón administrado después del último objeto alcanzable. La memoria sólo se compacta si, durante una recolección, se detecta un número significativo de objetos inalcanzables. Si todos los objetos del montón administrado sobreviven a una recolección, no hay necesidad de comprimir la memoria.

Para mejorar el rendimiento, el tiempo de ejecución asigna memoria a los objetos grandes en un montón aparte. El recolector de elementos no utilizados libera la memoria para los objetos grandes automáticamente. Sin embargo, para no mover objetos grandes en la memoria, dicha memoria no se compacta.

## Generaciones y rendimiento
Para optimizar el rendimiento del recolector de elementos no utilizados, el montón administrado se divide en tres generaciones: **0, 1 y 2**.
- Es más rápido compactar la memoria de una parte del montón administrado que la de todo el montón.
- Los objetos más recientes tienen una duración más corta y los objetos antiguos tienen una duración más larga. 
- Los objetos más recientes suelen estar relacionados unos con otros y la aplicación tiene acceso a ellos más o menos al mismo tiempo.

El **GC** almacena los nuevos objetos en la generación 0. Los objetos que sobreviven a las recolecciones se mueven y se almacenan en las generaciones 1 y 2. Como es más rápido compactar una parte del montón administrado que todo el montón, este esquema permite que el recolector libere la memoria en una generación específica en lugar de para todo el montón.

El **GC** realiza la recolección cuando se llena la generación 0. Si una aplicación trata de crear un nuevo objeto cuando está llena, invoca un proceso de liberacion. Primero examina los objetos de la generación 0. Éste es un enfoque más eficaz, ya que los objetos nuevos suelen tener una duración más corta y se espera que la aplicación no utilice muchos de los objetos de la generación 0 cuando se realice una recolección. Además, una recolección de tan sólo la generación 0 a menudo recupera suficiente memoria para que la aplicación pueda continuar creando nuevos objetos.

# Codigo inseguro (unsafe)
La mayor parte del código de C# que se escribe es "código seguro comprobable". El código seguro comprobable significa que las herramientas de .NET pueden comprobar que el código es seguro. En general, el código seguro no accede directamente a la memoria mediante punteros. Tampoco asigna memoria sin procesar. En su lugar, crea objetos administrados.

El código no seguro tiene las propiedades siguientes:

- Los métodos, tipos y bloques de código se pueden definir como no seguros.
- En algunos casos, el código no seguro puede aumentar el rendimiento de la aplicación al eliminar las comprobaciones de límites de matriz.
- El código no seguro es necesario al llamar a funciones nativas que requieren punteros.
- El código no seguro presenta riesgos para la seguridad y la estabilidad.
- El código que contenga bloques no seguros deberá compilarse con la opción del compilador AllowUnsafeBlocks.

## Punteros
- `int* p`: p es un puntero a un entero.
- `int** p`: p es un puntero a un puntero a un entero.
- `int*[] p`: p es una matriz unidimensional de punteros a enteros.
- `char* p`: p es un puntero a un valor char.
- `void* p`: p es un puntero a un tipo desconocido.

```Csharp
unsafe
{
    int[] numeroParaFixed = new int[5] { 3000, 2000, 1, 2, 3 };
    // La instrucción fixed evita que el recolector de elementos no utilizados reubique una variable móvil.
    fixed (int* variable = &numeroParaFixed[0])
    {
        int* numero = variable;
        Console.WriteLine(*numero);

        *numero += 2;
        Console.WriteLine(*numero);

        *numero += 2;
        Console.WriteLine(*numero);

        *numero += 2;
        Console.WriteLine(*numero);
    }
}
```

En la tabla siguiente se muestran los operadores e instrucciones que pueden funcionar en punteros en un contexto no seguro:

| Operador/Instrucción | Usar |
| -------------------- | ---- |
| *  | Realiza el direccionamiento indirecto del puntero. |
| -> |	Obtiene acceso a un miembro de un struct a través de un puntero. |
| [] | Indiza un puntero. |
| &  | Obtiene la dirección de una variable. |
| ++ y -- |	Incrementa y disminuye los punteros. |
| + y - | Realiza aritmética con punteros. |
| ==, !=, <, >, <= y >= | Compara los punteros. |
| stackalloc | Asigna memoria en la pila. |
| Instrucción fixed | Fija provisionalmente una variable para que pueda encontrarse su dirección. |

Mas informacion sobre codigo no seguro: [enlace](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/unsafe-code)

# Stackalloc
La expresión stackalloc asigna un bloque de memoria en la pila(**stack**). 

Un bloque de memoria asignado en el stack creado durante la ejecución del método se descarta automáticamente cuando se devuelva dicho método. No puede liberar explícitamente memoria asignada con stackalloc. 

Un bloque de memoria asignada a la pila no está sujeto a la recolección de elementos no utilizados y no tiene que fijarse con una instrucción fixed.

Puede asignar el resultado de una expresión `stackalloc` a una variable de uno de los siguientes tipos
```Csharp
int length = 3;
Span<int> numbers = stackalloc int[length];
for (var i = 0; i < length; i++)
{
    numbers[i] = i;
}

// Con condicionales
int length = 1000;
Span<byte> buffer = length <= 1024 ? stackalloc byte[length] : new byte[length];
```

- Usando punteros.
```Csharp
unsafe
{
    int length = 3;
    int* numbers = stackalloc int[length];
    for (var i = 0; i < length; i++)
    {
        numbers[i] = i;
    }
}
```
> Nota:  
Como la cantidad de memoria disponible en la pila depende del entorno en el que se ejecuta el código, hay que ser conservador al definir el valor límite real.

> Nota:  
Tenemos que evitar `stackalloc` dentro de bucles. Asignamos el bloque de memoria fuera y lo usamos dentro del bucle.

El uso de `stackalloc` habilita automáticamente las características de detección de saturación del búfer en el CLR. Si esto sucede, se finaliza el proceso lo antes posible para minimizar el riesgo de que se ejecute código malintencionado.

# Memory & Span
`Span<T>` y `Memory<T>` son los búferes de datos estructurados que se pueden usar en las canalizaciones. Es decir, están diseñados para que parte de los datos, o todos, se puedan pasar, procesar y modificar de forma eficaz.

Puesto que los búferes se pueden pasar entre las API, y se puede acceder a los buffer desde varios subprocesos, es importante tener en cuenta la duración.
- **Propiedad**. El propietario de una instancia de búfer es responsable de la administración de la duración, por ejemplo, destruirlo cuando ya no se use. Todos los búferes tienen un único propietario.
- **Consumo**. El consumidor de una instancia de búfer puede usar la instancia leyendolo y, si se permite, escribiendo. Solo se puede tener un consumidor a la vez, a menos que se proporcione algún mecanismo de sincronización externo. El consumidor no tiene porque ser el propietario.
- **Concesión**. La concesión es el período durante el cual un componente concreto puede ser el consumidor del búfer.

## Instrucciones de uso - [Rules](https://docs.microsoft.com/es-es/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#usage-guidelines)
1. Para una API sincrónica, use `Span<T>` en lugar de `Memory<T>` como parámetro, si es posible.
1. `ReadOnlySpan<T>` o `ReadOnlyMemory<T>` si el búfer debe ser de solo lectura.
1. Si el método acepta `Memory<T>` y devuelve `void`, no debe usar la instancia de `Memory<T>` después de que se devuelva el método.
1. Si el método acepta `Memory<T>` y devuelve una clase Task, no debe usar la instancia de `Memory<T>` después de las transiciones de Task a un estado terminal.
1. Si el constructor acepta `Memory<T>` como un parámetro, se da por sentado que los métodos de instancia del objeto construido son los consumidores de la instancia de `Memory<T>`
1. Si tiene una propiedad con el tipo `Memory<T>` configurable (o un método de instancia equivalente) en su tipo, se da por sentado que los métodos de instancia de ese objeto son los consumidores de la instancia de `Memory<T>`.
1. Si tiene una referencia de `IMemoryOwner<T>`, en algún punto, debe eliminarla o transferir su propiedad (pero no ambas cosas).
1. Si tiene un parámetro `IMemoryOwner<T>` en la superficie de API, implica la aceptación de la propiedad de esa instancia.
1. Si está encapsulando un método p/invoke sincrónico, la API debe aceptar `Span<T>` como parámetro.
1.  Si está encapsulando un método p/invoke asincrónico, la API debe aceptar `Memory<T>` como parámetro.

## `Span<T>`
Es una `estructura por referencia` que se asigna en el **Stack**.
```Csharp
var arr = new byte[10];
Span<byte> bytes = arr; // Implicit cast from T[] to Span<T>
```
```Csharp
Span<byte> bytes = stackalloc byte[2]; // Using C# 7.2 stackalloc support for spans
bytes[0] = 42;
bytes[1] = 43;
Assert.Equal(42, bytes[0]);
Assert.Equal(43, bytes[1]);
bytes[2] = 44; // throws IndexOutOfRangeException
```


## `Memory<T>`
`Memory<T>` es una estructura, por tanto, se intentará ubicar en el **Stack** pero podra contener referencias a objetos y por tanto, ubicarse en el **Heap**.

Las instancias de `Span<T>` solo pueden residir en la Stack y no en el Heap. Esto significa que no puede tener campos de este tipo en clases, estructuras que no sean de tipo ref, variables locales en métodos asincronos o iteradores, etc.

Estas limitaciones no importan en algunas situaciones, por ejemplo, las funciones de procesamiento sincrono y asociadas a cálculo. Sin embargo, la funcionalidad asincrona es otra historia.

En los casos en los que `Span<T>` no sea posible, tenemos este tipo, `Memory<T>`

Podemos crear un tipo `Memory<T>` a partir de una matriz y segmentarlo como lo haría con un Span, pero es un tipo struct (no de tipo referencia) y puede residir en la pila. Cuando queramos realizar el procesamiento de forma sincrona, se puede obtener un tipo `Span<T>` a partir de este
```Csharp
static async Task<int> ChecksumReadAsync(Memory<byte> buffer, Stream stream)
{
    int bytesRead = await stream.ReadAsync(buffer);
    return Checksum(buffer.Span.Slice(0, bytesRead));
    // Or buffer.Slice(0, bytesRead).Span
}
static int Checksum(Span<byte> buffer) { ... }
```


# Estructuras
Una estructura se usa para almacenar datos por tipo de valor, eso quiere decir que la idea de la estructura es almacenar la instancia en el **stack** y no en el **heap** como las clases, por tanto la instanciacion del objeto se realiza de manera mas optima.

Generalmente las estructuras se utilizan para realizar optimizaciones en el codigo.

Cabe decir que no siempre se almacenan en el **stack**, por ejemplo, si usamos una estructura en un delegado o un campo de un objeto de tipo `class`.

```Csharp
public struct Coords
{
    public double X { get; }
    public double Y { get; }
    public override string ToString() => $"({X}, {Y})";
}
```

## Estructura readonly
Para poder declarar la estructura como inmutable se puede usar el modificador `readonly`. 
- Cualquier campo se tiene que declarar como `readonly`.
- Las propiedades deben de ser de solo lectura. Por tanto solo podran contener los descriptores de acceso `get` e `init`.

```Csharp
public readonly struct Coords
{
}
```

## Estructura ref
Las instancias de un tipo de estructura `ref` se asignan en el **stack** y no pueden ubicarse en el **Heap**. Para asegurarse de eso, el compilador limita el uso de este tipo a:

- No puede ser el tipo de elemento de una matriz.
- No puede ser un tipo declarado de un campo de una clase o una estructura que no sea `ref`.
- No puede implementar interfaces.
- No se puede aplicar una conversión boxing a `ValueType` ni `Object`.
- No puede ser un argumento de tipo.
- No se puede capturar mediante una expresión lambda o una función local.
- No se puede usar en un método `async`. Aunque se pueden usar en métodos sincronos, como los que devuelven `Task` o `Task<TResult>`.
- No se puede usar en iteradores.

```Csharp
public ref struct CustomRef
{
    public bool IsValid;
    public Span<int> Inputs;
    public Span<int> Outputs;
}
```
Para poder usarse con `readonly`
```Csharp
public readonly ref struct ConversionRequest
{
    public ConversionRequest(double rate, ReadOnlySpan<double> values)
    {
        Rate = rate;
        Values = values;
    }

    public double Rate { get; }
    public ReadOnlySpan<double> Values { get; }
}
```


# Liberacion de Memoria
La liberacion de memoria en .Net consiste en marcar ciertos objetos como "liberados", quiere decir, que son objetos que ya no se van a volver a usar y que quiere liberar el recurso que se esta usando o cerrar el proceso.

Para dicha liberacion se ha de implementar una interfaz, que se llama `IDisposable` y tambien se suele hacer uso de los llamado Destructores.

El método Dispose se implementa para liberar recursos de la clase donde se implementa, sobretodo se usa para gestión de código no administrado como usos como conexiones a BBDD, Streams, etc.

```Csharp
public void Dispose()
{
    this.Dispose(true);
    GC.SuppressFinalize(this);
}

protected virtual void Dispose(bool disposing)
{
    if (disposing)
    {
        // Liberamos los recursos
        // En un clase como stream por ejemplo, aqui se ejecutaria el metodo Close()
    }
}
```

En todas las clases que tengan implementada la interfaz `IDisposable` se puede usar la instruccion `using` para liberar los recursos automaticamente cuando se acaba la sentencia.

```Csharp
using (var objeto = File.Create(""))
{
    objeto.ToString();
}
```

Los finalizadores (también denominados destructores) se usan para realizar cualquier limpieza final necesaria cuando el recolector de basura va a liberar el objeto de memoria
- Los finalizadores no se pueden definir en struct. Solo se usan con clases.
- Una clase solo puede tener un finalizador.
- Los finalizadores no se pueden heredar ni sobrecargar.
- No se puede llamar a los finalizadores. Se invocan automáticamente.
- Un finalizador no permite modificadores ni tiene parámetros.

```Csharp
internal class Program
{
    ~Program()
    {
        // Instrucciones para la limpieza de recursos
    }
}
```

