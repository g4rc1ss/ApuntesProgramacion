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
