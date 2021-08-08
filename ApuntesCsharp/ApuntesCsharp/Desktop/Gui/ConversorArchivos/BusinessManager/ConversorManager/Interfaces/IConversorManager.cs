using System.Windows.Controls;

namespace ConversorArchivos.BusinessManager.ConversorManager.Interfaces
{
    public interface IConversorManager
    {
        void ConvertTo(string folderPath, string extensionInicial, string extensionFinal);
    }
}