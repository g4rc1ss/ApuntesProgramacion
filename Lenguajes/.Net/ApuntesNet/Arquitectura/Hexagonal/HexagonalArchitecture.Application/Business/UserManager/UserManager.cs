using HexagonalArchitecture.Application.Dto;
using HexagonalArchitecture.Application.Ports.UserPort;

namespace HexagonalArchitecture.Application.Business.UserManager
{
    public class UserManager
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
