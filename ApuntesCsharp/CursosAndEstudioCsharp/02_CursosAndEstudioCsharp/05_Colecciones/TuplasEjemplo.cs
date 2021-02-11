﻿using System;

namespace CursosAndEstudioCsharp._05_Colecciones
{
    internal class TuplasEjemplo
    {
        public TuplasEjemplo()
        {
            var tupla = new Tuple<int, string, string, DateTime>(1, "Rodrigo", "Alejandro", DateTime.Now);

            var tupla2 = Tuple.Create(1, "Rodrigo", "Alejandro", DateTime.Now);

            var ejemplo = Ejemplo();

            var entero = ejemplo.Item1;
            var nombre1 = ejemplo.Item2;
        }

        public static Tuple<int, string, string, DateTime> Ejemplo()
        {
            return new Tuple<int, string, string, DateTime>(1, "Rodrigo", "Alejandro", DateTime.Now);
        }
    }
}
