# Dependency Inversion Principle
Traduccion: **Principio de inversion de dependencias**

- *Los módulos de alto nivel no deberían depender de los de bajo nivel. Ambos deberían depender de abstracciones.*
- *Las abstracciones no deberían depender de los detalles. Son los detalles los que deberían depender de abstracciones*

Este principio indica que debemos de invertir en el uso de dependencias para tener una capacidad mas elevada de abstraccion en nuestro codigo.

Por ejemplo, para la creacion de una arquitectura desacoplada, se hace uso de este principio en el cual las diferentes clases de la aplicacion lo que reciben son los objetos en forma de interfaz, de esta forma, se podria modificar el comportamiento de la aplicacion alterando la dependencia que se envia.

## Ejemplo de Inversion de Dependencias.
- Tenemos la clase `UserManager` que implementa la la interfaz `IUserManager` para poder ser usada como dependencia
- Recibimos por constructor una dependencias del tipo `IClaseSimuloBaseDeDatos`
```Csharp
public class UserManager : IUserManager
{
    private readonly IClaseSimuloBaseDeDatos _claseSimuloBaseDeDatos;

    public UserManager(IClaseSimuloBaseDeDatos claseSimuloBaseDeDatos)
    {
        _claseSimuloBaseDeDatos = claseSimuloBaseDeDatos;
    }

    public Task<List<UserDto>> GetUsersList()
    {
        return _claseSimuloBaseDeDatos.UserList();
    }
}
```
En el codigo necesitamos obtener una lista de usuarios, pero no necesitamos saber que clase se va a encargar ni el proceso de ello. Gracias al uso de la inversion de dependencias.
1. Obtenemos la dependencia a traves de una factoria
1. Llamamos al metodo que implementa esa dependencia.
```Csharp
var dependenciaDb = DependencyDbFactory.GetSimulacionBaseDatos();
var usuarios = DependencyApplicationFactory.GetUserManager(dependenciaDb);

var listaUsuarios = await usuarios.GetUsersList();
```

Las factorias de las dependencias son las siguientes.
```Csharp
public static IUserManager GetUserManager(IClaseSimuloBaseDeDatos claseSimulacion)
{
    return new UserManager(claseSimulacion);
}
```

```Csharp
public static IClaseSimuloBaseDeDatos GetSimulacionBaseDatos()
{
    return new ClaseSimuloBaseDeDatos();
}
```

Agregar inversión de dependencias nos proporciona flexibilidad y estabilidad a la hora de desarrollar. Ya que estaremos más seguros a la hora de ampliar funcionalidades, etc.

Como última gran ventaja, utilizar inversión de dependencias nos permite la creación de test unitarios  con mucha más facilidad, permitiéndonos crear mock de las mismas. 

---
**Importante**: No confundir este principio con la *Inyeccion de dependencias*.

El uso de la inyeccion de dependencias esta basado en el uso de este principio y fomenta su uso, pero no por hacer uso de la inyeccion estamos haciendo uso de la Inversion.

> La inyeccion de dependencias no exige que se deban implementar interfaces o clases abstractas.