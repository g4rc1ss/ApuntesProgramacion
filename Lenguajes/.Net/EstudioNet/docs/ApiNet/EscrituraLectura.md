Conjunto de clases y formas de trabajar con metodos **Input/Output**.

# Stream
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

# MemoryStream
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

## Lectura
Podemos leer mediante los metodos de la propia clase `MemoryStream`
```Csharp
using var streamEscrito = new MemoryStream();

int buffer;
while ((buffer = streamEscrito.ReadByte()) >= 0)
{
    Console.Write(Convert.ToChar(buffer));
}
```

## Escritura
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

## Copia
```Csharp
using var memoryStream = new MemoryStream();

await streamEscrito.CopyToAsync(memoryStream);
```

## Uso en otras clases derivadas
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

# Archivos de texto
Clases que interactuan con archivos de texto fisicamente

## Binary
Clase que debe recibir un objeto `Stream` y se utiliza para la lectura y escritura de archivos tratando el contenido directamente como binario con tipos primitivos.

### Lectura
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

### Escritura
```Csharp
using var fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
using var bw = new BinaryWriter(fs);
bw.Write(1.0M);
bw.Write("Este es el texto que se esta escribiendo");
```

### Copia
```Csharp
using var readBinaryFile = new BinaryReader(File.OpenRead(nombreArchivoFuente));
using var writeBinaryFile = new BinaryWriter(File.OpenWrite(nombreArchivoDestino));
for (byte data; readBinaryFile.PeekChar() != -1;)
{
    data = readBinaryFile.ReadByte();
    writeBinaryFile.Write(data);
}
```

## File
La clase File se usa para operaciones típicas como copiar, mover, cambiar el nombre, crear, abrir, eliminar y anexar a un único archivo cada vez

### Create
```Csharp
using var file = File.Create(archivo);
```

### Delete
```Csharp
File.Delete(archivo);
```

### Lectura
1. `ReadAllTextAsync`: Abre de forma asincrona un archivo de texto, lee todo el texto del archivo y, a continuación, cierra el archivo.
1. `ReadAllBytesAsync`: Abre de forma asincrona un archivo binario, lee su contenido, lo introduce en una matriz de bytes y, a continuación, cierra el archivo.
1. `ReadAllLinesAsync`: Abre de forma asincrona un archivo de texto, lee todas sus líneas y, a continuación, cierra el archivo.

### Escritura
1. `WriteAllTextAsync`: Crea de forma asincrona un archivo nuevo, escribe en él la cadena especificada y, a continuación, lo cierra. Si el archivo de destino ya existe, se sobrescribe.
1. `WriteAllBytesAsync`: Crea de forma asincrona un archivo nuevo, escribe en él la matriz de bytes especificada y, a continuación, lo cierra. Si el archivo de destino ya existe, se sobrescribe.
1. `WriteAllLinesAsync`: Crea de forma asincrona un archivo nuevo, escribe en él las líneas especificadas y, a continuación, lo cierra.

### Copia
```Csharp
File.Copy(nombreArchivoOrigen, nombreArchivoDestino);
```

## Stream en archivos
Para leer y escribir archivos `Stream` se suelen usar las clases `StreamReader` y `StreamWritter`

### Lectura
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

### Escritura
```Csharp
using var writeFile = new StreamWriter(nombreArchivo);
await writeFile.WriteAsync(textoEscribir);
```

# Serializacion
La serialización es el proceso de convertir el estado de un objeto en un formato que se pueda almacenar o transportar. Este proceso permite almacenar y transferir datos.

- La serialización binaria preserva la fidelidad de tipo, lo que es útil para conservar el estado de un objeto, por ejemplo, serializarlo en el Portapapeles.
- La serialización XML solo serializa propiedades y campos públicos y no preserva la fidelidad de tipo. Dado que XML es un estándar abierto, es una opción atractiva para compartir los datos por la web.
- La serialización de JSON solo serializa propiedades públicas y no preserva la fidelidad de tipo.

## Serializacion JSON
Actualmente se ha convertido en un estándar ampliamente utilizado para el intercambio de información entre sistemas.

### Json con Stream
Lee un objeto stream y lo convierte a texto con formato JSON

```Csharp
await JsonSerializer.SerializeAsync(stream, objectToSerialize);
```

Lee un JSON obtenido por un objeto Stream y lo devuelve en una instancia del tipo indicado.
```Csharp
await JsonSerializer.DeserializeAsync<T>(stream);
```

### Json con objetos
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

## Serializacion XML
Los archivos XML (Extensible Markup Language) son un meta lenguaje que sirve para almacenar datos y facilitar su transmisión entre diferentes tecnologías sin afectar su estructura original.

### XML Document

#### Leer documentos XML
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

#### Escribir documentos XML
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

### XML con Linq
Gracias a la abstraccion de linq, podemos cargar y consultar archivos Linq.

#### Leer un archivo con Linq
```Csharp
var document = XElement.Load(nombreArchivo);

document.Descendants("empleado")
    .Where(x => x.Attribute("id").Value == "1" && x.Element("nombre").Value == "empleado");
```

#### Escribir un archivo mediante Linq
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

### XML Serializando objetos con Streams
```Csharp
var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
var xmlSerializer = new XmlSerializer(typeof(ClaseSerializacion));
xmlSerializer.Serialize(streamObject, serializacion);
```
```Csharp
var xmlSerializer = new XmlSerializer(typeof(ClaseSerializacion));
var objetoDeserializado = xmlSerializer.Deserialize(streamObject);
```
