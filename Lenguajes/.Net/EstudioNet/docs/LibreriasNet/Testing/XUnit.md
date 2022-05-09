# xUnit

xUnit.net es una herramienta gratuita para la creacion y ejecucion de test, tanto unitarios, como de integración.

Para poder usar xUnit, creamos un proyecto nuevo en Visual Studio de test `xUnit` y se nos creará una template con una clase.

Si accedemos a la clase creada, veremos algo como lo siguiente:
```Csharp
using Xunit;

namespace UnitTests
{
    public class Class1
    {
        [Fact]
        public void MethodTest()
        {
        }
    }
}
```

## Fact
El atributo `[Fact]` indica al ejecutor de test los metodos que tiene que correr.


## Theory
```Csharp
[Theory]
[InlineData(object)]
public void MethodTest(int value)
{

}
```
Para poder reutilizar test con diferentes objetos o parametros de pruebas, podemos usar el atributo `[Theory]` junto a `[InlineData(object)]`.

En `InlineData` le pasamos un objeto que creamos y se inyectara en el parametro del metodo de testing. Este test se ejecutará tantas veces como atributos `InlineData` existan, de esta manera en el mismo test podemos probar varios casos de uso.


## Fixture
Existen muchos casos en los que necesitamos inicializar una serie de datos y de configuraciones antes de la ejecucion de los test. Para ello podemos hacer uso de los `Fixture`.

Para poder crear un `Fixture` tenemos que crear una clase que incluya el atributo `CollectionDefinition("Indicador de la collection")`.

```Csharp
[CollectionDefinition("Test")]
public class TestFixtureCollection : ICollectionFixture<TestServerFixture> { }
```
- **CollectionDefinition**: Indidicamos a xUnit, que todas las clases de test que implementen el atributo `[Collection("Test")]` se inicializaran con la configuracion y pasos iniciales marcados en `TestServerFixture`
- **ICollectionFixture**: Esta implementacion permite que la clase definida de `TestServerFixture` solamente se ejecute una vez y se reulize en todas las clases de test que la utilicen
    > Si queremos que se inicialice por cada clase de testing, usaremos `IClassFixture<TestServerFixture>`
- **TestServerFixture**: Esta clase la crearemos en el codigo y realizaremos toda la inicializacion de la clase en el contructor, por ejemplo, la configuracion de un inyector de dependencias.

Para poder hacer uso de la `Fixture`.
```Csharp
[Collection("Test")]
public class ClassTesting
{
    private readonly TestServerFixture _fixture;

    public ClassTesting(TestServerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task MethodTest()
    {
        
    }
}
```
xUnit ya sabe que en esta clase se requiere el `TestServerFixture` por el atributo de clase, inicializa ese objeto y lo inyectara al constructor como una dependencia y ya podremos usarlo para el resto de test.
