namespace Benchmarking.Fakes
{
    internal static class FakerThreadVsAsync
    {
        private const int DELAY = 100;

        internal static async Task ExecuteTask()
        {
            await Task.Delay(DELAY);
        }

        internal static Task ExecuteTaskBlocking()
        {
            ExecuteTask().Wait();
            return Task.CompletedTask;
        }
    }
}
