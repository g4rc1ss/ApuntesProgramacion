# Moq
Los test unitarios se encargan de testear los métodos o procesos de forma individual.

Eso significa que si nuestro programa requiere de dependencias externas, como una base de datos, no cumpliria ese requisito de Base de datos, puesto que estarias realizando un test de integración. Los test unitarios buscan analizar un algoritmo, validaciones, etc.

Para poder simular esas llamadas podemo hacer uso de la libreria `Moq`

`Install-Package Moq`

Para crear un mock, debemos de crear una clase descriptiva que indique que se va a moquear.

```Csharp
internal class WeatherForecastRepositoryMock
{
    public Mock<IWeatherForecastRepository> MockingWeatherForecastRepository { get; set; }

    public WeatherForecastRepositoryMock()
    {
        MockingWeatherForecastRepository = new Mock<IWeatherForecastRepository>();
        Initialize();
    }

    private void Initialize()
    {
        MockingWeatherForecastRepository.Setup(x => x.GetWeatherForecastAsync()).ReturnsAsync(FakeDataGenerator.GetFakeWeather);
    }
}
```
Como podemos deducir, se va a moquear una interface que nos va a devolver un pronostico del tiempo. Normalmente en nuestro negocio esta clase llamaria a una base de datos o una api, en este caso la vamos a simular devolviendo datos hardcodeados.

- **MockingWeatherForecastRepository**: Esta propiedad es la que usaremos para obtener la dependencia.
- **MockingWeatherForecastRepository()**: Instanciamos la propiedad e inicializamos sus metodos en el constructor.
- **Initialize()**: Este metodo se encarga de indicar el metodo que queremos moquear y cual es el resultado que debemos devolver, en este caso es un resultado `async` con los datos ubicacados en una clase estatica de `Fakes`

Si nuestros metodos a la hora de moquear reciben parametros, podemos hacer uso de `It.IsAny<Tipo>` para indicar que tenemos que enviar un parametro de ese tipo. 

```Csharp
MockingDataProtectionProvider.Setup(x => x.CreateProtector(It.IsAny<string>())).Returns(new DataProtectionMock().MockingDataProtector.Object);
```

> Los metodos de extension **no pueden ser moqueados**, solo podemos moquear los metodos de la propia clase

Para poder hacer uso de esta simulación en nuestro test
```Csharp
public async Task GetWeatherForecast_Then_ResponseWithOneOrMoreResults()
{
    var weatherService = new WeatherForecastRepositoryMock().MockingWeatherForecastRepository.Object;

    var response = await weatherService.GetWeatherForecastAsync();
}
```

1. Creamos una instancia de la clase moqueada y accedemos a la propiedad que hemos incializado en el constructor y obtenemos el objeto `Object` que nos devolvera una instancia de la interface que hemos moqueado.

1. Ejecutamos el metodo que hemos moqueado, de esta manera obtendremos los datos hardcodeados y despues podremos realizar las diferentes comprobaciones.
