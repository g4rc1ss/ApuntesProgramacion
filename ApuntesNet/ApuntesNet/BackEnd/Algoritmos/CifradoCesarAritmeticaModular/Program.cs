using System;
using System.Collections.Generic;
using System.Text;

namespace CifradoCesarAritmeticaModular {
    internal class Program {
        private const int NUM_SUSTITUCION = 5;
        private static readonly List<char> letrasSustitucion = new() {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z'
        };

        private static void Main(string[] args) {
            var frase = "Hola esta es la frase que va a ser encriptada con cifrado cesar abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine(frase);

            var fraseCifrada = CifrarFraseCesar(frase);
            Console.WriteLine(fraseCifrada);

            var fraseDescifrada = DescifrarFrase(fraseCifrada);
            Console.WriteLine(fraseDescifrada);
        }


        private static string CifrarFraseCesar(string frase) {
            frase = frase.ToUpper();
            var cifrarFrase = new StringBuilder();
            for (var i = 0; i < frase.Length; i++) {
                if (letrasSustitucion.Contains(frase[i])) {
                    var letraToAdd = (letrasSustitucion.IndexOf(frase[i]) + NUM_SUSTITUCION) % letrasSustitucion.Count;
                    cifrarFrase.Append(letrasSustitucion[letraToAdd]);
                } else {
                    cifrarFrase.Append(frase[i]);
                }
            }
            return cifrarFrase.ToString();
        }

        private static string DescifrarFrase(string frase) {
            frase = frase.ToUpper();
            var descifrarFrase = new StringBuilder();
            for (var i = 0; i < frase.Length; i++) {
                if (letrasSustitucion.Contains(frase[i])) {
                    var diccionarioDescifrados = CrearDiccionarioDescifrado(NUM_SUSTITUCION);
                    descifrarFrase.Append(diccionarioDescifrados[frase[i]]);
                } else {
                    descifrarFrase.Append(frase[i]);
                }
            }
            return descifrarFrase.ToString();
        }

        private static Dictionary<char, char> CrearDiccionarioDescifrado(int clave) {
            var diccionario = new Dictionary<char, char>();
            for (var i = 0; i < letrasSustitucion.Count; i++) {
                var index = i - clave;
                var valor = index < 0 ? letrasSustitucion.Count - Math.Abs(index) : index;
                diccionario.Add(letrasSustitucion[i], letrasSustitucion[valor]);
            }
            return diccionario;
        }
    }
}
