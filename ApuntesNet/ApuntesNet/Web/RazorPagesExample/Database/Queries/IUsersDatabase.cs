using RazorPagesExample.Database.DTO;

namespace RazorPagesExample.Database.Queries
{
    public interface IUsersDatabase
    {
        Task<IEnumerable<UserDatabase>> GetAllUsers();
    }
}
