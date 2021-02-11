using System;
using System.Threading.Tasks;

namespace CursoCSharp_2_programacion_asincrona_2
{
    public class Cafe
    {

    }

    public class Huevos
    {

    }

    public class Bacon
    {

    }

    public class Tostada
    {

    }

    public class Zumo
    {

    }

    public class EjemplosGenerales
    {
        public static async Task EjemplosGeneralesMultiThreading()
        {
            var cup = HacerCafe();
            Console.WriteLine("cafe listo");
            var eggs = await FreirHuevos(2);
            Console.WriteLine("huevos listos");
            var bacon = await FreirBacon(3);
            Console.WriteLine("bacon listo");
            var toast = await TostarPan(2);
            await AplicarMantequilla(toast);
            AplicarJamon(toast);
            Console.WriteLine("tostadas preparadas");
            var oj = HacerZumo();
            Console.WriteLine("zumo en su punto");

            Console.WriteLine("desayuno preparado!");
        }

        public static Cafe HacerCafe()
        {
            return new Cafe();
        }

        public static async Task<Huevos> FreirHuevos(int numHuevos)
        {
            return await Task.Run(() =>
            {
                return new Huevos();
            });
        }

        public static async Task<Bacon> FreirBacon(int numHuevos)
        {
            return await Task.Run(() =>
            {
                return new Bacon();
            });
        }

        public static async Task<Tostada> TostarPan(int numHuevos)
        {
            return await Task.Run(() =>
            {
                return new Tostada();
            });
        }

        public static async Task AplicarMantequilla(Tostada tostada)
        {
            await Task.Run(() =>
            {
                Console.Write("Aplicamos la mantequilla");
            });
        }

        public static void AplicarJamon(Tostada tostada)
        {

        }

        public static Zumo HacerZumo()
        {
            return new Zumo();
        }

    }
}
