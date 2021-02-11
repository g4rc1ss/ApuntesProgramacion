using System;
using System.Collections;

namespace CursosAndEstudioCsharp._05_Colecciones
{
    internal class HashTableEjemplo
    {
        public HashTableEjemplo()
        {
            var hashtable = new Hashtable
            {

                //Añadir valores
                { "Alejandro", 1.22 },
                { "Rodrigo", 5.21 },
                { "Miriam", 9.62 }
            };

            //recoriendo Hastable
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item.Value + " " + item.Key);
            }

            //Obtener valor del hastable
            var valor = hashtable["Alejandro"];

            Console.WriteLine(valor);

            Console.ReadLine();



            //cuantos elementos
            var cuantos = hashtable.Count;

            //buscar
            if (hashtable.ContainsKey("Alejandro"))
            {

            }

            if (hashtable.ContainsValue(9.62))
            {

            }

            //Eliminar
            hashtable.Remove("Alejandro");

            //recoriendo Hastable
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item.Value + " " + item.Key);
            }

            Console.ReadLine();

            //Limpiar
            hashtable.Clear();

            //recoriendo Hastable
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item.Value + " " + item.Key);
            }

            Console.ReadLine();
        }
    }
}
