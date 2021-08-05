using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RsaCipherExample.Archivos {
    public class RsaDecryptFile {
        private readonly string archivoRSA_TXT = "archivoRSA.txt";
        private readonly string archivoRSA_CRYPT = "archivoRSA.crypt";

        public void DescifrarRSA() {
            try {
                if (!File.Exists(archivoRSA_TXT)) {
                    var archivoEscrituraRSA = File.CreateText(archivoRSA_TXT);
                    archivoEscrituraRSA.Write("Esto es una prueba de escritura en un archivo de " +
                        "texto. \n" +
                        "Siguiente Linea jajajaja");
                    archivoEscrituraRSA.Close();//guardamos y cerramos el archivo
                }

                var archivoLectura = new StreamReader(archivoRSA_TXT);
                var textoCifrar = archivoLectura.ReadToEnd();
                archivoLectura.Close();


                //Obtenemos un array de bytes del texto a cifrar
                var textoCifrarBytes = Encoding.Default.GetBytes(textoCifrar);


                // Instanciamos el algorimo asimétrico RSA
                using (var rSA_Crypt = new RSACryptoServiceProvider()) {
                    // Establecemos la longitud de la clave que queremos usar
                    rSA_Crypt.KeySize = 4096;
                    // Encriptamos el mensaje con un relleno OAEP.
                    var mensajeCifrado = rSA_Crypt.Encrypt(textoCifrarBytes, true);

                    // Escribir en un fichero el mensaje cifrado
                    File.WriteAllBytes(archivoRSA_CRYPT, mensajeCifrado);
                    File.Delete(archivoRSA_TXT);


                    // Desencriptamos el mensaje
                    var mensajeDescifrado = rSA_Crypt.Decrypt(File.ReadAllBytes(archivoRSA_CRYPT), true);
                    var mensajeOriginal = Encoding.Default.GetString(mensajeDescifrado);


                    var archivoEscritura = File.CreateText(archivoRSA_TXT);
                    archivoEscritura.Write(mensajeOriginal);
                    archivoEscritura.Close();


                    // Sacamos el mensaje descifrado por consola
                    Console.WriteLine("----------------------------------- \n Mensaje desencriptado:");
                    Console.WriteLine(mensajeOriginal);
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
