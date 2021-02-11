using System;

namespace CursosAndEstudioCsharp._06_POO._17_Interfaz_VS_Abstract
{
    public abstract class Vehiculos
    {
        public void Mover()
        {
            Console.WriteLine("Moviendo {0} ruedas", Ruedas);
        }

        public abstract int Ruedas { get; }
    }

    public class Coche : Vehiculos
    {
        public override int Ruedas => 4;
    }

    public class Bicicleta : Vehiculos
    {
        public override int Ruedas => 2;
    }


    public interface IVehiculos
    {
        void Mover();
        int Ruedas { get; }
    }

    public class CocheI : IVehiculos
    {
        public int Ruedas => 4;

        public void Mover()
        {
            throw new NotImplementedException();
        }
    }

    public class BicicletaI : IVehiculos
    {
        public int Ruedas => 2;

        public void Mover()
        {
            throw new NotImplementedException();
        }
    }
}
