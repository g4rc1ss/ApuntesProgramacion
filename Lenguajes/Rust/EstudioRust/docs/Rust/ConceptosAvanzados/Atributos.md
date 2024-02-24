# Atributos
Los atributos proporcionan un método eficaz para asociar metadatos, o información declarativa, con código (ensamblados, tipos, métodos, propiedades, etc.). Después de asociar un atributo con una entidad de programa, se puede consultar el atributo en tiempo de ejecución mediante la utilización de una técnica denominada reflexión.

Los atributos tienen las propiedades siguientes:
- Los atributos agregan metadatos al programa. Los metadatos son información sobre los tipos definidos en un programa.
- Puedes aplicar uno o más atributos a todos los ensamblados, módulos o elementos de programa más pequeños como clases y propiedades.
- Los atributos pueden aceptar argumentos de la misma manera que los métodos y las propiedades.
- El programa puede examinar sus propios metadatos o los metadatos de otros programas mediante la reflexión.

```Csharp
internal class AtributoPersonalizado : Attribute
{
    public string Text { get; set; }

    public AtributoPersonalizado(string text)
    {
        Text = text;
    }
}

public enum Enumerador
{
    [AtributoPersonalizado("Hola")]
    one
}
```
