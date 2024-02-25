using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Textos;

public class AesEncryptText
{
    private readonly string _archivoAES_TXT = "archivo.txt";

    public void CifrarAES()
    {
        try
        {
            Console.WriteLine("Escribe el texto a encriptar");
            //Obtenemos un array de bytes del texto a cifrar
            var textoCifrarBytes = Console.ReadLine();

            Console.WriteLine("Escribe la contraseña");
            var contraseña = Console.ReadLine();

            var textoCifrado = default(byte[]);
            using (HashAlgorithm hash = SHA256.Create())
            {
                using var aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Create an encryptor to perform the stream transform.
                using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);                     // Create the streams used for encryption.
                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(textoCifrarBytes);
                    textoCifrarBytes = string.Empty;
                }
                textoCifrado = msEncrypt.ToArray();
            }

            File.Delete(_archivoAES_TXT);
            Console.WriteLine(Encoding.UTF8.GetString(textoCifrado));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
