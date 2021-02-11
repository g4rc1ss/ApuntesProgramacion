namespace CursosAndEstudioCsharp._06_POO._13_Constructores
{
    internal class Punto
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punto()
        {
            X = 0;
            Y = 0;
        }

        public Punto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Punto(int x)
        {
            X = x;
            Y = 0;
        }
    }
}
