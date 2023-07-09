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
