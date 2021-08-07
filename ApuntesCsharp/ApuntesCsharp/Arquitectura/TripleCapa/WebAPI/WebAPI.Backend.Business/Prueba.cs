using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Backend.Business {
    public class Prueba {
        public static string CifrarText(string text) {
            return new string(Encoding.UTF8.GetString(CifrarTextoAes(text)));
        }

        private static byte[] CifrarTextoAes(string text) {
            using (HashAlgorithm hash = SHA256.Create()) {
                return hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            }
        }
    }
}
