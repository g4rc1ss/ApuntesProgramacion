using System.Collections.Generic;

namespace CursosAndEstudioCsharp._12_LINQ._05_ClausulaJOIN
{
    public class LibroStats
    {
        public int Ventas { get; set; }
        public int Paginas { get; set; }
        public int Rank { get; set; }
        public string ISBN { get; set; }

        public static List<LibroStats> GetLibrosStats()
        {
            var listado = new List<LibroStats>
            {
                new LibroStats
                {
                    ISBN = "111111",
                    Paginas = 287,
                    Rank = 5,
                    Ventas = 2345
                },

                new LibroStats
                {
                    ISBN = "222222",
                    Paginas = 524,
                    Rank = 8,
                    Ventas = 234
                },

                new LibroStats
                {
                    ISBN = "3333333",
                    Paginas = 345,
                    Rank = 115,
                    Ventas = 23245
                },

                new LibroStats
                {
                    ISBN = "44444444",
                    Paginas = 124,
                    Rank = 7,
                    Ventas = 213
                },

                new LibroStats
                {
                    ISBN = "55555555",
                    Paginas = 678,
                    Rank = 1,
                    Ventas = 3434555
                },

                new LibroStats
                {
                    ISBN = "6666666",
                    Paginas = 478,
                    Rank = 4,
                    Ventas = 4343
                },

                new LibroStats
                {
                    ISBN = "777777777",
                    Paginas = 789,
                    Rank = 45,
                    Ventas = 2344
                },

                new LibroStats
                {
                    ISBN = "88888888",
                    Paginas = 890,
                    Rank = 123,
                    Ventas = 12343
                },

                new LibroStats
                {
                    ISBN = "999999999",
                    Paginas = 543,
                    Rank = 20,
                    Ventas = 8765
                }
            };

            return listado;
        }
    }
}
