using System;
using System.Text;

namespace CursosAndEstudioCsharp._04_Cadenas
{
    internal class _04_StringBuilder
    {
        public _04_StringBuilder()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder("Hola soy Batman");


            sb.Append("Hola soy Batman");
            sb.Append("y vivo en Gotham");

            Console.WriteLine(sb);
            Console.ReadLine();

            sb2.AppendLine("y vivo en Gotham");
            sb2.AppendFormat(" actualmente {0:dd/MM/yyyy}", DateTime.Now);

            Console.WriteLine(sb2);
            Console.ReadLine();

            if (sb.Capacity > 1)
            {
            }

            if (sb2.Length > 1)
            {
            }

            Console.WriteLine(sb2);
            Console.ReadLine();
        }
    }
}
