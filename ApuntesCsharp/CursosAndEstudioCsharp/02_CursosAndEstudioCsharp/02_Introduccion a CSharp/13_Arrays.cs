using System;

namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _13_Arrays
    {
        public _13_Arrays()
        {
            // int[] arrayDeEnteros2 = new int[5];
            int[] arrayDeEnteros3 = { 1, 2, 3, 4 };
            // int[,] arrayDeEnteros2Dimensiones = new int[2, 2];
            int[,] arrayDeEnteros2Dimensiones2 = { { 2, 2 }, { 3, 6 } };
            var arrayDeEnterosEscalonados = new int[6][];
            arrayDeEnterosEscalonados[0] = new int[4] { 3, 6, 7, 2 };
            arrayDeEnterosEscalonados[1] = new int[2] { 1, 3 };

            for (var i = 0; i < arrayDeEnteros3.Length; i++)
            {
                Console.WriteLine(arrayDeEnteros3[i]);
            }

            for (var i = 0; i < arrayDeEnteros2Dimensiones2.GetLongLength(0); i++)
            {
                for (var x = 0; x < arrayDeEnteros2Dimensiones2.GetLongLength(1); x++)
                {
                    Console.WriteLine(arrayDeEnteros2Dimensiones2[i, x]);
                }
            }

            for (var i = 0; i < arrayDeEnterosEscalonados.GetLongLength(0); i++)
            {
                for (var x = 0; x < arrayDeEnterosEscalonados.GetLongLength(1); x++)
                {
                    Console.WriteLine(arrayDeEnterosEscalonados[i][x]);
                }
            }


            foreach (var elementos in arrayDeEnteros3)
            {
                Console.WriteLine(elementos);
            }
        }
    }
}
