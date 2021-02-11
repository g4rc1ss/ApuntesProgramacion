using System;

namespace CursosAndEstudioCsharp._04_Cadenas
{
    internal class _01_TratamientoStrings
    {
        public _01_TratamientoStrings()
        {
            Console.WriteLine("Hello World!");

            var miCadena = "";
            Console.WriteLine(miCadena);

            var miCadena1 = string.Empty;
            Console.WriteLine(miCadena1);

            var miCadena2 = "Hola Mundo!";
            Console.WriteLine(miCadena2);

            var numero = 7;
            var numeroString = numero.ToString();
            Console.WriteLine(numeroString);
        }
    }
}
