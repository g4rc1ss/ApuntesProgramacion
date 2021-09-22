using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ContadorPalabrasString {
    internal class Program {
        private static void Main(string[] args) {
            var stopWatch = new Stopwatch();
            var stringToCount = GenerarStringToCount();

            var cadenaArray = CleanAndConvertString(stringToCount);

            //stopWatch.Start();
            //var palabrasContadas = ContadorPalabras(cadenaArray);
            //stopWatch.Stop();

            //foreach (var item in palabrasContadas) {
            //    Console.WriteLine($"La palabra: {item.Key} \n" +
            //        $"repeticiones: {item.Value}\n" +
            //        $"-----------------------------------------------------------------");
            //}
            //Console.WriteLine($"La instruccion con Diccionario tarda: {stopWatch.Elapsed.TotalMilliseconds}");

            //stopWatch.Reset();

            stopWatch.Start();
            var totalIteraciones = ContadorTradicionalPalabras(cadenaArray);
            stopWatch.Stop();
            Console.WriteLine($"La instruccion con doble doble iteracion tarda: {stopWatch.Elapsed.TotalMilliseconds}\n" +
                $"Se han realizado {totalIteraciones} iteraciones.");
        }

        private static int ContadorTradicionalPalabras(string[] cadenaArray) {
            var iteraciones = 0;
            for (var i = 0; i < cadenaArray.Length; i++) {
                var repeticionPalabra = 0;
                for (var x = i; x < cadenaArray.Length; x++) {
                    if (cadenaArray[i] == cadenaArray[x]) {
                        repeticionPalabra++;
                    }
                    iteraciones++;
                }
                Console.WriteLine($"La palabra: {cadenaArray[i]} \n" +
                    $"repeticiones: {repeticionPalabra}\n" +
                    $"-----------------------------------------------------------------");
                iteraciones++;
            }
            return iteraciones;
        }

        private static Dictionary<string, int> ContadorPalabras(string[] cadenaArray) {
            throw new NotImplementedException();
        }

        private static string GenerarStringToCount() {
            var cadena = "Hola, este es un mensaje para hacer la prueba de contador de contador de palabras.\n" +
                "lo suyo es usar palabras que se repitan un poco para ver como funciona el metodo que vamos a realizar.";
            var cadenaToReturn = new StringBuilder();
            foreach (var item in Enumerable.Range(0, 1000)) {
                cadenaToReturn.Append(cadena);
            }
            return cadenaToReturn.ToString();
        }

        private static string[] CleanAndConvertString(string stringToCount) {
            var replace = Regex.Replace(stringToCount, @"[,.]*", string.Empty);
            return Regex.Split(replace, @"\W");
        }
    }
}
