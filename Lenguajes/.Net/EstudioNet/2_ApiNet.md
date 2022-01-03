# String
Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el 
texto se almacena como una colección secuencial de solo lectura de 
objetos Char.

## Métodos de string
1. `Replace`: Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
1. `Split`: Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
1. `IndexOf`: Devuelve el indice donde se encuentra el caracter indicado
1. `CompareTo`: Compara el string con otro objeto, como por ejemplo, otra cadena
1. `SubString`: Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial

```csharp
var cadena = "Hola, yo me llamo Ralph, que tal estamos?";

var cadenaReplace = cadena.Replace(',', '\n');

var cadenaSplit = cadena.Split('m');

var cadenaIndex = cadena.IndexOf('m');

var cadenaCompare = cadena.CompareTo("Hola, yo me llamo Ralph");

var cadenaSubString = cadena.Substring(3, 5);
```

## Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| \\' | Comilla simple | 0x0027
| \\" | Comilla doble  | 0x0022
| \\\\ | Barra diagonal inversa | 0x005C
| \\0 | Null | 0x0000
| \\a | Alerta | 0x0007
| \\b | Retroceso | 0x0008
| \\f | Avance de página | 0x000C
| \\n | Nueva línea | 0x000A
| \\r | Retorno de carro | 0x000D
| \\t | Tabulación horizontal | 0x0009
| \\U | Secuencia de escape Unicode para pares suplentes. | \\Unnnnnnnn
| \\u | Secuencia de escape Unicode | \\u0041 = "A"
| \\v | Tabulación vertical | 0x000B
| \\x | Secuencia de escape Unicode similar a "\u" | \x0041 o \x41 = "A"

## Interpolacion de Cadenas
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con el método `String.Format`, pero mejora la facilidad de uso y la claridad en línea.
```csharp
var saludo = "Hola";
Console.WriteLine($"{saludo} terricola");
```

## StringBuilder
StringBuilder es una clase de cadena mutable. Mutabilidad significa que una vez creada una instancia de la clase, se puede modificar anexando, quitando, reemplazando o insertando caracteres. 

StringBuilder mantiene un búfer para alojar las modificaciones en la cadena.

Los datos nuevos se anexan al búfer si hay espacio disponible; de lo contrario, se asigna un búfer nuevo y mayor, los datos del búfer original se copian en el nuevo búfer y, a continuación, los nuevos datos se anexan al nuevo búfer.

```Csharp
var stringBuilder = new StringBuilder();
stringBuilder.Append(true);
stringBuilder.Append("Terminado");
stringBuilder.Replace("Hola", "Adios");
var cadenaCompleta = stringBuilder.ToString();
```

## Expresiones Regulares
Las expresiones regulares proporcionan un método eficaz y flexible para procesar texto. La notación extensa de coincidencia de patrones de expresiones regulares permite analizar rápidamente grandes cantidades de texto para:

- Buscar patrones concretos de caracteres.
- Validar el texto para garantizar que coincide con un patrón predefinido (como una dirección de correo electrónico).
- Extraer, editar, reemplazar o eliminar subcadenas de texto.
- Agregar cadenas extraídas en una colección para generar un informe.

Para muchas aplicaciones que usan cadenas o analizan grandes bloques de texto, las expresiones regulares son una herramienta indispensable.

```Csharp
var correo = "correo@electronico.com";
var expresionRegularCorreo = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
var correoRegex = Regex.Match(correo, expresionRegularCorreo);
Console.WriteLine(correoRegex);

var telefono = "111222333";
var expresionRegularTelefono = "([0-9][ -]*){9}";
var telefonoRegex = Regex.Match(telefono, expresionRegularTelefono);
Console.WriteLine(telefonoRegex);
```

# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación


## Listas

Una lista es un tipo de colección ordenada(un array)

### Métodos de listas
1. `Add`: Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
1. `IndexOf`: Devuelve la posicion de la lista donde se ubica el objeto a buscar
1. `Insert`: Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
1. `Remove`: Eliminar de la lista el objeto indicado
1. `Reverse`: Ordenas la lista al contra

```Csharp
var lista = new List<string>() { "Hola" };

lista.Add("me llamo Ralph");

lista.IndexOf("Hola");

lista.Insert(1, "jajajajaja");

lista.Remove("me llamo Ralph");

lista.Reverse();
```


## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede 
tener como máximo un valor en el diccionario

### Métodos de diccionarios
1. `Keys`: Devuelve una lista con las claves del diccionario
1. `Values`: Devuelve una lista con los valores del diccionario
1. `ContainsKey`: Devuelve un bool indicando si la clave existe en el diccionario
1. `Remove`: Elimina la Key del diccionario y por tanto, los valores asociados a la misma
1. `TryGetValue`: Metodo para obtener el valor asociado a la clave indicada

```Csharp
var diccionario = new Dictionary<string, string>()
{
    { "Clave", "Valor" },
    {"Key", "Value" }
};

Dictionary<string, string>.KeyCollection claves = diccionario.Keys;

Dictionary<string, string>.ValueCollection valores = diccionario.Values;

diccionario.ContainsKey("Clave");

diccionario.Remove("Key");

diccionario.TryGetValue("Key", out string valor);

```


## Tuplas
Una tupla es una estructura de datos que contiene una secuencia de elementos de diferentes tipos, esta estructura es de solo lectura, por tanto se usa para almacenar objetos que no van a ser modificados después.

```Csharp
var tupla = new Tuple<string, bool, int, double>("cadena", false, 500, 578.98);

tupla.Item1;
tupla.Item2;
tupla.Item3;
tupla.Item4;
```


## Tablas Hash
Representa una colección de pares de clave y valor que se organizan por código hash de la clave

### Métodos de tablas hash
1. `Add`: Agrega un nuevo elemento con el par clave-valor
1. `Remove`: Elimina la Clave y el valor asociado a la misma
1. `ContainsKey`: Devuelve un bool para saber si contiene la clave
1. `Clear`: Limpia todos los elementos de la tabla
1. `["key"]`: Para acceder al valor asociado a la clave mediante el inidizador

```Csharp
var tablaHash = new Hashtable();

tablaHash.Add("Key", "Value");

tablaHash.Remove("Key");

tablaHash.ContainsKey("Key");

tablaHash.Clear();

tablaHash["Key"];
```


## Pilas
El Stack es una coleccion LIFO(Last in, First Out) sin tamaño fijo de los objetos indicados.

Al usar la forma de almacenamiento LIFO, en la coleccion se trabaja todo el rato sobre los primeros elementos, osea que cuando agregas un elemento nuevo por ejemplo, no se guardaria en el ultimo indice, sino que se almacenaria en el indice 0, al principio de la coleccion.

### Métodos de pilas
1. `Push`: Agrega un nuevo elemento en la parte superior de Stack<T>
1. `Pop`: Elimina un elemento de la parte superior
1. `Peek`: Devuelve un eleemnto de la parte superior
1. `Clear`: Limpia todos los elementos de la coleccion
1. `ToArray`: Convierte la pila en un array del tipo indicado
1. `Contains`: Comprueba si exite el item que le pasamos por parametro

```Csharp
var pila = new Stack<string>();

pila.Push("Elemento");

pila.Pop();

pila.Peek();

pila.Clear();

pila.ToArray();

pila.Contains("objeto");
```


## Colas
La Queue es una coleccion FIFO(First In, First Out).

Al usar la forma de almacenamiento FIFO, a la hora de agregar elementos se tendran que ir agregando al final de la coleccion y a la hora de trabajar con ellos, se iran extrayendo del mas antiguo al mas nuevo, por tanto, se accedera a los primeros.

### Métodos de colas
1. `Enqueue`: Agrega un nuevo elemento al final de la coleccion
1. `Dequeue`: Elimina el elemento mas antiguo, por tanto el primer elemento de la coleccion
1. `Peek`: Devuelve el elemento mas antiguo de la coleccion
1. `Clear`: Limpia todos los elementos de la coleccion
1. `ToArray`: Convierte la cola en un array del tipo indicado
1. `Contains`: Comprobamos si la coleccion contiene un objeto especifico

```Csharp
var cola = new Queue<string>();

cola.Enqueue("Elemento");

cola.Dequeue();

cola.Peek();

cola.Clear();

cola.ToArray();

cola.Contains("objeto");
```


## Implementar la Interfaz IEnumerable
`IEnumerable<T>` es la interfaz base para las colecciones, como listas, diccionarios, etc.  
Tiene un metodo que ha de ser implementado llamado `GetEnumerator` que devolvera un objeto de tipo `IEnumerator<T>`.  

Se puede usar la palabra clave `yield` para ir moviendonos al siguiente registro de la lista o implementando dicha interfaz en una clase para poder ir moviendonos a los siguientes elementos.

Para ver el ejemplo con `yield`, [pincha aqui ](#yield)

```Csharp
public class EnumerablePersonalizado<T> : IEnumerable<T>
{
    public T[] enumerable;

    public EnumerablePersonalizado(int maxIndex)
    {
        enumerable = new T[maxIndex];
    }

    public IEnumerator<T> GetEnumerator() => new EnumeradorEnumerablePersonalizado<T>(enumerable);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EnumeradorEnumerablePersonalizado<T> : IEnumerator<T>
{
    private T[] collection;
    private int indiceActual;
    private T objetoActual;
    private bool disposedValue = false;

    public EnumeradorEnumerablePersonalizado(T[] collection)
    {
        this.collection = collection;
        indiceActual = -1;
        objetoActual = default;
    }

    public T Current { get { return objetoActual; } }

    object IEnumerator.Current { get { return Current; } }

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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                collection = null;
                objetoActual = default;
            }
        }
        disposedValue = true;
    }
}
```


## Implementar IList
Si se quiere realizar un tipo de lista ordenada personalizado se debera de implementar la interfaz `IList<T>`.  
Las listas requieren que sean dinamicas, por tanto se implementara el metodo `Add()`, que se pueda acceder a ellas mediante un `index[]`, que se puedan limpiar, etc.

```Csharp
public class ListaPersonalizada<T> : IList<T>
{
    public T[] lista;

    public ListaPersonalizada()
    {
        lista = Array.Empty<T>();
    }

    public T this[int index] {
        get {
            return lista[index];
        }

        set {
            lista[index] = value;
        }
    }

    public int Count {
        get {
            return lista.Length;
        }
    }

    public bool IsReadOnly {
        get {
            throw new NotImplementedException();
        }
    }

    public void Add(T item)
    {
        var listaNueva = new T[lista.Length + 1];
        for (int i = 0; i < lista.Length; i++)
        {
            listaNueva[i] = lista[i];
        }
        listaNueva[lista.Length] = item;
        lista = listaNueva;
    }

    public void Clear() => throw new NotImplementedException();
    public bool Contains(T item) => throw new NotImplementedException();
    public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();
    public int IndexOf(T item) => throw new NotImplementedException();
    public void Insert(int index, T item) => throw new NotImplementedException();
    public bool Remove(T item) => throw new NotImplementedException();
    public void RemoveAt(int index) => throw new NotImplementedException();
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in lista)
        {
            yield return item;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```


## Implementar IDictionary
`IDictionary<TKey, TValue>` es una interfaz base que se utiliza para las colecciones con pares clave-valor.  
Las claves tienes que ser unicas y los valores pueden ser `null` o repetidos.

```Csharp
public class DiccionarioPersonalizado<TKey, TValue> : IDictionary<TKey, TValue>
{
    private DictionaryEntry[] dictionary;
    private int itemsInUse = 0;

    public DiccionarioPersonalizado()
    {
        dictionary = Array.Empty<DictionaryEntry>();
    }

    public TValue this[TKey key] {
        get {
            if (TryGetKeyIndex(key, out var index))
            {
                return (TValue)dictionary[index].Value;
            }
            return default;
        }

        set {
            if (TryGetKeyIndex(key, out var index))
            {
                dictionary[index].Value = value;
            }
            else
            {
                Add(key, value);
            }
        }
    }

    public ICollection<TKey> Keys {
        get {
            var keys = new TKey[itemsInUse];
            for (int i = 0; i < itemsInUse; i++)
                keys[i] = (TKey)dictionary[i].Key;
            return keys;
        }
    }

    public ICollection<TValue> Values {
        get {
            var values = new TValue[itemsInUse];
            for (int i = 0; i < itemsInUse; i++)
                values[i] = (TValue)dictionary[i].Key;
            return values;
        }
    }

    public int Count {
        get {
            throw new NotImplementedException();
        }
    }

    public bool IsReadOnly {
        get {
            throw new NotImplementedException();
        }
    }

    private bool TryGetKeyIndex(object key, out int index)
    {
        for (index = 0; index < itemsInUse; index++)
        {
            if (dictionary[index].Key.Equals(key))
                return true;
        }
        return false;
    }

    public void Add(TKey key, TValue value)
    {
        var diccionarioNuevo = new DictionaryEntry[itemsInUse + 1];
        for (int i = 0; i < itemsInUse; i++)
        {
            diccionarioNuevo[i].Key = dictionary[i].Key;
            diccionarioNuevo[i].Value = dictionary[i].Value;
        }
        diccionarioNuevo[itemsInUse].Key = key;
        diccionarioNuevo[itemsInUse].Value = value;
        dictionary = diccionarioNuevo;
        itemsInUse++;
    }

    public void Add(KeyValuePair<TKey, TValue> item) => throw new NotImplementedException();
    public void Clear() => throw new NotImplementedException();
    public bool Contains(KeyValuePair<TKey, TValue> item) => throw new NotImplementedException();
    public bool ContainsKey(TKey key) => throw new NotImplementedException();
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => throw new NotImplementedException();
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        foreach (var item in dictionary)
        {
            yield return new KeyValuePair<TKey, TValue>((TKey)item.Key, (TValue)item.Value);
        }
    }
    public bool Remove(TKey key) => throw new NotImplementedException();
    public bool Remove(KeyValuePair<TKey, TValue> item) => throw new NotImplementedException();
    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}
```


# Escritura Lectura
Conjunto de clases y formas de trabajar con metodos **Input/Output**.

## Stream
Stream es una clase abstracta para todos los flujos. Un flujo es una secuencia de bytes como, por ejemplo, un archivo, un dispositivo de entrada/salida o un socket TCP/IP. La clase `Stream` y sus derivadas proporcionan una vista genérica de estos diferentes tipos de entrada.

Las secuencias comprenden tres operaciones fundamentales:
- Puede leer desde secuencias. La lectura es la transferencia de datos desde una secuencia a una estructura de datos, como una matriz de bytes.
- Puede escribir en secuencias. La escritura es la transferencia de datos de una estructura de datos a una secuencia.
- Los flujos pueden admitir búsquedas. La búsqueda hace referencia a la consulta y modificación de la posición actual dentro de una secuencia. La funcionalidad de búsqueda depende del tipo de almacenamiento de respaldo que tenga una secuencia. Por ejemplo, las secuencias de red no tienen un concepto unificado de una posición actual y, por lo general, no admiten la búsqueda.

Algunas de las secuencias más utilizadas que heredan de Stream son `FileStream` , y `MemoryStream` .

Puede consultar una secuencia mediante las propiedades `CanRead`, `CanWrite` y `CanSeek` de la clase Stream.

Los metodos `Read` y `Write` leen y escriben datos en una variedad de formatos. En el caso de las secuencias que admiten la búsqueda, usamos los metodos `Seek` y `SetLength` y las propiedades `Position` y `Length` para consultar y modificar la posición y la longitud de la secuencia respectivamente.

Este tipo implementa la interfaz `IDisposable`. Cuando haya terminado de utilizar el tipo, debemos desecharlo directa o indirectamente.

Cuando desechamos un objeto Stream, se vacían los datos almacenados en búfer y se llama al metodo `Flush`. `Dispose` también libera los recursos del sistema operativo, como los identificadores de archivos, las conexiones de red o la memoria usada para cualquier almacenamiento en búfer interno.

## MemoryStream
Esta clase a menudo es usada para lidiar con bytes viniendo de otros lugares, por ejemplo un archivo o una ubicación de red, sin bloquear la fuente. Por ejemplo, puedes leer el contenido entero de un archivo en un `MemoryStream`, el cual bloquea y desbloquea el archivo inmediatamente y trabajamos con esta instancia directamente.

Gracias a que implementa la clase Stream, podemos cargar la `MemoryStream` y usar otras clases existentes como `StreamReader`, etc.
```Csharp
using var streamEscrito = new MemoryStream();

int buffer;
while ((buffer = streamEscrito.ReadByte()) >= 0)
{
    Console.Write(Convert.ToChar(buffer));
}
```

### Lectura
Podemos leer mediante los metodos de la propia clase `MemoryStream`
```Csharp
using var streamEscrito = new MemoryStream();

int buffer;
while ((buffer = streamEscrito.ReadByte()) >= 0)
{
    Console.Write(Convert.ToChar(buffer));
}
```

### Escritura
Podemos escribir mediante los metodos de la propia clase `MemoryStream`
```Csharp
byte[] firstString = new UnicodeEncoding().GetBytes("Texto a convertir en bytes");
byte[] secondString = new UnicodeEncoding().GetBytes("Texto a agregar");

var memoryStream = new MemoryStream();

memoryStream.Write(firstString, 0, firstString.Length);

foreach (var item in secondString)
{
    memoryStream.WriteByte(item);
}
```

### Copia
```Csharp
using var memoryStream = new MemoryStream();

await streamEscrito.CopyToAsync(memoryStream);
```

### Uso en otras clases derivadas
Podemos hacer uso de otras clases derivadas de `Stream` para tratar el objeto `MemoryStream`

```Csharp
using var memoryStream = new MemoryStream();
using var streamWriter = new StreamWriter(memoryStream);

await streamWriter.WriteLineAsync("Hola, me llamo Ralph");

memoryStream.Seek(0, SeekOrigin.Begin);
var reader = new StreamReader(memoryStream);
Console.WriteLine(await reader.ReadToEndAsync());

streamWriter.Flush();
```

## Archivos de texto
Clases que interactuan con archivos de texto fisicamente

### Binary
Clase que debe recibir un objeto `Stream` y se utiliza para la lectura y escritura de archivos tratando el contenido directamente como binario con tipos primitivos.

#### Lectura
```Csharp
// Apertura del archivo `ArchivoBinario.bin` en modo lectura:
// Muestra la información tal cual está escrita en el archivo binario:
using (var fs = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read))
{
    Console.Write(Environment.NewLine);
    // Lectura y conversión de los datos binarios en el tipo de 
    // correspondiente:

    // Posiciona el cursor desde se iniciara la lectura del 
    // archivo `ArchivoBinario`:
    fs.Position = 0;
    using (var br = new BinaryReader(fs))
    {
        Console.WriteLine(br.ReadDecimal());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadChar());
    }
}
```

#### Escritura
```Csharp
// Crea objeto `FileStream` para referenciar un archivo binario -ArchivoBinario.bin-:
// Escritura sobre el archivo binario `ArchivoBinario.bin` usando un 
// objeto de la clase `BinaryWriter`:
using (var fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write))
{
    using (var bw = new BinaryWriter(fs))
    {
        // Escritura de datos de naturaleza primitiva:
        bw.Write(1.0M);
        bw.Write("Este es el texto que se esta");
        bw.Write('\n');
        bw.Write("escribiendo con la Clase Binary de .NET");
    }
}
Console.WriteLine($"Los datos han sido escritos en el archivo `{nombreArchivo}`.");
```

#### Copia
```Csharp
using var readBinaryFile = new BinaryReader(File.OpenRead(nombreArchivoFuente));
using var writeBinaryFile = new BinaryWriter(File.OpenWrite(nombreArchivoDestino));
for (byte data; readBinaryFile.PeekChar() != -1;)
{
    data = readBinaryFile.ReadByte();
    writeBinaryFile.Write(data);
}
```

### File
La clase File se usa para operaciones típicas como copiar, mover, cambiar el nombre, crear, abrir, eliminar y anexar a un único archivo cada vez

#### Create
```Csharp
using var file = File.Create(archivo);
```

#### Delete
```Csharp
File.Delete(archivo);
```

#### Lectura
1. `ReadAllTextAsync`: Abre de forma asincrona un archivo de texto, lee todo el texto del archivo y, a continuación, cierra el archivo.
1. `ReadAllBytesAsync`: Abre de forma asincrona un archivo binario, lee su contenido, lo introduce en una matriz de bytes y, a continuación, cierra el archivo.
1. `ReadAllLinesAsync`: Abre de forma asincrona un archivo de texto, lee todas sus líneas y, a continuación, cierra el archivo.

```Csharp
await File.ReadAllTextAsync(nombreArchivoTextAsync);
await File.ReadAllBytesAsync(nombreArchivoBytes);
await File.ReadAllLinesAsync(nombreArchivoAllLines);
```

#### Escritura
1. `WriteAllTextAsync`: Crea de forma asincrona un archivo nuevo, escribe en él la cadena especificada y, a continuación, lo cierra. Si el archivo de destino ya existe, se sobrescribe.
1. `WriteAllBytesAsync`: Crea de forma asincrona un archivo nuevo, escribe en él la matriz de bytes especificada y, a continuación, lo cierra. Si el archivo de destino ya existe, se sobrescribe.
1. `WriteAllLinesAsync`: Crea de forma asincrona un archivo nuevo, escribe en él las líneas especificadas y, a continuación, lo cierra.

```Csharp
await File.WriteAllTextAsync(nombreArchivoTextAsync, textoEscribir);
await File.WriteAllBytesAsync(nombreArchivoBytes, Encoding.UTF8.GetBytes(textoEscribir));
await File.WriteAllLinesAsync(nombreArchivoAllLines, textoEscribir.Split('\n'));
```

#### Copia
```Csharp
File.Copy(nombreArchivoOrigen, nombreArchivoDestino);
```

### Stream en archivos
Para leer y escribir archivos `Stream` se suelen usar las clases `StreamReader` y `StreamWritter`

#### Lectura
1. `ReadToEndAsync`: Lee de forma asincrónica todos los caracteres desde la posición actual hasta el final de la secuencia y los devuelve como una cadena.
1. `ReadAsync`: Lee de forma asincrónica un número máximo de caracteres especificado en la secuencia actual y escribe los datos en un búfer, comenzando en el índice especificado.
1. `ReadBlockAsync`: Lee de forma asincrónica un número máximo de caracteres especificado en la secuencia actual y escribe los datos en un búfer, comenzando en el índice especificado.

```Csharp
using (var readFile = new StreamReader(nombreArchivo))
{
    await readFile.ReadToEndAsync();
}

using (var readFile = new StreamReader(nombreArchivo))
{
    while (readFile.Peek() >= 1)
    {
        await (char)readFile.ReadAsync()
    }
}

using (var readFile = new StreamReader(nombreArchivo))
{
    var buffer = new char[5];
    while (!readFile.EndOfStream)
    {
        var lenght = await readFile.ReadBlockAsync(buffer, 0, buffer.Length);
        Console.WriteLine(new string(buffer, 0, lenght));
    }
}
```

#### Escritura
```Csharp
using var writeFile = new StreamWriter(nombreArchivo);
await writeFile.WriteAsync(textoEscribir);
```


## Serializacion
La serialización es el proceso de convertir el estado de un objeto en un formato que se pueda almacenar o transportar. Este proceso permite almacenar y transferir datos.

- La serialización binaria preserva la fidelidad de tipo, lo que es útil para conservar el estado de un objeto entre distintas invocaciones de una aplicación. Por ejemplo, puede compartir un objeto entre distintas aplicaciones si lo serializa en el Portapapeles.

- La serialización XML solo serializa propiedades y campos públicos y no preserva la fidelidad de tipo. Esto es útil si se desea proporcionar o utilizar los datos sin restringir la aplicación que utiliza los datos. Dado que XML es un estándar abierto, es una opción atractiva para compartir los datos por el web.

- La serialización de JSON solo serializa propiedades públicas y no preserva la fidelidad de tipo.

### Serializacion JSON
Actualmente se ha convertido en un estándar ampliamente utilizado para el intercambio de información entre sistemas.

#### Json con Stream
1. Instanciamos el objeto que vamos a serializar
1. Usamos la clase `JsonSerializer` para guardar el contenido del objeto en un stream que debemos de enviar, por ejemplo podemos enviarle un `StreamFile`
1. Deserializamos leyendo el stream correspondiente y mapeando en contenido JSON en un objeto nuevo del tipo indicado.

```Csharp
var crearJSON = new ClaseParaJSON()
{
    Ruta = "archivo.txt"
};
await JsonSerializer.SerializeAsync(jsonStream, json);

var localizacion = await JsonSerializer.DeserializeAsync<ClaseParaJSON>(jsonStream);
```

#### Json con objetos
1. Creamos el objeto a mapear
1. Serializamos el objeto, lo que nos devolvera un `string` con el contenido del json
1. Suponiendo un JSON en memoria ya, con ese formato
1. Deserializamos el contenido json en un objeto del tipo que le pasamos.

```Csharp
var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
var serializado = JsonSerializer.Serialize(serializacion);


const string JSON = @"{""Nombre"":""Nombre"",""Apellidos"":""Apellido""}";
var deserializado = JsonSerializer.Deserialize<ClaseSerializacion>(JSON);
```

### Serializacion XML
Los archivos XML (Extensible Markup Language) son un meta lenguaje que sirve para almacenar datos y facilitar su transmisión entre diferentes tecnologías sin afectar su estructura original.

#### XML Document

##### Leer documentos XML
```Csharp
public ReadXmlFile(string nombreArchivo)
{
    var document = new XmlDocument();
    document.Load(nombreArchivo);

    foreach (XmlNode node in document.DocumentElement.ChildNodes)
    {
        var id = node.Attributes["id"].Value;
        Console.WriteLine($"Id: {id}");

        foreach (XmlNode elements in node.ChildNodes)
        {
            Console.WriteLine($"{elements.Name} : {elements.InnerText}");
        }
    }
}
```

##### Escribir documentos XML
```Csharp
public WriteXmlFile(string nombreArchivo)
{
    var document = new XmlDocument();

    var xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
    var elementRoot = document.DocumentElement;
    document.InsertBefore(xmlDeclaration, elementRoot);

    var empresa = document.CreateElement(string.Empty, "empresa", string.Empty);
    document.AppendChild(empresa);

    for (var x = 1; x < 4; x++)
    {
        var empleado = document.CreateElement(string.Empty, "empleado", string.Empty);
        empleado.SetAttribute("id", $"{x}");
        empresa.AppendChild(empleado);

        var nombre = document.CreateElement(string.Empty, "nombre", string.Empty);
        var textName = document.CreateTextNode($"Empleado {x}");
        nombre.AppendChild(textName);
        empleado.AppendChild(nombre);

        var status = document.CreateElement(string.Empty, "status", string.Empty);
        var textStatus = document.CreateTextNode("activo");
        status.AppendChild(textStatus);
        empleado.AppendChild(status);
    }

    document.Save(nombreArchivo);
}
```

#### XML con Linq
Gracias a la abstraccion de linq, podemos cargar y consultar archivos Linq.

##### Leer un archivo con Linq
```Csharp
var document = XElement.Load(nombreArchivo);

from item in document.Descendants("empleado")
where item.Attribute("id").Value == "1"
    && item.Element("nombre").Value == "Empleado 1"
select item;
```

##### Escribir un archivo mediante Linq
```Csharp
 var empresa = new XElement("empresa",
                new XElement("empleado",
                        new XAttribute("id", "1"),
                    new XElement("nombre", "empleado 1"),
                    new XElement("status", "activo")),

                new XElement("empleado",
                        new XAttribute("id", "2"),
                    new XElement("nombre", "empleado 2"),
                    new XElement("status", "activo")),

                new XElement("empleado",
                        new XAttribute("id", "3"),
                    new XElement("nombre", "empleado 3"),
                    new XElement("status", "activo")));

empresa.Save(nombreArchivo);
```

#### XML Serializando objetos con Streams
1. Creamos un objeto de la clase a serializar
1. Creamos una instancia de `XmlSerializer` al que le tenemos que pasar el tipo que se va a serializar
1. Invocamos el metodo `Serialize` enviandole un objeto `Stream`, por ejemplo, le podemos mandar un `File.Open()` y el objeto a serializar.

```Csharp
var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
var xmlSerializer = new XmlSerializer(typeof(ClaseSerializacion));
xmlSerializer.Serialize(streamObject, serializacion);
```

1. Creamos una instancia de `XmlSerializer` al que le tenemos que pasar el tipo que se va a serializar
1. Invocamos el metodo `Deserialize` enviandole un objeto `Stream`, por ejemplo, le podemos mandar un `File.Open()` y nos devolvera una instancia del tipo indicado anteriormente.
```Csharp
var xmlSerializer = new XmlSerializer(typeof(ClaseSerializacion));
var objetoDeserializado = xmlSerializer.Deserialize(streamObject);
```

# Uso de Internet
Conjunto de clases para establecer conexiones con internet con `.Net` como llamadas a API Rest, etc.

## HttpClient
`HttpClient` es una clase que proporciona .Net para hacer llamadas a traves del protocolo `http`.

Cuando realizamos un **Request** y recibimos una **Response**, este, nos indicará un `HttpStatusCode` el cual es muy util para saber si el resultado esta correctamente.

Para ver los codigos de estado, podemos acceder [aqui](https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP)

**Importante**  
Hacer uso de `HttpClient` dentro de un bloque `using` puede ocasionar problemas porque cuando se invoca el metodo `Dispose` no se cierra la conexion directamente, sino que el servidor suele dejarla como en *espera* durante un tiempo, por tanto, los sockets se pueden ir ocupando y llegar un punto en el cual no haya sockets disponibles en la aplicacion para funcionar. 

En el siguiente ejemplo hacemos un bucle de 10 conexiones con el using y ejecutamos un comando `netstat` en el servidor para comprobar las conexiones establecidas y si nos fijamos, las conexiones no se cierran.
```Csharp
for(int i = 0; i<10; i++)
{
    using var client = new HttpClient();
    var result = await client.GetAsync("url a consultar");
    Console.WriteLine(result.StatusCode);
}
```
![image](https://user-images.githubusercontent.com/28193994/147914625-ec00502a-a8ca-4216-88c0-e183e87fd3d5.png)

El protocolo TCP/IP funciona de la siguiente manera.

![image](https://user-images.githubusercontent.com/28193994/147914590-f0ea6873-5148-4f4e-8059-5e6104cd2e01.png)


La solución mas común es incluirlo como static y no hacer uso de dispose. De esta forma lo que estamos haciendo es compartir el mismo socket para todas las conexiones.

Una solucion, sobretodo para Dependency Injection, es usar la clase `HttpClientFactory` que hay nas abajo explicada,

### Configurar Headers


### Solicitud GET
Formas de consultar datos por **GET** a un API

Cabe destacar que las solicitudes `GET` se envian los datos de consulta a traves de `QueryString` y se puede configurar de la siguiente forma.

```Csharp
var url = new UriBuilder(urlBase);
var parametersQueryString = HttpUtility.ParseQueryString(url.Query);
parametersQueryString.Add(parametro.Key, parametro.Value?.ToString());

url.Query = parametersQueryString.ToString();
url.ToString();
```

#### GetStringAsync
```Csharp
await httpClient.GetStringAsync(urlFinal);
```

#### GetFromJsonAsync
```Csharp
await httpClient.GetFromJsonAsync<ClaseDeserializar>(urlFinal);
```

### Solicitud POST
Metodos para envio de datos por **POST** a un API.

#### PostAsync
1. `StringContent`: Creamos el contenido que vamos a hacer post.
    1. `content`: contenido a enviar en formato string.
    1. `encoding`: tipo de codificacion con la que esta escrita la peticion, por ejemplo, `UTF8Encoding.UTF8`
    1. `mediaType`: el tipo de datos que contiene la peticion, por ejemplo, `application/json`.

```Csharp
HttpClient httpClient = new HttpClient();
var content = new StringContent("string con el contenido", encoding, "tipo de envio");

await httpClient.PostAsync($"url", content);
```

#### PostAsJsonAsync
```Csharp
await Http.PostAsJsonAsync<TipoSerializar>("url", objetoToSerializar); 
```

### Solicitud PUT
Metodos de enviar datos para actualizar por **PUT** en un API

#### PutAsync
1. `StringContent`: Creamos el contenido que vamos a hacer post.
    1. `content`: contenido a enviar en formato string.
    1. `encoding`: tipo de codificacion con la que esta escrita la peticion, por ejemplo, `UTF8Encoding.UTF8`
    1. `mediaType`: el tipo de datos que contiene la peticion, por ejemplo, `application/json`.

```Csharp
HttpClient httpClient = new HttpClient();
var content = new StringContent("string con el contenido", encoding, "tipo de envio");

await httpClient.PutAsync($"url", content);
```

#### PustAsJsonAsync
```Csharp
await Http.PutAsJsonAsync<TipoSerializar>("url", objetoToSerializar); 
```

### Solicitud DELETE
Metodos solicitar el borrado de algun dato por **DELETE** a un API

#### DeleteAsync
```Csharp
await httpClient.DeleteAsync($"url");
```

### HttpClient con Dependency Injection
Podemos configurar parametros en el objeto HttpClient para inyectarlo como dependencia y centrarnos solamente en realizar la peticion que necesitamos.

**Importante**  
Este metodo no es recomendable usarlo por el problema de los sockets comentado anteriormente.

```Csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44326/api/") });
```

### HttpClientFactory
La implementación actual de `IHttpClientFactory` implementa `IHttpMessageHandlerFactory` y proporciona las siguientes ventajas.

- Proporciona una ubicación central para denominar y configurar instancias de HttpClient.
- HttpClient ya posee el concepto de controladores de delegación, que se pueden vincular entre sí para las solicitudes HTTP salientes.
- Administrar la duración de `HttpMessageHandler` para evitar los problemas mencionados y los que se pueden producir al administrar las duraciones de HttpClient.

> Las instancias de HttpClient insertadas mediante DI se pueden eliminar de forma segura, porque el elemento `HttpMessageHandler` asociado lo administra la factory.

![image](https://user-images.githubusercontent.com/28193994/147922775-8ca43a43-bdab-409c-914f-a435bb7ae356.png)

1. Registramos la dependencia con un identificador, que usaremos para reultilizar las instancias
1. Importamos la dependencia y creamos el cliente en base al identificador.
```Csharp
services.AddHttpClient("Nombre identificador", httpClient =>
{
    httpClient.BaseAddress = new Uri("url");
});

private readonly HttpClient _httpClient;
public DispensacionConsultaNegocio(IHttpClientFactory httpClientFactory)
{
    _httpClient = httpClientFactory.CreateClient("Nombre identificador");
}
```

1. En vez de registrar el serivicio de la forma convencional, podemos registrarlo con `AddHttpClient<>`.
1. Inyectamos la dependencia directamente importante la clase `HttpClient`
```Csharp
services.AddHttpClient<IServicio, Servicio>(httpClient =>
{
    httpClient.BaseAddress = new Uri("url");
});

private readonly HttpClient _httpClient;

public DispensacionConsultaNegocio(HttpClient httpClient)
{
    _httpClient = httpClient;
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


## ThreadPool
La clase ThreadPool se utiliza para poder reutilizar los hilos y optimizar su uso.  
Con la clase Thread, cada vez que ejecutamos un metodo `start()` se crea un nuevo hilo para ejecutar la accion correspondiente. Con esta clase lo que se consigue es que si ya existe un hilo creado y este ha terminado su ejecucion, poder reutilizarlo para la ejecucion de otra instruccion, con esto evitamos un consumo extra de registros.

```Csharp
ThreadPool.QueueUserWorkItem(x =>
{
    Console.WriteLine($"Id Thread: {Thread.CurrentThread.ManagedThreadId}");
});
```


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


### Async & Await
El núcleo de la programación asincrona son los objetos `Task` y `Task<T>`, que modelan las operaciones asincronas. Son compatibles con las palabras clave `async` y `await`. El modelo es bastante sencillo en la mayoría de los casos:

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
