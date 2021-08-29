using ParallelExecutionCode.EjecucionEnParalelo;

namespace ParallelExecutionCode {
    internal class Program {
        private static void Main() {
            //Tareas en parallelo con Parallel
            new UsoParallelBucles().BucleFor();
            new UsoParallelBucles().BucleForEach();
            _ = new UsoParallelInvoke();
            _ = new UsoParallelLINQ();
        }
    }
}
