using Garciss.Paging.Internal;
using Microsoft.EntityFrameworkCore;

namespace Garciss.Paging.PaginateExtensions;

public static class PaginateExtensions
{
    /// <summary>
    /// Crea una clase de paginacion para cualquier IEnumerable
    /// Se le manda el indice y el numero de registros a devolver
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <param name="size"></param>
    /// <param name="from"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IPaginate<T> ToPaginate<T>(this IEnumerable<T> source, int index, int size, int from = 0) where T : class
    {
        if (from > index)
        {
            throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");
        }

        var count = source.Count();
        var items = source.Skip((index - from) * size).Take(size).ToList();

        return new Paginate<T>
        {
            Index = index,
            Size = size,
            From = from,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size),
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <param name="size"></param>
    /// <param name="from"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int index, int size, int from = 0) where T : class
    {
        if (from > index)
        {
            throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");
        }

        var count = source.Count();
        var items = source.Skip((index - from) * size).Take(size).ToList();

        return new Paginate<T>
        {
            Index = index,
            Size = size,
            From = from,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size),
        };
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <param name="size"></param>
    /// <param name="from"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size, int from = 0,
        CancellationToken cancellationToken = default) where T : class
    {
        if (from > index)
        {
            throw new ArgumentException($"From: {from} > Index: {index}, debe ser <= Index");
        }

        var count = await source.CountAsync(cancellationToken);
        var items = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken);

        return new Paginate<T>
        {
            Index = index,
            Size = size,
            From = from,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size)
        };
    }
}
