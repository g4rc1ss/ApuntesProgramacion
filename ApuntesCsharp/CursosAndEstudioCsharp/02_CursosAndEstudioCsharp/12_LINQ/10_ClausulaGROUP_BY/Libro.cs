using System;
using System.Collections.Generic;

namespace CursosAndEstudioCsharp._12_LINQ._10_ClausulaGROUP_BY
{
    internal class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaSalida { get; set; }

        public static List<Libro> GetLibros()
        {
            var libros = new List<Libro>
            {
                new Libro
                {
                    FechaSalida = DateTime.Now.AddYears(-3),
                    ISBN = "111111",
                    Precio = 12.22M,
                    Titulo = "El señor de los anillos"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddYears(-2),
                    ISBN = "222222",
                    Precio = 18.15M,
                    Titulo = "El origen perdido"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddYears(-5),
                    ISBN = "3333333",
                    Precio = 22.49M,
                    Titulo = "La catredal del mar"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddYears(-3),
                    ISBN = "44444444",
                    Precio = 8.35M,
                    Titulo = "Eragon"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddYears(-1),
                    ISBN = "55555555",
                    Precio = 32.28M,
                    Titulo = "Juego de Tronos"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddYears(-1),
                    ISBN = "6666666",
                    Precio = 15.65M,
                    Titulo = "Insulgente"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddMonths(-3),
                    ISBN = "7777777",
                    Precio = 25.37M,
                    Titulo = "El ocho"
                },

                new Libro
                {
                    FechaSalida = DateTime.Now.AddMonths(3),
                    ISBN = "8888888",
                    Precio = 5.37M,
                    Titulo = "Mi amigo el fantasma"
                }
            };

            return libros;
        }
    }
}
