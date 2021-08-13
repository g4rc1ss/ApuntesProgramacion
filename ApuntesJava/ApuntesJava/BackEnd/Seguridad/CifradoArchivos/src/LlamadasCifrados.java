import Cifrado.Asimetrico.RSA.RSA;

public class LlamadasCifrados {
    public static void main(String[] args) {
        new Cifrado.Simetrico.Aes().CifrarAES();
        new RSA().cifrarRSA();
    }
}
