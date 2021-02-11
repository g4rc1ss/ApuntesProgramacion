using System;

namespace CursosAndEstudioCsharp._06_POO._05_CamposAndPropiedades
{
    internal class Program
    {
        public Program()
        {
            //Clase clase = new Clase();
            //clase.Campo = 12;
            //clase.Apellidos = "Lopez Serrano";
            ////clase.Edad = 12;

            //Console.WriteLine(clase.Edad);
            //Console.ReadLine();

            var clase2 = new Clase();
            var estado = clase2.Estado;
            clase2.Estado = 5;

            Console.WriteLine(clase2.Edad);
            clase2.Metodo(28);

            Console.WriteLine(clase2.Edad);
            Console.ReadLine();
        }
    }
}
