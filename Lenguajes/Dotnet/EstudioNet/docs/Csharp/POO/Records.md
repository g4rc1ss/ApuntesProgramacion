# Records
Los `records` son un tipo de referencia inmutable. Los records son una forma concisa de definir clases cuyo propósito principal es almacenar datos. Se diseñan para ser utilizados como contenedores de datos con características especiales que facilitan la creación de objetos inmutables y proporcionan métodos útiles de igualdad y desestructuración.

1. **Inmutabilidad**: Los records son inmutables, lo que significa que una vez creados, sus valores no pueden cambiarse. Esto se logra declarando sus propiedades como solo lectura.

2. **Igualdad estructural**: Los records tienen una semántica de igualdad basada en el contenido de sus propiedades, en lugar de en sus referencias. Esto significa que dos records se considerarán iguales si sus propiedades tienen los mismos valores.

3. **Desestructuración**: Los records permiten la desestructuración, lo que significa que se pueden descomponer en varias variables en una sola declaración. Esto simplifica el código y mejora la legibilidad.

4. **Sintaxis concisa**: Los records se definen usando una sintaxis compacta que facilita su creación y uso.


Para crear un record se puede utilizar la siguiente sintaxis
```csharp
public record Prueba(string param1, string param2, int param3);
```
De esta forma, crea en tiempo de compilación la clase inmutable con los parametros que hemos indicado

```csharp
public record Prueba
{
    public required string Param1 { get; init; }
    public string Param2 { get; init; }
    public int Param3 { get; init; }
}
```
La otra forma de crearla es la habitual, como las clases de datos

```csharp
Prueba pruebaRecord;
var pruebaRecord2 = new Prueba
{
    Param1 = "2",
    Param2 = "1",
    Param3 = 3
};
pruebaRecord = pruebaRecord2 with { param2 = "3", param3 = 2 };
Console.WriteLine(pruebaRecord);
```
Los records, al ser inmutables no permiten la modificación de los datos de las variables, por tanto, si queremos cambiarlos se puede hacer uso de la palabra clave `with`.

La palabra clave `with` es utilizada en los record para copiar el contenido del objeto de referencia a otro objeto nuevo(no copia la referencia, sino todo el contenido) y permite modificar los parametros, asignando los nuevos datos y dejando los que no hemos indicado iguales al objeto anterior.
