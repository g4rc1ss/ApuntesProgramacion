using HexagonalArchitecture.DB.UserDb;

namespace HexagonalArchitecture.DB
{
    public class DependencyDbFactory
    {
        public static ClaseSimuloBaseDeDatos GetSimulacionBaseDatos()
        {
            return new();
        }
    }
}
