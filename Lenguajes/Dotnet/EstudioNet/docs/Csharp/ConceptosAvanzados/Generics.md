# Generics
Los genéricos introducen en .NET el concepto de parámetros de tipo, lo que le permite diseñar clases y métodos que aplazan la especificación de uno o varios tipos hasta que el código de cliente declare y cree una instancia de la clase o el método.

Para que usar los genéricos?
- Use tipos genéricos para maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- El uso más común de los genéricos es crear clases de colección.
- Puede crear sus propias interfaces, clases, métodos, eventos y delegados genéricos.
- Puede limitar las clases genéricas para habilitar el acceso a métodos en tipos de datos determinados.
- Puede obtener información sobre los tipos que se usan en un tipo de datos genérico en tiempo de ejecución mediante la reflexión

```Csharp
class ClaseGenerica<T> where T : class, IEnumerable, new()
{
    public void Add(T input)
    {
    }
}
```

## Constraints
Los constraints son condiciones que deben de cumplir el parametro que se le pasa al generic para que funcione.

| Constraint | Descripción |
| ---------- | ----------- |
| class | El argumento de tipo debe ser cualquier clase, interfaz, delegado o tipo de matriz. |
| class? |	El argumento de tipo debe ser una clase, interfaz, delegado o tipo de matriz que acepte valores NULL o que no acepte valores NULL. |
| struct | El argumento de tipo debe ser tipos de valor que no aceptan valores NULL, como los tipos de datos primitivos int, char, bool, float, etc.
| new() |	El argumento de tipo debe ser un tipo de referencia que tenga un constructor público sin parámetros. No se puede combinar con restricciones. `struct unmanaged`
| notnull |	Disponible en C# 8.0 en adelante. El argumento de tipo puede ser tipos de referencia que no aceptan valores NULL o tipos de valor. Si no es así, el compilador genera una advertencia en lugar de un error.
| unmanaged | El argumento de tipo debe ser tipos no permitidos queno aceptan valores NULL.
| baseClassName | El argumento de tipo debe ser o derivar de la clase base especificada. Las clases Object, Array, ValueType no se pueden como restricción de clase base. Enum, Delegate, MulticastDelegate no se admiten como restricción de clase base antes de C# 7.3.
| baseClassName? | El argumento de tipo debe ser o derivar de la clase base especificada que acepta valores NULL o que no acepta valores NULL.
| interfaceName | El argumento de tipo debe ser o implementar la interfaz especificada.
| interfaceName? | El argumento de tipo debe ser o implementar la interfaz especificada. Puede ser un tipo de referencia que acepta valores NULL, un tipo de referencia que no acepta valores NULL o un tipo de valor.
| where T: U | El argumento de tipo proporcionado para `T` debe ser o derivar del argumento proporcionado para `U`.

