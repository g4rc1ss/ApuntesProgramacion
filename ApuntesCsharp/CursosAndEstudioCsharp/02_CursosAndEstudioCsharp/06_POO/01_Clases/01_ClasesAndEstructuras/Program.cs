using System;

namespace CursosAndEstudioCsharp._06_POO._01_ClasesAndEstructuras
{
    internal class Program
    {
        public Program()
        {
            var punto = new Point
            {
                X = 10,
                Y = 8
            };


            var puntoStruct = new PointStruct
            {
                X = 20,
                Y = 7
            };

            SumaCoordenadas(punto);
            SumarCoordenadas(puntoStruct);

            Console.WriteLine($"Suma de coordenadas clase: X={punto.X} Y={punto.Y}");
            Console.WriteLine($"Suma de coordenadas struct: X={puntoStruct.X} Y={puntoStruct.Y}");
            Console.ReadKey();
        }

        public static void SumaCoordenadas(Point point)
        {
            point.X = point.X + 10;
            point.Y = point.Y + 10;
        }

        public static void SumarCoordenadas(PointStruct pointStruct)
        {
            pointStruct.X = pointStruct.X + 10;
            pointStruct.Y = pointStruct.Y + 10;
        }
    }
}
