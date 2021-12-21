using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RsaCipherExample.Archivos
{
    public class RsaEncryptFile
    {
        private readonly string archivoRSA_TXT = "archivoRSA.txt";
        private readonly string archivoRSA_CRYPT = "archivoRSA.crypt";

        public void CifrarRSA()
        {
            try
            {
                if (!File.Exists(archivoRSA_TXT))
                {
                    var archivoEscrituraRSA = File.CreateText(archivoRSA_TXT);
                    archivoEscrituraRSA.Write("Esto es una prueba de escritura en un archivo de " +
                        "texto. \n" +
                        "Siguiente Linea jajajaja");
                    archivoEscrituraRSA.Close();//guardamos y cerramos el archivo
                }

                //Obtenemos un array de bytes del texto a cifrar
                var textoCifrarBytes = File.ReadAllBytes(archivoRSA_TXT);

                // Instanciamos el algorimo asimétrico RSA
                using (var rsaCrypt = RSA.Create())
                {
                    // Establecemos la longitud de la clave que queremos usar
                    rsaCrypt.KeySize = 4096;
                    File.WriteAllBytes("public.key", rsaCrypt.ExportRSAPublicKey());
                    File.WriteAllBytes("private.key", rsaCrypt.ExportRSAPrivateKey());

                    var mensajeCifrado = rsaCrypt.Encrypt(textoCifrarBytes, RSAEncryptionPadding.Pkcs1);

                    // Escribir en un fichero el mensaje cifrado
                    File.WriteAllBytes(archivoRSA_CRYPT, mensajeCifrado);
                    File.Delete(archivoRSA_TXT);

                    Console.WriteLine("----------------------------------- \n Mensaje encriptado:");
                    Console.WriteLine(Encoding.UTF8.GetString(File.ReadAllBytes(archivoRSA_CRYPT)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
