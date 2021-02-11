namespace CursosAndEstudioCsharp._06_POO._04_ConstantesClases
{
    internal class Clase
    {
        //Constantes
        private const int IVA = 9;
        private const int IVA7 = 7, IVA11 = 11, IVA21 = 21;

        // Propiedades
        private int Importe { get; set; }

        // Metodos
        public int CalcularImporte(int importe)
        {
            //IVA = 11; //No se puede modificar
            return importe + (importe * IVA);
        }
    }
}
