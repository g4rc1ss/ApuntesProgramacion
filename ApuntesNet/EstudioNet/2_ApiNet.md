# Escritura & Lectura
## Serializacion
La serialización es el proceso de convertir un objeto en una secuencia de bytes para almacenarlo o transmitirlo a la memoria, a una base de datos o a un archivo. Su propósito principal es guardar el estado de un objeto para poder volver a crearlo cuando sea necesario. El proceso inverso se denomina deserialización.

```Csharp
public class ClaseSerializacion
{
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    private string CuentaBancaria { get; set; }

    public ClaseSerializacion()
    {
    }

    public ClaseSerializacion(string nombre, string apellidos, string cuentaBancaria)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
        CuentaBancaria = cuentaBancaria ?? throw new ArgumentNullException(nameof(cuentaBancaria));
    }
}
```

### Archivo JSON
La serialización de JSON serializa las propiedades públicas de un objeto en una cadena, una matriz de bytes, etc.

#### Serializar JSON
```Csharp
static void Main(string[] args)
{
    var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
    var serializado = System.Text.Json.JsonSerializer.Serialize(serializacion);
}
```

#### Deserializar JSON
```Csharp
static void Main(string[] args)
{
    const string JSON = @"{""Nombre"":""Nombre"",""Apellidos"":""Apellido""}";
    var deserializado = System.Text.Json.JsonSerializer.Deserialize<ClaseSerializacion>(JSON);
}
```

### Archivo XML
La serialización XML serializa las propiedades y los campos públicos de un objeto o los parámetros y valores devueltos de los métodos en una secuencia XML que se ajusta a un documento específico del lenguaje de definición de esquema XML (XSD). La serialización XML produce clases fuertemente tipadas cuyas propiedades y campos públicos se convierten a XML.

#### Serializar XML
```Csharp
static void Main(string[] args)
{
    var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ClaseSerializacion));
    using var file = System.IO.File.Create("Archivo.xml");
    xmlSerializer.Serialize(file, serializacion);
}
```

#### Deserializar XML
```Csharp
static void Main(string[] args)
{
    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ClaseSerializacion));
    using var file = System.IO.File.OpenRead("Archivo.xml");
    var objetoDeserializado = xmlSerializer.Deserialize(file);
}
```

# Reflexion
`Reflection` proporciona objetos (de tipo `Type`) que describen los ensamblados, módulos y tipos. Puedes usar reflexión para crear dinámicamente una instancia de un tipo, enlazar el tipo a un objeto existente u obtener el tipo desde un objeto existente e invocar sus métodos, o acceder a sus campos y propiedades. Si usas atributos en el código, la reflexión le permite acceder a ellos.

```Csharp
interface IClaseReflexion
{
    string Nombre { get; set; }
}

interface IClaseReflexionDos : IClaseReflexion
{
    string Apellidos { get; set; }
}

public class ClaseReflexion : IClaseReflexionDos
{
    [Prueba("Hola", NamedInt = 5000)]
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    private string CuentaBancaria { get; set; }


    public ClaseReflexion()
    {
    }

    public ClaseReflexion(string nombre, string apellidos, string cuentaBancaria)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
        CuentaBancaria = cuentaBancaria ?? throw new ArgumentNullException(nameof(cuentaBancaria));
    }
}

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class PruebaAttribute : Attribute
{
    // See the attribute guidelines at 
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    private readonly string positionalString;

    // This is a positional argument
    public PruebaAttribute(string positionalString)
    {
        this.positionalString = positionalString;
    }

    public string PositionalString {
        get { return positionalString; }
    }

    // This is a named argument
    public int NamedInt { get; set; }
}


var obtenerTodasInterfaces = from interfaz in Assembly.GetExecutingAssembly().GetTypes()
                             where interfaz.IsInterface
                             select interfaz;
var obtenerClaseImplementaInterface = from clase in Assembly.GetExecutingAssembly().GetTypes()
                                      where clase.IsClass && clase.GetInterface(nameof(IClaseReflexion)) != null
                                      select clase;
var leerAtributosDePropiedades = from propiedad in typeof(ClaseReflexion).GetProperties()
                                 let atributo = propiedad.GetCustomAttribute<PruebaAttribute>()
                                 where atributo != null
                                 select atributo;
```


# MultiThreading
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer uso de la clase Parallel para realizar esas consultas de forma paralelizada y reducir los tiempos.

---
## Thread
Con la clase Thread se pueden crear multiples hilos para poder ejecutar tareas a traves de subprocesos. Esta clase permite obtener el paralelismo de los datos.

```Csharp
var hilo = new Thread(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Hilo {i}");
    }
});
hilo.Start();
```

---
## ThreadPool
La clase ThreadPool se utiliza para poder reutilizar los hilos y optimizar su uso.  
Con la clase Thread, cada vez que ejecutamos un metodo `start()` se crea un nuevo hilo para ejecutar la accion correspondiente. Con esta clase lo que se consigue es que si ya existe un hilo creado y este ha terminado su ejecucion, poder reutilizarlo para la ejecucion de otra instruccion, con esto evitamos un consumo extra de registros.

```Csharp
ThreadPool.QueueUserWorkItem(x =>
{
    Console.WriteLine($"Id Thread: {Thread.CurrentThread.ManagedThreadId}");
});
```

---
## Sincronizacion de hilos
Con el uso de la sincronizacion podremos establecer el orden de ejecucion de los hilos en el procesador para poder tener una mejor gestion sobre estos

### Join
El metodo Join correspondiente a una clase `Thread` hace que se espere a que termine la ejecucion del hilo antes de seguir con el codigo siguiente.

```Csharp
var hilo1 = new Thread(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Hilo 1 {i}");
    }
});
hilo1.Start();
hilo1.Join();

var hilo2 = new Thread(() => {
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Hilo 2 {i}");
    }
});
hilo2.Start();
hilo2.Join();

Thread.Sleep(1000);
```

---
## Bloqueos de hilos
Consiste en bloquear un hilo para que, cuando un hilo esta ejecutando la tarea correspondiente no se pueda manipular dicha ejecucion a traves de otros hilos que estan en ejecucion.

### lock()
El uso del metodo `lock` se usa para indicar a los subprocesos que han de esperar a que acabe el hilo que esta en ejecucion dentro del bloque de instruccion.  
Para poder hacer uso de `lock`, se tiene que crear un objeto instaciado de la clase `object` y agregarlo como parametro.

En el siguiente codigo, si lo probamos se podra apreciar que siempre se obtiene el mismo resultado, puesto que cada vez que se hace la operacion de suma o resta se realiza el bloqueo, si probamos a quitar la instruccion `lock` Y lo ejecutamos, cada vez se mostrará un resultado diferente, a eso se le denomina `condicion de carrera`
```Csharp
class CuentaBancaria
{
    private object bloqueoAgregarCantidad = new object();
    private object bloqueoQuitarCantidad = new object();
    private int cantidad;

    public int Cantidad {
        get {
            return cantidad;
        }
        set {
            cantidad = value;
        }
    }

    public CuentaBancaria(int cantidad)
    {
        Cantidad = cantidad;
    }
    public void QuitarCantidad(int dinero)
    {
        lock (bloqueoQuitarCantidad)
        {
            Cantidad -= dinero;
        }
    }
    public void AgregarCantidad(int dinero)
    {
        lock (bloqueoAgregarCantidad)
        {
            Cantidad += dinero;
        }
    }
}

// Codigo que ejecuta
var cuentaBancaria = new CuentaBancaria(10000);
new Thread(() => cuentaBancaria.AgregarCantidad(500)).Start();
new Thread(() => cuentaBancaria.QuitarCantidad(400)).Start();
new Thread(() => cuentaBancaria.AgregarCantidad(300)).Start();
new Thread(() => cuentaBancaria.QuitarCantidad(200)).Start();

Console.WriteLine(cuentaBancaria.Cantidad);
```

# Task Parallel Library
La biblioteca TPL (Task Parallel Library, biblioteca de procesamiento paralelo basado en tareas) es un conjunto de API y tipos públicos de los espacios de nombres System.Threading y System.Threading.Tasks. El propósito de la TPL es aumentar la productividad de los desarrolladores simplificando el proceso de agregar paralelismo y simultaneidad a las aplicaciones. La TPL escala el grado de simultaneidad de manera dinámica para usar con mayor eficacia todos los procesadores disponibles. Además, la TPL se encarga de la división del trabajo, la programación de los subprocesos en ThreadPool, la compatibilidad con la cancelación, la administración de los estados y otros detalles de bajo nivel. Al utilizar la TPL, el usuario puede optimizar el rendimiento del código mientras se centra en el trabajo para el que el programa está diseñado.

## Programación Asincrona
La programacion asincrona se realiza cuando se quieren evitar bloqueos en el hilo principal de la aplicación, cuando se realiza una operacion que requiere tiempo de procesamiento, el hilo sobre el que se esta ejecutando se bloquea hasta que termine, eso causa que la aplicacion no responda a mas operaciones.

Por ejemplo, en una interfaz Desktop, si se usa el patron en las operaciones costosas, la interfaz no se bloqueará mientras se ejecutan las instrucciones.  
En una aplicacion web como `ASP.NET` usar el patron hara que se puedan recibir mas peticiones mientras las peticiones anteriores estan en espera de que termine el proceso que ocupa tiempo, como por ejemplo, una consulta a BBDD.

---
### Async & Await
El núcleo de la programación asincrónica son los objetos `Task` y `Task<T>`, que modelan las operaciones asincrónicas. Son compatibles con las palabras clave `async` y `await`. El modelo es bastante sencillo en la mayoría de los casos:

- Para el código enlazado a E/S, espera una operación que devuelva `Task` o `Task<T>` dentro de un método async.
- Para el código enlazado a la CPU, espera una operación que se inicia en un subproceso en segundo plano con el método `Task.Run`.

La palabra clave `await` es donde ocurre la magia. Genera control para el autor de la llamada del método que ha realizado `await`, y permite una interfaz de usuario con capacidad de respuesta o un servicio flexible.

```Csharp
public async Task MetodoAsync()
{
    // Para operaciones E/S
    var stringData = await _httpClient.GetStringAsync(URL);

    // Para operaciones enlazadas a la CPU
    await Task.Run(() => 
    {
        // Ejecucion de codigo costoso en tiempo
        Thread.Sleep(10000)
    });
}
```


## Parallel
La clase estatica `Parallel` contiene los metodos `For`, `ForEach` e `Invoke` y se utiliza para hacer procesamiento multihilo de manera automatizada, su uso principal consta en el tratamiento de objetos como `Listas` o `Arrays` y la ejecucion de metodos en paralelo.

### Parallel Invoke
Permite la ejecucion paralelizada de un array de delegados

Cuando se ejecuta la instruccion, el metodo Invoke recibe un array de delegados que ejecutaran en un hilo nuevo y esperara a que estos terminen
```Csharp
Parallel.Invoke(
    () => objeto.Metodo1(),
    () =>
    {
        objeto = new Program();
    }
);
```

### Parallel For
Permite la ejecucion paralelizada de la lectura de una coleccion que implemente `IEnumerable`

```Csharp
Parallel.For(0, collection.Count, (x, state) =>
{
    Console.WriteLine($"Valor de la coleccion - {collection[x]} \n" +
        $"Estado del hilo {state.IsStopped}");
});
```
- El primer parámetro del método se envía el numero por el que se empieza
- El segundo parámetro se envía el numero final de la iteración
- En el tercer parámetro se envían 1 o 2 parámetros
    - `int`: que contendrá el número por el que va la iteración
    - `ParallelLoopState`: un objeto que se encargara de gestionar los      estados de los hilos, pudiendo parar la ejecución, etc.

### Parallel ForEach
El bucle paralelizado ForEach, permite leer una coleccion que implementa `IEnumerable` al igual que el bucle paralelizado For, la diferencia reside en que en ForEach obtienes ya el objeto del indice.

```Csharp
Parallel.ForEach(collection, (item, state, index) =>
{
    Console.WriteLine($"Valor de la coleccion - {item} \n" +
        $"Manipulacion de estado de los hilos {state.LowestBreakIteration} \n" +
        $"Indice en el que estamos posicionados actualmente - {index}");
});
```
- El primer parámetro se envía el objeto que queremos leer, un List<string> por ejemplo
- El segundo parámetro va la lambda que puede recibir dos parámetros
    - `obj` Contendrá un objeto del tipo de la lista y solo 1 elemento de dicha lista, es lo mismo que si a un array le hacemos un objetoArray[x] con un for normal.
    - `ParallelLoopState` Un objeto que se encargara de gestionar los estados de los hilos, pudiendo parar la ejecución, etc.
    - `index` Una propiedad que devuelve en que indice de la coleccion estamos.


# LINQ
Linq es una API orientada al uso de consultas a diferentes tipos de contenido, como objetos, entidades, XML, etc. De esta manera se resume en una sintaxis sencilla y fácil de leer, tratar y mantener el tratamiento de diferentes tipos de datos.

---
## Sintaxis de consulta
### From
```Csharp
var cust = new List<Customer>();
//queryAllCustomers is an IEnumerable<Customer>
from cust in customers
select cust;
```

### Join
```Csharp
from category in categories
join prod in products on category.ID equals prod.CategoryID
select new
{
    ProductName = prod.Name,
    Category = category.Name
};

products.Join(categories,
product => product.CategoryID,
category => category.ID,
(product, category) => new
{
    ProductName = product.Name,
    Category = category.Name
});
```

### Let
```Csharp

from sentence in strings
let words = sentence.Split(' ')
from word in words
let w = word.ToLower()
where w[0] == 'a' || w[0] == 'e'
    || w[0] == 'i' || w[0] == 'o'
    || w[0] == 'u'
select word;
```

### Where
```Csharp
from prod in products
where prod.Name == "Producto 2"
select prod;

products.Where(prod => prod.Name == "Producto 2");
```                                                                                                                                                       
### Group by
```Csharp
from product in products
group product by new
{
    product.CategoryID,
    product.Name
} into prod
select new
{
    idCategoria = prod.Key.CategoryID,
    nombre = prod.Key.Name
};

products.GroupBy(product => new
{
    product.CategoryID,
    product.Name
}).Select(prod => new
{
    idCategoria = prod.Key.CategoryID,
    nombre= prod.Key.Name
});
```

### Order by
```Csharp
from product in products
orderby product.CategoryID ascending
select product;
products.OrderBy(product => product.CategoryID);

from product in products
orderby product.CategoryID descending
select product;
products.OrderByDescending(product => product.CategoryID);
```

---
## Evaluacion/Ejecucion de Consulta
Para poder tratar las consultas, la api de LINQ devuelve objetos del tipo `IEnumerable<>` o `IQueryable<>`.  
Hay diferentes formas de leer los datos, por un lado mediante un `foreach` se pueden iterar un `IEnumerable` y por otro lado, hay metodos que convierten los datos a una coleccion directamente.

### ToList
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToList();
```

### ToArray
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToArray();
```

### ToDictionary
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToDictionary(key => key.CategoryID, value => value.Name);
```

### ToLookup
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToLookup(key => key.CategoryID, value => value.Name);
```

### Count
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).Count()
 ```

### FirstOrDefault
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).FirstOrDefault()
 ```

---
## Extension de Linq
En `Linq` mediante el uso de la interfaz `IEnumerable<T>` se pueden realizar metodos de extension para ampliar y personalizar la libreria linq para realizar filtros o guardar el objeto en una lista personalizada

### Tratamiento de Consultas personalizadas
```Csharp
public static class ExtensionLinq
{
    public static IEnumerable<Coche> FiltrarPorAudi(this IEnumerable<Coche> coches)
    {
        foreach (Coche coche in coches)
        {
            if (coche?.Marca == MarcaCoche.Audi)
            {
                yield return coche;
            }
        }
    }
}
```

### Ejecucion de Consultas Personalizadas
```Csharp
public static class ExtensionLinq
{
    public static ListaPersonalizada<T> ToListaPersonalizada<T>(this IEnumerable<T> coches)
    {
        var listaNueva = new ListaPersonalizada<T>();
        foreach (var coche in coches)
        {
            listaNueva.Add(coche);
        }
        return listaNueva;
    }
}
```

---
## Arboles de Expresion
Los árboles de expresiones son estructuras de datos que definen código. Se basan en las mismas estructuras que usa un compilador para analizar el código y generar el resultado compilado. Hay cierta similitud entre los árboles de expresiones y los tipos usados en las API de Roslyn para compilar analizadores y correcciones de código. (Los analizadores y las correcciones de código son paquetes de NuGet que realizan un análisis estático en código y pueden sugerir posibles correcciones). Los conceptos son similares y el resultado final es una estructura de datos que permite examinar el código fuente de forma significativa. En cambio, los árboles de expresiones se basan en un conjunto de clases y API totalmente diferentes a las de Roslyn.

Para la creacion y asignacion de una variable que sume 2 numeros, se crearia el siguiente arbol de expresion:

- Instrucción de declaración de variable con asignación (var sum = 1 + 2;)
    - Declaración de tipo de variable implícita (var sum)
        - Palabra clave var implícita (var)
        - Declaración de nombre de variable (sum)
    - Operador de asignación (=)
    - Expresión binaria de suma (1 + 2)
        - Operando izquierdo (1)
        - Operador de suma (+)
        - Operando derecho (2)

Podemos devolver el cuerpo de la funcion pasada como un string.  
Por ejemplo, un uso muy elevado que se le da a los arboles de expresion es con `EntityFramework` para la conversion de objetos `IQueryable<>` a una consulta `SQL`
```Csharp
public static class ClaseExpression
{
    public static string WhereToString<T>(T argumento, Expression<Func<T, bool>> expression)
    {
        return $"WHERE {expression.Body.ToString().Replace("==", "=")}";
    }
}

var persona = new Persona
{
    Nombre = "Hola",
    Apellido = "Adios"
};
var expresion = ClaseExpression.WhereToString(persona, x => x.Nombre == x.Apellido);
```
