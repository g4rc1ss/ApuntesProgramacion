namespace DeferredExecutionYield.YieldEnumerator;

internal class YieldExecution
{

    public IEnumerable<int> GetEnumerableWithYield()
    {
        for (var i = 0; i < 100; i++)
        {
            yield return i;
        }
    }

    public async IAsyncEnumerable<int> GetAsyncEnumerableWithYieldAsync()
    {
        for (var i = 0; i < 100; i++)
        {
            yield return await Task.FromResult(i);
        }
    }
}
