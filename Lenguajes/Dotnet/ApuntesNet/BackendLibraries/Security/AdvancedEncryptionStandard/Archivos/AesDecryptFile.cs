﻿using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Archivos;

public class AesDecryptFile
{
    private readonly string _archivoAES_TXT = "archivo.txt";
    private readonly string _archivoAES_TXT_Cifrado = "archivo.txt.crypt";

    public void DescifrarAES()
    {
        try
        {
            Console.WriteLine("Escribe la contraseña");
            string? contraseña = Console.ReadLine();

            using (HashAlgorithm hash = SHA256.Create())
            {
                using Aes? aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Create an encryptor to perform the stream transform.
                using ICryptoTransform? decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using FileStream? fileStreamCrypt = new(_archivoAES_TXT_Cifrado, FileMode.Open, FileAccess.Read);
                using FileStream? fileStreamOut = new(_archivoAES_TXT, FileMode.OpenOrCreate, FileAccess.Write);
                using CryptoStream? decryptStream = new(fileStreamCrypt, decryptor, CryptoStreamMode.Read);
                for (int data; (data = decryptStream.ReadByte()) != -1;)
                {
                    fileStreamOut.WriteByte((byte)data);
                }
            }

            File.Delete(_archivoAES_TXT_Cifrado);
            Console.WriteLine(File.ReadAllText(_archivoAES_TXT));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
