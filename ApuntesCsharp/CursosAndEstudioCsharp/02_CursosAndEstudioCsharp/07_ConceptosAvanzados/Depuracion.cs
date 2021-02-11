namespace CursosAndEstudioCsharp._07_ConceptosAvanzados
{
    internal class Depuracion
    {
        public Depuracion()
        {
            var num1 = 15;
            var num2 = 20;

            var suma = Suma(num1, num2);
            var multiplicacion = Multiplicacion(num1, num2);
        }

        public static int Suma(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Multiplicacion(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
