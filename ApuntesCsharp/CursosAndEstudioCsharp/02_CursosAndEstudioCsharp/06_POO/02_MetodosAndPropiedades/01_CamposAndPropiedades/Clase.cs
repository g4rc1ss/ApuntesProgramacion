namespace CursosAndEstudioCsharp._06_POO._05_CamposAndPropiedades
{
    internal class Clase
    {
        public int Campo;
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; private set; }
        public int Estado = 1;

        public readonly string Identificador = "XX";

        //Constructor
        public Clase()
        {
            Identificador = "ABCD";
            Edad = 10;
        }

        public void Metodo(int edad)
        {
            if (edad > 18)
            {
                Edad = edad;
            }
            //Identificador = "XXX";
        }
    }
}
