﻿using System.Text;

const int NUM_SUSTITUCION = 5;
List<char> letrasSustitucion =
[
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
];

var frase = "Hola esta es la frase que va a ser encriptada con cifrado cesar abcdefghijklmnopqrstuvwxyz";
Console.WriteLine(frase);

var fraseCifrada = CifrarFraseCesar(frase);
Console.WriteLine(fraseCifrada);

var fraseDescifrada = DescifrarFrase(fraseCifrada);
Console.WriteLine(fraseDescifrada);



string CifrarFraseCesar(string frase)
{
    frase = frase.ToUpper();
    var cifrarFrase = new StringBuilder();
    for (var i = 0; i < frase.Length; i++)
    {
        if (letrasSustitucion.Contains(frase[i]))
        {
            var letraToAdd = (letrasSustitucion.IndexOf(frase[i]) + NUM_SUSTITUCION) % letrasSustitucion.Count;
            cifrarFrase.Append(letrasSustitucion[letraToAdd]);
        }
        else
        {
            cifrarFrase.Append(frase[i]);
        }
    }
    return cifrarFrase.ToString();
}

string DescifrarFrase(string frase)
{
    frase = frase.ToUpper();
    var descifrarFrase = new StringBuilder();
    for (var i = 0; i < frase.Length; i++)
    {
        if (letrasSustitucion.Contains(frase[i]))
        {
            var diccionarioDescifrados = CrearDiccionarioDescifrado(NUM_SUSTITUCION);
            descifrarFrase.Append(diccionarioDescifrados[frase[i]]);
        }
        else
        {
            descifrarFrase.Append(frase[i]);
        }
    }
    return descifrarFrase.ToString();
}

Dictionary<char, char> CrearDiccionarioDescifrado(int clave)
{
    var diccionario = new Dictionary<char, char>();
    for (var i = 0; i < letrasSustitucion.Count; i++)
    {
        var index = i - clave;
        var valor = index < 0 ? letrasSustitucion.Count - Math.Abs(index) : index;
        diccionario.Add(letrasSustitucion[i], letrasSustitucion[valor]);
    }
    return diccionario;
}
