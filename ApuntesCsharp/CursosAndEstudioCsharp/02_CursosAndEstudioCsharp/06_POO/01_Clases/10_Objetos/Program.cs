using System;

namespace CursosAndEstudioCsharp._06_POO._01_Clases._10_Objetos
{
    internal class Program
    {
        public Program()
        {
            Console.WriteLine("Hello World!");

            var cuenta1 = new CuentaBancaria
            {
                Saldo = 1500
            };

            var cuenta2 = new CuentaBancaria
            {
                Saldo = 2200
            };

            var suma = cuenta1.Saldo + cuenta2.Saldo;
        }
    }
}
