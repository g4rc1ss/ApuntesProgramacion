using System;

namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _14_ConversionesDeTipo
    {
        public _14_ConversionesDeTipo()
        {
            var cadena = "Hola";
            var numero = 12;

            cadena = numero.ToString();

            //Implicitos
            var numeroEntero = 34543;
            long numeroLong = numeroEntero;

            //Explicitos
            var numeroDouble = 12.56;
            var numeroEnteroDouble = (int)numeroDouble;
            Console.WriteLine(numeroEnteroDouble);

            //definidos por el usuario

            //Con clases de asistentes



            var doubleValor = 8.45;
            var enteroValor = Convert.ToInt32(doubleValor);
            Convert.ToInt32(doubleValor);
        }
    }
}
