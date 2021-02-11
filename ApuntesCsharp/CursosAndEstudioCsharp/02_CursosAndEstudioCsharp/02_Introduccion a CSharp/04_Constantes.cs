using System;

namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _04_Constantes
    {
        public const string NOMBRE = "Pedro";
        public const int NUMERO_PEDIDOS_MAXIMOS = 10;
        public _04_Constantes()
        {
            //Esto no se puede hacer
            //NUMERO_PEDIDOS_MAXIMOS = 12;

            for (var i = 0; i < 12; i++)
            {
                if (i < NUMERO_PEDIDOS_MAXIMOS)
                {
                    Console.Write(i);
                }
            }
        }
    }
}
