using System.Threading.Tasks;

namespace WebAPI.Backend.Business.Actions.Cipher.Interfaces {
    public interface ICipherAction {
        Task<string> CifrarTexto(string textoCifrar);
    }
}
