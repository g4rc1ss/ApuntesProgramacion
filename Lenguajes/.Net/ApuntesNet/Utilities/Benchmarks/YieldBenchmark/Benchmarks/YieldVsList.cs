using BenchmarkDotNet.Attributes;
using Benchmarking.Fakes;

namespace Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class YieldVsList
    {
        public YieldVsList()
        {
        }

        [Benchmark]
        public void ExpensiveObjectsWithList()
        {
            FakerYieldVsList.WithBuffer();
        }

        [Benchmark]
        public void ExpensiveObjectsWithYield()
        {
            var response = FakerYieldVsList.WithYield();

            // Leemos el yield puesto que es una ejecucion diferida
            foreach (var item in response) ;

        }
    }
}
