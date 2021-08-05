using ParallelExecutionCode.EjecucionEnParalelo;
using System;

namespace ParallelExecutionCode {
    internal class Program {
        private static void Main(string[] args) {
            //Tareas en parallelo con Parallel
            new UsoParallelBucles().BucleFor();
            new UsoParallelBucles().BucleForEach();
            new UsoParallelInvoke();
            new UsoParallelLINQ();
        }
    }
}
