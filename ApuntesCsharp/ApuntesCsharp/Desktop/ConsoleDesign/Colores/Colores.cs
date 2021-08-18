using System;
namespace ConsoleDesign.Colores {
    public class Colores {
        public static void PintamosColores() {
            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.DarkYellow} Esto es AMARILLO\n");
            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.Cyan} AZUL\n");
            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.Red} ROJO");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("back blanco y Fore rojo Oscuro");
            Console.ResetColor();
        }
    }
}
