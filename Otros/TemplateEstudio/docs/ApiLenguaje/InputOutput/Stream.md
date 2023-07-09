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
