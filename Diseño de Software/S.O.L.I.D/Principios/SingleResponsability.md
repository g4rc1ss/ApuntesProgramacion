# Single Responsability Principle
Traduccion: **Principio de responsabilidad Unica**.

El autor de SOLID declara en este principio que *"Una clase debe tener solo una razón para cambiar"*.

Cuando escribimos codigo, uno de los objetivos principales es que este sea **facil de mantener y de leer**. Este principio lo que declara es que **una clase debe de hacer una cosa y hacerla bien**.

Cuando tenemos clases que realizan más de una tarea acaban acoplándose unas con otras cuando no deberían estar juntos haciendo esa clase mucho más difícil de usar y entender, comprender y por supuesto mantener.

Un ejemplo rápido de que el principio de responsabilidad única funciona es unix ya que unix originalmente era un sistema de línea de comandos donde cada comando es un pequeño script y este hace lo que se le pide correctamente. 

## Usandolo de forma erronea
```Csharp
public void GuardarArticulo(string contenido, string titulo)
{
    Log.Information($"vamos a insertar el articulo {titulo}");
    File.WriteAllText($"{path}/{titulo}.txt", contenido);
    Log.Information($"articulo {titulo} insertado");
    this.Cache.Add(titulo, contenido);
}

public string ConsultarArticulo(string titulo)
{
    Log.Information($"Consultar artículo {titulo}");

    string contenido = this.Cache.Get(titulo);
    if (!string.IsNullOrWhiteSpace(contenido))
    {
        Log.Information($"Artículo encontrado en la cache {titulo}");
        return contenido;
    }

    Log.Information($"buscar articulo en el sistema de archivos {titulo}");
    contenido = File.ReadAllText($"{path}/{titulo}.txt");

    return contenido;
}
```

En estos dos métodos debemos Identificar qué factores o que código nos llevarían a tener que modificar la clase y podemos encontrar los siguientes: 
- Realizamos múltiples logs.
- Almacenamos el artículo, en este caso en el sistema de archivos.
- El sistema de cache. 

Como vemos disponemos de 3 puntos.
- Por ejemplo podríamos cambiar los logs, de serolog a log4net o a otro personalizado por nosotros.
- Podríamos querer almacenar los artículos en una base de datos en vez de en el sistema de ficheros.
- Si queremos cambiar el sistema de cache. 
Por estos motivos el principio de responsabilidad única no se estaría cumpliendo, ya que si cambiamos el sistema de log, deberemos cambiar una clase que lee artículos, lo cual no es correcto. 

## Usandolo correctamente
Creamos una clase que se encargará exclusivamente del registro de logs
```Csharp
public class Logging
{
    public void Info(string message)
    {
        Log.Information(message);
    }
    public void Error(string message, Exception e)
    {
        Log.Error(e, message);
    }
    public void Fatal(string message, Exception e)
    {
        Log.Fatal(e, message);
    }
}
```

Creamos una clase que se encargará exclusivamente del almacenamiento en `cache`
```Csharp
public class Cache
{
    private Dictionary<string, string> CacheDicctionary;
    public Cache()
    {
        CacheDicctionary = new Dictionary<string, string>();
    }

    public void Add(string titulo, string contenido)
    {
        if(!CacheDicctionary.TryAdd(titulo, contenido))
        {
            CacheDicctionary[titulo] = contenido;
        }
    }

    public string Get(string titulo)
    {
        CacheDicctionary.TryGetValue(titulo, out string contenido);
        return contenido;
    }

}
```

Creamos una clase que se encarga del almacenamiento.
```Csharp
public class Almacenamiento
{
    string path="C:/temp";
    public void EscribirFichero(string titulo, string contenido)
    {
        File.WriteAllText($"{path}/{titulo}.txt", contenido);
    }

    public string LeerFichero(string titulo)
    {
        return File.ReadAllText($"{path}/{titulo}.txt");
    }
}
```

De esta forma lo que se consigue es que si en un momento dado necesitamos modificar la forma de almacenamiento, registro o cache, por ejemplo, cambiando la librería o clase que se encarga de ello, podremos hacerlo sin afectar a todo el codigo porque cada clase tiene su "tarea" asignada.