using System;

namespace CursosAndEstudioCsharp._06_POO._11_MetodosDeExtension
{
    internal static class ExtensionMethods
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
