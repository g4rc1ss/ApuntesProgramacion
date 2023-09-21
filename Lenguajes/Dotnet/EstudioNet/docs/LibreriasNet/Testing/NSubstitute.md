# NSubstitute
Los test unitarios se encargan de testear los métodos o procesos de forma individual.

Eso significa que si nuestro programa requiere de dependencias externas, como una base de datos, no cumpliria ese requisito de Base de datos, puesto que estarias realizando un test de integración. Los test unitarios buscan analizar un algoritmo, validaciones, etc.

`Install-Package NSubstitute`

Si queremos mockear la siguiente interface.

```Csharp
public interface IRepositoryToMock
{
    Task GetRepositoryAsync(string name);
    Task<IEnumerable<string>> GetRepositoriesAsync();
}
```

```Csharp
_repositoryMock = Substitute.For<IRepositoryToMock>();

_repositoryMock.Add(1, 2).Returns(3);
Assert.That(_repositoryMock.Add(1, 2), Is.EqualTo(3));

```
Como podemos deducir, se va a moquear la implementacion de la interface de repositorio. Normalmente en nuestro negocio esta clase llamaria a una base de datos o una api, en este caso la vamos a simular devolviendo datos hardcodeados.

Si nuestros metodos a la hora de moquear reciben parametros, podemos hacer uso de `Arg.IsAny<T>` para indicar que tenemos que enviar un parametro de ese tipo. 

```Csharp
_repositoryMock.Add(10, -5);
_repositoryMock.Received().Add(10, Arg.Any<int>());
_repositoryMock.Received().Add(10, Arg.Is<int>(x => x < 0));
```

> Los metodos de extension **no pueden ser moqueados**, solo podemos moquear los metodos de la propia clase

Para poder hacer uso de esta simulación en nuestro test
```Csharp

```

1. 
