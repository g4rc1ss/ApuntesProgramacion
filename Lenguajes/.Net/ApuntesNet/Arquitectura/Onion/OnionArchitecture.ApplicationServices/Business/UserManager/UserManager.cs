using OnionArchitecture.Domain.Interfaces.BusinessContracts;
using OnionArchitecture.Domain.Interfaces.DatabaseContracts.UserContracts;
using OnionArchitecture.Domain.Models.Dto;

namespace OnionArchitecture.ApplicationServices.Business.UserManager
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
