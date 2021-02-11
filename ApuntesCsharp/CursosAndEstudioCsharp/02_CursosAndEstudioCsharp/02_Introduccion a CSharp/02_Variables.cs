using System;

namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _02_Variables
    {
        public _02_Variables()
        {
            var mensaje = Console.ReadLine();

            var edad = default(int);  //0
            int? altura = null;

            edad = edad + 5;

            if (altura == null)
            {
                //hacer algo
            }

            DateTime? fecha = new DateTime();
            fecha = null;

            //comprobar nulo
            var dia = fecha?.Day;

            Console.Write(edad);
            Console.ReadLine();
        }
    }
}
