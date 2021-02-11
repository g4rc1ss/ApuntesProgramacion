namespace CursosAndEstudioCsharp._06_POO._08_ClasesAbstractasAndVirtual
{
    public abstract class Clase : ClaseAbstacta
    {
        public override int Sumar(int i, int z)
        {
            return i + z;
        }

        public abstract override int Restar(int i, int z);

    }
}
