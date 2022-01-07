using System.Text;

namespace EnMemoria.Escritura
{
    internal class Escribir
    {
        internal static async Task<MemoryStream> Write()
        {
            var firstString = new UnicodeEncoding().GetBytes("Texto a convertir en bytes");
            var secondString = new UnicodeEncoding().GetBytes("Texto a agregar");

            var memoryStream = new MemoryStream();

            await memoryStream.WriteAsync(firstString);

            foreach (var item in secondString)
            {
                memoryStream.WriteByte(item);
            }

            return memoryStream;
        }
    }
}
