using HexagonalArchitecture.Application.Dto;
using HexagonalArchitecture.Application.Ports.UserPort.UserDb;
using HexagonalArchitecture.Application.Ports.UserPort.UserManager;

namespace HexagonalArchitecture.Application.Business.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IClaseSimuloBaseDeDatos _claseSimuloBaseDeDatos;

        public UserManager(IClaseSimuloBaseDeDatos claseSimuloBaseDeDatos)
        {
            _claseSimuloBaseDeDatos = claseSimuloBaseDeDatos;
        }

        public Task<List<UserDto>> GetUsersList()
        {
            return _claseSimuloBaseDeDatos.UserList();
        }
    }
}
