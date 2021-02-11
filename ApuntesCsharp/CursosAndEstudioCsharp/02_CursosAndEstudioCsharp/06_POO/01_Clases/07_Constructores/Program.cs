using System;

namespace CursosAndEstudioCsharp._06_POO._13_Constructores
{
    internal class Program
    {
        public Program()
        {
            var punto = new Punto();

            Console.WriteLine($"X = {punto.X} Y = {punto.Y}");

            var punto2 = new Punto(10, 20);

            Console.WriteLine($"X = {punto2.X} Y = {punto2.Y}");

            var punto3 = new Punto(10);

            Console.WriteLine($"X = {punto3.X} Y = {punto3.Y}");
        }
    }
}
