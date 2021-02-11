namespace CursosAndEstudioCsharp._06_POO._16_Interfaces
{
    internal interface IEquatable<T>
    {
        bool Equals(T obj);
        int EsIgual(int numero);
    }

    internal interface IComparacion
    {
        int EsIgualaCoche(int numero);
    }
}
