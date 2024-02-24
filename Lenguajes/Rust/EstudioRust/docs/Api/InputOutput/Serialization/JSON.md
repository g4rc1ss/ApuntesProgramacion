# Serializacion JSON
Actualmente se ha convertido en un estándar ampliamente utilizado para el intercambio de información entre sistemas.

## Json con Stream
Lee un objeto stream y lo convierte a texto con formato JSON

```Csharp
await JsonSerializer.SerializeAsync(stream, objectToSerialize);
```

Lee un JSON obtenido por un objeto Stream y lo devuelve en una instancia del tipo indicado.
```Csharp
await JsonSerializer.DeserializeAsync<T>(stream);
```

## Json con objetos
Convierte un objeto a un texto en formato JSON

```Csharp
var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
var serializado = JsonSerializer.Serialize(serializacion);
```

Lee un texto en formato JSON y devuelve una instancia del tipo indicado.
```Csharp
const string JSON = @"{""Nombre"":""Nombre"",""Apellidos"":""Apellido""}";
var deserializado = JsonSerializer.Deserialize<ClaseSerializacion>(JSON);
```
