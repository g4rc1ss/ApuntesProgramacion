using HexagonalArchitecture.Application.Dto;

namespace HexagonalArchitecture.Application.Ports.UserPort
{
    public interface IClaseSimuloBaseDeDatos
    {
        Task<List<UserDto>> UserList();
    }
}
