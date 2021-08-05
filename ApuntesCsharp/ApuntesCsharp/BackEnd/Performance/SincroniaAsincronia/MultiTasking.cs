using SincroniaAsincronia.EjecucionEnParalelo;
using SincroniaAsincronia.Hilos;
using SincroniaAsincronia.Tareas;
using System;
using System.Threading;

namespace SincroniaAsincronia {
    internal class MultiTasking {
        private static void Main(string[] args) {
            // HILOS
            new Thread(new CreacionDeHilos().FuncHilo1).Start();
            new Thread(() => new CreacionDeHilos().FuncHilo2("hilo2")).Start();

            //Tareas normales de codigo
            new CreacionTareas().Task2();
            new CreacionTareas().Task1();
            var task = new CreacionTareas().Task3("task3");

            //Tareas en parallelo con Parallel
            new UsoParallelBucles().BucleFor();
            new UsoParallelBucles().BucleForEach();
            new UsoParallelInvoke();
            new UsoParallelLINQ();

            // Asincronia
            for (var x = 0; x < 10000; x++)
                Console.WriteLine("Ejecutando lo ultimo");
            Console.WriteLine("Pulsa para terminar el programa");
            Console.Read();
        }
    }
}
