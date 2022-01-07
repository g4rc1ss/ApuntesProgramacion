using OnionArchitecture.Domain.Models.Dto;

namespace OnionArchitecture.Domain.Interfaces.BusinessContracts
{
    public interface IUserManager
    {
        Task<List<UserDto>> GetUsersList();
    }
}
