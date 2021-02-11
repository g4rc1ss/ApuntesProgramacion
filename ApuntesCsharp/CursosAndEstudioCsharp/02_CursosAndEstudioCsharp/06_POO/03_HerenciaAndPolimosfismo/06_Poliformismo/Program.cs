using System;
using System.Collections.Generic;

namespace CursosAndEstudioCsharp._06_POO._03_HerenciaAndPolimosfismo._06_Poliformismo
{
    internal class Program
    {
        public Program()
        {
            var gato = new Gato();
            gato.HacerRuido();

            var perro = new Perro();
            perro.HacerRuido();

            var lobo = new Lobo();
            lobo.HacerRuido();

            Console.Read();

            var zoo = new List<Animal>
            {
                gato,
                perro,
                lobo
            };

            foreach (var item in zoo)
            {
                item.HacerRuido();
            }

            Console.Read();
        }
    }
}
