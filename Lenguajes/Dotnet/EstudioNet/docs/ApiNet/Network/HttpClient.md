# HttpClient
`HttpClient` es una clase que proporciona .Net para hacer llamadas a traves del protocolo `http`.

Cuando realizamos un **Request** y recibimos una **Response**, este, nos indicará un `HttpStatusCode` el cual es muy util para saber si el resultado esta correctamente.

Para ver los codigos de estado, podemos acceder [aqui](https://es.wikipedia.org/wiki/Anexo:C%C3%B3digos_de_estado_HTTP)

>**Importante**  
Hacer uso de `HttpClient` dentro de un bloque `using` puede ocasionar problemas porque cuando se invoca el metodo `Dispose` no se cierra la conexion directamente, sino que el servidor suele dejarla como en *espera* durante un tiempo, por tanto, los sockets se pueden ir ocupando y llegar un punto en el cual no haya sockets disponibles en la aplicacion para funcionar. 

En el siguiente ejemplo hacemos un bucle de 10 conexiones con el using y ejecutamos un comando `netstat` en el servidor para comprobar las conexiones establecidas y si nos fijamos, las conexiones no se cierran.
```Csharp
for(int i = 0; i < 10; i++)
{
    using var client = new HttpClient();
    var result = await client.GetAsync("url a consultar");
    Console.WriteLine(result.StatusCode);
}
```
![image](https://user-images.githubusercontent.com/28193994/147914625-ec00502a-a8ca-4216-88c0-e183e87fd3d5.png)

El protocolo TCP/IP funciona de la siguiente manera.

![image](https://user-images.githubusercontent.com/28193994/147914590-f0ea6873-5148-4f4e-8059-5e6104cd2e01.png)

Una solucion, sobretodo para Dependency Injection, es usar la clase `DefaultHttpClientFactory` que hay nas abajo explicada.

## Configurar Headers
Para crear, eliminar y modificar los headers de una solicitud Http, en el objeto de `HttpClient` debemos acceder a la propiedad `DefaultRequestHeaders` la cual contendra toda la informacion sobre las diferentes cabeceras que se pueden tratar.

```Csharp
httpClient.DefaultRequestHeaders.Accept.Clear();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", autenticationToken);
```

## **GET**
Formas de consultar datos por **GET** a un API

Cabe decir que las solicitudes `GET` se envian los datos de consulta a traves de `QueryString` y se puede configurar de la siguiente forma.

```Csharp
var url = new UriBuilder(urlBase);
var parametersQueryString = HttpUtility.ParseQueryString(url.Query);
parametersQueryString.Add(parametro.Key, parametro.Value?.ToString());

url.Query = parametersQueryString.ToString();
url.ToString();
```

### GetStringAsync
```Csharp
httpClient.GetStringAsync(urlFinal);
```

### GetFromJsonAsync
```Csharp
httpClient.GetFromJsonAsync<ClaseDeserializar>(urlFinal);
```

## **POST**
Metodos para envio de datos por **POST** a un API.

### PostAsync
```Csharp
var content = new StringContent("string con el contenido", UTF8Encoding.UTF8, "application/json");
httpClient.PostAsync($"url", content);
```

### PostAsJsonAsync
```Csharp
httpClient.PostAsJsonAsync<TipoSerializar>("url", objetoToSerializar); 
```

## **PUT**
Metodos de enviar datos para actualizar por **PUT** en un API

### PutAsync
```Csharp
var content = new StringContent("string con el contenido", UTF8Encoding.UTF8, "application/json");
httpClient.PutAsync($"url", content);
```

### PustAsJsonAsync
```Csharp
httpClient.PutAsJsonAsync<TipoSerializar>("url", objetoToSerializar); 
```

## **DELETE**
Metodos solicitar el borrado de algun dato por **DELETE** a un API

### DeleteAsync
```Csharp
httpClient.DeleteAsync($"url");
```

## HttpClient con Dependency Injection
Podemos configurar parametros en el objeto HttpClient para inyectarlo como dependencia y centrarnos solamente en realizar la peticion que necesitamos.

> **Importante**  
Este metodo no es recomendable usarlo por el problema de los sockets comentado anteriormente.

```Csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44326/api/") });
```

## HttpClientFactory
La implementación actual de `IHttpClientFactory` implementa `IHttpMessageHandlerFactory` y proporciona las siguientes ventajas.

- Proporciona una ubicación central para denominar y configurar instancias de HttpClient.
- HttpClient ya posee el concepto de controladores de delegación, que se pueden vincular entre sí para las solicitudes HTTP salientes.
- Administrar la duración de `HttpMessageHandler` para evitar los problemas mencionados y los que se pueden producir al administrar las duraciones de HttpClient.

> Las instancias de `HttpClient` creadas a traves de `IHttpClientFactory` pueden ser `Disposed` sin problema, puesto que el método `CreateClient` envia un parametro a `false` para que no se ejecute la eliminación completa del objeto y poder reutlizarlo mas adelante en el pool.

![image](https://user-images.githubusercontent.com/28193994/147922775-8ca43a43-bdab-409c-914f-a435bb7ae356.png)

1. Registramos la dependencia con un identificador, que usaremos para reultilizar las instancias
1. Importamos la dependencia y creamos el cliente en base al identificador.
```Csharp
services.AddHttpClient("Nombre identificador", httpClient =>
{
    httpClient.BaseAddress = new Uri("url");
});

private readonly IHttpClientFactory _httpClientFactory;
public DispensacionConsultaNegocio(IHttpClientFactory httpClientFactory)
{
    _httpClientFactory = httpClientFactory;
}

public void MethodHttpClientExecute()
{
    using var httpClient = _httpClientFactory.CreateClient("Nombre identificador");
}
```

## Crear Handler en HttpClient
Para crear un handler por el cual se pasará a la hora de realizar una peticion http puede ser interesante para configurar acciones antes de enviar la request o cuando la recibimos.

Para indicar en `HttpClient` que queremos hacer uso de dicho Handler hay 2 formas.

### Sin inyeccion de dependencias
A la hora de instancia la clase `HttpClient` pasamos por constructor una instancia del handler a usar.

```csharp
var handler = new HandlerHttpPersonalizado();
var httpClient = new HttpClient(handler);
```

### Con Inyeccion de dependencias
Si usamos `IHttpClientFactory`, en la configuracion del cliente, despues de usar el metodo `AddHttpClient` debemos de realizar lo siguiente:

```csharp
services.AddTransient<HttpMessageConfigHandler>();

services.AddHttpClient()
    .AddHttpMessageHandler<HttpMessageConfigHandler>();
```
> Lo positivo de hacer inyeccion de dependencias, es que podemos hacer uso de ello dentro de la clase `handler`, por ejemplo, para inyectar un `ILogger<>`.
