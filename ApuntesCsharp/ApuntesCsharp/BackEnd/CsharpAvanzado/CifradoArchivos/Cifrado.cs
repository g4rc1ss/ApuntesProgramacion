namespace CifradoArchivos {
    internal class Cifrado {
        private static void Main(string[] args) {
            new CifradoSimetricos.AES().CifrarAES();
            new CifradoAsimetricos.RSA().CifrarRSA();
        }
    }
}
