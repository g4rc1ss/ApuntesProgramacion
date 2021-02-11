using System;
using System.IO;

namespace CompilacionInstalacion {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Console.WriteLine(File.Exists("img/sombra.jpg") ? "Existe SOMBRA, HACKEAMOS? :p" : "No existe");
            Console.Read();
        }
    }
}
