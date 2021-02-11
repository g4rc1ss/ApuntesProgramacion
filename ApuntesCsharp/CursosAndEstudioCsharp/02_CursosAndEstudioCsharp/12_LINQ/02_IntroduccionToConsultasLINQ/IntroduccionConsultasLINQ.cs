using System;
using System.Linq;

namespace CursosAndEstudioCsharp._12_LINQ._02_IntroduccionToConsultasLINQ
{
    internal class IntroduccionConsultasLINQ
    {
        public IntroduccionConsultasLINQ()
        {
            var libros = Libro.GetLibros();

            var titulosLibros = from l in libros
                                select l.Titulo;

            foreach (var titulo in titulosLibros)
            {
                Console.WriteLine(titulo);
            }

            Console.ReadKey();
        }
    }
}
