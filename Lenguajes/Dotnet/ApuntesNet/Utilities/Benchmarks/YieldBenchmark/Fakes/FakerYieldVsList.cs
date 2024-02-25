namespace YieldBenchmark.Fakes;

public class FakerYieldVsList
{
    private const int NUMBEROFOBJECTS = 1000_000_000;

    public static List<int> WithBuffer()
    {
        var buffer = new List<int>();

        foreach (var item in Enumerable.Range(0, NUMBEROFOBJECTS))
        {
            buffer.Add(item);
        }
        return buffer;
    }

    public static IEnumerable<int> WithYield()
    {
        foreach (var item in Enumerable.Range(0, NUMBEROFOBJECTS))
        {
            yield return item;
        }
    }
}
