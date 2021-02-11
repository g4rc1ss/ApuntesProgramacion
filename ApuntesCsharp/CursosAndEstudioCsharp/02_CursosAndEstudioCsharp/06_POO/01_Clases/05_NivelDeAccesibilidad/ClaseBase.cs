namespace CursosAndEstudioCsharp._06_POO._07_NivelDeAccesibilidad
{
    internal class ClaseBase
    {
        public string Telefono { get; set; }
        private int Edad { get; set; }
        internal string Nombre { get; set; }
        protected string Apellidos { get; set; }
        protected internal string Nacionalidad { get; set; }

        public ClaseBase()
        {
            Edad = 16;
            Apellidos = "Lopez";
        }

        public void Sumar(int a, int b)
        {

        }
    }
}
