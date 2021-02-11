using System;
using System.Linq;
using CursosAndEstudioCsharp._12_LINQ._02_IntroduccionToConsultasLINQ;
using CursosAndEstudioCsharp._12_LINQ._05_ClausulaJOIN;

namespace CursosAndEstudioCsharp._12_LINQ._06_ClausulaLET
{
    internal class ClausulaLET
    {
        public ClausulaLET()
        {
            var libros = Libro.GetLibros();
            var librosStats = LibroStats.GetLibrosStats();

            var TitulosLibros = from l in libros
                                join s in librosStats on l.ISBN equals s.ISBN
                                let ganancias = (l.Precio * s.Ventas)
                                select new
                                {
                                    TituloSeleccionado = l.Titulo,
                                    Ganancias = ganancias
                                };

            foreach (var item in TitulosLibros)
            {
                Console.WriteLine($"Titulo: {item.TituloSeleccionado} Ganancias: {item.Ganancias}");
            }
        }
    }
}
