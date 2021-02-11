using System;
using System.Collections;

namespace CursosAndEstudioCsharp._05_Colecciones
{
    internal class PilaEjemplo
    {
        public PilaEjemplo()
        {
            var pila = new Stack();

            pila.Push(1);
            pila.Push(5);
            pila.Push(10);
            pila.Push(3);

            //3 --> 10 --> 5 --> 1

            var numero = pila.Pop();

            Console.WriteLine(numero);
            Console.ReadLine();

            foreach (var item in pila)
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }

            //Contar elementos
            var contador = pila.Count;

            //Limpiar la pila
            pila.Clear();

            if (pila.Contains(10))
            {
                Console.WriteLine("Contiene un 10");
            }
        }
    }
}
