using System;
using System.Linq;
using CursosAndEstudioCsharp._12_LINQ._02_IntroduccionToConsultasLINQ;
using CursosAndEstudioCsharp._12_LINQ._05_ClausulaJOIN;

namespace CursosAndEstudioCsharp._12_LINQ._07_ClausulaWHERE
{
    internal class ClausulaWHERE
    {
        public ClausulaWHERE()
        {
            var libros = Libro.GetLibros();
            var librosStats = LibroStats.GetLibrosStats();

            var TitulosLibros = from l in libros
                                join s in librosStats on l.ISBN equals s.ISBN
                                where s.Ventas > 1000
                                select new
                                {
                                    Nombre = l.Titulo,
                                    VentasLibro = s.Ventas
                                };

            var TitulosLibros2 = from l in libros
                                 join s in librosStats on l.ISBN equals s.ISBN
                                 where s.Ventas > 1000
                                 where l.FechaSalida > DateTime.Now.AddYears(-2)
                                 select new
                                 {
                                     Nombre = l.Titulo,
                                     VentasLibro = s.Ventas
                                 };
        }
    }
}
