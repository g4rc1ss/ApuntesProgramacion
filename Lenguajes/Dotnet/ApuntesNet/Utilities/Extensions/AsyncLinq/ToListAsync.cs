namespace Garciss.AsyncLinq
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetListAsync<T>(this IAsyncEnumerable<T> value)
        {
            var buffer = new List<T>();
            await foreach (var item in value)
            {
                buffer.Add(item);
            }

            return buffer;
        }
    }
}
