using ConversorArchivos.BusinessManager;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConversorArchivos.Actions.Interfaces
{
    public interface IConvertirAction
    {
        Task ConvertTo(string folderPath, string extensionInicial, string extensionFinal);
    }
}
