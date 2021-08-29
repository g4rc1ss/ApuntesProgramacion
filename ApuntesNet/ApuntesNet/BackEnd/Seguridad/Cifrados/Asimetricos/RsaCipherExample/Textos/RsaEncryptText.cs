using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RsaCipherExample.Textos {
    public class RsaEncryptText {
        public void CifrarRSA() {
            try {
                Console.WriteLine("Escribe el texto a cifrar");
                //Obtenemos un array de bytes del texto a cifrar
                var textoCifrarBytes = Encoding.UTF8.GetBytes(Console.ReadLine());

                // Instanciamos el algorimo asimétrico RSA
                using (var rsaCrypt = RSA.Create()) {
                    // Establecemos la longitud de la clave que queremos usar
                    rsaCrypt.KeySize = 4096;
                    File.WriteAllBytes("public.key", rsaCrypt.ExportRSAPublicKey());
                    File.WriteAllBytes("private.key", rsaCrypt.ExportRSAPrivateKey());

                    var mensajeCifrado = rsaCrypt.Encrypt(textoCifrarBytes, RSAEncryptionPadding.Pkcs1);

                    Console.WriteLine("----------------------------------- \n Mensaje encriptado:");
                    Console.WriteLine(Encoding.UTF8.GetString(mensajeCifrado));
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
