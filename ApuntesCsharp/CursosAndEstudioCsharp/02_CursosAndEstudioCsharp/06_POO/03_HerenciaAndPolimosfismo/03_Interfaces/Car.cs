using System;

namespace CursosAndEstudioCsharp._06_POO._16_Interfaces
{
    internal class Car : Program, IEquatable<Car>, IComparacion
    {
        public bool Equals(Car obj)
        {
            throw new NotImplementedException();
        }

        public int EsIgual(int numero)
        {
            throw new NotImplementedException();
        }

        public int EsIgualaCoche(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
