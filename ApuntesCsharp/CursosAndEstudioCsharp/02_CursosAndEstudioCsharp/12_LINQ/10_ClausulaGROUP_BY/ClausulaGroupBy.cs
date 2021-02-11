﻿using System;
using System.Linq;

namespace CursosAndEstudioCsharp._12_LINQ._10_ClausulaGROUP_BY
{
    internal class ClausulaGroupBy
    {
        public ClausulaGroupBy()
        {
            var libros = Libro.GetLibros();
            var librosStats = LibroStats.GetLibrosStats();

            var titulosLibros = from l in libros
                                join s in librosStats on l.ISBN equals s.ISBN
                                let porSalir = (l.FechaSalida > DateTime.Now ? "por salir" : "en venta")
                                orderby s.Rank
                                group new
                                {
                                    Titulo = l.Titulo,
                                    Precio = l.Precio,
                                    Paginas = s.Paginas
                                }
                                by porSalir
                                into librosAgrupados
                                select new
                                {
                                    Status = librosAgrupados.Key,
                                    Valores = librosAgrupados
                                };
        }
    }
}
