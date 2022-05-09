# Estudio Net
Índice ordenado para estudiar el uso del lenguaje C# y las librerias mas utilizadas tanto del API .Net, como librerias externas o Frameworks.


## Estudio basico Csharp
Lista de contenido en el que se explica el lenguaje C#, la programación Orientada a Objetos, las excepciones y conceptos avanzados como el uso de indizadores, etc.

1. [**Estructura del Código**](./docs/Csharp/EstructuraCodigo/EstructuraCodigo.md)
    - [Variables](./docs/Csharp/EstructuraCodigo/Variables.md)
    - [Condicionales](./docs/Csharp/EstructuraCodigo/InstruccionSeleccion.md)
    - [Bucles](./docs/Csharp/EstructuraCodigo/InstruccionIteracion.md)
    - [Operadores](./docs/Csharp/EstructuraCodigo/Operadores.md)
    - [Enumeradores](./docs/Csharp/EstructuraCodigo/Enums.md)
1. **Programación Orientada a Objetos**: La programación orientada a objetos (Object Oriented Programming, OOP) es un modelo de programación que organiza el diseño de software en torno a datos u objetos, en lugar de funciones y lógica. Un objeto se puede definir como un campo de datos que tiene atributos y comportamiento únicos.
    - [Clases](./docs/Csharp/POO/Clases.md)
    - [Clases Estaticas](./docs/Csharp/POO/StaticClass.md)
    - [Metodos](./docs/Csharp/POO/Method.md)
    - [Propiedades](./docs/Csharp/POO/Properties.md)
    - [Herencia](./docs/Csharp/POO/Herencia.md)
    - [Clases Abstractas](./docs/Csharp/POO/ClasesAbstractas.md)
    - [Clases Selladas](./docs/Csharp/POO/SealedClass.md)
    - [Interfaces](./docs/Csharp/POO/Interfaces.md)
    - [Polimorfismo](./docs/Csharp/POO/Polimorfismo.md)
    - [Covarianza & Contravarianza](./docs/Csharp/POO/CovarianzaContravarianza.md)
1. [Tratamiento de Excepciones](./docs/Csharp/Excepciones/TratamientoExcepciones.md)
1. **Conceptos Avanzados**
    - [Atributos](./docs/Csharp/ConceptosAvanzados/Atributos.md)
    - [Indizadores](./docs/Csharp/ConceptosAvanzados/Indizadores.md)
    - [Generics](./docs/Csharp/ConceptosAvanzados/Generics.md)
    - [Yield](./docs/Csharp/ConceptosAvanzados/Yield.md)
    - [Events](./docs/Csharp/ConceptosAvanzados/Events.md)


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
    - Archivos de Texto
        - [Binarios](./docs/ApiNet/InputOutput/TextFiles/Binary.md)
        - [File](./docs/ApiNet/InputOutput/TextFiles/File.md)
        - [Usando Streams](./docs/ApiNet/InputOutput/TextFiles/StreamOnFiles.md)
    - [Serializar objetos](./docs/ApiNet/InputOutput/Serialization/Serializacion.md)
        - [JSON](./docs/ApiNet/InputOutput/Serialization/JSON.md)
        - [XML](./docs/ApiNet/InputOutput/Serialization/XML.md)
1. **Uso de Internet**
    - [HttpClient](./docs/ApiNet/Network/HttpClient.md)
    - [HttpMessageHandler](./docs/ApiNet/Network/HttpMessageHandler.md)
1. [Delegados](./docs/ApiNet/Delegados.md)
1. [Reflexion](./docs/ApiNet/Reflexion.md)
1. [Gestion de Memoria](./docs/ApiNet/GestionMemoria.md)
1. [Interoperabilidad](./docs/ApiNet/Interoperabilidad.md)

## Estudio de Librerias Externas de .Net
Documentación sobre el uso de librerias o frameworks que no estan alojados en el API de .Net y que tienen un uso especifico como `Dapper` para el acceso a base de datos relacionales o `MemoryCache` para cachear objetos en memoria.

1. **Inyeccion de Dependencias**
    1. [Explicacion de DI](./docs/LibreriasNet/DependencyInjection/DependencyInjection.md)
    1. [Implementar DI en Proyectos](./docs/LibreriasNet/DependencyInjection/ImplementarDiProyectos.md)
1. [IOptions](./docs/LibreriasNet/IOptions.md)
1. **Logging**: Los logs son cadenas de texto que se almacenan y son utilizados para guardar registro de las acciones que se han realizado en la aplicación.
    - [Logging con Serilog](./docs/LibreriasNet/Logging/LoggingSerilog.md)
1. **Caching**:
    - [Cache en Memoria (IMemoryCache)](./docs/LibreriasNet/Caching/CacheMemoriaMemory.md)
    - [Cache en Memoria (IDistributedCache)](./docs/LibreriasNet/Caching/CacheMemoriaDistributed.md)
    - [Cache Distribuida con Servidor Redis](./docs/LibreriasNet/Caching/CacheServerRedis.md)
1. [Protección de Datos](./docs/LibreriasNet/IDataProtectionProvider.md)
1. [Middleware](./docs/LibreriasNet/Middleware.md)
1. **Database**
    - [Dapper](./docs/LibreriasNet/Database/Dapper.md)
    - [Entity Framework Core](./docs/LibreriasNet/Database/EntityFrameworkCore/EFCore.md)
        - [Migrations](./docs/LibreriasNet/Database/EntityFrameworkCore/Migrations.md)
1. [Identity](./docs/LibreriasNet/Identity.md)
1. [Mediatr](./docs/LibreriasNet/Mediatr.md)
1. [AutoMapper](./docs/LibreriasNet/AutoMapper.md)

1. **Testing**
    - [XUnit](./docs/LibreriasNet/Testing/XUnit.md)
    - [Moq](./docs/LibreriasNet/Testing/Moq.md)
    - [Fluent Assert](./docs/LibreriasNet/Testing/FluentAssertions.md)
