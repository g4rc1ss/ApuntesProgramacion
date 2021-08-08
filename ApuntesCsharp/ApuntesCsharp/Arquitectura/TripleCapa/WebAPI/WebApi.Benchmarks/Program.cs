using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace WebApi.Benchmarks {
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50)]
    internal class Program {
        private static void Main() {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
