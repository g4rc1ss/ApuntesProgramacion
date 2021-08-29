using System.Security.Cryptography;
using System.Text;
using WebAPI.Backend.Business.BusinessManager.CipherManager.Interfaces;

namespace WebAPI.Backend.Business.BusinessManager.CipherManager {
    public class CipherManager : ICipherManager {

        public CipherManager() {

        }

        public string CifrarText(string text) {
            using HashAlgorithm hash = SHA256.Create();

            var textoHasheado = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            return new string(Encoding.UTF8.GetString(textoHasheado));
        }
    }
}
