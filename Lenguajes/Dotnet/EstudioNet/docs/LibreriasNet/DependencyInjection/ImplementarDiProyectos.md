# Implementar DI en proyectos
Para implementar solamente la Inyeccion de dependencias se podra usar el siguiente codigo.

1. Instanciamos una clase del tipo `ServiceCollection`
1. Agregamos las dependencias que necesitamos a la coleccion.
1. Compilamos la coleccion para poder hacer uso de esas dependencias y obtenemos el `ServiceProvider`
1. Ejecutamos el metodo `GetRequiredService()` para resolver la dependencia que necesitamos pasandole la interface
```Csharp
var services = new ServiceCollection();
services.AddTransient<IServicioInyectado, ServicioInyectado>();

var serviceProvider = services.BuildServiceProvider();

var servicio = serviceProvider.GetRequiredService<IServicioInyectado>();
await servicio.ExecuteAsync();
```

La inyeccion de dependencias se puede implementar en todos los tipos de proyectos actuales de .Net
