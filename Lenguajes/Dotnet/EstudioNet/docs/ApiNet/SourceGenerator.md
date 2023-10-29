# Source Generators
Los source generators son una utilidad muy buena, puesto que permite utilizar el concepto de `reflection` en tiempo de compilación, eso significa que los metodos, los tipos o la generacion de codigo se realiza de forma estatica a la hora compilar y no de forma dinamica a la hora de ejecutar

Esto proporciona utlidad sobretodo a nivel de rendimiento, puesto que el uso de reflexion, al ser en tiempo de ejecución, consume muchos recursos

Un uso muy bueno de esto es, por ejemplo, automappers como `Mapperly`, que genera mapeos en tiempo de compilación, al final el efecto es como si escribiesemos nosotros dicho mapeo a mano, pero lo hace una libreria de forma automatizada.

![alt]()

## Uso de Source Generators

Creamos la clase donde vamos a implementar el codigo que despues necesitaremos modificar o crear con el Source Geneartor

En este caso vamos a crear un mapper sencillo, el cual creamos la `partial class UsuarioMapper` con un partial method
```Csharp
namespace MyApp
{
    class Program
    {
        static void Main()
        {
            var usuario = new Usuario();
            usuario.Nombre = "Lark";
            usuario.Edad = 14;

            var usuarioMapper = new UsuarioMapper();
            var usuarioDTO = usuarioMapper.ToUsuarioDTO(usuario);

            Console.WriteLine(usuarioDTO.Nombre);
            Console.WriteLine(usuarioDTO.Edad);
        }
    }

    public class Usuario{
        public string Nombre{get;set;}
        public int Edad{get;set;}
    }

    public class UsuarioDTO{
        public string Nombre{get;set;}
        public int Edad{get;set;}
    }

    public partial class UsuarioMapper{
        public partial UsuarioDTO ToUsuarioDTO(Usuario user);
    }
}
```

Para la clase generadora implementamos la interfaz `ISourceGenerator` y el tag `[Generator]` en la clase donde vamos a implementar el código.
```Csharp
namespace SourceGeneratorSamples
{
    [Generator]
    public class UserMapperGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            StringBuilder sourceBuilder = new StringBuilder(@"
using System;
namespace MyApp
{
    public partial class UsuarioMapper{
        public partial UsuarioDTO ToUsuarioDTO(Usuario user){
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.Nombre = user.Nombre;
            usuarioDTO.Edad = user.Edad;
            return usuarioDTO;
        }
    }
}");
            context.AddSource("mapper", sourceBuilder.ToString());
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required
        }
    }
}
```
El resultado es que a la hora de compilar el código se genera la implementacion que hemos desarrollado.
```Csharp
namespace MyApp
{
    public partial class UsuarioMapper
    {
        public partial UsuarioDTO ToUsuarioDTO(Usuario user)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.Nombre = user.Nombre;
            usuarioDTO.Edad = user.Edad;
            return usuarioDTO;
        }
    }
}
```

> - Para las pruebas he utilizado un compilador online, [Source Generators Playground](https://wengier.com/SourceGeneratorPlayground)
> - Para ver una lista con documentación y proyectos que hacen uso de `Source Generators` existe el siguiente [repositorio](https://github.com/amis92/csharp-source-generators/blob/main/README.md)
