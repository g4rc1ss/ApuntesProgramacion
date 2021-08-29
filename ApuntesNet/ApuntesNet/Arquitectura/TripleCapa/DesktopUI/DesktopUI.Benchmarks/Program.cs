using BenchmarkDotNet.Running;
using DesktopUI.Benchmarks.BenchmarkManager;

namespace DesktopUI.Benchmarks {
    internal class Program {
        private static void Main() {
            BenchmarkRunner.Run<UserManagerBench>();
        }
    }
}
