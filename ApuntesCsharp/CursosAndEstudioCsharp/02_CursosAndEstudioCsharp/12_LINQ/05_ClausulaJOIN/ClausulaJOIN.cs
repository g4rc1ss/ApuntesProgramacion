using System;
using System.Linq;
using CursosAndEstudioCsharp._12_LINQ._02_IntroduccionToConsultasLINQ;

namespace CursosAndEstudioCsharp._12_LINQ._05_ClausulaJOIN
{
    internal class ClausulaJOIN
    {
        public ClausulaJOIN()
        {
            var libros = Libro.GetLibros();
            var librosStats = LibroStats.GetLibrosStats();

            var TitulosLibros = from l in libros
                                join s in librosStats on l.ISBN equals s.ISBN
                                select new
                                {
                                    TituloSeleccionado = l.Titulo,
                                    PaginasLibro = s.Paginas
                                };

            foreach (var item in TitulosLibros)
            {
                Console.WriteLine($"Titulo: {item.TituloSeleccionado} Paginas: {item.PaginasLibro}");
            }

            Console.ReadKey();
        }
    }
}
