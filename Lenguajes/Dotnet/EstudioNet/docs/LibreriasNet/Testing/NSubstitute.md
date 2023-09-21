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
_repositoryToMock.GetRepositoryAsync(Arg.Any<string>()).Returns(Task.CompletedTask);
_repositoryToMock.GetRepositoriesAsync().Returns(Enumerable.Range(0, 1000).Select(x => $"{x}"));

Assert.True(repositories.Count() == 1000);
```
Como podemos deducir, se va a moquear la implementacion de la interface de repositorio. Normalmente en nuestro negocio esta clase llamaria a una base de datos o una api, en este caso la vamos a simular devolviendo datos hardcodeados.

Si nuestros metodos a la hora de moquear reciben parametros, podemos hacer uso de `Arg.IsAny<T>` para indicar que tenemos que enviar un parametro de ese tipo.
