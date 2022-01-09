using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class ThreadsVsAsync
    {
        const int DELAY = 2000;
        private readonly IEnumerable<int> _lenght = Enumerable.Range(0, 5);

        [Benchmark]
        public async Task ExecuteWithMultiThreading()
        {
            await Parallel.ForEachAsync(_lenght, async (value, token) =>
            {
                await Task.Delay(DELAY, token);
            });
        }

        [Benchmark]
        public async Task ExecuteWithAsync()
        {
            var lista = new List<Task>();

            foreach (var item in _lenght)
            {
                lista.Add(Task.Delay(DELAY));
            }

            await Task.WhenAll(lista);
        }

        [Benchmark]
        public async Task ExecuteWithOtherMethodAsync()
        {
            var lista = new List<Task>();

            foreach (var item in _lenght)
            {
                lista.Add(Task.Delay(DELAY));
            }

            await Task.WhenAll(lista);
        }

        [Benchmark]
        public async Task ExecuteWithOtherMethodSync()
        {
            foreach (var item in _lenght)
            {
                await ExecuteTask();
            }
        }

        private async Task ExecuteTask()
        {
            await Task.Delay(DELAY);
        }
    }
}
