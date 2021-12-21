using RazorPagesExample.Business.Manager;

namespace RazorPagesExample.Business.Action
{
    public interface IUserAction
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
