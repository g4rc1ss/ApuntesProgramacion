Hasta ahora, para convertir un objeto de un tipo a otro, habia que hacerlo de forma manual, mediante operadores implicitos o a traves de algunas librerias externas como `Automapper`

`Automapper` es una libreria bastante interesante que automatiza el proceso de conversion, pero tenia un problema, el performance.

Cuando usamos librerias que tienen mapeos automaticos, generalmente de forma interna utilizan reflection, un recurso que te permite acceder al assembly, leer los metadatos, acceder a propiedades de forma dinamica, crear codigo, etc. En tiempo de ejecución. Una libreria muy util para muchas cosas, pero el problema es que el rendimiento que ofrece.

Cuando necesitamos mapear objetos muy grandes o muchos objetos, estas librerias suelen afectar significativamente al rendimiento de la plataforma. Para esto esta `Mapperly`

Mapperly hace uso de `Source Generators`, que a diferencia de `Reflection`, en vez de crear y acceder a codigo en tiempo de ejecucion, lo hace en tiempo de compilación, por tanto, es como si creamos nosotros el mapeo a mano, pero sin hacerlo.

## Configurar Mapeo con Mapperly

```Csharp
[Mapper]
public partial class PuebloMapper
{
    [MapProperty(nameof(@PuebloEntity.Id), nameof(@PuebloEntityResponse.Id))]
    [MapProperty(nameof(@PuebloEntity.Name), nameof(@PuebloEntityResponse.Nombre))]
    [MapProperty(nameof(@PuebloEntity.Location), nameof(@PuebloEntityResponse.Ubicacion))]
    public partial PuebloEntityResponse ToPuebloEntityResponse(PuebloEntity puebloEntity);
}
```
- Cremoas una `partial class` y le agregamos el atributo `[Mapper]`
- Si en los tipos tenemos nombres diferentes para el mismo valor de datos, indicamos el atributo `MapProperty` pasandole como primer parametro el **From** y como segundo el **To**
- Creamos el `partial method`, que vamos a devolver un tipo(`PuebloEntityResponse`), el nombre del metodo y recibimos el tipo a mapear(`PuebloEntity`)

Cuando compilemos el codigo, se generara una clase con el mismo nombre que implementará el metodo que hemos declarado haciendo el mapeo

El codigo decompilado seria el siguiente:
```Csharp
[Mapper]
public class PuebloMapper
{
    [MapProperty("Id", "Id")]
    [MapProperty("Name", "Nombre")]
    [MapProperty("Location", "Ubicacion")]
    public PuebloEntityResponse ToPuebloEntityResponse(PuebloEntity puebloEntity)
    {
        PuebloEntityResponse puebloEntityResponse = new PuebloEntityResponse();
        puebloEntityResponse.Id = puebloEntity.Id;
        puebloEntityResponse.Nombre = puebloEntity.Name;
        puebloEntityResponse.Ubicacion = puebloEntity.Location;
        return puebloEntityResponse;
    }
}
```

## Implementar Mapperly

```Csharp
var mapper = new PuebloMapper();
var entidad = new PuebloEntity
{
    Id = 1,
    Location = "Algun sitio",
    Name = "bilbao",
};
var response = mapper.ToPuebloEntityResponse(entidad);
```
- Creamos la instancia del objeto de `PuebloMapper`
- Creamos el objeto que queremos mapear
- Ejecutamos el mapeo llamando al metodo, que estara implementado automaticamente por la libreria