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
