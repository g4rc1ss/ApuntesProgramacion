using System;

namespace CleanArchitecture.Infraestructure.InfraestructureHelper;

public static class DbExtensions
{
    /// <summary>
    /// Esta funcion requiere que el siguiente codigo este en el OnModelCreating del contexto a utilizar
    ///     modelBuilder.HasDbFunction(() => DbExtensions.JsonValue(string.Empty, string.Empty))
    ///     .HasTranslation(args => SqlFunctionExpression.Create("JSON_VALUE", args, typeof(string), null));
    /// </summary>
    /// <param name="source"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string JsonValue(string source, string path)
    {
        throw new NotImplementedException();
    }
}
