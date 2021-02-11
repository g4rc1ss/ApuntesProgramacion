﻿using System;
using System.Collections;

namespace CursosAndEstudioCsharp._05_Colecciones
{
    internal class QueueEjemplo
    {
        public QueueEjemplo()
        {
            //FIFO --> First In First Out  --> sale el primero que entra
            var cola = new Queue();

            cola.Enqueue(3);
            cola.Enqueue(5);
            cola.Enqueue(1);

            //extraer valores de la cola
            var valorCola = cola.Dequeue();
            Console.WriteLine(valorCola);
            Console.ReadLine();

            valorCola = cola.Dequeue();
            Console.WriteLine(valorCola);
            Console.ReadLine();

            //para observar el valor
            var valor = cola.Peek();
            Console.WriteLine(valor);
            Console.ReadLine();

            //comprobar existe un valor
            if (cola.Contains(1))
            {
                //codigo
            }

            //borrar valores en cola
            cola.Clear();


            cola.Enqueue(13);
            cola.Enqueue(15);

            //conocer cuantos elementos hay en la cola
            var elementos = cola.Count;
            Console.WriteLine(elementos);
            Console.ReadLine();

            //recorrer cola
            foreach (var item in cola)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
