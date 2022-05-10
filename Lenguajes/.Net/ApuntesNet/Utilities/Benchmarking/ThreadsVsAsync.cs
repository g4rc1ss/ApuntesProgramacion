using BenchmarkDotNet.Attributes;
using Benchmarking.Fakes;

namespace Benchmarking
{
    public class ThreadsVsAsync
    {
        private readonly IEnumerable<int> _lenght = Enumerable.Range(0, 5);

        [Benchmark]
        public async Task ExecuteWithParallelAsync()
        {
            await Parallel.ForEachAsync(_lenght, async (value, token) =>
            {
                await Faker.ExecuteTask();
            });
        }

        [Benchmark]
        public async Task ExecuteWithTaskAsync()
        {
            var lista = new List<Task>();

            foreach (var item in _lenght)
            {
                lista.Add(Faker.ExecuteTask());
            }

            await Task.WhenAll(lista);
        }

        [Benchmark]
        public async Task ExecuteAsyncWithAwaitSecuential()
        {
            foreach (var item in _lenght)
            {
                await Faker.ExecuteTask();
            }
        }

        [Benchmark]
        public async Task ExecuteWithAsyncBlocking()
        {
            var lista = new List<Task>();

            foreach (var item in _lenght)
            {
                lista.Add(Faker.ExecuteTaskBlocking());
            }

            await Task.WhenAll(lista);
        }

    }
}
