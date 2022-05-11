namespace DatabaseLibrariesBenchmark.Fakes
{
    public class FakerYieldVsList
    {
        private const int NumberOfObjects = 1000_000_000;

        public static List<int> WithBuffer()
        {
            var buffer = new List<int>();

            foreach (var item in Enumerable.Range(0, NumberOfObjects))
            {
                buffer.Add(item);
            }
            return buffer;
        }

        public static IEnumerable<int> WithYield()
        {
            foreach (var item in Enumerable.Range(0, NumberOfObjects))
            {
                yield return item;
            }
        }
    }
}
