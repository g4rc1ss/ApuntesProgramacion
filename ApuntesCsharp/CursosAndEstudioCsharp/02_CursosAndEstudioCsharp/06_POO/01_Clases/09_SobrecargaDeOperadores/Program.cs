using System;

namespace CursosAndEstudioCsharp._06_POO._15_SobrecargaDeOperadores
{
    internal class Program
    {
        public Program()
        {
            var punto = new Punto(200, 50);

            punto = +punto;

            Console.WriteLine($" X = {punto.X} Y = {punto.Y}");

            punto = +punto;
            punto = +punto;
            punto = +punto;

            Console.WriteLine($" X = {punto.X} Y = {punto.Y}");

            punto = -punto;

            Console.WriteLine($" X = {punto.X} Y = {punto.Y}");
        }
    }
}
