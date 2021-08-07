using BenchmarkDotNet.Running;
using WebApi.Benchmarks.BenchmarkManager;

namespace WebApi.Benchmarks {
    internal class Program {
        private static void Main() {
            BenchmarkRunner.Run<CipherManagerBench>();
            BenchmarkRunner.Run<IdentityManagerBench>();
        }
    }
}
