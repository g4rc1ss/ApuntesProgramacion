namespace Benchmarking.Fakes
{
    internal static class Faker
    {
        private const int DELAY = 2000;

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
