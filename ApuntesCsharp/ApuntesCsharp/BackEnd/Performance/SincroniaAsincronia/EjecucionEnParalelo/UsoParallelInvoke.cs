using System;
using System.Threading.Tasks;

namespace SincroniaAsincronia.EjecucionEnParalelo {
    internal class UsoParallelInvoke {
        public UsoParallelInvoke() {
            Parallel.Invoke(
                () => Metodo1(),
                () => Metodo2(2)
            );
        }

        private void Metodo1() {
            Console.WriteLine("Hola 1");
        }
        private void Metodo2(int numero) {
            Console.WriteLine($"Hola {numero}");
        }
    }
}
