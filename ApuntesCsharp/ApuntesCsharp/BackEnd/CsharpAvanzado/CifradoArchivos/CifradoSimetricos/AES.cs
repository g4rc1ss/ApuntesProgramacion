using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CifradoSimetricos {
    public class AES {
        private readonly string archivoAES_TXT = "archivo.txt";

        public void CifrarAES() {
            try {
                if (!File.Exists(archivoAES_TXT)) {
                    var archivoEscritura = File.CreateText(archivoAES_TXT);
                    archivoEscritura.Write("Esto es una prueba de escritura en un archivo de " +
                        "texto. \n" +
                       "Siguiente Linea jajajaja");
                    archivoEscritura.Close();//guardamos y cerramos el archivo
                }

                var archivoLectura = new StreamReader(archivoAES_TXT);
                var textoCifrar = archivoLectura.ReadToEnd();
                archivoLectura.Close();

                var aes = new AESHelper();
                using (HashAlgorithm hash = SHA256.Create()) {
                    //Obtengo la pass por teclado
                    Console.WriteLine("Escribe la contraseña");
                    var contraseña = Console.ReadLine();

                    var cifradoAES = new AESHelper();
                    cifradoAES.EncriptarFichero(archivoAES_TXT, hash.ComputeHash(Encoding.Unicode.GetBytes(contraseña)), aes.IV);
                    File.Delete(archivoAES_TXT);

                    cifradoAES.DesencriptarFichero($"{archivoAES_TXT}.crypt", aes.Key, aes.IV);
                }
                File.Delete($"{archivoAES_TXT}.crypt");

            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
