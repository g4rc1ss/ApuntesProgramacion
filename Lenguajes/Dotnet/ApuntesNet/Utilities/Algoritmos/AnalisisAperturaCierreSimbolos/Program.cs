﻿const string PRUEBA1 = "[[[{{()}}]]]";
const string PRUEBA2 = "[[[{{(}]]]";

Dictionary<char, char> simbolosAperturaCierre = new()
{
    { '(', ')' },
    { '{', '}' },
    { '[', ']' }
};

var resultado = default(bool);
Console.WriteLine("------------------ PRUEBA DE SIMBOLOS CORRECTOS ------------------");
resultado = ComprobacionStringSimbolos(PRUEBA1);
Console.WriteLine($"Resultado = {resultado}");

Console.WriteLine("------------------ PRUEBA DE SIMBOLOS INCORRECTOS ------------------");
resultado = ComprobacionStringSimbolos(PRUEBA2);
Console.WriteLine($"Resultado = {resultado}");


bool ComprobacionStringSimbolos(string frase)
{
    var stack = new Stack<char>();
    foreach (var item in frase)
    {
        if (simbolosAperturaCierre.ContainsKey(item))
        {
            stack.Push(item);
        }
        else if (simbolosAperturaCierre.ContainsValue(item) && simbolosAperturaCierre[stack.Peek()] == item)
        {
            stack.Pop();
        }
        else
        {
            break;
        }
    }
    return stack.Count == 0;
}
