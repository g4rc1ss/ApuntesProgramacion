using System.IO;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _01_MemoryStream
    {
        public _01_MemoryStream()
        {
            var ms = new MemoryStream(150);
            var capacidad = ms.Capacity;
            var longitud = ms.Length;
            var posicion = ms.Position;
        }
    }
}
