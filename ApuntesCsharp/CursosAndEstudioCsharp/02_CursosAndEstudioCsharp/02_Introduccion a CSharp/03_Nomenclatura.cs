namespace CursosAndEstudioCsharp._02_Introduccion_a_CSharp
{
    internal class _03_Nomenclatura
    {
        private readonly string _estaEsMiCadena;
        public _03_Nomenclatura()
        {
        }

        //Bien
        public int SumaDosNumeros(int numeroUno, int numeroDos)
        {
            var resultado = numeroUno + numeroDos;
            return resultado;
        }

        //Mal
        public int Sumar(int a, int b)
        {
            var c = a + b;
            return c;
        }
    }
}
