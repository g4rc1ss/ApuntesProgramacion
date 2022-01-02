using System.Text;

namespace EnMemoria.Escritura
{
    internal class Escribir
    {
        internal async Task<MemoryStream> Write()
        {
            byte[] firstString = new UnicodeEncoding().GetBytes("Texto a convertir en bytes");
            byte[] secondString = new UnicodeEncoding().GetBytes("Texto a agregar");

            var memoryStream = new MemoryStream();
            
            memoryStream.Write(firstString, 0, firstString.Length);

            foreach (var item in secondString)
            {
                memoryStream.WriteByte(item);
            }

            return memoryStream;
        }
    }
}
