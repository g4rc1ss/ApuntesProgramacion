```Csharp
using System;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code...
        }
    }
}
```
- ``using`` -> Para importar librerías y módulos
- ``namespace`` -> indica la ubicación del programa
- ``class`` -> Creamos una clase, que es un modulo que se usa para declarar objetos y tratarlos añadiendo funciones.
- ``Main(string[] args)`` -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto


# Alias en using
Al importar un namespace, podemos asignar un alias para identificarlo. Para acceder a una clase que contiene un alias, se usara el operador `::`. Para acceder al namespace de .Net de forma exclusiva, se usara el alias `global`

```Csharp
using aliasUsing = System;

aliasUsing::Console.WriteLine();
global::System.Console.WriteLine();
```





