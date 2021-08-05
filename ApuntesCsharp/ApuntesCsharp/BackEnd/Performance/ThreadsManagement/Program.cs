using System;
using System.Threading;
using ThreadsManagement.Hilos;

namespace ThreadsManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(new CreacionDeHilos().FuncHilo1).Start();
            new Thread(() => new CreacionDeHilos().FuncHilo2("hilo2")).Start();
        }
    }
}
