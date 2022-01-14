# String
Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el 
texto se almacena como una colección secuencial de solo lectura de 
objetos Char.

1. `Replace`: Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
1. `Split`: Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
1. `IndexOf`: Devuelve el indice donde se encuentra el caracter indicado
1. `CompareTo`: Compara el string con otro objeto, como por ejemplo, otra cadena
1. `SubString`: Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial

## Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| `\'` | Comilla simple | 0x0027
| `\"` | Comilla doble  | 0x0022
| `\\` | Barra diagonal inversa | 0x005C
| `\0` | Null | 0x0000
| `\a` | Alerta | 0x0007
| `\b` | Retroceso | 0x0008
| `\f` | Avance de página | 0x000C
| `\n` | Nueva línea | 0x000A
| `\r` | Retorno de carro | 0x000D
| `\t` | Tabulación horizontal | 0x0009
| `\U` | Secuencia de escape Unicode para pares suplentes. | `\Unnnnnnnn`
| `\u` | Secuencia de escape Unicode | `\u0041` = "A"
| `\v` | Tabulación vertical | 0x000B
| `\x` | Secuencia de escape Unicode similar a "\u" | \x0041 o \x41 = "A"

## Interpolacion de Cadenas
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con el método `String.Format`, pero mejora la facilidad de uso y la claridad en línea.
```csharp
var saludo = "Hola";
Console.WriteLine($"{saludo} terricola");
```

## StringBuilder
**string** es una clase inmutable, eso quiere decir que su valor no puede ser modificado y por tanto, cuando realizamos labores como concatenar, lo que en realidad se hace es crear una cadena nueva con esas dos cadenas juntas.

**StringBuidler** en cambio permite la mutabilidad de la cadena, por tanto, es posible hacer modificaciones a esta sin ncesidad de crearla de nuevo, dando lugar a mas performance en dependiendo que situaciones.

```Csharp
var stringBuilder = new StringBuilder();
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
Todas las colecciones ofrecen métodos para agregar, quitar o buscar elementos.

## Listas (`List<T>`)
Una lista es un tipo de colección ordenada.
> Estos objetos no son seguros para subprocesos, para ello es mejor usar `ConcurrentBag<T>`

1. `Add`: Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
1. `IndexOf`: Devuelve la posicion de la lista donde se ubica el objeto a buscar
1. `Insert`: Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
1. `Remove`: Eliminar de la lista el objeto indicado
1. `Reverse`: Ordenas la lista al contra

## Diccionario (`Dictionary<TKey, TValue>`)
Es una estructura de datos que representa una colección de pares clave-valor

> - La clave tiene que ser única.  
> - No se soporta la concurrencia o multihilo. Para ello se debe de usar `ConcurrentDictionary<TKey, TValue>`

1. `Keys`: Devuelve una lista con las claves del diccionario
1. `Values`: Devuelve una lista con los valores del diccionario
1. `ContainsKey`: Devuelve un bool indicando si la clave existe en el diccionario
1. `Remove`: Elimina la Key del diccionario y por tanto, los valores asociados a la misma
1. `TryGetValue`: Metodo para obtener el valor asociado a la clave indicada

## Pilas  (`Stack<T>`)
Coleccion de tipo **LIFO**(Last in, First Out), los elementos mas recientes son los que iremos obteniendo en iteracion.
> Para crear un Stack seguro para subprocesos, usaremos `ConcurrentStack<T>`

1. `Push`: Inserta un elemento al principio de `Stack<T>`
1. `Pop`: Quita y devuelve el objeto situado al principio
1. `Peek`: Devuelve el objeto situado al principio de `Stack<T>` sin eliminarlo.
1. `Clear`: Quita todos los objetos de la coleccion
1. `Contains`: Comprueba si exite el item que le pasamos por parametro

## Colas  (`Queue<T>`)
Coleccion de tipo **FIFO**(First in, First out), el primer elemento que insertamos, sera el primero que recogemos al recorrer la coleccion
> Para crear una Queue segura para subprocesos, usaremos `ConcurrentQueue<T>`

1. `Enqueue`: Agrega un nuevo elemento al final de la coleccion
1. `Dequeue`: Elimina el elemento mas antiguo, por tanto el primer elemento de la coleccion
1. `Peek`: Devuelve el elemento mas antiguo de la coleccion
1. `Clear`: Limpia todos los elementos de la coleccion
1. `Contains`: Comprobamos si la coleccion contiene un objeto especifico

## IEnumerable
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

## IEnumerator
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


# Delegados
Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

```Csharp
delegate void DelegadoNormal(string texto);
delegate void DelegadoGeneric<in T>(T objeto);
delegate string DelegadoRetorna(string textp);
delegate TResult DelegadoGenericCompleto<in TSource, out TResult>(TSource objeto);

var ejemplo = new DelegadoNormal(Console.WriteLine);
ejemplo("Hola, soy el delegado normal");
```

## Delegados como Parametros
El uso de delegados como parametros permite agregar flexibilidad a la hora de desarrollar, por ejemplo, una clase que realiza una consulta a base de datos y queremos mapear el resultado. Nosotros realizamos la consulta y el mapeo nos lo puede pasar el usuario, puesto que no tenemos por que saber el nombre de los campos que nos devolverá

### Action
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

### Func
Permite devolver un resultado en la ejecucion del delegado.
```Csharp
public static TResult Run<TResult>(Func<TResult> func) => func();
public static TResult Run<T1, TResult>(this T1 x, Func<T1, string, TResult> func) => func(x, "");

ClaseFunc.Run(() => string.Empty);
```


# Escritura Lectura
Conjunto de clases y formas de trabajar con metodos **Input/Output**.

## Stream
Stream es una clase abstracta para todos los flujos. Un flujo es una secuencia de bytes como, por ejemplo, un archivo, un dispositivo de entrada/salida o un socket TCP/IP. La clase `Stream` y sus derivadas proporcionan una vista genérica de estos diferentes tipos de entrada.

Las secuencias comprenden tres operaciones fundamentales:
- Puede leer desde secuencias. La lectura es la transferencia de datos desde una secuencia a una estructura de datos, como una matriz de bytes.
- Puede escribir en secuencias. La escritura es la transferencia de datos de una estructura de datos a una secuencia.
- Los flujos pueden admitir búsquedas. La búsqueda hace referencia a la consulta y modificación de la posición actual dentro de una secuencia.

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
using (var fs = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read))
{
    Console.Write(Environment.NewLine);
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
using var fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
using var bw = new BinaryWriter(fs);
bw.Write(1.0M);
bw.Write("Este es el texto que se esta escribiendo");
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

#### Escritura
1. `WriteAllTextAsync`: Crea de forma asincrona un archivo nuevo, escribe en él la cadena especificada y, a continuación, lo cierra. Si el archivo de destino ya existe, se sobrescribe.
1. `WriteAllBytesAsync`: Crea de forma asincrona un archivo nuevo, escribe en él la matriz de bytes especificada y, a continuación, lo cierra. Si el archivo de destino ya existe, se sobrescribe.
1. `WriteAllLinesAsync`: Crea de forma asincrona un archivo nuevo, escribe en él las líneas especificadas y, a continuación, lo cierra.

#### Copia
```Csharp
File.Copy(nombreArchivoOrigen, nombreArchivoDestino);
```

### Stream en archivos
Para leer y escribir archivos `Stream` se suelen usar las clases `StreamReader` y `StreamWritter`

#### Lectura
1. `ReadToEndAsync`: Lee de forma asincrona todos los caracteres desde la posición actual hasta el final de la secuencia y los devuelve como una cadena.
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

- La serialización binaria preserva la fidelidad de tipo, lo que es útil para conservar el estado de un objeto, por ejemplo, serializarlo en el Portapapeles.
- La serialización XML solo serializa propiedades y campos públicos y no preserva la fidelidad de tipo. Dado que XML es un estándar abierto, es una opción atractiva para compartir los datos por la web.
- La serialización de JSON solo serializa propiedades públicas y no preserva la fidelidad de tipo.

### Serializacion JSON
Actualmente se ha convertido en un estándar ampliamente utilizado para el intercambio de información entre sistemas.

#### Json con Stream
Lee un objeto stream y lo convierte a texto con formato JSON

```Csharp
await JsonSerializer.SerializeAsync(stream, objectToSerialize);
```

Lee un JSON obtenido por un objeto Stream y lo devuelve en una instancia del tipo indicado.
```Csharp
await JsonSerializer.DeserializeAsync<T>(stream);
```

#### Json con objetos
Convierte un objeto a un texto en formato JSON

```Csharp
var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
var serializado = JsonSerializer.Serialize(serializacion);
```

Lee un texto en formato JSON y devuelve una instancia del tipo indicado.
```Csharp
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

document.Descendants("empleado")
    .Where(x => x.Attribute("id").Value == "1" && x.Element("nombre").Value == "empleado");
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
empresa.Save(nombreArchivo);
```

#### XML Serializando objetos con Streams
```Csharp
var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
var xmlSerializer = new XmlSerializer(typeof(ClaseSerializacion));
xmlSerializer.Serialize(streamObject, serializacion);
```
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

>**Importante**  
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

Una solucion, sobretodo para Dependency Injection, es usar la clase `HttpClientFactory` que hay nas abajo explicada,

### Configurar Headers
Para crear, eliminar y modificar los headers de una solicitud Http, en el objeto de `HttpClient` debemos acceder a la propiedad `DefaultRequestHeaders` la cual contendra toda la informacion sobre las diferentes cabeceras que se pueden tratar.

```Csharp
httpClient.DefaultRequestHeaders.Accept.Clear();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", autenticationToken);
```

### **GET**
Formas de consultar datos por **GET** a un API

Cabe decir que las solicitudes `GET` se envian los datos de consulta a traves de `QueryString` y se puede configurar de la siguiente forma.

```Csharp
var url = new UriBuilder(urlBase);
var parametersQueryString = HttpUtility.ParseQueryString(url.Query);
parametersQueryString.Add(parametro.Key, parametro.Value?.ToString());

url.Query = parametersQueryString.ToString();
url.ToString();
```

#### GetStringAsync
```Csharp
httpClient.GetStringAsync(urlFinal);
```

#### GetFromJsonAsync
```Csharp
httpClient.GetFromJsonAsync<ClaseDeserializar>(urlFinal);
```

### **POST**
Metodos para envio de datos por **POST** a un API.

#### PostAsync
```Csharp
var content = new StringContent("string con el contenido", UTF8Encoding.UTF8, "application/json");
httpClient.PostAsync($"url", content);
```

#### PostAsJsonAsync
```Csharp
httpClient.PostAsJsonAsync<TipoSerializar>("url", objetoToSerializar); 
```

### **PUT**
Metodos de enviar datos para actualizar por **PUT** en un API

#### PutAsync
```Csharp
var content = new StringContent("string con el contenido", UTF8Encoding.UTF8, "application/json");
httpClient.PutAsync($"url", content);
```

#### PustAsJsonAsync
```Csharp
httpClient.PutAsJsonAsync<TipoSerializar>("url", objetoToSerializar); 
```

### **DELETE**
Metodos solicitar el borrado de algun dato por **DELETE** a un API

#### DeleteAsync
```Csharp
httpClient.DeleteAsync($"url");
```

### HttpClient con Dependency Injection
Podemos configurar parametros en el objeto HttpClient para inyectarlo como dependencia y centrarnos solamente en realizar la peticion que necesitamos.

> **Importante**  
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


# Acceso a datos (ADO.NET)
ADO.NET proporciona acceso coherente a orígenes de datos como SQL Server y XML, así como a orígenes OLE DB y ODBC.

El funcionamiento de ADO.NET se basa esencialmente en utilizar los siguientes componentes:
- **DataSet**: El componente más importante, puede almacenar datos provenientes de múltiples consultas.
- **DataReader** Realiza eficientemente lecturas de grandes cantidades de datos que no caben en memoria
- **DbConnection** Utilizada para conectarse a la base de datos.
- **DbCommand** Permite especificar las órdenes, generalmente en `SQL`.

Un proveedor de datos debe proporcionar una implementación de Connection, Command, DataAdapter y DataReader.

El modo de funcionamiento típico de ADO.NET es el siguiente:
- Se crean un objeto `DbConnection` especificando la cadena de conexión.
- Se crea un objeto `DbCommand` y se indica la Query `SQL`.
- Se crea un DataSet donde almacenar los datos.
- Se abre la conexión.
- Se rellena el DataSet con datos a través del DataAdapter.
- Se cierra la conexión.
- Se trabaja con los datos almacenados en el DataSet.

## Interfaz `IDbConnection`
Representa una conexión abierta a un origen de datos y se implementa mediante proveedores de datos de .NET que acceden a bases de datos relacionales, por ejemplo, `SqlClient`.

## Interfaz `IDbCommand`
Se utiliza para definir, parametrizar y ejecutar una consulta al origen de datos, por ejemplo, una query SQL a una Sqlite.

Dispone de los siguientes metodos:
- `ExecuteReader()` Devuelve un `IDataReader` para leer los datos de una consulta, por ejemplo, para una `SELECT`
- `ExecuteScalar` devuelve un objeto, por ejemplo, para procedimientos almacenados
- `ExecuteNonQuery` devuelve un `int` para indicar el numero de registros modificados, por tanto se usara para insertar, actualizar y borrar.

## Interfaz `IDataReader`
Proporciona acceso secuencial de sólo lectura a una fuente de datos, por ejemplo, los datos que nos devuelve la consulta.
> Utilizar IDataReader deshabilita las operaciones con IDbConnection hasta que esta sea cerrada.

## Clase `DataSet`
Un DataSet encapsula un conjunto de tablas independientemente de su procedencia y mantiene las relaciones existentes entre estas.

El contenido de un DataSet puede serializarse en formato XML.

## Clase `DataTable`
Conjunto de `DataColumn` y `DataRow` que reprensenta el concepto de una tabla en memoria. La integridad de los datos se mantienen gracias al uso de objetos que representan restricciones

- `DataColumn` Define el tipo de una columna de una tabla e incluye las restricciones y las relaciones que afectan a la columna.
- `DataRow` Representa una coleccion de Rows en un `DataTable`, de acuerdo con el esquema definido por los `DataColumn` de la tabla. Además, incluye propiedades para determinar el estado de una fila especifica, por ejemplo, "nuevo, cambiado, borrado, etc".

> Cabe decir que las clases `DataSet` y `DataTable` no necesariamente se tienen que utilizar para el acceso a bases de datos, se pueden crear y utilizar para uso normal si, por ejemplo, queremos crear una tabla en memoria por algun motivo. No obstante, habra que valorar eso en cuestiones de rendimiento.

## Microsoft SQL Server
El procedimiento de una consulta sql con las clases abstractas podria ser el siguiente:

1. Creamos una extension de la clase abstracta `DbConnection` para tener acceso a las llamadas asincronas, recibimos la `sql`, una lista de `DbParameter` para parametrizar la query y el delegado en el que vamos a indicar el proceso de mapeo
1. Indicamos al objeto connection que se desechará al acabar, creamos un `DbCommand`, que sera el encargado de la ejecucion y lectura de la query.
1. Pasamos la query al `CommandText` e indicamos que es de tipo `text`, esto es debido a que podemos pasarle tipos como el de `StoredProcedure`.
1. Si tenemos parametros, los agregamos.
1. Abrimos la conexion de forma asincrona
1. Ejecutamos la query de forma asincrona
1. Leemos los resultados de forma asincrona y al agregar a la lista que devolvemos el resultado, lo mapeamos con el delegado que le pasamos.
```Csharp
public static async Task<IEnumerable<T>> ExecuteSqlQueryAsync<T>(this DbConnection connection, string sql, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper)
{
    using (connection)
    {
        using (var connect = connection.CreateCommand())
        {
            connect.CommandText = sql;
            connect.CommandType = System.Data.CommandType.Text;

            foreach (var parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            await connection.OpenAsync();

            using (var rows = await connect.ExecuteReaderAsync())
            {
                var entities = new List<T>();
                while (await rows.ReadAsync())
                {
                    entities.Add(mapper(rows));
                }
                return entities;
            }
        }
    }
}
```
La forma de ejecutar el codigo anterior seria de la siguiente forma.
```Csharp
var parameters = new List<DbParameter>
{
    new SqlParameter($"@NombreParametro", NombreParametro)
};
var dbConnection = new SqlConnection("Cadena de conexion");
dbConnection.ExecuteSqlQueryAsync(sql, parameters,
result => new
{
    anonimo1 = new
    {
        Nombre = result["NOMBRENEW"] == null ? null : result["NOMBRENEW"].ToString(),
    },
    UltimaModificacion = Convert.ToDateTime(result["MODIFIEDON"])
});
```
> **Importante**: Hay que hacer uso de las queries parametrizadas para evitar problemas como las Sql Injection.


# LINQ (Language Integrated Query)
Con el tiempo se han desarrollado diferentes lenguajes para los distintos tipos de orígenes de datos, como `SQL` para las bases de datos relacionales y `XQuery` para XML.

 LINQ simplifica tener que aprender diferentes lenguajes de consulta para trabajar con los datos de varios formatos y orígenes. En una consulta LINQ siempre se trabaja con objetos. Se usan los mismos patrones de codificación básicos para consultar y transformar datos de documentos XML, bases de datos SQL, conjuntos de datos de ADO.NET, colecciones y cualquier otro formato para el que haya disponible un proveedor de LINQ.

 Los objetos compatibles con LINQ tienen que tener implementadas las interfaces `IEnumerable` o `IQueryable`

 - **IQueryable**: Está pensada para que sea implementada por los proveedores de consultas. Esta interfaz esta pensada para ejecutar e interpretar [**árboles de expresion**](#arboles-de-expresion)

## Sintaxis de consulta
La mayoría de las consultas de la documentación introductoria de Language Integrated Query (LINK) se escribe con la sintaxis de consulta declarativa de LINQ. Pero la sintaxis de consulta debe traducirse en llamadas de método para .NET Common Language Runtime (CLR) al compilar el código. Estas llamadas de método invocan los operadores de consulta estándar, que tienen nombres tales como Where, Select, GroupBy, Join, Max y Average. Puede llamarlas directamente con la sintaxis de método en lugar de la sintaxis de consulta.

### Where
```Csharp
from prod in products
where prod.Name == "Producto 2"
select prod;

products.Where(prod => prod.Name == "Producto 2");
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

## Ejecucion aplazada de consulta

```Csharp
var query = products.Where(prod => prod.Name == "Producto 2");
foreach(var prod in query)
{
}
```

## Ejecucion Inmediata de consulta
Hay varias formas de ejecutar la consulta **Linq**. Uno de ellos seria mediante un bucle `foreach` y otra mediante funciones que extienden directamente de `IEnumerable` que serian los siguientes.

### ToList
```Csharp
products.Where(prod => prod.Name == "Producto 2")
    .ToList();
```

### ToArray
```Csharp
products.Where(prod => prod.Name == "Producto 2")
    .ToArray();
```

### ToDictionary
```Csharp
products.Where(prod => prod.Name == "Producto 2")
    .ToDictionary(key => key.CategoryID, value => value.Name);
```

### ToLookup
```Csharp
products.Where(prod => prod.Name == "Producto 2")
    .ToLookup(key => key.CategoryID, value => value.Name);
```

### Count
```Csharp
products.Where(prod => prod.Name == "Producto 2")
    .Count()
 ```

### FirstOrDefault
```Csharp
products.Where(prod => prod.Name == "Producto 2")
    .FirstOrDefault()
 ```

## Extension de Linq
En `Linq` mediante el uso de la interfaz `IEnumerable<T>` se pueden realizar metodos de extension para ampliar y personalizar la libreria linq para realizar filtros o guardar el objeto en una lista personalizada

### Creacion de consultas personalizadas
Formas de extender la clase `IEnumerable` para crear consultas personalizadas en Linq.

#### Consulta personalizada con Iterator
1. Creamos el metodo de extension sobre la interfaz `IEnumerable<T>` y recibimos una funcion que recibe un parametro `T` y devolvera un `bool`
1. Retornamos una instacia de nuestra clase, que implementará la interfaz `IEnumerator<T>`
```Csharp
public static IEnumerable<T> WherePersonalizado<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
{
    return new EnumeratorPersonalizadoWhere<T>(enumerable, predicate);
}
```

1. Creamos una clase que tiene que implementar `IEnumerable` e `IEnumerator<T>`
    - `IEnumerable` es implementada, puesto que tenemos que devolver un IEnumerable para que se pueda tratar como **Linq** cuando devolvamos la instancia.
    - `IEnumerator` es implementada para que la instancia pueda sea iterable. Cuando se intenta acceder al siguiente elemento mediante un bucle, llama al metodo `MoveNext()`, es donde habra que realizar la tarea asignada a la nuestra instancia.
```Csharp
public class EnumeratorPersonalizadoWhere<T> : IEnumerable<T>, IEnumerator<T>
{
    private readonly Func<T, bool> _predicate;
    private readonly IEnumerable<T> _enumerable;
    private IEnumerator<T>? _enumerator;
    private int caso;

    public T Current { get; }

    object IEnumerator.Current => Current;

    public EnumeratorPersonalizadoWhere(IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        _predicate = predicate;
        _enumerable = enumerable;
        caso = 1;
    }

    public bool MoveNext()
    {
        switch (caso)
        {
            case 1:
                _enumerator = _enumerable.GetEnumerator();
                caso = 2;
                goto case 2;
                break;
            case 2:
                while (_enumerator.MoveNext())
                {
                    var item = _enumerator.Current;
                    if (_predicate(item))
                    {
                        return true;
                    }
                }
                Dispose();
                break;
        }
        return false;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        if (_enumerator == null) return;
        _enumerator.Dispose();
        _enumerator = null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

#### Consulta personalizada con Yield
Gracias al uso de yield podemos ahorrarnos el lastre de crear una clase personalizada para iteracion

1. Creamos el metodo de extension de `IEnumerable` y recibimos los parametros correspondientes para realizar la consulta
1. Creamos un bucle foreach del enumerable que recibimos para poder resolver el resto de iterators.
1. Realizamos el proceso de la consulta que necestiamos
1. Usamos la instruccion `yield return` para devolver lo que necesitamos.
```Csharp
public static IEnumerable<T> WherePersonalizadoYield<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
{
    foreach (var item in enumerable)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}
```

### Crear ejecucion personalizada de la consulta
Para resolver una consulta **linq** debemos de iterarlo, por ejemplo, creando un bucle foreach. De esta forma se resuelve la consulta.

```Csharp
public static List<T> ToListPersonalizada<T>(this IEnumerable<T> enumerable)
{
    var lista = new List<T>();
    foreach (var item in enumerable)
    {
        lista.Add(item);
    }

    return lista;
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

Su funcionamiento consiste en lo siguiente.

1. Hilos en el IOCP
1. Estamos esperando a una operacion asincrona, por ejemplo, lectura de un fichero de disco. Se pasa el thread al **IOCP**(threads que se mantienen a la espera), se inicia la operacion I/O, se crea la maquina de estados y se retorna un objeto `Task` a nuestro codigo.
1. Se espera a que termine la operacion I/O.
1. Se señala el IOCP.
1. El IOCP hace un callback para enviar la respuesta, se añade el resultado a la maquina de estados y se ejecuta el `TrySetResult`, se marcara la tarea como `Completed` y obtendremos el resultado solicitado en nuestro codigo. 
![image](https://user-images.githubusercontent.com/28193994/148436299-fba37b44-9af8-49ab-b4c5-cff9f7cc15d0.png)

Cuando ejecutamos la instruccion await, se nos genera codigo de bajo nivel de forma invisible, que crea y ejecuta una maquina de estados que se encarga de comprobar si la tarea fue ejecutada.

Un codigo que nosotros hacemos tan sencillo como lo siguiente:
```Csharp
private static async Task<string> GetWebData()
{
    BeforeTaskCreation();
    var task = new HttpClient().GetStringAsync(new Uri("https://www.google.es"));
    AfterTaskCreation();
    var result = await task;
    AfterAwaitTask(result);
    return result;
}
```
Genera el siguiente resultado.

1. Crea una estructura que implementa una interface `IAsyncStateMachine`
1. Declara variables para la maquina de estados
1. Declara el metodo MoveNext(), cuando se ejecuta el `default` lo que hace es ejecutar la funcion asincrona que queriamos y va obteniendo el awaiter, si no es completada, ira cambiando el estado y sera llamado de nuevo mas adelante hasta que sea completo, cuando eso pase, se acabará la ejecucion del switch y se retornará el resultado que queremos.

```Csharp
private struct AsyncStateMachine : IAsyncStateMachine
{
    public int CurrentState;
    public AsyncTaskMethodBuilder<string> Builder;
    public Task<string> Task;
    public string Result;
    private TaskAwaiter<string> awaiter;

    void IAsyncStateMachine.MoveNext()
    {
        string currentResult = null;
        try
        {
            bool flag = true;
            TaskAwaiter<string> awaiter;
            switch (this.CurrentState)
            {
                case -3:
                    goto label_6;
                case 0:
                    awaiter = this.awaiter;
                    this.awaiter = new TaskAwaiter<string>();
                    this.CurrentState = -1;
                    break;
                default:
                    this.Task = new HttpClient().GetStringAsync(new Uri("https://www.google.es"));
                    awaiter = this.Task.GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        this.CurrentState = 0;
                        this.awaiter = awaiter;
                        this.Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, AsyncStateMachine>(ref awaiter, ref this);
                        flag = false;
                        return;
                    }
                    break;
            }
            string result = awaiter.GetResult();
            awaiter = new TaskAwaiter<string>();
            this.Result = result;
            currentResult = this.Result;
        }
        catch (Exception ex)
        {
            this.CurrentState = -2;
            this.Builder.SetException(ex);
            return;
        }

    label_6:
        this.CurrentState = -2;
        this.Builder.SetResult(currentResult);
    }

    void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
    {
        this.Builder.SetStateMachine(param0);
    }
}
```

1. Creamos una instancia de la estructura de maquina de estado.
1. Creamos una instancia de `AsyncTaskMethodBuilder`
1. Indica que el estado es -1
1. Inicia la maquina de estados
1. Retorna el resultado
```Csharp
private static Task<string> GetWebData()
{
    AsyncStateMachine stateMachine = new AsyncStateMachine();
    stateMachine.Builder = AsyncTaskMethodBuilder<string>.Create();
    stateMachine.CurrentState = -1;
    stateMachine.Builder.Start<AsyncStateMachine>(ref stateMachine);
    return stateMachine.Builder.Task;
}
```

#### Async Eliding
Visto el codigo anterior, aparte de darnos cuenta de que la magia no existe, se ve que, aunque el uso de await nos da mas escalabilidad, requiere de mas proceso a lo tonto, al final, para nosotros solo es una palabra, ¿no?.

Generalmente cuando creamos una operacion asincrona, es asincrona hasta lo mas profundo de nuestro codigo, esto no es algo malo, pero hay que tener en cuenta que si en ese codigo se usan, por ejemplo, 5 await, se van a crear 5 maquinas de estado para el control de ese await y muchas veces, hacemos un await con un return. Eso provoca un procesamiento innecesario.

No siempre es posible, pero usando el siguiente codigo de ejemplo, podriamos evitar este problema.

- Creamos una maquina de estados para la ejecucion de `MetodoConAwait()`, cuando se llame al metodo, se creara otra maquina de estamos para la ejecucion de `Task.Delay`
- Creamos una maquina de estados para la ejecucion de `MetodoSinAwait()`, este metodo llamara a `Task.Delay` y la maquina de estados controlara su ejecucion.

Es importante saber analizar esto, puesto que en el caso de `result1` estamos generando 2 maquinas de estado cuando en el caso de `result2` estamos generando 1 y si ejecutamos el codigo veremos que ambas hacen exactamente el mismo resultado. Por tanto en el primer caso estamso generando codigo innecesario

```Csharp
public static async Task MetodoQueEjecuta()
{
    await MetodoConAwait();

    await MetodoSinAwait();
}


public static async Task MetodoConAwait()
{
    await Task.Delay(100000);
}

public static Task MetodoSinAwait()
{
    return Task.Delay(100000);
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

await Parallel.ForEachAsync(Enumerable.Range(0, 10), async (value, token) =>
{
    await Task.Delay(2000);
    Console.WriteLine($"ForEachAsync NOMBRE  --  {value}");
});
```
- El primer parámetro se envía el objeto que queremos leer, un List<string> por ejemplo
- El segundo parámetro va la lambda que puede recibir dos parámetros
    - `obj` Contendrá un objeto del tipo de la lista y solo 1 elemento de dicha lista, es lo mismo que si a un array le hacemos un objetoArray[x] con un for normal.
    - `ParallelLoopState` Un objeto que se encargara de gestionar los estados de los hilos, pudiendo parar la ejecución, etc.
    - `index` Una propiedad que devuelve en que indice de la coleccion estamos.

## Paralelizacion
Las operaciones **asincronas** estan centrads en usar un mismo hilo para la ejecucion de operaciones **E/S**, de esta manera permite mayor **escalabilidad**.

Las operaciones **Parallel** estan mas centradas en usan multiples hilos, puesto que tienen que realizar procesamiento enlazado a la **cpu**.

### Ejemplos de uso de tipos de paralizacion
- Si queremos realizar varias consultas a base de datos de forma simultanea podemos hacer uso de las operaciones asincronas directamente.
    ```Csharp
        public async Task<List<UserResponse>> GetListUsers()
        {
            using var context = _contextFactory.CreateDbContext();
            await Task.Delay(1000);
            return await (from user in context.User
                        select new UserResponse
                        {
                            Id = user.Id,
                            NombreUsuario = user.UserName,
                            Nombre = user.NormalizedUserName,
                            Email = user.Email,
                            TieneDobleFactor = user.TwoFactorEnabled
                        }).ToListAsync();
        }

    ```
    - Suponiendo la ejecucion de multiples queries
        - Creamos una lista de tareas
        - Ejecutamos las tareas y las agregamos en la lista
        - Esperamos el resultado de las queries
    ```Csharp
        var tareas = new List<Task>();

        foreach (var item in Enumerable.Range(0, 10))
        {
            tareas.Add(userDam.GetListUsers());
        }
        await Task.WhenAll(tareas);
    ```

- Si queremos realiza operaciones costosas, por ejemplo, deserializar varios objetos grandes en memoria, leer estructuras de datos muy complejas, calculos muy grandes, debemos de usar el paralelismo por cpu.
    - Suponiendo que queremos calcular el coseno de una lista de elementos.  
    Si son pocos elementos no hace falta, pero si son una cantidad elevada, se podria considerar una carga bastante elevada a la cpu.
    ```Csharp
    Parallel.For(0, itemList.Count(), (i) =>
    {
        itemList[i] += (int)Math.Cos(i);
    });
    ```
    ![image](https://user-images.githubusercontent.com/28193994/148693892-581d79e0-1e8f-409b-bcee-d3fa3bad1a19.png)


# Gestion de Memoria
La administración de memoria automática es uno de los servicios que proporciona el CLR durante la ejecución. Los programadores no tienen que escribir código para realizar tareas de administración de memoria al programar aplicaciones administradas. La administración automática de la memoria puede eliminar problemas frecuentes, como olvidar liberar un objeto y causar una pérdida de memoria.

## Garbage Collector
El recolector de elementos no utilizados administra la asignación y liberación de la memoria de una aplicación.

### Asignar memoria
Cuando inciamos la aplicacion, se reserva un espacio para las direcciones de memoria denominado montón administrado, que contiene un puntero a la dirección que se asignará al siguiente objeto. Todos los tipos de referencia se asignan en el montón administrado. Cuando creamos el primer tipo de referencia, se le asigna la memoria base del montón. Cuando creamos el resto de objetos se va asignando memoria en los espacios que siguen inmediatamente despues a la asignacion del ultimo objeto.

La asignación de memoria desde el montón administrado es más rápida que la asignación de memoria no administrada. Como el JIT asigna memoria a los objetos agregando un valor a un puntero, este método es casi tan rápido como la asignación de memoria desde la pila. Además, puesto que los nuevos objetos que se asignan consecutivamente se almacenan uno junto a otro en el montón administrado, la aplicación puede tener un acceso muy rápido a los objetos.


### Liberar memoria
El **GC** determina cuál es el mejor momento para realizar una recolección basándose en las asignaciones. Cuando lleva a cabo una recolección, libera la memoria de los objetos que no se usan. 

**GC** determina qué objetos ya no se usan examinando las **raíces** de la aplicación. Todas las aplicaciones tienen un conjunto de **raíces**. Cada raíz hace referencia a un objeto del montón, o bien se establece en `null`. Las **raíces** de una aplicación incluyen campos estáticos, variables locales y parámetros de pila de un subproceso y registros de la CPU. El **GC** tiene acceso a la lista de **raíces** activas que **Just-In-Time (JIT)** y el runtime mantienen. Se examinan las **raíces** de la aplicación y, durante este proceso, crea un gráfico que contiene todos los objetos que no se pueden alcanzar. Durante el proceso de recolección, usa una función de copia de memoria para compactar los objetos **alcanzables** en la memoria y libera los bloques de espacios **inalcanzables**. 

Una vez que se ha compactado la memoria de los objetos alcanzables, el **GC** hace las correcciones de puntero necesarias para que las raíces de la aplicación señalen a los objetos en sus nuevas ubicaciones. También sitúa el puntero del montón administrado después del último objeto alcanzable. La memoria sólo se compacta si, durante una recolección, se detecta un número significativo de objetos inalcanzables. Si todos los objetos del montón administrado sobreviven a una recolección, no hay necesidad de comprimir la memoria.

Para mejorar el rendimiento, el tiempo de ejecución asigna memoria a los objetos grandes en un montón aparte. El recolector de elementos no utilizados libera la memoria para los objetos grandes automáticamente. Sin embargo, para no mover objetos grandes en la memoria, dicha memoria no se compacta.

### Generaciones y rendimiento
Para optimizar el rendimiento del recolector de elementos no utilizados, el montón administrado se divide en tres generaciones: **0, 1 y 2**.
- Es más rápido compactar la memoria de una parte del montón administrado que la de todo el montón.
- Los objetos más recientes tienen una duración más corta y los objetos antiguos tienen una duración más larga. 
- Los objetos más recientes suelen estar relacionados unos con otros y la aplicación tiene acceso a ellos más o menos al mismo tiempo.

El **GC** almacena los nuevos objetos en la generación 0. Los objetos que sobreviven a las recolecciones se mueven y se almacenan en las generaciones 1 y 2. Como es más rápido compactar una parte del montón administrado que todo el montón, este esquema permite que el recolector libere la memoria en una generación específica en lugar de para todo el montón.

El **GC** realiza la recolección cuando se llena la generación 0. Si una aplicación trata de crear un nuevo objeto cuando está llena, invoca un proceso de liberacion. Primero examina los objetos de la generación 0. Éste es un enfoque más eficaz, ya que los objetos nuevos suelen tener una duración más corta y se espera que la aplicación no utilice muchos de los objetos de la generación 0 cuando se realice una recolección. Además, una recolección de tan sólo la generación 0 a menudo recupera suficiente memoria para que la aplicación pueda continuar creando nuevos objetos.

## Codigo inseguro (unsafe)
La mayor parte del código de C# que se escribe es "código seguro comprobable". El código seguro comprobable significa que las herramientas de .NET pueden comprobar que el código es seguro. En general, el código seguro no accede directamente a la memoria mediante punteros. Tampoco asigna memoria sin procesar. En su lugar, crea objetos administrados.

El código no seguro tiene las propiedades siguientes:

- Los métodos, tipos y bloques de código se pueden definir como no seguros.
- En algunos casos, el código no seguro puede aumentar el rendimiento de la aplicación al eliminar las comprobaciones de límites de matriz.
- El código no seguro es necesario al llamar a funciones nativas que requieren punteros.
- El código no seguro presenta riesgos para la seguridad y la estabilidad.
- El código que contenga bloques no seguros deberá compilarse con la opción del compilador AllowUnsafeBlocks.

### Punteros
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

## Stackalloc
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

## Memory & Span
`Span<T>` y `Memory<T>` son los búferes de datos estructurados que se pueden usar en las canalizaciones. Es decir, están diseñados para que parte de los datos, o todos, se puedan pasar, procesar y modificar de forma eficaz.

Puesto que los búferes se pueden pasar entre las API, y se puede acceder a los buffer desde varios subprocesos, es importante tener en cuenta la duración.
- **Propiedad**. El propietario de una instancia de búfer es responsable de la administración de la duración, por ejemplo, destruirlo cuando ya no se use. Todos los búferes tienen un único propietario.
- **Consumo**. El consumidor de una instancia de búfer puede usar la instancia leyendolo y, si se permite, escribiendo. Solo se puede tener un consumidor a la vez, a menos que se proporcione algún mecanismo de sincronización externo. El consumidor no tiene porque ser el propietario.
- **Concesión**. La concesión es el período durante el cual un componente concreto puede ser el consumidor del búfer.

### Instrucciones de uso - [Rules](https://docs.microsoft.com/es-es/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#usage-guidelines)
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

### `Span<T>`
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


### `Memory<T>`
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

## Estructuras
Una estructura se usa para almacenar datos por tipo de valor, eso quiere decir que la idea de la estructura es almacenar la instancia en el **stack** y no en el **heap** como las clases, por tanto la instanciacion del objeto se realiza de manera mas optima.

Generalmente las estructuras se utilizan para realizar optimizaciones en el codigo.

Cabe decir que no siempre se almacenan en el **stack**, por ejemplo, si usamos una estructura en un delegado o un campo de un objeto de tipo `class`.

```Csharp
public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
```

### Estructura readonly
Para poder declarar la estructura como inmutable se puede usar el modificador `readonly`. 
- Cualquier campo se tiene que declarar como `readonly`.
- Las propiedades deben de ser de solo lectura. Por tanto solo podran contener los descriptores de acceso `get` e `init`.

```Csharp
public readonly struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; init; }
    public double Y { get; init; }

    public override string ToString() => $"({X}, {Y})";
}
```

### Estructura ref
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

## Liberacion de Memoria
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

using var objeto = File.Create("");
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


# Interoperabilidad
La interoperabilidad consiste en la capacidad de poder comunicarse con otro software, por ejemplo, hacer uso de liberias nativas del sistema operativo para la GUI, usar librerias desarrolladas en otros lenguajes, etc.

> Las técnicas de interoperabilidad, al ejecutar librerias externas son recursos no administrados y por tanto, el Garbage Collector no va a actuar sobre ellas.

## P/Invoke 
Es una libreria que permite acceder a estructuras, devoluciones de llamada y funciones de bibliotecas no administradas desde código administrado.
```rust
#[no_mangle]
pub extern fn add_numbers(number1: i32, number2: i32) -> i32 {
    println!("Hola con Rust");
    number1 + number2
}

/*
> cargo new lib
> cd lib
Creamos el archivo lib.rs
Editamos el archivo cargo.toml y agregamos:
    [lib]
    name="libreriaEjemploRust"
    crate-type = ["dylib"]
> cargo build
```

```Csharp
[DllImport("libreriaEjemploRust.dll")]
private static extern int add_numbers(int number1, int number2);

public static void Main(string[] args)
{
    int suma = add_numbers(1, 2);
    Console.WriteLine(suma);
}
```
