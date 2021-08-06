using System.Security.Cryptography;
using System.Text;

namespace BackApi {
    public class Prueba {
        public string CifrarText(string text) {
            return new string(Encoding.UTF8.GetString(CifrarTextoAes(text)));
        }

        private byte[] CifrarTextoAes(string text) {
            using (HashAlgorithm hash = SHA256.Create()) {
                return hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            }
        }
    }
}
