namespace Builder.Query.Extensions;

internal static class ExtensionsMethod
{
    internal static IPatronBuilder Select(this IPatronBuilder patron, string select)
    {
        var patronBuilder = patron as PatronBuilder;
        patronBuilder.Select = select;
        return patronBuilder;
    }

    internal static IPatronBuilder Where(this IPatronBuilder patron, string where)
    {
        var patronBuilder = patron as PatronBuilder;
        patronBuilder.Where = where;
        return patronBuilder;
    }

    internal static IPatronBuilder From(this IPatronBuilder patron, string from)
    {
        var patronBuilder = patron as PatronBuilder;
        patronBuilder.From = from;
        return patronBuilder;
    }

    internal static IPatronBuilder OrderBy(this IPatronBuilder patron, string orderBy)
    {
        var patronBuilder = patron as PatronBuilder;
        patronBuilder.Orderby = orderBy;
        return patronBuilder;
    }
}
