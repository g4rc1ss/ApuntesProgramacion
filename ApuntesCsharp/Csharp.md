# C#

![CSharp Icono](https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png)

## CSharp
CSharp es un [lenguaje de programación compilado](https://es.wikipedia.org/wiki/Lenguaje_de_programación_compilado) con la filosofía de hacer un código fácil de leer y programar, con una sintaxis sencilla

CSharp se usa en diferentes entornos todos basados en .NET Framework o .NET CORE
- **.NET Framework** -> Es un conjunto de librerías que se usan con el fin de poder desarrollar aplicaciones rápidamente.

- **.NET CORE** -> Es un framework de código abierto, basado en .Net framework. Esta realizado desde cero prácticamente y esta mas destinado a poder usar una plataforma como es ``.NET`` desde sistemas como MacOS y GNU_Linux
---
### Que framework usar?

Esta es una pregunta un poco mas complicada, yo personalmente apuesto por .NET CORE porque me gusta mas el rollo multiplataforma y que pueda crear una aplicación y distribuirla/usarla en mi mac, mi windows y mi linux.

.NET Framework esta mas centrado en windows y tiene librerías muy potentes que todavía no han sido migradas a .NET CORE como por ejemplo la librería WPF para el desarrollo de GUI etc. 

Si se desea hacer una aplicación Desktop con el fin de correrla solo en plataformas windows sera mejor usar .net Framework porque esta mas hecha

En cambio si deseamos crear una aplicación web (ASP) o aplicaciones en consola podríamos crear aplicaciones .``net CORE`` puesto que son aplicaciones multiplataforma y es algo que esta muy a futuro

---
### Diferencias entre Frameworks

- **NET Core es nuevo, y escrito prácticamente desde cero** -> NET Core es, en muchos sentidos, un reboot de .NET Framework y ha tenido que ser reescrito desde cero

- **.NET Core es open source** -> .NET Core es un proyecto completamente open source desde sus orígenes

- **.NET Core es multiplataforma** -> De esta forma, ahora sería totalmente posible, por ejemplo, programar una aplicación en Windows y ejecutarla en un Mac, o desarrollarla en Mac y ejecutarla en una distribución Debian de Linux.

- **En .NET Core el rendimiento es algo prioritario** -> Desde sus orígenes, en .NET Core el rendimiento ha sido siempre una prioridad
    >  Por dar algunas cifras, algo tan simple y recurrente como utilizar los métodos `IndexOf()` o `StartsWith()` sobre una cadena son un `200%` más rápidos en .NET Core que en .NET Framework. Un `ToString()` sobre el elemento de un enum gana un `600%` de rendimiento. `LINQ`es hasta un `300%` más eficiente en determinados puntos. `Lazy<T>` es un `500%` más rápido etc.