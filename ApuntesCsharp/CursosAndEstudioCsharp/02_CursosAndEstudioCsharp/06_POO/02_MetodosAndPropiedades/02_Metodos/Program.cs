using System;

namespace CursosAndEstudioCsharp._06_POO._06_Metodos
{
    internal class Program
    {
        public Program()
        {
            var clase = new Clase();
            clase.Calcular(27);
            var suma = clase.Sumar(1, 6);

            Console.WriteLine(suma);
            Console.ReadLine();
        }
    }
}
