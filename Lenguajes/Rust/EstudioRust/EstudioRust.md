# Estudio Net
Índice ordenado para estudiar el uso del lenguaje Rust y las librerias mas utilizadas tanto del API .Net, como librerias externas o Frameworks.


## Estudio basico Csharp
Lista de contenido en el que se explica el lenguaje Rust, la programación Orientada a Objetos, las excepciones y conceptos avanzados como el uso de indizadores, etc.

1. [**Estructura del Código**](./docs/Rust/EstructuraCodigo/EstructuraCodigo.md)
    - [Variables](./docs/Rust/EstructuraCodigo/Variables.md)
    - [Condicionales](./docs/Rust/EstructuraCodigo/InstruccionSeleccion.md)
    - [Bucles](./docs/Rust/EstructuraCodigo/InstruccionIteracion.md)
    - [Operadores](./docs/Rust/EstructuraCodigo/Operadores.md)
    - [Enumeradores](./docs/Rust/EstructuraCodigo/Enums.md)
1. **Programación Orientada a Objetos**: La programación orientada a objetos (Object Oriented Programming, OOP) es un modelo de programación que organiza el diseño de software en torno a datos u objetos, en lugar de funciones y lógica. Un objeto se puede definir como un campo de datos que tiene atributos y comportamiento únicos.
    - [Structs](./docs/Rust/POO/Structs.md)
    - [Traits](./docs/Rust/POO/Traits.md)
1. [Tratamiento de Excepciones](./docs/Rust/Excepciones/TratamientoExcepciones.md)
1. **Conceptos Avanzados**
    - [Atributos](./docs/Rust/ConceptosAvanzados/Atributos.md)
    - [Indizadores](./docs/Rust/ConceptosAvanzados/Indizadores.md)
    - [Generics](./docs/Rust/ConceptosAvanzados/Generics.md)
    - [Yield](./docs/Rust/ConceptosAvanzados/Yield.md)
    - [Events](./docs/Rust/ConceptosAvanzados/Events.md)


## Estudio del API .Net
Documentacion sobre el uso de librerias del API de .Net

El API .Net se basa principalmente en el uso de los namespaces: `System`, `System.IO`, `System.Net`, `System.Collections`, `System.Data`, etc.

1. **Cadenas**
    - [String](./docs/Api/Cadenas/String.md)
    - [StringBuilder](./docs/Api/Cadenas/StringBuilder.md)
    - [Expresiones Regulares](./docs/Api/Cadenas/ExpresionesRegulares.md)
1. **Colecciones**
    - [IEnumerable](./docs/Api/Enumerables/Colecciones/IEnumerable.md)
    - [IEnumerator](./docs/Api/Enumerables/Colecciones/IEnumerator.md)
    - [Listas](./docs/Api/Enumerables/Colecciones/List.md)
    - [Diccionarios](./docs/Api/Enumerables/Colecciones/Dictionary.md)
    - [Pilas](./docs/Api/Enumerables/Colecciones/Stack.md)
    - [Colas](./docs/Api/Enumerables/Colecciones/Queue.md)
1. [LINQ (Language Integrated Query)](./docs/Api/Enumerables/LINQ.md)
1. **Database**
    - [Acceso a datos (ADO.NET)](./docs/Api/Database/ADONET.md)
1. **Threads**
    - [MultiThreading](./docs/Api/Threading/MultiThreading.md)
    - [Sincronizar Hilos](./docs/Api/Threading/SyncThreads.md)
    - [Task Parallel Library](./docs/Api/Threading/TaskParallelLibrary/TPL.md)
        - [Async & await](./docs/Api/Threading/TaskParallelLibrary/Async.md)
        - [Crear tareas asincronas](./docs/Api/Threading/TaskParallelLibrary/CrearTaskAsync.md)
        - [Parallel](./docs/Api/Threading/TaskParallelLibrary/Parallel.md)
        - [Cancelacion de Subprocesos](./docs/Api/Threading/TaskParallelLibrary/CancellationToken.md)
1. **Escritura y Lectura**
    - [Stream](./docs/Api/InputOutput/Stream.md)
    - [MemoryStream](./docs/Api/InputOutput/MemoryStream.md)
    - Archivos de Texto
        - [Binarios](./docs/Api/InputOutput/TextFiles/Binary.md)
        - [File](./docs/Api/InputOutput/TextFiles/File.md)
        - [Usando Streams](./docs/Api/InputOutput/TextFiles/StreamOnFiles.md)
    - [Serializar objetos](./docs/Api/InputOutput/Serialization/Serializacion.md)
        - [JSON](./docs/Api/InputOutput/Serialization/JSON.md)
        - [XML](./docs/Api/InputOutput/Serialization/XML.md)
1. **Uso de Internet**
    - [HttpClient](./docs/Api/Network/HttpClient.md)
    - [HttpMessageHandler](./docs/Api/Network/HttpMessageHandler.md)
1. [Delegados](./docs/Api/Delegados.md)
1. [Reflexion](./docs/Api/Reflexion.md)
1. [Source Generators](./docs/Api/SourceGenerator.md)
1. [Gestion de Memoria](./docs/Api/GestionMemoria.md)
1. [Interoperabilidad](./docs/Api/Interoperabilidad.md)

## Estudio de Librerias Externas de .Net
Documentación sobre el uso de librerias o frameworks que no estan alojados en el API de .Net y que tienen un uso especifico como `Dapper` para el acceso a base de datos relacionales o `MemoryCache` para cachear objetos en memoria.

1. **Inyeccion de Dependencias**
    1. [Explicacion de DI](./docs/Librerias/DependencyInjection/DependencyInjection.md)
    1. [Implementar DI en Proyectos](./docs/Librerias/DependencyInjection/ImplementarDiProyectos.md)
1. **Servicios Host**
    1. [Host](./docs/Librerias/ServiciosHost/Host.md)
    1. [Worker Services](./docs/Librerias/ServiciosHost/WorkerServices.md)
1. [IOptions](./docs/Librerias/IOptions.md)
1. **Logging**: Los logs son cadenas de texto que se almacenan y son utilizados para guardar registro de las acciones que se han realizado en la aplicación.
    - [Registros con ILogger<T>](./docs/Librerias/Logging/InterfazILogger.md)
    - [Logging con Serilog](./docs/Librerias/Logging/LoggingSerilog.md)
1. **Caching**:
    - [Cache en Memoria (IMemoryCache)](./docs/Librerias/Caching/CacheMemoriaMemory.md)
    - [Cache en Memoria (IDistributedCache)](./docs/Librerias/Caching/CacheMemoriaDistributed.md)
    - [Cache Distribuida con Servidor Redis](./docs/Librerias/Caching/CacheServerRedis.md)
1. [Protección de Datos](./docs/Librerias/IDataProtectionProvider.md)
1. [Middleware](./docs/Librerias/Middleware.md)
1. **Database**
    - [Dapper](./docs/Librerias/Database/Dapper.md)
    - [Entity Framework Core](./docs/Librerias/Database/EntityFrameworkCore/EFCore.md)
        - [Consultas](./docs/Librerias/Database/EntityFrameworkCore/Consultas.md)
        - [Migrations](./docs/Librerias/Database/EntityFrameworkCore/Migrations.md)
1. [Identity](./docs/Librerias/Identity.md)
1. [Mediatr](./docs/Librerias/Mediatr.md)
1. **Mappers**
    1. [AutoMapper](./docs/Librerias/AutoMapper.md)
    1. [Mapperly](./docs/Librerias/Mapperly.md)
1. **Testing**
    - [XUnit](./docs/Librerias/Testing/XUnit.md)
    - [NSubstitute](./docs/Librerias/Testing/NSubstitute.md)
    - [Fluent Assert](./docs/Librerias/Testing/FluentAssertions.md)
