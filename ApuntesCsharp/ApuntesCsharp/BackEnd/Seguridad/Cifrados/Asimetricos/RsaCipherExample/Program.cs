using RsaCipherExample.Archivos;
using RsaCipherExample.Textos;

namespace RsaCipherExample {
    internal class Program {
        private static void Main(string[] args) {
            new RsaEncryptFile().CifrarRSA();
            new RsaDecryptFile().DescifrarRSA();
            
            new RsaEncryptText().CifrarRSA();
            new RsaDecryptText().DescifrarRSA();
        }
    }
}
