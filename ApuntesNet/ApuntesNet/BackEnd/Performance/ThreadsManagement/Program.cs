using System.Threading;
using ThreadsManagement.Hilos;

namespace ThreadsManagement
{
    internal class Program
    {
        private static void Main()
        {
            new Thread(CreacionDeHilos.FuncHilo1).Start();
            new Thread(() => CreacionDeHilos.FuncHilo2("hilo2")).Start();
        }
    }
}
