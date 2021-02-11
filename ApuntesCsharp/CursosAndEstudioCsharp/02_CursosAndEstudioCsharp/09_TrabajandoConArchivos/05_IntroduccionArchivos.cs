using System.IO;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _05_IntroduccionArchivos
    {
        public _05_IntroduccionArchivos()
        {
            //Modos
            //FileMode.Append
            //FileMode.Create
            //FileMode.CreateNew
            //FileMode.Open
            //FileMode.OpenOrCreate
            //FileMode.Truncate

            var fs = new FileStream("miArchivo.txt", FileMode.Create);
        }
    }
}
