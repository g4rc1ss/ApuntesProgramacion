namespace ConversorArchivos.BusinessManager.ConversorManager
{
    using Aspose.Words;
    using ConversorArchivos.BusinessManager.ConversorManager.Interfaces;
    using System.IO;
    using System.Threading.Tasks;

    public class ConversorManager : IConversorManager
    {
        public ConversorManager()
        {

        }

        public void ConvertTo(string folderPath, string extensionInicial, string extensionFinal)
        {
            string[] listadoArchivos = Directory.GetFiles(folderPath, $"*.{extensionInicial}", SearchOption.AllDirectories);

            _ = Parallel.ForEach(listadoArchivos, archivo =>
              {
                  FileInfo nombreArchivo = new FileInfo(archivo);
                  string nombreArchivoSinExtension = nombreArchivo.Name.Replace(nombreArchivo.Extension, string.Empty);
                  DirectoryInfo directorio = Directory.CreateDirectory($"{nombreArchivo.DirectoryName}\\{nombreArchivoSinExtension}");

                  Document archivoConvertido = new Document(nombreArchivo.FullName);
                  archivoConvertido.Save($"{directorio.FullName}\\{nombreArchivoSinExtension}.{extensionFinal}");
              });
        }
    }
}
