using System.Linq;
using CursosAndEstudioCsharp._12_LINQ._02_IntroduccionToConsultasLINQ;
using CursosAndEstudioCsharp._12_LINQ._05_ClausulaJOIN;

namespace CursosAndEstudioCsharp._12_LINQ._08_ClausulaORDER_BY
{
    internal class ClausulaORDER_BY
    {
        public ClausulaORDER_BY()
        {
            var libros = Libro.GetLibros();
            var librosStats = LibroStats.GetLibrosStats();

            var TitulosLibros = from l in libros
                                join s in librosStats on l.ISBN equals s.ISBN
                                orderby l.FechaSalida, s.Paginas
                                select new
                                {
                                    Nombre = l.Titulo,
                                    Fecha = l.FechaSalida,
                                    Pag = s.Paginas
                                };

            var TitulosLibros2 = from l in libros
                                 join s in librosStats on l.ISBN equals s.ISBN
                                 orderby l.FechaSalida, s.Paginas descending
                                 select new
                                 {
                                     Nombre = l.Titulo,
                                     Fecha = l.FechaSalida,
                                     Pag = s.Paginas
                                 };

            var TitulosLibros3 = from l in libros
                                 join s in librosStats on l.ISBN equals s.ISBN
                                 orderby l.FechaSalida descending, s.Paginas
                                 select new
                                 {
                                     Nombre = l.Titulo,
                                     Fecha = l.FechaSalida,
                                     Pag = s.Paginas
                                 };
        }
    }
}
