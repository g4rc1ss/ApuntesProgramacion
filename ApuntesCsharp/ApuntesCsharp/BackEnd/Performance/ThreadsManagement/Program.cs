using System.Threading;
using ThreadsManagement.Hilos;

namespace ThreadsManagement {
    internal class Program {
        private static void Main(string[] args) {
            new Thread(new CreacionDeHilos().FuncHilo1).Start();
            new Thread(() => new CreacionDeHilos().FuncHilo2("hilo2")).Start();
        }
    }
}
