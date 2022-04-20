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
