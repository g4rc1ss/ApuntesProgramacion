using System;

namespace CursosAndEstudioCsharp._06_POO._03_HerenciaAndPolimosfismo._05_Herencia
{
    internal class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void SetX(int value)
        {
            if (value < 100)
                X = value;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void SetY(int value)
        {
            if (value > 50)
                Y = value;
            else
                throw new ArgumentOutOfRangeException();
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }
    }
}
