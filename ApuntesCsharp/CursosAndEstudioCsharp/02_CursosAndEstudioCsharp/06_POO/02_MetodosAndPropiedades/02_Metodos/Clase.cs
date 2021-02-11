using System;

namespace CursosAndEstudioCsharp._06_POO._06_Metodos
{
    internal class Clase
    {
        public int Campo;
        public string Nombre { get; set; }
        public readonly string Identificador = "XX";

        //Constructor
        public Clase()
        {
        }

        //Metodo
        public void Calcular(int edad)
        {
            //Operacion de nuestro metodo
            Console.WriteLine(edad + 15);
        }

        //Metodo
        public int Sumar(int numero, int numero2)
        {
            //Operacion de nuestro metodo
            return numero + numero2;
        }
    }
}
