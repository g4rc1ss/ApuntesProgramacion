using System;
using System.Collections;

namespace CursosAndEstudioCsharp._05_Colecciones
{
    internal class ArrayListEjemplo
    {
        public ArrayListEjemplo()
        {
            //ArrayList
            var lista = new ArrayList
            {
                1,
                "Batman"
            };

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

            var elemento = lista[0];
            var elemento1 = lista[1];

            Console.WriteLine(elemento1);
            Console.ReadLine();

            var contador = lista.Count;

            lista.Insert(1, "Superman");

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

            lista.RemoveAt(1);

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
