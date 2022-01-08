using HexagonalArchitecture.Application.Dto;

namespace HexagonalArchitecture.Application.Ports.UserPort.UserManager
{
    public interface IUserManager
    {
        Task<List<UserDto>> GetUsersList();
    }
}
