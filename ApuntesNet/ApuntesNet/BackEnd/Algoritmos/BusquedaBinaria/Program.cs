using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BusquedaBinaria {
    internal class Program {
        private static void Main(string[] args) {
            var arrayOrdenado = Enumerable.Range(0, 1_000_000_000).ToList();
            var numero = 9_000_000;
            var existeNumero = default(bool);
            Stopwatch stopwatch = new();

            stopwatch.Start();
            existeNumero = BuscarValorRecurviso(in arrayOrdenado, numero, 0, arrayOrdenado.Count - 1);
            stopwatch.Stop();
            Console.WriteLine($"El valor obtenido con recursividad: {existeNumero} \n" +
                $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Reset();

            stopwatch.Start();
            existeNumero = BuscarValorIteracion(in arrayOrdenado, numero);
            stopwatch.Stop();
            Console.WriteLine($"El valor es obtenido con iteracion: {existeNumero} \n" +
                $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Reset();

            stopwatch.Start();
            existeNumero = BusquedaTradicional(in arrayOrdenado, numero);
            stopwatch.Stop();
            Console.WriteLine($"El valor es obtenido con iteracion: {existeNumero} \n" +
                $"El tiempo de busqueda es: {stopwatch.Elapsed.TotalMilliseconds}");
        }

        private static bool BusquedaTradicional(in List<int> arrayOrdenado, int numero) {
            foreach (var item in arrayOrdenado) {
                if (item == numero) {
                    return true;
                }
            }
            return false;
        }

        private static bool BuscarValorIteracion(in List<int> arrayOrdenado, int numero) {
            var left = 0;
            var right = arrayOrdenado.Count - 1;

            while (left < right) {
                var mitad = (right + left) / 2;
                if (arrayOrdenado[mitad] == numero) {
                    return true;
                } else if (arrayOrdenado[mitad] < numero) {
                    left = mitad;
                } else if (arrayOrdenado[mitad] > numero) {
                    right = mitad;
                }
            }
            return false;
        }

        private static bool BuscarValorRecurviso(in List<int> arrayOrdenado, int numero, int left, int right) {
            var mitad = (right + left) / 2;
            var valorRetorno = default(bool);
            if (right < left) {
                return false;
            }

            if (arrayOrdenado[mitad] == numero) {
                return true;
            } else if (arrayOrdenado[mitad] < numero) {
                valorRetorno = BuscarValorRecurviso(arrayOrdenado, numero, mitad, right);
            } else if (arrayOrdenado[mitad] > numero) {
                valorRetorno = BuscarValorRecurviso(arrayOrdenado, numero, left, mitad);
            }
            return valorRetorno;
        }
    }
}
