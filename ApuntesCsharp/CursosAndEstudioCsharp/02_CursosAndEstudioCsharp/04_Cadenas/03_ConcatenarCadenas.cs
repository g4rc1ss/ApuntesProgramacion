using System;

namespace CursosAndEstudioCsharp._04_Cadenas
{
    internal class _03_ConcatenarCadenas
    {
        public _03_ConcatenarCadenas()
        {
            var superheroe = "Superman";
            var procedencia = "Kripton";
            var superpoder = "super fuerza";

            var todosDatos = superheroe + " procede de " + procedencia + " y tiene " + superpoder;

            var todosDatosConcat = string.Concat(superheroe, " procede de ", procedencia, " y tiene ", superpoder);
            var todosDatosConcat2 = string.Concat(superheroe, superpoder);

            var todosDatosInterpolation = $"{superheroe} procede de {procedencia} y tiene {superpoder}";
            var ejemploInterpolacion = $"{ 3 + 5 } es igual a 8?";

            Console.WriteLine(todosDatos);
            Console.ReadLine();

            Console.WriteLine(todosDatosConcat);
            Console.WriteLine(todosDatosConcat2);
            Console.ReadLine();

            Console.WriteLine(todosDatosInterpolation);
            Console.ReadLine();

            Console.WriteLine(ejemploInterpolacion);
            Console.ReadLine();
        }
    }
}
