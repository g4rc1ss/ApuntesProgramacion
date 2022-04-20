# Estudio Net
Índice ordenado para estudiar el uso del lenguaje C# y las librerias mas utilizadas tanto del API .Net, como librerias externas o Frameworks.


## Estudio basico Csharp
Lista de contenido en el que se explica el lenguaje C#, la programación Orientada a Objetos, las excepciones y conceptos avanzados como el uso de indizadores, etc.

1. [Estructura del Código](./docs/Csharp/EstructuraCodigo.md)
1. [Programación Orientada a Objetos](./docs/Csharp/ProgramacionOrientadaObjetos.md)
1. [Tratamiento de Excepciones](./docs/Csharp/TratamientoExcepciones.md)
1. [Conceptos Avanzados](./docs/Csharp/ConceptosAvanzados.md)


## Estudio del API .Net
Documentacion sobre el uso de librerias del API de .Net

El API .Net se basa principalmente en el uso de los namespaces: `System`, `System.IO`, `System.Net`, `System.Collections`, `System.Data`, etc.

1. **Cadenas**
    - [String](./docs/ApiNet/Cadenas/String.md)
    - [StringBuilder](./docs/ApiNet/Cadenas/StringBuilder.md)
    - [Expresiones Regulares](./docs/ApiNet/Cadenas/ExpresionesRegulares.md)
1. **Colecciones**
    - [IEnumerable](./docs/ApiNet/Enumerables/Colecciones/IEnumerable.md)
    - [IEnumerator](./docs/ApiNet/Enumerables/Colecciones/IEnumerator.md)
    - [Listas](./docs/ApiNet/Enumerables/Colecciones/List.md)
    - [Diccionarios](./docs/ApiNet/Enumerables/Colecciones/Dictionary.md)
    - [Pilas](./docs/ApiNet/Enumerables/Colecciones/Stack.md)
    - [Colas](./docs/ApiNet/Enumerables/Colecciones/Queue.md)
1. [LINQ (Language Integrated Query)](./docs/ApiNet/Enumerables/LINQ.md)
1. **Database**
    - [Acceso a datos (ADO.NET)](./docs/ApiNet/Database/ADONET.md)
1. **Threads**
    - [MultiThreading](./docs/ApiNet/Threading/MultiThreading.md)
    - [Sincronizar Hilos](./docs/ApiNet/Threading/SyncThreads.md)
    - [Task Parallel Library](./docs/ApiNet/Threading/TaskParallelLibrary/TPL.md)
        - [Async & await](./docs/ApiNet/Threading/TaskParallelLibrary/Async.md)
        - [Parallel](./docs/ApiNet/Threading/TaskParallelLibrary/Parallel.md)
1. **Escritura y Lectura**
    - [Stream](./docs/ApiNet/InputOutput/Stream.md)
    - [MemoryStream](./docs/ApiNet/InputOutput/MemoryStream.md)
    - [Archivos de Texto](./docs/ApiNet/InputOutput/TextFiles.md)
    - [Serializar objetos](./docs/ApiNet/InputOutput/Serializacion.md)
1. **Uso de Internet**
    - [HttpClient](./docs/ApiNet/Network/HttpClient.md)
1. [Delegados](./docs/ApiNet/Delegados.md)
1. [Reflexion](./docs/ApiNet/Reflexion.md)
1. [Gestion de Memoria](./docs/ApiNet/GestionMemoria.md)
1. [Interoperabilidad](./docs/ApiNet/Interoperabilidad.md)

## Estudio de Librerias Externas de .Net
Documentación sobre el uso de librerias o frameworks que no estan alojados en el API de .Net y que tienen un uso especifico como `Dapper` para el acceso a base de datos relacionales o `MemoryCache` para cachear objetos en memoria.

1. [Dependency Injection](./docs/LibreriasNet/DependencyInjection.md)
1. [Utilizar Cache](./docs/LibreriasNet/Caching.md)
1. [IOptions](./docs/LibreriasNet/IOptions.md)
1. [IDataProtectionProvider](./docs/LibreriasNet/IDataProtectionProvider.md)
1. [Middleware](./docs/LibreriasNet/Middleware.md)
1. **Database**
    - [Dapper](./docs/LibreriasNet/Database/Dapper.md)
    - [Entity Framework Core](./docs/LibreriasNet/Database/EFCore.md)
1. [Identity](./docs/LibreriasNet/Identity.md)
1. [Mediatr](./docs/LibreriasNet/Mediatr.md)
1. [AutoMapper](./docs/LibreriasNet/AutoMapper.md)
