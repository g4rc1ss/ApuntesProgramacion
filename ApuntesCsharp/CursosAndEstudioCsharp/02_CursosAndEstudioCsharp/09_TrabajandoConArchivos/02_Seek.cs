using System.IO;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _02_Seek
    {
        public _02_Seek()
        {
            var ms = new MemoryStream(150);
            var capacidad = ms.Capacity;
            var longitud = ms.Length;
            var posicion = ms.Position;

            ms.Seek(0, SeekOrigin.Begin);
            ms.Seek(10, SeekOrigin.Begin);
            ms.Seek(-10, SeekOrigin.Begin);

            ms.Seek(5, SeekOrigin.Current);
            ms.Seek(-10, SeekOrigin.Current);
        }
    }
}
