namespace Benchmarking.Fakes
{
    internal class FakerYieldVsList
    {
        private const string Path = "archivoLectura.txt";

        internal static async Task<List<object>> ReadFileWithBufferList()
        {
            var file = new StreamReader(Path);
            var buffer = new List<object>();

            while (!file.EndOfStream)
            {
                buffer.Add(new
                {
                    NombrePueblo = await file.ReadLineAsync()
                });
            }
            return buffer;
        }

        internal static async IAsyncEnumerable<object> ReadFileWithYield()
        {
            var file = new StreamReader(Path);

            while (!file.EndOfStream)
            {
                yield return new
                {
                    NombrePueblo = await file.ReadLineAsync()
                };
            }
        }
    }
}
