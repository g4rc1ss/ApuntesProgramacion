using BenchmarkDotNet.Attributes;
using Benchmarking.Fakes;

namespace Benchmarking.Benchmarks
{
    internal class YieldVsList
    {
        public YieldVsList()
        {
        }

        [Benchmark]
        internal async Task ReadWithListAsync()
        {
            await FakerYieldVsList.ReadFileWithBufferList();
        }

        [Benchmark]
        internal async Task ReadWithYieldAsync()
        {
            var response = FakerYieldVsList.ReadFileWithYield();

            // Leemos el yield puesto que es una ejecucion diferida
            await foreach (var item in response) ;

        }
    }
}
