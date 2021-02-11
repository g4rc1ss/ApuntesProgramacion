namespace CursosAndEstudioCsharp._06_POO._07_NivelDeAccesibilidad
{
    internal class Program
    {
        public Program()
        {
            var clasedev = new ClaseDerivada
            {
                Nacionalidad = "Española",
                Nombre = "Alejandro",
                Telefono = "1122233"
            };
            clasedev.Sumar(6, 7);
        }
    }
}
