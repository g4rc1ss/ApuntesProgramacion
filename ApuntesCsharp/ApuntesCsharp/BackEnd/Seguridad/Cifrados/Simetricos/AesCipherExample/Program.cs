
using AesCipherExample.Archivos;
using AesCipherExample.Textos;
using System;

namespace AesCipherExample {
    internal class Program {
        private static void Main(string[] args) {
            new AesEncryptFile().CifrarAES();
            new AesDecryptFile().DescifrarAES();

            new AesEncryptText().CifrarAES();
            new AesDecryptText().DescifrarAES();
        }
    }
}
