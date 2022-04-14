Es importante mantener la informacion sensible protegida, por si se diera el caso de una filtracion de datos o similares, es fundamental tener dichos datos encriptados.

Microsoft provee de una implementacion que se llama `IDataProtectionProvider`.

Este sistema de cifrado usa unas claves ubicadas en `%LOCALAPPDATA%\ASP.NET\DataProtection-Keys` generadas por el propio programa. [Mas info](https://docs.microsoft.com/es-es/aspnet/core/security/data-protection/configuration/default-settings?view=aspnetcore-6.0)

El algoritmo utiliza las claves ubicadas fisicamente con un `purpose` que tendremos que pasar para proteger y desproteger. El motivo de esto es que si, por ejemplo, tenemos un elemento protegido con el `purpose` *"identificador 1"* y tratamos de desprotegerlo con una instancia de `purpose` *"identificador 2"*, no deberia de ser capaz de realizar la accion.

Los `purpose` no estan pensados para estar en `vaults` ni nada por el estilo, se pueden hardcodear sin problema.

# Implementar por Inyeccion de dependencias
Para poder hacer uso de este servicio, necesitamos implementar en la inyeccion de dependencias el servicio:
```Csharp
builder.Services.AddDataProtection();
```

Una vez registrado, realizamos la inyeccion de dependencia en el contructor y creamos el "*protector*"

# Implementar en entornos no compatibles con DI
Para poder usar este servicio en un entorno no compatible con la inyeccion de dependencias necesitamos usar el paquete `Microsoft.AspNetCore.DataProtectorExtensions` para obtener el tipo `DataProtectionProvider`.

Para instanciar `DataProtectionProvider` necesitamos mandarle un objeto `DirectoryInfo` que debe de contener el path donde se ubican las claves criptograficas a usar.

```Csharp
// Get the path to %LOCALAPPDATA%\myapp-keys
var destFolder = Path.Combine(
    System.Environment.GetEnvironmentVariable("LOCALAPPDATA"),
    "myapp-keys");

DataProtectionProvider.Create(new DirectoryInfo(destFolder));
```

# Proteger la información
Para crear el protector tenemos que mandarle un `purpose`, este parametro por convencion suele ser el namespace y el nombre de tipo del componente.
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

## Proteger
Una vez tenemos una instancia de `IDataProtector` debemos de realizar la funcion de cifrado.

```Csharp
_protector.Protect(profileDto.Email);
```

## Desproteger
Cuando necesitamos descifrar debemos de hacer los mismos pasos y usar el metodo `Unprotect()`

```Csharp
_protector.Unprotect(values.personalProfile.Email)
```
