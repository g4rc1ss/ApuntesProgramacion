La implementacion del *Options Pattern* nos aporta poder encapsular y separar la lógica de la configuracion de la aplicacion del resto de componentes.

Para poder hacer uso de este servicio, necesitaremos instalar `Microsoft.Extensions.Options`.

Para implementar el patron Options tenemos que agregarlo con el objeto `IConfiguration` en la inyeccion de dependencias.

Llamamos al metodo `Configure` pasandole una clase sobre la que mapeara la configuracion contenida en la section indicada.
```Csharp
builder.services.Configure<T>(Configuration.GetSection("seccion"));
```

**Los beneficios que nos aporta este patron son:**
1. Utilizarlo, nos fuerza a tener nuestra configuración **fuertemente tipada** y así, evitar errores.
1. Cuando revisamos código, o simplemente lo leemos después de un tiempo, es mucho más sencillo de entender si nuestro tipo de configuración se llama `IOptions<T>`, así sabemos de dónde viene.

Si, por ejemplo, necesitamos hacer uso de validaciones o algun proceso de verificación de datos podemos usar el metodo `PostConfiguration` despues de usar el metodo `Configure<T>`.

```Csharp
builder.services.Configure<T>(Configuration.GetSection("seccion"));
builder.services.PostConfigure<T>(configuration =>
{
    if ( string.IsNullOrWhiteSpace(configuration.property))
    {
        throw new ApplicationException("");
    }
});
```

# Cuando usar los patrones
La elección entre las diferentes interfaces del patrón `IOptions` dependerá de tu caso de uso, puesto que estos varían segun sus tiempos de vida.

- `IOptions` si no vas a cambiar la configuración.
- `IOptionsSnapshot` si vas a cambiar la configuración.
- `IOptionsMonitor` si necesitas cambiar la configuración constantemente o detectas que ese cambio puede pasar en el medio de un proceso.

## IOptions
Con esta opcion, nuestra configuracio se crea en el contenedor de dependencias como singleton, por lo que si la modificamos, no se podra visualizar dicho cambio.

## IOptionsSnapshot
Si implementamos esta interfaz, se creara una instancia del objeto correspondiente una vez por Request(**scoped**) la cual va a ser inmutable.

La ventaja principal es que nos permite cambiar el valor de la configuracion en tiempo de ejecución, de esta forma, no hará falta hacer un despliegue para ello.

![image](https://user-images.githubusercontent.com/28193994/147843223-464ee4fe-16a2-40e0-9e4d-a58a81640a94.png)

## IOptionsMonitor
`IOptionsMonitor<T>` se inyecta en nuestro servicio como `Singleton` y funciona de una manera especial, ya que en vez de acceder a .Value para acceder a T como hacíamos anteriormente, ahora realizamos `.CurrentValue` el cual nos devuelve el valor en el momento.

Esto quiere decir que si cambias el valor a mitad de la request o mitad de un proceso, este obtendrá el valor actualizado:

![image](https://user-images.githubusercontent.com/28193994/147843227-51c7f8c0-55cf-4897-a434-da23cf136f40.png)

