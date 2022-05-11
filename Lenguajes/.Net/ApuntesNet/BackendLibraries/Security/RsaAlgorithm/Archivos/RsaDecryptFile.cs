using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RsaAlgorithm.Archivos
{
    public class RsaDecryptFile
    {
        private readonly string archivoRSA_TXT = "archivoRSA.txt";
        private readonly string archivoRSA_CRYPT = "archivoRSA.crypt";

        public void DescifrarRSA()
        {
            try
            {
                // Instanciamos el algorimo asimétrico RSA
                using (var rsaCrypt = RSA.Create())
                {
                    // Establecemos la longitud de la clave que queremos usar
                    rsaCrypt.KeySize = 4096;

                    rsaCrypt.ImportRSAPublicKey(File.ReadAllBytes("public.key"), out var publicKey);
                    rsaCrypt.ImportRSAPrivateKey(File.ReadAllBytes("private.key"), out var privateKey);

                    // Desencriptamos el mensaje
                    var mensajeDescifrado = rsaCrypt.Decrypt(File.ReadAllBytes(archivoRSA_CRYPT), RSAEncryptionPadding.Pkcs1);
                    var mensajeOriginal = Encoding.Default.GetString(mensajeDescifrado);

                    using (var archivoEscritura = File.CreateText(archivoRSA_TXT))
                    {
                        archivoEscritura.Write(mensajeOriginal);
                    }

                    // Sacamos el mensaje descifrado por consola
                    Console.WriteLine("----------------------------------- \n Mensaje desencriptado:");
                    Console.WriteLine(mensajeOriginal);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
