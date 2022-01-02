using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ContadorPalabrasString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            var stringToCount = GenerarStringToCount();

            var cadenaArray = CleanAndConvertString(stringToCount);

            stopWatch.Start();
            var totalIteracionDiccionario = ContadorPalabras(cadenaArray);
            stopWatch.Stop();

            Console.WriteLine($"La instruccion con Diccionario tarda: {stopWatch.Elapsed.TotalMilliseconds}\n" +
                $"Se han realizado {totalIteracionDiccionario} iteraciones.");

            stopWatch.Reset();

            stopWatch.Start();
            var totalIteracionesCuadratico = ContadorTradicionalPalabras(cadenaArray);
            stopWatch.Stop();
            Console.WriteLine($"La instruccion con doble iteracion tarda: {stopWatch.Elapsed.TotalMilliseconds}\n" +
                $"Se han realizado {totalIteracionesCuadratico} iteraciones.");
        }

        private static long ContadorTradicionalPalabras(string[] cadenaArray)
        {
            long iteraciones = 0;
            var palabrasEvaluadas = new List<string>();
            for (var i = 0; i < cadenaArray.Length; i++)
            {
                if (!palabrasEvaluadas.Contains(cadenaArray[i]))
                {
                    var repeticionPalabra = 0;
                    for (var x = i; x < cadenaArray.Length; x++)
                    {
                        if (cadenaArray[i] == cadenaArray[x])
                        {
                            repeticionPalabra++;
                        }
                        iteraciones++;
                    }
                    palabrasEvaluadas.Add(cadenaArray[i]);
                    //Console.WriteLine($"La palabra: {cadenaArray[i]} \n" +
                    //    $"repeticiones: {repeticionPalabra}\n" +
                    //    $"-----------------------------------------------------------------");
                }
                iteraciones++;
            }
            return iteraciones;
        }

        private static long ContadorPalabras(string[] cadenaArray)
        {
            var diccionarioPalabras = new Dictionary<string, int>();
            long iteraciones = 0;

            for (var i = 0; i < cadenaArray.Length; i++)
            {
                if (!diccionarioPalabras.ContainsKey(cadenaArray[i]))
                {
                    diccionarioPalabras.Add(cadenaArray[i], 0);
                }
                diccionarioPalabras[cadenaArray[i]]++;
                iteraciones++;
            }
            //PrintDictionary(diccionarioPalabras);
            return iteraciones;
        }

        private static void PrintDictionary(Dictionary<string, int> diccionario)
        {
            foreach (var item in diccionario)
            {
                Console.WriteLine($"La palabra: {item.Key} \n" +
                    $"repeticiones: {item.Value}\n" +
                    $"-----------------------------------------------------------------");
            }
        }

        private static string GenerarStringToCount()
        {
            var cadena = "Hola, este es un mensaje para hacer la prueba de contador de palabras.\n" +
                "lo suyo es usar palabras que se repitan un poco para ver como funciona el metodo que vamos a realizar.";
            var cadenaToReturn = new StringBuilder();
            foreach (var item in Enumerable.Range(0, 100_000))
            {
                cadenaToReturn.Append(cadena);
            }
            return cadenaToReturn.ToString();
        }

        private static string[] CleanAndConvertString(string stringToCount)
        {
            var replace = Regex.Replace(stringToCount, @"[,.]*", string.Empty);
            return Regex.Split(replace, @"\W");
        }
    }
}
