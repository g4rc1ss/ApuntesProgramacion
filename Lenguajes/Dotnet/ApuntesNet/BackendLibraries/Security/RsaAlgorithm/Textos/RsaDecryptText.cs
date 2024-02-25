using System.Security.Cryptography;
using System.Text;

namespace RsaAlgorithm.Textos;

public class RsaDecryptText
{
    public void DescifrarRSA()
    {
        try
        {
            Console.WriteLine("Escribe el texto a descifrar");
            //Obtenemos un array de bytes del texto a cifrar
            var textoDescifrarBytes = Encoding.UTF8.GetBytes(Console.ReadLine());

            // Instanciamos el algorimo asimétrico RSA
            using var rsaCrypt = RSA.Create();
            // Establecemos la longitud de la clave que queremos usar
            rsaCrypt.KeySize = 4096;
            rsaCrypt.ImportRSAPublicKey(File.ReadAllBytes("public.key"), out var publicKey);
            rsaCrypt.ImportRSAPrivateKey(File.ReadAllBytes("private.key"), out var privateKey);

            // Desencriptamos el mensaje
            var mensajeDescifrado = rsaCrypt.Decrypt(textoDescifrarBytes, RSAEncryptionPadding.Pkcs1);

            Console.WriteLine("----------------------------------- \n Mensaje encriptado:");
            Console.WriteLine(Encoding.UTF8.GetString(mensajeDescifrado));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
