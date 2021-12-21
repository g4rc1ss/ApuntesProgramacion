using WebApiExample.Database.DTO;

namespace WebApiExample.Database.Queries
{
    public interface IUsersDatabase
    {
        Task<IEnumerable<UserDatabase>> GetAllUsers();
        Task<bool> InsertUser(UserDatabase userRequest);
    }
}
