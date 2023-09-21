using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garciss.UnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// Obtiene una lista a partir de un IAsyncEnumerable de forma asincrona
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetListAsync<T>(this IAsyncEnumerable<T> enumerable)
        {
            var buffer = new List<T>();
            await foreach (var item in enumerable)
            {
                buffer.Add(item);
            }

            return buffer;
        }
    }
}
