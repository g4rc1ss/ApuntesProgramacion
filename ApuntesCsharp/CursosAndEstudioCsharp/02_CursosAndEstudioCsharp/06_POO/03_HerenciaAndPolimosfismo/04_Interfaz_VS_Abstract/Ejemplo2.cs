using System;

namespace CursosAndEstudioCsharp._06_POO._17_Interfaz_VS_Abstract
{
    public abstract class Vehiculos2
    {
        public void Mover()
        {
            Console.WriteLine("Moviendo {0} ruedas", Ruedas);
        }

        public abstract int Ruedas { get; }
    }

    public interface IVehiculos2
    {
        int Puertas { get; }
        bool EsAereo { get; }
    }

    public class Coche2 : Vehiculos, IVehiculos2
    {
        public override int Ruedas => 4;

        public int Puertas => 4;

        public bool EsAereo => false;
    }

    public class Avion : Vehiculos, IVehiculos2
    {
        public override int Ruedas => 2;

        public int Puertas => 3;

        public bool EsAereo => true;
    }

    public class Bicicleta2 : Vehiculos, IVehiculos2
    {
        public override int Ruedas => 2;

        public int Puertas => 0;

        public bool EsAereo => false;
    }

}
