using System;
using System.Threading.Tasks;

namespace ParallelExecutionCode.EjecucionEnParalelo
{
    internal class UsoParallelInvoke
    {
        public UsoParallelInvoke()
        {
            Parallel.Invoke(
                () => Metodo1(),
                () => Metodo2(2)
            );
        }

        private static void Metodo1()
        {
            Console.WriteLine("Hola 1");
        }
        private static void Metodo2(int numero)
        {
            Console.WriteLine($"Hola {numero}");
        }
    }
}
