using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Archivos
{
    public class AesDecryptFile
    {
        private readonly string archivoAES_TXT = "archivo.txt";
        private readonly string archivoAES_TXT_Cifrado = "archivo.txt.crypt";

        public void DescifrarAES()
        {
            try
            {
                Console.WriteLine("Escribe la contraseña");
                var contraseña = Console.ReadLine();

                using (HashAlgorithm hash = SHA256.Create())
                {
                    using (var aesAlg = Aes.Create())
                    {
                        aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                        // Create an encryptor to perform the stream transform.
                        using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                        using (var fileStreamCrypt = new FileStream(archivoAES_TXT_Cifrado, FileMode.Open, FileAccess.Read))
                        using (var fileStreamOut = new FileStream(archivoAES_TXT, FileMode.OpenOrCreate, FileAccess.Write))
                        using (var decryptStream = new CryptoStream(fileStreamCrypt, decryptor, CryptoStreamMode.Read))
                        {
                            for (int data; (data = decryptStream.ReadByte()) != -1;)
                            {
                                fileStreamOut.WriteByte((byte)data);
                            }
                        }
                    }
                }

                File.Delete(archivoAES_TXT_Cifrado);
                Console.WriteLine(File.ReadAllText(archivoAES_TXT));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
