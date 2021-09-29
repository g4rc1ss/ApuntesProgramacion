using System;
using System.Collections.Generic;

namespace Memorization.Clase {
    internal class Memoizacion<T, TResult> {
        private static readonly Dictionary<T, TResult> diccionario = new();

        public static TResult AddMemoizacion(Func<T, TResult> method, T argument) {
            if (!diccionario.TryGetValue(argument, out var result)) {
                result = method.Invoke(argument);
                diccionario.Add(argument, result);
            }
            return result;
        }
    }
}
