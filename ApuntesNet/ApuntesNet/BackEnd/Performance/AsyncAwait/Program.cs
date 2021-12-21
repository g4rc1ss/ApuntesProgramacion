using System;
using AsyncAwait.Async;

namespace AsyncAwait
{
    internal class Program
    {
        /// <summary>
        /// Creamos un bucle que cree Arrobas cada vez que se recarga, se llama a un metodo que es asincrono, pero no se usa await para no bloquear
        /// el hilo, el await se usa mas adelante, como se hace con las GUIS al final. Por tanto la interfaz principal no se bloquea y se pueden
        /// esperar mas eventos e internamente se siguen ejecutando los procesos correspondientes
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static void Main()
        {
            var asincronia = new Asincronia();

            for (var i = 0; i < 30; i++)
            {
                Console.Write("@");

                var ejecutarSincronico = Console.ReadLine();

                if (ejecutarSincronico.StartsWith("s"))
                {
                    Console.WriteLine("Ejemplo de codigo NO asincrono");
                    asincronia.LlamadaMetodo();
                }
                else
                {
                    Console.WriteLine("Ejemplo de codigo asincrono enlazado a CPU");
                    _ = asincronia.CpuAsync();

                    Console.WriteLine("Ejemplo de codido asincrono E/S");
                    _ = asincronia.ESAsync();

                    Console.WriteLine("Ejemplo de codido asincrono en bucles foreach");
                    _ = asincronia.ExecuteIEnumerableAsync();
                }
            }
        }
    }
}
