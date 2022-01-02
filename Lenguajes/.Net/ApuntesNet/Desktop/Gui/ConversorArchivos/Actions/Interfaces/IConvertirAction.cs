using System.Threading.Tasks;

namespace ConversorArchivos.Actions.Interfaces
{
    public interface IConvertirAction
    {
        Task ConvertTo(string folderPath, string extensionInicial, string extensionFinal);
    }
}
