namespace CursosAndEstudioCsharp._06_POO._15_SobrecargaDeOperadores
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

        public static Punto operator +(Punto valor)
        {
            var nuevoPunto = new Punto
            {
                X = valor.X + 1,
                Y = valor.Y + 1
            };

            return nuevoPunto;
        }

        public static Punto operator -(Punto valor)
        {
            var nuevoPunto = new Punto
            {
                X = valor.X - 1,
                Y = valor.Y - 1
            };

            return nuevoPunto;
        }
    }
}
