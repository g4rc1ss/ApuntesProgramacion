﻿
using AesCipherExample.Archivos;
using AesCipherExample.Textos;

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