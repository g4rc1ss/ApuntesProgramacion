using System;
using System.Collections.Generic;

namespace CursosAndEstudioCsharp._05_Colecciones
{
    internal class DiccionaryEjemplo
    {
        public DiccionaryEjemplo()
        {
            var openWith =
            new Dictionary<string, string>
            {
                { "txt", "notepad.exe" },
                { "bmp", "paint.exe" },
                { "dib", "paint.exe" },
                { "rtf", "wordpad.exe" }
            };

            var valor = string.Empty;

            openWith.TryGetValue("dib", out valor);

            var ejemplo1 = openWith["rtf"];


            if (!openWith.ContainsKey("doc"))
            {
                openWith.Add("doc", "win.exe");
            }

            openWith["doc"] = "winword.exe";

            //recorrer el diccionario
            foreach (var kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            //Obtener las keys
            var keyColl =
            openWith.Keys;

            //Eliminar registro
            openWith.Remove("doc");

            foreach (var kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
