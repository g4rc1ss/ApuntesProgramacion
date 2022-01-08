using HexagonalArchitecture.Application.Business.UserManager;
using HexagonalArchitecture.Application.Ports.UserPort.UserDb;
using HexagonalArchitecture.Application.Ports.UserPort.UserManager;

namespace HexagonalArchitecture.Application
{
    public class DependencyApplicationFactory
    {
        public static IUserManager GetUserManager(IClaseSimuloBaseDeDatos claseSimulacion)
        {
            return new UserManager(claseSimulacion);
        }
    }
}
