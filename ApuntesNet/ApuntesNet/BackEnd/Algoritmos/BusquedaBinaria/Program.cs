using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BusquedaBinaria {
    internal class Program {
        private static void Main(string[] args) {
            var arrayOrdenado = Enumerable.Range(0, 1000_000_000).ToList();
            var numero = 1000_000_000 - 1;
            var existeNumero = default(bool);
            Stopwatch stopwatch = new();

            Console.WriteLine("\n----------------------- BUSQUEDA NORMAL POR ITERACION -----------------------");
            stopwatch.Start();
            existeNumero = BusquedaTradicional(in arrayOrdenado, numero);
            stopwatch.Stop();
            Console.WriteLine($"{existeNumero} \n" +
                $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}");


            stopwatch.Reset();

            Console.WriteLine("\n----------------------- BUSQUEDA BINARIA ITERADA -----------------------");
            stopwatch.Start();
            existeNumero = BuscarValorIteracion(in arrayOrdenado, numero);
            stopwatch.Stop();
            Console.WriteLine($"{existeNumero} \n" +
                $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Reset();

            Console.WriteLine("\n----------------------- BUSQUEDA BINARIA RECURSIVA -----------------------");
            stopwatch.Start();
            existeNumero = BuscarValorRecurviso(in arrayOrdenado, numero, 0, arrayOrdenado.Count - 1);
            stopwatch.Stop();
            Console.WriteLine($"{existeNumero} \n" +
                $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}");
        }

        private static bool BusquedaTradicional(in List<int> arrayOrdenado, long numero) {
            var iteraciones = 0;
            foreach (var item in arrayOrdenado) {
                iteraciones++;
                if (item == numero) {
                    Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
                    return true;
                }
            }
            Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
            return false;
        }

        private static bool BuscarValorIteracion(in List<int> arrayOrdenado, long numero) {
            var iteraciones = 0;
            var left = 0;
            var right = arrayOrdenado.Count - 1;

            while (left <= right) {
                iteraciones++;
                var mitad = (right + left) / 2;
                if (arrayOrdenado[mitad] == numero) {
                    Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
                    return true;
                } else if (arrayOrdenado[mitad] < numero) {
                    // Movemos el left a la derecha una posicion
                    left = mitad + 1;
                } else if (arrayOrdenado[mitad] > numero) {
                    // Movemos el right a la izquierda una posicion
                    right = mitad - 1;
                }
            }
            Console.WriteLine($"El numero de iteraciones son: {iteraciones}");
            return false;
        }

        static int iteracionesRecursivas = 0;
        private static bool BuscarValorRecurviso(in List<int> arrayOrdenado, long numero, int left, int right) {
            iteracionesRecursivas++;
            var mitad = (right + left) / 2;
            var valorRetorno = default(bool);
            if (right < left) {
                return false;
            }

            if (arrayOrdenado[mitad] == numero) {
                Console.WriteLine($"El numero de iteraciones son: {iteracionesRecursivas}");
                return true;
            } else if (arrayOrdenado[mitad] < numero) {
                valorRetorno = BuscarValorRecurviso(arrayOrdenado, numero, mitad + 1, right);
            } else if (arrayOrdenado[mitad] > numero) {
                valorRetorno = BuscarValorRecurviso(arrayOrdenado, numero, left, mitad - 1);
            }
            return valorRetorno;
        }
    }
}
