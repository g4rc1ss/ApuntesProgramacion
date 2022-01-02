using System;
using System.Diagnostics;
using Memorization.Clase;

namespace Memorization
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            Console.WriteLine(CalcularFibonacci(50));
            stopWatch.Stop();
            var tiempoFuncionNormal = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Reset();

            stopWatch.Start();
            Console.WriteLine(CalcularFibConMemoizacion(50));
            stopWatch.Stop();
            var tiempoFuncionMemoizacion = stopWatch.Elapsed.TotalMilliseconds;


            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"EL TIEMPO DE {nameof(CalcularFibonacci)} es: {tiempoFuncionNormal}\n" +
                $"EL TIEMPO DE {nameof(CalcularFibConMemoizacion)} es: {tiempoFuncionMemoizacion}");
        }

        private static long CalcularFibonacci(long numero)
        {
            Console.WriteLine($"Calculando el fib de {numero}");
            return numero > 1 ? CalcularFibonacci(numero - 1) + CalcularFibonacci(numero - 2) : numero;
        }

        private static long CalcularFibConMemoizacion(long numero)
        {
            Console.WriteLine($"Calculando el fib de {numero}");
            return numero > 1
                ? Memoizacion<long, long>.AddMemoizacion(CalcularFibConMemoizacion, numero - 1) + Memoizacion<long, long>.AddMemoizacion(CalcularFibConMemoizacion, numero - 2)
                : numero;
        }
    }
}
