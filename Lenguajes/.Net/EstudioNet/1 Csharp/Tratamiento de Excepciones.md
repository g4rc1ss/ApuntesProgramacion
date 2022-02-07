# Tratamiento de Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

## Capurando las excepciones
```Csharp
try
{
    // Ejecucion del codigo que puede llegar a tener una excepcion
}
catch (Exception ex)
{
    // Se ha producido la excepcion y se obtiene un objeto de tipo Exception
    // Este objeto contiene unos valores para rastrear el motivo del error
}
finally
{
    // Esta es una parte del codigo que se ejecuta siempre aunque se produzca la excepcion
    // Y generalmente se usa para cerrar recursos, por ejemplo, abres una conexion con
    // la base de datos y a la hora de recibir los datos se produce la excepcion,
    // pues pasara por aqui para cerrar la conexion con la base de datos.
}
```

## Provocando una excepcion
```Csharp
public static void Main(string[] args)
{
    throw new ArgumentNullException($"El parametro {nameof(args)} es nulo");
}
```

## Creando excepciones propias
```Csharp
class MyException : Exception
{
    public MyException() : base()
    {
    }

    public MyException(string message) : base(message)
    {
    }

    public MyException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
```

