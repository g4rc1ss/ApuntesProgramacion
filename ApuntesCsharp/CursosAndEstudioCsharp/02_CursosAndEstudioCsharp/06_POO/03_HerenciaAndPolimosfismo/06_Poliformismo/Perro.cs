using System;

namespace CursosAndEstudioCsharp._06_POO._03_HerenciaAndPolimosfismo._06_Poliformismo
{
    public class Perro : Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("El perro hace Guau Guau");
        }
    }
}
