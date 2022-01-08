using HexagonalArchitecture.Application.Dto;

namespace HexagonalArchitecture.Application.Ports.UserPort.UserDb
{
    public interface IClaseSimuloBaseDeDatos
    {
        Task<List<UserDto>> UserList();
    }
}
