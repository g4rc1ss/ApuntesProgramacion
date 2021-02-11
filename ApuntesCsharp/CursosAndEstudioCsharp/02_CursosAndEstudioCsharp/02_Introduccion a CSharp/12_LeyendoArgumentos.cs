using System;

namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _12_LeyendoArgumentos
    {
        public _12_LeyendoArgumentos(string[] args)
        {
            Console.WriteLine("Hay " + args.Length + " elementos");

            foreach (var argumentos in args)
            {
                Console.WriteLine(argumentos);
            }
        }
    }
}
