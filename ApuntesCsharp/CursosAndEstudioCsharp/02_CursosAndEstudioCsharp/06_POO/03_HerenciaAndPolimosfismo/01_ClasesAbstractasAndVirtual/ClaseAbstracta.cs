namespace CursosAndEstudioCsharp._06_POO._08_ClasesAbstractasAndVirtual
{
    public abstract class ClaseAbstacta
    {
        public abstract int Sumar(int i, int z);

        public virtual int Restar(int i, int z)
        {
            return i - z;
        }
    }
}
