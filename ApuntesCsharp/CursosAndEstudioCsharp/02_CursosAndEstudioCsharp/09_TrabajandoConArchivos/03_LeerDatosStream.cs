using System.IO;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _03_LeerDatosStream
    {
        public _03_LeerDatosStream()
        {
            var ms = new MemoryStream(150);
            var capacidad = ms.Capacity;
            var longitud = ms.Length;
            var posicion = ms.Position;

            var buffer = new byte[50];

            ms.Read(buffer, 0, 5);
        }
    }
}
