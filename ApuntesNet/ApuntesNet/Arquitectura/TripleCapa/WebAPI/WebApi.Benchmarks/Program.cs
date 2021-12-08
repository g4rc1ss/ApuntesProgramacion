using System;
using BenchmarkDotNet.Running;

namespace WebApi.Benchmarks {
    internal class Program {
        private static void Main() {
            var bench = BenchmarkRunner.Run(typeof(Program).Assembly);
            Console.Clear();

            foreach (var item in bench) {
                Console.WriteLine(item);
            }
        }
    }
}
