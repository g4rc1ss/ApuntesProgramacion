using System;
using System.Linq;
using CursosAndEstudioCsharp._12_LINQ._02_IntroduccionToConsultasLINQ;

namespace CursosAndEstudioCsharp._12_LINQ._09_ClausulaSELECT
{
    public class Categoria
    {
        public string Titulo { get; set; }
        public string IdLibro { get; set; }
    }

    internal class ClausulaSELECT
    {
        public ClausulaSELECT()
        {
            var libros = Libro.GetLibros();

            var tituloLibros = from l in libros
                               select l.Titulo;

            var ejemplo2 = from l in libros
                           select new Categoria { IdLibro = l.ISBN, Titulo = l.Titulo };

            var ejemplo3 = from l in libros
                           where l.FechaSalida > DateTime.Now.AddMonths(-6)
                           select l;

            var ejemplo4 = from l in libros
                           select new { ISBN = l.ISBN, ISBNAux = "wqr-" + l.ISBN };

            var ejemplo5 = from l in libros
                           select new { ISBN = l.ISBN, Lanzado = (l.FechaSalida < DateTime.Now ? "En venta" : "En breve") };

        }
    }
}
