using BenchmarkDotNet.Running;

namespace WebApi.Benchmarks {
    internal class Program {
        private static void Main() {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
