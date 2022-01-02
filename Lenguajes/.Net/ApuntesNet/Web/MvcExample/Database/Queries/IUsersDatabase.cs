using MvcExample.Database.DTO;

namespace MvcExample.Database.Queries
{
    public interface IUsersDatabase
    {
        Task<IEnumerable<UserDatabase>> GetAllUsers();
    }
}
