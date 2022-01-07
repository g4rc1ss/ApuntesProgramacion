using HexagonalArchitecture.Application.Business.UserManager;
using HexagonalArchitecture.Application.Ports.UserPort;

namespace HexagonalArchitecture.Application
{
    public class DependencyApplicationFactory
    {
        public static UserManager GetUserManager(IClaseSimuloBaseDeDatos claseSimulacion)
        {
            return new(claseSimulacion);
        }
    }
}
