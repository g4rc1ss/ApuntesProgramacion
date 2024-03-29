﻿using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Archivos;

public class AesEncryptFile
{
    private readonly string _archivoAES_TXT = "archivo.txt";
    private readonly string _archivoAES_TXT_Cifrado = "archivo.txt.crypt";

    public void CifrarAES()
    {
        try
        {
            if (!File.Exists(_archivoAES_TXT))
            {
                var archivoEscritura = File.CreateText(_archivoAES_TXT);
                archivoEscritura.Write("Esto es una prueba de escritura en un archivo de " +
                    "texto. \n" +
                   "Siguiente Linea jajajaja");
                archivoEscritura.Close();//guardamos y cerramos el archivo
            }

            Console.WriteLine("Escribe la contraseña");
            var contraseña = Console.ReadLine();

            using (HashAlgorithm hash = SHA256.Create())
            {
                using var aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using var fileStreamOutput = new FileStream(_archivoAES_TXT_Cifrado, FileMode.OpenOrCreate, FileAccess.Write);
                using var cryptStream = new CryptoStream(fileStreamOutput, encryptor, CryptoStreamMode.Write);
                using var fileStreamInput = new FileStream(_archivoAES_TXT, FileMode.Open, FileAccess.Read);
                for (int data; (data = fileStreamInput.ReadByte()) != -1;)
                {
                    cryptStream.WriteByte((byte)data);
                }
            }

            File.Delete(_archivoAES_TXT);
            Console.WriteLine(File.ReadAllText(_archivoAES_TXT_Cifrado));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
