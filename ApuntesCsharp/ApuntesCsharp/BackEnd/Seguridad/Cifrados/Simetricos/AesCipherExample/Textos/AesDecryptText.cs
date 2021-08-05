using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesCipherExample.Textos {
    public class AesDecryptText {
        private readonly string archivoAES_TXT = "archivo.txt";

        public void DescifrarAES() {
            try {
                if (!File.Exists(archivoAES_TXT)) {
                    var archivoEscritura = File.CreateText(archivoAES_TXT);
                    archivoEscritura.Write("Esto es una prueba de escritura en un archivo de " +
                        "texto. \n" +
                       "Siguiente Linea jajajaja");
                    archivoEscritura.Close();//guardamos y cerramos el archivo
                }

                Console.WriteLine("Escribe la contraseña");
                var contraseña = Console.ReadLine();

                using (HashAlgorithm hash = SHA256.Create()) {
                    using (var aesAlg = Aes.Create()) {
                        aesAlg.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(contraseña));

                        using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                        using (var fileStreamOutput = new FileStream($"{archivoAES_TXT}.crypt", FileMode.Create, FileAccess.Write))
                        using (var cryptStream = new CryptoStream(fileStreamOutput, encryptor, CryptoStreamMode.Write))
                        using (var fileStreamInput = new FileStream(archivoAES_TXT, FileMode.Open, FileAccess.Read))
                            for (int data; (data = fileStreamInput.ReadByte()) != -1;)
                                cryptStream.WriteByte((byte)data);
                    }
                    File.Delete(archivoAES_TXT);
                }
                Console.WriteLine(File.ReadAllText($"{archivoAES_TXT}.crypt"));
                File.Delete($"{archivoAES_TXT}.crypt");

            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
