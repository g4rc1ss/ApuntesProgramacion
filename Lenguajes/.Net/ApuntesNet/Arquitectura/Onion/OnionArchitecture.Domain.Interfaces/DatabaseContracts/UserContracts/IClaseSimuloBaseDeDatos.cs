using OnionArchitecture.Domain.Models.Dto;

namespace OnionArchitecture.Domain.Interfaces.DatabaseContracts.UserContracts
{
    public interface IClaseSimuloBaseDeDatos
    {
        Task<List<UserDto>> UserList();
    }
}
