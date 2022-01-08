using HexagonalArchitecture.Application.Ports.UserPort.UserDb;
using HexagonalArchitecture.DB.UserDb;

namespace HexagonalArchitecture.DB
{
    public class DependencyDbFactory
    {
        public static IClaseSimuloBaseDeDatos GetSimulacionBaseDatos()
        {
            return new ClaseSimuloBaseDeDatos();
        }
    }
}
