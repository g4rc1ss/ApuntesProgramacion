using System;

namespace CursosAndEstudioCsharp._04_Cadenas
{
    internal class _02_FormatoFechas
    {
        public _02_FormatoFechas()
        {
            var fecha = new DateTime();
            fecha = DateTime.Now;
            Console.WriteLine("ToLocalTime: " + fecha.ToLocalTime());
            Console.WriteLine("ToLongDateString: " + fecha.ToLongDateString());
            Console.WriteLine("ToLongTimeString: " + fecha.ToLongTimeString());
            Console.WriteLine("ToOADate: " + fecha.ToOADate());
            Console.WriteLine("ToShortDateString: " + fecha.ToShortDateString());
            Console.WriteLine("ToShortTimeString: " + fecha.ToShortTimeString());
            Console.WriteLine("ToString: " + fecha.ToString());
            Console.WriteLine("ToUniversalTime: " + fecha.ToUniversalTime());
            Console.ReadLine();


            var fechaString = string.Format("La fecha de hoy es: {0:dd/MM/yyyy hh:mm:ss}", DateTime.Now);
            Console.WriteLine(fechaString);
            Console.ReadLine();
        }
    }
}
