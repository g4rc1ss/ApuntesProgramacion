using System;

namespace Garciss.EnumExtensions;

/// <summary>
/// Para evitar tener un array de claves o constantes asociado a una enumeración,
/// se puede optar por asignar un atributo a cada elemento de la enumeración, de
/// forma que toda la información se encuentra en un único lugar
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public sealed class EnumDescriptionAttribute : Attribute
{
    /// <summary>
    /// Texto que se asocia como clave a un elemento de la enumeración
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// Constructor del atributo
    /// </summary>
    /// <param name="text"></param>
    public EnumDescriptionAttribute(string text)
    {
        Text = text;
    }
}
