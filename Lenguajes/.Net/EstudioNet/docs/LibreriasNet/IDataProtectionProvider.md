# Protección de Datos
Es importante mantener la informacion sensible protegida, por si se diera el caso de una filtracion de datos o similares, es fundamental tener dichos datos encriptados.

Microsoft provee de una implementacion que se llama `IDataProtectionProvider`.

Este algoritmo utiliza las claves junto a un `purpose` que tendremos que pasar para proteger y desproteger los textos. El motivo de esto es que si, por ejemplo, tenemos un elemento protegido con el `purpose` *"identificador 1"* y tratamos de desprotegerlo con una instancia de `purpose` *"identificador 2"*, no deberia de ser capaz de realizar la accion.

> Los `purpose` están pensados para ser hardcodeados, no son contraseñas, **son identificadores**.

# Configuración de Almacenamiento y Claves
Este sistema de cifrado utiliza unas claves aleatorias generadas por la propia libreria y por defecto se almacenan en `%LOCALAPPDATA%\ASP.NET\DataProtection-Keys\` y `HOME\.aspnet\DataProtection-Keys\` (dependendiendo del Sistema Operativo) en archivos `.xml` y se genera un archivo nuevo con clave cada 90 días.
> Esta configuración se puede modificar

> Para configurar `IDataProtection` se hace uso de la implementación `IDataProtectionBuilder`, de la cual extienden métodos para ello.

> **Si no utilizamos Inyeccion de Dependencias**: Los métodos que veremos mas abajo se pueden configurar con la clase de Factoria `DataProtectionProvider` usando el método `Create` con sobrecarga de parametros para ello.

## Almacenando en Directorio personalizado
Para almacenar las claves en otro directorio debemos usar el método:

> En Windows, esta configurado un sistema de cifrado de claves en reposo. Si configuramos otra ubicación de dichas claves, estas no serán protegidas.

```Csharp
 services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"Nuevo\Path\Claves"))
```

## Almacenando en BBDD con Entity Framework Core
Podemos almacenar en cualquier base de datos relacional haciendo uso de `EntityFrameworkCore` para ello. Necesitaremos el paquete `Microsoft.AspNetCore.DataProtection.EntityFrameworkCore`
> En este ejemplo se usará la Base de Datos `SQL Server` de Microsoft

```Csharp
services.AddDataProtection()
    .PersistKeysToDbContext<ContextoBaseDatos>();
```

El Contexto tiene que implementar la interface `IDataProtectionKeyContext` que contiene una propiedad de tipo `DbSet<DataProtectionKey>` llamada `DataProtectionKeys` y es la que utilizará la libreria para recuperar y almacenar las claves.

> Para crear esta tabla podemos hacer uso de Migraciones o crearla a mano, el script seria el siguiente:
```SQL
CREATE TABLE [DataProtectionKeys] (
    [Id] int NOT NULL IDENTITY,
    [FriendlyName] nvarchar(max) NULL,
    [Xml] nvarchar(max) NULL,
    CONSTRAINT [PK_DataProtectionKeys] PRIMARY KEY ([Id])
);
```

## Almacenando en Base de Datos Redis
Para almacenar las claves en un servidor Redis necesitaremos instalar el paquete `Microsoft.AspNetCore.DataProtection.StackExchangeRedis`.

```Csharp
var redis = ConnectionMultiplexer.Connect("<URI>");
var key = "DataProtection-Keys";

 services.AddDataProtection()
    .PersistKeysToStackExchangeRedis(redis, key);
```

## Configuración Caducidad de Claves
Podemos indicar cada cuanto tiempo se debe generar una clave nueva para el cifrado.
> El tiempo mínimo que se puede establecer son 7 días
```Csharp
 services.AddDataProtection()
    .SetDefaultKeyLifetime(TimeSpan.FromDays(7))
```

## Configuración de Algoritmos
Podemos personalizar el Algoritmo de Cifrado que vamos a usar, por ejemplo, igual preferimos un cifrado de 128 o un validador de Hash `SHA512`:

```Csharp
 services.AddDataProtection()
    .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC, // default
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256   // default
    });
```

## Protección de Claves con Certificados
Para almacenar las claves en otro directorio debemos usar el método:

```Csharp
 services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"Nuevo\Path\Claves"))
```


# Implementar por Inyeccion de dependencias
Para poder hacer uso de este servicio con inyeccion de dependencias usaremos el método
```Csharp
builder.Services.AddDataProtection();
```

Una vez registrado, realizamos la inyeccion de dependencia en el contructor y creamos el "*protector*"
```Csharp
public class PutPersonalProfile
{
    private readonly IDataProtector _protector;

    public PutPersonalProfile(IDataProtectionProvider protectorProvider)
    {
        _protector = protectorProvider.CreateProtector("purpose");
    }
}
```

# Implementar en entornos no compatibles con DI
Para poder usar este servicio en un entorno no compatible con la inyeccion de dependencias necesitamos usar el paquete `Microsoft.AspNetCore.DataProtectorExtensions` para obtener el tipo `DataProtectionProvider`.

Para instanciar `DataProtectionProvider` necesitamos mandarle un objeto `DirectoryInfo` que debe de contener el path donde se ubican las claves criptograficas a usar.

```Csharp
var destFolder = Path.Combine(
    System.Environment.GetEnvironmentVariable("LOCALAPPDATA"),
    "myapp-keys");

IDataProtectionProvider provider = DataProtectionProvider.Create(new DirectoryInfo(destFolder));
IDataProtector protector = provider.CreateProtector("purpose");
```

# Proteger la información (IDataProtector)
Para crear el protector tenemos que mandarle un `purpose`, este parametro por convencion suele ser el namespace y el nombre de tipo del componente.

## Proteger
Una vez tenemos una instancia de `IDataProtector` debemos de realizar la funcion de cifrado.

```Csharp
_protector.Protect("Texto a encriptar");
```

## Desproteger
Cuando necesitamos descifrar debemos de hacer los mismos pasos y usar el metodo `Unprotect()`

```Csharp
_protector.Unprotect("Texto encriptado para volver al original");
```
