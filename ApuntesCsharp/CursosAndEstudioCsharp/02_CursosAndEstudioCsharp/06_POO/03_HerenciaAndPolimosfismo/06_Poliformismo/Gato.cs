using System;

namespace CursosAndEstudioCsharp._06_POO._03_HerenciaAndPolimosfismo._06_Poliformismo
{
    public class Gato : Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("El gato hace miiiiau");
        }
    }
}
