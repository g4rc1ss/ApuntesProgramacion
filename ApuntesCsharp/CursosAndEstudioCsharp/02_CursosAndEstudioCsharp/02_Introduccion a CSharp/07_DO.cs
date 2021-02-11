using System;

namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _07_DO
    {
        public _07_DO()
        {
            //do
            //{
            //    //Instrucciones
            //} while (true);

            var numero = 0;

            do
            {
                Console.Write(numero);
                numero++; //numero = numero + 1;

                if (numero == 5)
                {
                    return;
                }

            }
            while (numero < 10);
        }
    }
}
